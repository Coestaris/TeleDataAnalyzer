namespace TeleDataAnalyzerLib.MediaInfo
{
    public class StickerMediaData : MediaInfo
    {
        public char Emoji;
        public int Width;
        public int Height;

        public StickerMediaData(char emoji, int width, int height)
        {
            Type = MediaType.Sticker;
            Emoji = emoji;
            Width = width;
            Height = height;
        }
    }
}
