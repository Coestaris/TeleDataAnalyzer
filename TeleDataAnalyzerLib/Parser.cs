using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeleDataAnalyzerLib.MediaInfo;

namespace TeleDataAnalyzerLib
{
    public class Parser
    {
        public const string Key_TextType_Link = "link";
        public const string MessKey_Forwarded = "forwarded_from";
        public const string Key_ChatType = "type";
        public const string Key_ChatMessages = "messages";
        public const string MessKey_ID = "id";
        public const string MessKey_Date = "date";
        public const string MessKey_File = "file";
        public const string MessKey_Edited = "edited";
        public const string MessKey_From = "from";
        public const string MessKey_photo = "photo";
        public const string MessKey_MediaType = "media_type";
        public const string MessKey_Text = "text";
        public const string MessKey_Media_MimeType = "mime_type";
        public const string MessKey_Media_Duration = "duration_seconds";
        public const string MessKey_Media_Width = "width";
        public const string MessKey_Media_Height = "height";
        public const string MessKey_Media_Emoji = "sticker_emoji";
        public const string MessKey_Media_Performer = "performer";
        public const string MessKey_Media_Title = "title";
        
        public string GetPlainText(JArray array, out List<string> _links)
        {
            List<string> links = new List<string>();
            string result = "";

            foreach(JToken a in array)
            {
                switch (a.Type)
                {
                    case (JTokenType.Object):
                        {
                            var text = a.Value<string>(MessKey_Text);
                            if(a.Value<string>(Key_ChatType) == Key_TextType_Link)
                            {
                                links.Add(text);
                            }
                            else
                            {
                                result += text;
                            }
                        }
                        break;
                    case (JTokenType.String):
                        result += a.Value<string>();
                        break;
                    default:
                        result += "";
                        break;
                }
            }

            _links = links;
            return result;
        }

        public Parser(string fileName)
        {
            JObject json = JObject.Parse(File.ReadAllText(fileName));
            var chatType = json.GetValue(Key_ChatType);
            var chatMessages = json.GetValue(Key_ChatMessages);

            List<Message> messages = new List<Message>();
            foreach (JObject a in chatMessages)
            {
                Message message = new Message();

                message.From = a.Value<string>(MessKey_From);
                message.ID = a.Value<int>(MessKey_ID);

                message.Date = a.Value<DateTime>(MessKey_Date);
                message.Edited = a.Value<DateTime>(MessKey_Edited);

                if (a.ContainsKey(MessKey_Forwarded))
                    message.ForwardedFrom = a.Value<string>(MessKey_Forwarded);

                var text = a.GetValue(MessKey_Text);

                switch (text.Type)
                {
                    case (JTokenType.Array):
                        message.Text = GetPlainText(text.Value<JArray>(), out var _links);
                        message.Links = _links;
                        break;
                    case (JTokenType.String):
                        message.Text = text.Value<string>();
                        break;
                    default:
                        message.Text = "";
                        break;
                }

                if (a.ContainsKey(MessKey_photo))
                {
                    message.MediaType = MediaType.Photo;
                    message.MediaInfo = new PhotoMediaData(
                            a.Value<int>(MessKey_Media_Width),
                            a.Value<int>(MessKey_Media_Height)
                        );
                }
                else if (a.ContainsKey(MessKey_MediaType))
                {
                    var mediaType = (MediaType)Enum.Parse(typeof(MediaType), a.Value<string>(MessKey_MediaType), true);
                    switch (mediaType)
                    {
                        case MediaType.Sticker:
                            message.MediaInfo = new StickerMediaData(
                                a.Value<string>(MessKey_Media_Emoji),
                                a.Value<int>(MessKey_Media_Width),
                                a.Value<int>(MessKey_Media_Height));
                            break;
                        case MediaType.Audio_file:
                            message.MediaInfo = new AudioMediaData(
                                a.Value<string>(MessKey_Media_Performer),
                                a.Value<string>(MessKey_Media_Title),
                                a.Value<int>(MessKey_Media_Duration));
                            break;
                        case MediaType.Video_file:
                        case MediaType.Animation:
                        case MediaType.Video_message:
                            message.MediaInfo = new VideoMediaData(
                              a.Value<int>(MessKey_Media_Duration),
                                a.Value<int>(MessKey_Media_Width),
                                a.Value<int>(MessKey_Media_Height),
                                mediaType);
                            break;
                        case MediaType.Voice_message:
                            message.MediaInfo = new VoiceMediaData(
                                a.Value<int>(MessKey_Media_Duration));
                            break;
                        case MediaType.Null:
                        default:
                            message.MediaInfo = null;
                            break;
                    }
                    message.MediaType = mediaType;
                }
                else if (a.ContainsKey(MessKey_File))
                {
                    message.MediaType = MediaType.File;
                    message.MediaInfo = new FileMediaData(
                        a.Value<string>(MessKey_Media_MimeType));
                }

                messages.Add(message);
            }

            File.WriteAllLines("output.txt", messages.Select(p => p.ToString()));
        }
    }
}
