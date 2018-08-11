using System.Linq;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class MonthUsageTask : ParseTask
    {
        public ExcelWriter Writer;

        public MonthUsageTask(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "Month usage";

        protected override void InnerReset() { }

        protected override void InnerRun()
        {
            var groups = Writer.chat.Messages.GroupBy(p => p.Date.Month).OrderBy(p => p.Key);
            Writer.WriteString();
            Writer.WriteString();

            Writer.WriteString("Месяц", "Сообщений");
            foreach (var a in groups)
                Writer.WriteString(a.Key.ToString(), a.Count());

            InnerEnd();
        }
    }
}
