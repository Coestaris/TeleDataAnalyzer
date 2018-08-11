using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleDataAnalyzerLib.MediaInfo;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class GroupUsersTable : ParseTask
    {
        public ExcelWriter Writer;

        public GroupUsersTable(ExcelWriter writer)
        {
            Writer = writer;
        }

        public override string Name => "General info";

        protected override void InnerReset() { }

        protected override void InnerRun()
        {
            InnerEnd();
            var users = Writer.chat.Messages.GroupBy(p => p.From).OrderByDescending(p => p.Count() / (float)Writer.chat.Messages.Count());
            int counter = 0;

            Writer.WriteString();
            Writer.WidhtOffset = 2;

            var start = Writer.Offset;

            Writer.Width = 24;
            Writer.WriteString(
                fill : Color.White,
                font : new Font("Tahoma", 12, FontStyle.Bold),
                foreColor : Color.Black,
                widhts: new int[]
                {
                    20,
                    21,
                    21,
                    21,
                    11,
                    18,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                    13,
                },
                values : new string[]
                {
                    "Имя",
                    "Первое с-ние",
                    "Последние с-ние",
                    "В чате",
                    "Сообщений",
                    "Измененных с-ний",
                    "% всех с-ний",
                    "Изображений",
                    "Войсов",
                    "Видосов",
                    "Гифок",
                    "Аудио",
                    "Файлов",
                    "Видео с-ний",
                    "Стикеров",
                    "Ссылок",
                    "С-ний в день"
                });

            foreach (var item in users)
            {
                CurrentStep = counter++ / users.Count();

                DateTime first = item.First().Date;
                DateTime last = item.Last().Date;
                
                Writer.WriteString(
                    string.IsNullOrEmpty(item.Key) ? "[SERVICE_MSG]" : item.Key,
                    first.ToString(),
                    last.ToString(),
                    ExcelWriter.ToPrettyFormat(last - first),
                    item.Count().ToString(),
                    item.Count(p => p.IsEdited).ToString(),
                    string.Format("{0:0.##}%", item.Count() / (float)Writer.chat.Messages.Count() * 100),
                    item.Count(p => p.IsPhoto).ToString(),
                    item.Count(p => p.IsVoice).ToString(),
                    item.Count(p => p.IsVideo).ToString(),
                    item.Count(p => p.IsGIF).ToString(),
                    item.Count(p => p.IsAudio).ToString(),
                    item.Count(p => p.IsFile).ToString(),
                    item.Count(p => p.IsVideoMessage).ToString(),
                    item.Count(p => p.IsSticker).ToString(),
                    item.Sum(p => p.HasLinks ? p.Links.Count : 0).ToString(),
                    string.Format("{0:0.##}", item.Count() / (last - first).TotalDays));
            }

            {
                CurrentStep = counter++ / users.Count();

                DateTime first = Writer.chat.Messages.First().Date;
                DateTime last = Writer.chat.Messages.Last().Date;

                Writer.WriteString(
                    "TOTAL",
                    first.ToString(),
                    last.ToString(),
                    ExcelWriter.ToPrettyFormat(last - first),
                    Writer.chat.Messages.Count().ToString(),
                    Writer.chat.Messages.Count(p => p.IsEdited).ToString(),
                    string.Format("{0:0.##}%", Writer.chat.Messages.Count() / (float)Writer.chat.Messages.Count() * 100),
                    Writer.chat.Messages.Count(p => p.IsPhoto).ToString(),
                    Writer.chat.Messages.Count(p => p.IsVoice).ToString(),
                    Writer.chat.Messages.Count(p => p.IsVideo).ToString(),
                    Writer.chat.Messages.Count(p => p.IsGIF).ToString(),
                    Writer.chat.Messages.Count(p => p.IsAudio).ToString(),
                    Writer.chat.Messages.Count(p => p.IsFile).ToString(),
                    Writer.chat.Messages.Count(p => p.IsVideoMessage).ToString(),
                    Writer.chat.Messages.Count(p => p.IsSticker).ToString(),
                    Writer.chat.Messages.Sum(p => p.HasLinks ? p.Links.Count : 0).ToString(),
                    string.Format("{0:0.##}", Writer.chat.Messages.Count() / (last - first).TotalDays));
            }
        }
    }
}
