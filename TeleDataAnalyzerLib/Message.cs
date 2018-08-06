using System;

namespace TeleDataAnalyzerLib
{
    public class Message
    {
        public User From;
        public DateTime Date;

        public MediaType MediaType;

        public bool IsSticker => MediaType == MediaType.Sticker;
        public bool IsAudio => MediaType == MediaType.Audio_file;
        public bool IsVideo => MediaType == MediaType.Video_file;
        public bool IsGIF => MediaType == MediaType.Animation;
        public bool IsVoice => MediaType == MediaType.Voice_message;
        public bool IsVideoMessage => MediaType == MediaType.Video_message;

        public MediaInfo MediaInfo;
    }
}
