using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TeleDataAnalyzerLib.MediaInfo;

namespace TeleDataAnalyzerLib.Tasks
{
    public class ParseMessagesTask : ParseTask
    {
        private string FileName;

        public override string Name => "Parsing Messages";

        protected override void InnerReset() { }

        public void AddUser(List<string> users, string user)
        {
            if (user != null)
            {
                if (users.Contains(user)) return;
                else users.Add(user);
            }
        }

        public string GetPlainText(JArray array, out List<string> _links)
        {
            List<string> links = new List<string>();
            string result = "";

            foreach (JToken a in array)
            {
                switch (a.Type)
                {
                    case (JTokenType.Object):
                        {
                            var text = a.Value<string>(Parser.MessKey_Text);
                            if (a.Value<string>(Parser.Key_ChatType) == Parser.Key_TextType_Link)
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

        protected override void InnerRun()
        {
            List<Chat> resultChats = new List<Chat>();
            List<string> globalUsers = new List<string>();

            var json = parser.Object;
            var chats = json.Value<JObject>(Parser.Key_Chats).Value<JArray>(Parser.Key_List);

            int chatCounter = 0;
            int subCounter = 0;

            foreach (var chat in chats)
            {
                CurrentStep = chatCounter++ / (float)chats.Count;

                var chatType = chat.Value<string>(Parser.Key_ChatType);
                var chatMessages = chat.Value<JArray>(Parser.Key_ChatMessages);
                var chatName = chat.Value<string>(Parser.Key_ChatName);

                SubtaskName = chatName;

                List<string> participants = new List<string>();
                List<Message> messages = new List<Message>();
                foreach (JObject a in chatMessages)
                {

                    SubTaskCurrentStep = subCounter++ / (float)chatMessages.Count;
                    Message message = new Message();

                    message.From = a.Value<string>(Parser.MessKey_From);
                    AddUser(participants, message.From);
                    AddUser(globalUsers, message.From);

                    message.ID = a.Value<int>(Parser.MessKey_ID);

                    message.Date = a.Value<DateTime>(Parser.MessKey_Date);
                    message.Edited = a.Value<DateTime>(Parser.MessKey_Edited);

                    if (a.ContainsKey(Parser.MessKey_Forwarded))
                        message.ForwardedFrom = a.Value<string>(Parser.MessKey_Forwarded);

                    var text = a.GetValue(Parser.MessKey_Text);

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

                    if (a.ContainsKey(Parser.MessKey_photo))
                    {
                        message.MediaType = MediaType.Photo;
                        message.MediaInfo = new PhotoMediaData(
                                a.Value<int>(Parser.MessKey_Media_Width),
                                a.Value<int>(Parser.MessKey_Media_Height)
                            );
                    }
                    else if (a.ContainsKey(Parser.MessKey_MediaType))
                    {
                        var mediaType = (MediaType)Enum.Parse(typeof(MediaType), a.Value<string>(Parser.MessKey_MediaType), true);
                        switch (mediaType)
                        {
                            case MediaType.Sticker:
                                message.MediaInfo = new StickerMediaData(
                                    a.Value<string>(Parser.MessKey_Media_Emoji),
                                    a.Value<int>(Parser.MessKey_Media_Width),
                                    a.Value<int>(Parser.MessKey_Media_Height));
                                break;
                            case MediaType.Audio_file:
                                message.MediaInfo = new AudioMediaData(
                                    a.Value<string>(Parser.MessKey_Media_Performer),
                                    a.Value<string>(Parser.MessKey_Media_Title),
                                    a.Value<int>(Parser.MessKey_Media_Duration));
                                break;
                            case MediaType.Video_file:
                            case MediaType.Animation:
                            case MediaType.Video_message:
                                message.MediaInfo = new VideoMediaData(
                                  a.Value<int>(Parser.MessKey_Media_Duration),
                                    a.Value<int>(Parser.MessKey_Media_Width),
                                    a.Value<int>(Parser.MessKey_Media_Height),
                                    mediaType);
                                break;
                            case MediaType.Voice_message:
                                message.MediaInfo = new VoiceMediaData(
                                    a.Value<int>(Parser.MessKey_Media_Duration));
                                break;
                            case MediaType.Null:
                            default:
                                message.MediaInfo = null;
                                break;
                        }
                        message.MediaType = mediaType;
                    }
                    else if (a.ContainsKey(Parser.MessKey_File))
                    {
                        message.MediaType = MediaType.File;
                        message.MediaInfo = new FileMediaData(
                            a.Value<string>(Parser.MessKey_Media_MimeType));
                    }

                    messages.Add(message);
                }

                subCounter = 0;
                resultChats.Add(new Chat()
                {
                    Messages = messages,
                    Type = (ChatType)Enum.Parse(typeof(ChatType), chatType, true),
                    Name = chatName,
                    Participants = participants
                });
            }

            parser.GlobalUsers = globalUsers;
            parser.Chats = resultChats;
            InnerEnd();
        }
    }
}
