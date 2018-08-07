using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDataAnalyzerLib.Tasks
{
    class ParseJSONTask : ParseTask
    {
        private string FileName;

        public ParseJSONTask(string fileName)
        {
            FileName = fileName;
        }

        public override string Name => "Parsing JSON";

        protected override void InnerReset()
        {
        }

        protected override void InnerRun()
        {
            parser.Object = JObject.Parse(File.ReadAllText(FileName));
        }
    }
}
