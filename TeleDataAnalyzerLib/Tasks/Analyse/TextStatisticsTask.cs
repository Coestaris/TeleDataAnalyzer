using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class TextStatisticsTask : ParseTask
    {
        public ExcelWriter Writer;

        public TextStatisticsTask(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "Collecting text staticstics";

        protected override void InnerReset() { }

        public class MyGrouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
        {
            public TKey Key
            {
                get;
                set;
            }
        }

        protected override void InnerRun()
        {
            const int count = 200;
            List<char> splitChars = new List<char>();
            for (char c = '\0'; c < (char)255; c++)
                if (!char.IsLetterOrDigit(c))
                    splitChars.Add(c);

            var groups = Writer.chat.Messages.GroupBy(p => p.From).OrderByDescending(p => p.Count()).ToList();
            groups.InsertRange(0, Writer.chat.Messages.GroupBy(x => "TOTAL").ToList());

            var allText = new List<string>();
            int globalCounter = 0;

            List<Dictionary<string, int>> result = new List<Dictionary<string, int>>();

            foreach (var a in groups)
            {
                int counter = 0;

                SubtaskName = a.Key;
                CurrentStep = (globalCounter++ / (float)groups.Count()) / 2f;
                allText = new List<string>();
                
                foreach (var b in a)
                {
                    SubTaskCurrentStep = (counter++ / (float)a.Count()) / 2f;
                    allText.AddRange(
                        b.Text.Split(splitChars.ToArray())
                        .ToList()
                        .FindAll(p => !string.IsNullOrWhiteSpace(p))
                        .Select(p => p.ToLower()));
                }

                counter = 0;
                var groupedWords = new Dictionary<string, int>();
                foreach(var word in allText)
                {
                    SubTaskCurrentStep = .5f + (counter++ / (float)allText.Count()) / 2f;
                    if (groupedWords.ContainsKey(word))
                        groupedWords[word]++;
                    else groupedWords.Add(word, 1);
                }

                groupedWords = groupedWords.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
                result.Add(groupedWords);
            }

            SubtaskName = "Outputting results";

            Writer.WriteString();
            Writer.WriteString();

            const int rowsPerMember = 3;
            var array1 = new List<string>();
            var array2 = new List<string>();

            int chatCounter = 0;
            for(int i = 0; i < groups.Count(); i++)
            {
                array1.Add(groups.ElementAt(i).Key);
                array1.Add($"С-ний: {groups.ElementAt(i).Count()}");
                array1.Add($"Слов: {result[chatCounter].Sum(p => p.Value)} ({string.Format("{0:.##}", result[chatCounter++].Sum(p => p.Value)/(float)groups.ElementAt(i).Count())})");

                for (int j = 0; j < rowsPerMember - 2; j++)
                    array1.Add("");

                array2.AddRange(new List<string>
                {
                    "Слово",
                    "Кол-во",
                    "% от всех",
                    ""
                });
            }

            Writer.WriteString(array1.ToArray());
            Writer.WriteString(array2.ToArray());


            for (int i = 0; i < count; i++) 
            {
                chatCounter = 0;
                CurrentStep = .5f + (i / (float)count) / 2;
                SubTaskCurrentStep = i / (float)count;

                List<string> listToAdd = new List<string>();
                foreach (var a in result)
                {
                    if (i >= a.Count())
                    {
                        listToAdd.AddRange(new List<string>
                        {
                            "",
                            "",
                            "",
                            ""
                        });
                    }
                    else
                    {
                        listToAdd.AddRange(new List<string>
                        {
                            a.ElementAt(i).Key,
                            a.ElementAt(i).Value.ToString(),
                            string.Format("{0:0.###}%", a.ElementAt(i).Value / (float)a.Sum(p => p.Value)),
                            ""
                        });
                    }
                    chatCounter++;
                }
                Writer.WriteString(listToAdd.ToArray());
            }

            InnerEnd();
        }
    }
}
