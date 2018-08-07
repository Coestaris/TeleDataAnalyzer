using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TeleDataAnalyzerLib;

namespace TeleDataAnalyzer
{
    public partial class ProgressDialog : Form
    {
        private List<ParseTask> Tasks;
        private Parser parser;
        private const int MaxValue = 100;

        public string CurrentTask;

        public ProgressDialog(List<ParseTask> tasks, Parser parser)
        {
            InitializeComponent();
            Tasks = tasks;
            this.parser = parser;
        }

        private void Runner_AsyncTaskСhanged(ParseTaskRunner runner, Parser parser)
        {
            if (InvokeRequired)
            {
                Invoke(new ParseTaskRunner.AsyncTaskChangedDelegate(Runner_AsyncTaskСhanged), runner, parser);
            }
            else
            {
                CurrentTask = Tasks[runner.index - 1].Name;
            }
        }

        private void Runner_AsyncTaskPeriodical(ParseTaskRunner runner, Parser parser)
        {
            if (InvokeRequired)
            {
                Invoke(new ParseTaskRunner.AsyncTaskPeriodicalDelegate(Runner_AsyncTaskPeriodical), runner, parser);
            }
            else
            {
                progressBarTotal.Value = Math.Min(progressBarTotal.Maximum, (int)((runner.index - 1) * MaxValue + Tasks[runner.index - 1].CurrentStep * MaxValue));
                progressBarCurrent.Value = Math.Min(progressBarCurrent.Maximum, (int)(Tasks[runner.index - 1].SubTaskCurrentStep * MaxValue));

                labelTotal.Text = string.Format("[{0:0.0}%. {1:0}/{2:0}]. Task: {3}", (float)progressBarTotal.Value / progressBarTotal.Maximum * 100,
                    runner.index, Tasks.Count, CurrentTask);

                labelCurrent.Text = string.Format("{0:0.0}% - {1}", (float)progressBarCurrent.Value / progressBarCurrent.Maximum * 100,
                    Tasks[runner.index - 1].SubtaskName);
            }
        }

        private void Runner_AsyncParseEnd(ParseTaskRunner runner, Parser parser)
        {
            if(InvokeRequired)
            {
                Invoke(new ParseTaskRunner.AsyncParseEndDelegate(Runner_AsyncParseEnd), runner, parser);
            }
            else
            {
                Exception ex = Tasks[runner.FailedTaskIndex].Error;
                if(ex != null)
                {
                    MessageBox.Show(string.Format("{0}\n{1}\n\n{2}", 
                        ex.Message, ex.StackTrace, ex.InnerException), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Close();
            }
        }

        private void ProgressDialog_Load(object sender, EventArgs e)
        {
            ParseTaskRunner runner = new ParseTaskRunner(parser);

            progressBarTotal.Maximum = Tasks.Count * MaxValue;
            progressBarCurrent.Maximum = MaxValue;

            runner.UpdatePeriod = 50;
            runner.AsyncParseEnd += Runner_AsyncParseEnd;
            runner.AsyncTaskPeriodical += Runner_AsyncTaskPeriodical;
            runner.AsyncTaskСhanged += Runner_AsyncTaskСhanged;

            runner.RunAsync(Tasks);
        }
    }
}
