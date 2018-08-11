using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class HoursUsageTask : ParseTask
    {
        public ExcelWriter Writer;

        public HoursUsageTask(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "Hours usage";

        public struct DataNode
        {
            public int Month;
            public  Dictionary<int, int> Messages;
        }

        protected override void InnerReset() { }

        protected override void InnerRun()
        {
            var totalGroups = Writer.chat.Messages.GroupBy(p => p.Date.Hour).OrderBy(p => p.Key);
            Writer.WriteString();
            Writer.WriteString();

            var array1 = new List<string>();
            var array2= new List<List<string>>();

            var specificGroups = Writer.chat.Messages.GroupBy(p => p.Date.Month).Select(p => 
                new DataNode() { Month = p.Key, Messages = p.GroupBy(j => j.Date.Hour).OrderBy(j => j.Key).ToDictionary(j => j.Key, j => j.Count()) })
                .ToList();

            specificGroups.Insert(0, new DataNode() { Month = -1, Messages = totalGroups.ToDictionary(j => j.Key, j => j.Count()) });

            foreach (var item in specificGroups)
            {
               
                array1.AddRange(new string[]
                {
                    $"Час суток (за {item.Month} месяц)",
                    "Сообщений",
                    ""
                });

               
            }

            for (int i = 0; i < 24; i++) 
            {
                var tmp = new List<string>();
                foreach (var a in specificGroups)
                {
                    tmp.AddRange(new string[]
                    {
                        i.ToString(),
                        a.Messages.ContainsKey(i) ? a.Messages[i].ToString() : "",
                        ""
                    });
                }
                array2.Add(tmp);
            }



            Writer.WriteString(array1.ToArray());
            foreach (var a in array2)
                Writer.WriteString(a.ToArray());

            InnerEnd();
        }
    }
}
