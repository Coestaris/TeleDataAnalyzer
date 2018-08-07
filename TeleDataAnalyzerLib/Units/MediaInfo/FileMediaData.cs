namespace TeleDataAnalyzerLib.MediaInfo
{
    public class FileMediaData : MediaData
    {
        public string MimeType;
       
        public FileMediaData(string mimeType)
        {
            Type = MediaType.File;
            MimeType = mimeType;
        }
    }
}
