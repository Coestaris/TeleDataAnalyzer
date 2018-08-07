using System;
using System.Threading;

namespace TeleDataAnalyzerLib
{
    public abstract class ParseTask
    {
        public float SubTaskCurrentStep { get; protected set; }
        public string SubtaskName { get; protected set; }

        public float CurrentStep { get; protected set; }

        public abstract string Name { get; }
        public TimeSpan Length { get; private set; }

        public Exception Error { get; internal set; }
        public ParseTaskStatus Status { get; private set; } = ParseTaskStatus.Waiting;

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        protected Thread workingThread;
        protected Parser parser;

        protected abstract void InnerReset();
        protected abstract void InnerRun();

        public void Reset()
        {
            Length = TimeSpan.Zero;
            Status = ParseTaskStatus.Waiting;

            InnerReset();
        }

        public void RunAsync(Parser parser)
        {
            workingThread = new Thread(p => Run(parser));
            workingThread.Start();
        }

        public void Run(Parser parser)
        {
            SubtaskName = Name;
            this.parser = parser;
            StartTime = DateTime.Now;
            Status = ParseTaskStatus.Running;
            InnerRun();
        }

        protected void InnerEnd()
        {
            EndTime = DateTime.Now;
            Length = TimeSpan.FromMilliseconds((EndTime - StartTime).TotalMilliseconds);
            Status = ParseTaskStatus.Ok;
            CurrentStep = 1;
        }

        protected void InnerEnd(Exception error)
        {
            EndTime = DateTime.Now;
            Length = TimeSpan.FromMilliseconds((EndTime - StartTime).TotalMilliseconds);
            Status = ParseTaskStatus.Failed;
            Error = error;
            CurrentStep = 1;
        }

        public virtual void Abort()
        {
            workingThread?.Abort();
            Status = ParseTaskStatus.Aborted;
        }
    }
}
