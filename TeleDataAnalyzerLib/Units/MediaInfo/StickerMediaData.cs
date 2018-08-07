namespace TeleDataAnalyzerLib.MediaInfo
{
    public class StickerMediaData : MediaData
    {
        public string Emoji;
        public int Width;
        public int Height;

        public StickerMediaData(string emoji, int width, int height)
        {
            Type = MediaType.Sticker;
            Emoji = emoji;
            Width = width;
            Height = height;
        }
    }
}
