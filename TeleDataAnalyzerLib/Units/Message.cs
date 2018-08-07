using System;
using TeleDataAnalyzerLib.MediaInfo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace TeleDataAnalyzerLib
{
    public class Message
    {
        public string From;
        public DateTime Date;
        internal DateTime Edited;
        public List<string> Links;

        public MediaType MediaType = MediaType.Null;
        public MediaData MediaInfo;

        public int ID;
        public string Text;

        public string ForwardedFrom; 

        public bool IsSticker => MediaType == MediaType.Sticker;
        public bool IsAudio => MediaType == MediaType.Audio_file;
        public bool IsVideo => MediaType == MediaType.Video_file;
        public bool IsGIF => MediaType == MediaType.Animation;
        public bool IsVoice => MediaType == MediaType.Voice_message;
        public bool IsVideoMessage => MediaType == MediaType.Video_message;

        public bool HasText => !string.IsNullOrEmpty(Text);
        public bool HasLinks => Links != null && Links.Count != 0;
        public bool IsEdited => Edited.Year != 1970;
        public bool IsForwarded => !string.IsNullOrEmpty(ForwardedFrom);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append('[');
            sb.AppendFormat("At: {0}", Date);
            if (IsEdited) sb.AppendFormat(" Edited at: {0}", Edited);
            if (IsForwarded) sb.AppendFormat(" Forwarded: {0}", ForwardedFrom);
            sb.AppendFormat(" By: {0}", From);
            sb.Append("]: ");

            switch (MediaType)
            {
                case MediaType.Photo:
                    {
                        PhotoMediaData data = MediaInfo as PhotoMediaData;
                        sb.AppendFormat("Photo[{0}x{1}]", data.Width, data.Height);
                        break;
                    }
                case MediaType.Sticker:
                    {
                        StickerMediaData data = MediaInfo as StickerMediaData;
                        sb.AppendFormat("Sticker[{0}. {1}x{2}]", data.Emoji, data.Width, data.Height);
                        break;
                    }
                case MediaType.Audio_file:
                    {
                        AudioMediaData data = MediaInfo as AudioMediaData;
                        sb.AppendFormat("Audio[{0} - {1}. {2}s]", data.Performer, data.Title, data.Duration);
                        break;
                    }

                case MediaType.Video_file:
                case MediaType.Animation:
                case MediaType.Video_message:
                    {
                        VideoMediaData data = MediaInfo as VideoMediaData;
                        sb.AppendFormat("Audio[{0}x{1}. {2}s]", data.Width, data.Height, data.Duration);
                        break;
                    }
                case MediaType.Voice_message:
                    {
                        VoiceMediaData data = MediaInfo as VoiceMediaData;
                        sb.AppendFormat("Voice[{0}s]", data.Duration);
                        break;
                    }
                case MediaType.File:
                    {
                        FileMediaData data = MediaInfo as FileMediaData;
                        sb.AppendFormat("File[{0}]", data.MimeType);
                        break;
                    }
                case MediaType.Null:
                default:
                    break;
            }

            if (HasText) sb.AppendFormat("\"{0}\"", Text);
            if (HasLinks) sb.AppendFormat(". Links: {0}", Links.Count);
            return sb.ToString();
        }

        public Message()
        {

        }
    }
}
