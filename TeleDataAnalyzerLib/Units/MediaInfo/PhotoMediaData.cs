namespace TeleDataAnalyzerLib.MediaInfo
{
    public class PhotoMediaData : MediaData
    {
        public int Width;
        public int Height;

        public PhotoMediaData(int width, int height)
        {
            Type = MediaType.Photo;
            Width = width;
            Height = height;
        }
    }
}
