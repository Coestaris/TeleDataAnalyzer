using Newtonsoft.Json.Linq;
using System.IO;

namespace TeleDataAnalyzerLib.Tasks
{
    public class ParseJSONTask : ParseTask
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
            InnerEnd();
        }
    }
}
