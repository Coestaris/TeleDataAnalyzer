namespace TeleDataAnalyzerLib.MediaInfo
{
    public class VoiceMediaData : MediaInfo
    {
        public int Duration;

        public VoiceMediaData(int duration)
        {
            Type = MediaType.Voice_message;
            Duration = duration;
        }
    }
}
