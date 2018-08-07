using System;
using System.Linq;
using TeleDataAnalyzerLib.MediaInfo;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class GroupGeneralInfo : ParseTask
    {
        public ExcelWriter Writer;

        public GroupGeneralInfo(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "General info";

        protected override void InnerReset() { }

        protected override void InnerRun()
        {
            /*
            - кол-во сообщений
            - кол-во медиа
            - кол-во изм. сообщ

            - первое сообщение
            - последнее сообщение
             */

            int count = Writer.chat.Messages.Count;
            int countMedia = Writer.chat.Messages.Count(p => p.MediaType != MediaType.Null);
            int countEdited = Writer.chat.Messages.Count(p => p.IsEdited);
            int countForwarded = Writer.chat.Messages.Count(p => p.IsForwarded);

            DateTime first = Writer.chat.Messages.First().Date;
            DateTime last = Writer.chat.Messages.Last().Date;

            var photos = Writer.chat.Messages.FindAll(p => p.MediaType == MediaType.Photo);
            var voices = Writer.chat.Messages.FindAll(p => p.MediaType == MediaType.Voice_message);
            var videos = Writer.chat.Messages.FindAll(p => p.MediaType == MediaType.Video_file);
            var videoM = Writer.chat.Messages.FindAll(p => p.MediaType == MediaType.Video_message);
            var animms = Writer.chat.Messages.FindAll(p => p.MediaType == MediaType.Animation);
            var stickers = Writer.chat.Messages.FindAll(p => p.MediaType == MediaType.Sticker);

            string mostStricker = "";

            if(stickers.Count != 0)
            {
                mostStricker = stickers.GroupBy(p => (p.MediaInfo as StickerMediaData).Emoji).
                    OrderByDescending(p => p.Count()).First().Key;
            }

            double widhtAv = photos.Count == 0 ? 0 : photos.Average(p => (p.MediaInfo as PhotoMediaData).Width);
            double heightAv = photos.Count == 0 ? 0 : photos.Average(p => (p.MediaInfo as PhotoMediaData).Height);
            double voiceAv = voices.Count == 0 ? 0 : voices.Average(p => (p.MediaInfo as VoiceMediaData).Duration);
            double videoAv = videos.Count == 0 ? 0 : videos.Average(p => (p.MediaInfo as VideoMediaData).Duration);
            double videoMessAv = videoM.Count == 0 ? 0 : videoM.Average(p => (p.MediaInfo as VideoMediaData).Duration);
            double animationAv = animms.Count == 0 ? 0 : animms.Average(p => (p.MediaInfo as VideoMediaData).Duration);
            
            Writer.WriteString("Количество сообщений", count);
            Writer.WriteString("Общее количество медиа", countMedia);
            Writer.WriteString("Количество измененных сообщений", countEdited);
            Writer.WriteString("Количество пересланных сообщений", countForwarded);
            Writer.WriteString("Первое сообщение", first.ToString());
            Writer.WriteString("Последние сообщение", last.ToString());

            Writer.WriteString("Средний рамер изображений", string.Format("W: {0:.0}.W:{1:0.}({2:0.} pixels)", widhtAv, heightAv, widhtAv * heightAv));
            Writer.WriteString("Средняя длина войсов", string.Format("{0:.00}s", voiceAv));
            Writer.WriteString("Средняя длина видео", string.Format("{0:.00}s", videoAv));
            Writer.WriteString("Средняя длина видео-сообщений", string.Format("{0:.00}s", videoMessAv));
            Writer.WriteString("Средняя длина гифок", string.Format("{0:.00}s", animationAv));
            Writer.WriteString("Самый популярный стикер (его смайлик)", mostStricker);
            
            InnerEnd();
        }
    }
}
