using System;
using System.Collections.Generic;
using System.Linq;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class LinkUsageTask : ParseTask
    {
        public ExcelWriter Writer;

        public LinkUsageTask(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "Link usage";

        protected override void InnerReset() { }
        
        public string GetHost(string uri)
        {
            uri = uri.ToLower();
            uri = uri.Replace('\\', '/');

            uri = uri.Replace("www.", "");
            uri = uri.Replace("http://", "");
            uri = uri.Replace("https://", "");
            if (!uri.EndsWith("/"))
                uri += '/';

            return uri.Split('/')[0];
        }

        protected override void InnerRun()
        {
            var links = new List<string>();

            Writer.chat.Messages.FindAll(p => p.HasLinks)
                .ForEach(p => links.AddRange(p.Links));
            
            var groups = links.GroupBy(p => GetHost(p)).OrderBy(p => p.Key).OrderByDescending(p => p.Count());
            Writer.WriteString();
            Writer.WriteString();

            Writer.WriteString("Домен", "Кол-во");
            foreach (var a in groups)
                Writer.WriteString(a.Key.ToString(), a.Count());

            InnerEnd();
        }
    }
}
