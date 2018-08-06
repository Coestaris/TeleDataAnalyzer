namespace TeleDataAnalyzerLib.MediaInfo
{
    public class VoiceMediaData : MediaData
    {
        public int Duration;

        public VoiceMediaData(int duration)
        {
            Type = MediaType.Voice_message;
            Duration = duration;
        }
    }
}
