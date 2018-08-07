using System.Collections.Generic;

namespace TeleDataAnalyzerLib
{
    public class Chat
    {
        public string Name;
        public List<Message> Messages;
        public ChatType Type;
        public List<string> Participants;

        public override string ToString()
        {
            return string.Format("{0}. MSG: {1}. Type: {2}", Name, Messages.Count, Type);
        }
    }
}
