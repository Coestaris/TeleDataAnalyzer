using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDataAnalyzerLib
{
    public class Parser
    {
        public const string Key_ChatType = "type";
        public const string Key_ChatMessages = "messages";

        public const string MessKey_ID = "id";
        public const string MessKey_Date = "date";
        public const string MessKey_Edited = "edited";
        public const string MessKey_From = "from";
        public const string MessKey_photo = "photo";
        public const string MessKey_MediaType = "media_type";
        public const string MessKey_Text = "text";

        public const string MessKey_Media_Duration = "duration_seconds";
        public const string MessKey_Media_Width = "width";
        public const string MessKey_Media_Height = "height";
        public const string MessKey_Media_Emoji = "sticker_emoji";
        public const string MessKey_Media_Performer = "performer";
        public const string MessKey_Media_Title = "title";



        public Parser(string fileName)
        {
            JObject json = (JObject)JObject.Parse(File.ReadAllText(fileName));
            var chatType = json.GetValue(Key_ChatType);
            var chatMessages = json.GetValue(Key_ChatMessages);

            CultureInfo provider = new System.Globalization.CultureInfo("en-US");
            var format = "yyyy-MM-dd\"T\"HH:mm:ss";

            List<Message> messages = new List<Message>();
            foreach(JObject a in chatMessages)
            {
                Message message = new Message();

                message.From = a.Value<string>(MessKey_From);
                message.ID = a.Value<int>(MessKey_ID);

                message.Date = a.Value<DateTime>(MessKey_Date);
                message.Edited = a.Value<DateTime>(MessKey_Edited);

                message.Text = a.Value<string>(MessKey_Text);

                if(a.ContainsKey(MessKey_photo))
                {
                    message.MediaType = MediaType.Photo;
                    message.MediaInfo = new MediaInfo.PhotoMediaData(
                            a.Value<int>(MessKey_Media_Width),
                            a.Value<int>(MessKey_Media_Height)
                        );
                }
                else if(a.ContainsKey(MessKey_MediaType))
                {
                    
                }

                messages.Add(message);

            }
        }
    }
}
