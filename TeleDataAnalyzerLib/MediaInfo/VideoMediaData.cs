using System;

namespace TeleDataAnalyzerLib.MediaInfo
{
    public class VideoMediaData : MediaInfo
    {
        public int Duration;
        public int Width;
        public int Height;

        public VideoMediaData(int duration, int width, int height, MediaType type)
        {
            if(type != MediaType.Video_file && type != MediaType.Video_message &&
                type != MediaType.Animation) throw new ArgumentException();

            Type = type;
            Duration = duration;
            Width = width;
            Height = height;
        }
    }
}
