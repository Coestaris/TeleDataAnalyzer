using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class DayUsageTask : ParseTask
    {
        public ExcelWriter Writer;

        public DayUsageTask(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "Days usage";

        protected override void InnerReset() { }

        protected override void InnerRun()
        {
            var groups = Writer.chat.Messages.GroupBy(p => p.Date.DayOfWeek).OrderBy(p => p.Key);
            Writer.WriteString();
            Writer.WriteString();

            Writer.WriteString("День недели", "Сообщений");
            foreach (var a in groups)
                Writer.WriteString(a.Key.ToString(), a.Count());

            InnerEnd();
        }
    }
}
