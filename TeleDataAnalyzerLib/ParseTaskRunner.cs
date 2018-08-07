using System;
using System.Collections.Generic;
using System.Threading;

namespace TeleDataAnalyzerLib
{
    public class ParseTaskRunner
    {
        public ParseTaskStatus Status { get; private set; } = ParseTaskStatus.Waiting;

        public int index;
        private Thread workingThread;
        private Thread periodThread;

        public int FailedTaskIndex;

        public List<ParseTask> Tasks;

        public delegate void AsyncParseEndDelegate(ParseTaskRunner runner, Parser parser);
        public delegate void AsyncTaskChangedDelegate(ParseTaskRunner runner, Parser parser);
        public delegate void AsyncTaskPeriodicalDelegate(ParseTaskRunner runner, Parser parser);

        public event AsyncParseEndDelegate AsyncParseEnd;
        public event AsyncTaskChangedDelegate AsyncTaskСhanged;
        public event AsyncTaskChangedDelegate AsyncTaskPeriodical;

        public Parser parser;

        public int UpdatePeriod;

        public ParseTaskRunner(Parser parser)
        {
            this.parser = parser;
        }

        public void Reset()
        {
            Status = ParseTaskStatus.Waiting;
            foreach (var task in Tasks)
                task.Reset();
        }

        public void AbortAsync()
        {
            workingThread?.Abort();
            Status = ParseTaskStatus.Aborted;
        }


        public void Run(List<ParseTask> tasks, bool complete = true, int tasksToComplete = 0)
        {
            Tasks = tasks;
            Status = ParseTaskStatus.Running;
            index = 0;

            if (AsyncTaskPeriodical != null)
            {
                periodThread = new Thread(
                    p =>
                    {
                        while (true)
                        {
                            Thread.Sleep(UpdatePeriod);
                            AsyncTaskPeriodical.Invoke(this, parser);
                        }
                    });
                periodThread.Start();
            }

            foreach (var task in Tasks)
            {
                if (!complete && index == tasksToComplete) break;

                index++;
                AsyncTaskСhanged?.Invoke(this, parser);

                Exception exception = null;
                try
                {
                    task.Run(parser);
                }
                catch(Exception ex)
                {
                    exception = ex;
                }
                
                AsyncTaskСhanged?.Invoke(this, parser);
                task.Error = exception;

                if (task.Status != ParseTaskStatus.Ok || exception != null)
                {
                    FailedTaskIndex = index - 1;
                    Status = ParseTaskStatus.Failed;
                    periodThread?.Abort();
                    AsyncParseEnd?.Invoke(this, parser);

                    return;
                }
            }
            Status = ParseTaskStatus.Ok;

            parser.ParseTime = TimeSpan.Zero;
            Tasks.ForEach(p => parser.ParseTime += p.Length);
            periodThread?.Abort();

            AsyncParseEnd?.Invoke(this, parser);
        }

        public void RunAsync(List<ParseTask> tasks, bool complete = true, int tasksToComplete = 0)
        {
            workingThread = new Thread(p => Run(tasks, complete, tasksToComplete));
            workingThread.Start();
        }
    }
}
