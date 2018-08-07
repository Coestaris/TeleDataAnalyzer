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
        internal TimeSpan ParseTime;

        public const string Key_Chats = "chats";
        public const string Key_List = "list";

        public const string Key_TextType_Link = "link";
        public const string MessKey_Forwarded = "forwarded_from";
        public const string Key_ChatType = "type";
        public const string Key_ChatName = "name";
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

        public JObject Object { get; internal set; }

    }
}
