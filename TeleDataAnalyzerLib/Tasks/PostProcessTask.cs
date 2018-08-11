using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TeleDataAnalyzerLib.MediaInfo;

namespace TeleDataAnalyzerLib.Tasks
{
    public class PostProcessTask : ParseTask
    {
        public override string Name => "Post-processing";

        protected override void InnerReset() { }

        protected override void InnerRun()
        {
            parser.Chats = parser.Chats.OrderByDescending(p => p.Messages.Count).ToList();

            InnerEnd();
        }
    }
}
