namespace TeleDataAnalyzerLib.MediaInfo
{
    public class AudioMediaData : MediaInfo
    {
        public string Performer;
        public string Title;
        public int Duration;

        public AudioMediaData(string performer, string title, int duration)
        {
            Type = MediaType.Audio_file;
            Performer = performer;
            Title = title;
            Duration = duration;
        }
    }
}
