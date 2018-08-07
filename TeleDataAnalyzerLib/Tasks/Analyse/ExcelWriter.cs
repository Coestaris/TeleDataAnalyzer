using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Text;

namespace TeleDataAnalyzerLib.Tasks.Analyse
{
    public class ExcelWriter
    {
        public Chat chat;
        public ExcelWorksheet worksheet;
        public int Offset = 1;
        public int Width = 20;

        public int WidhtOffset { get; internal set; }

        public void WriteString()
        {
            Offset++;
        }

        public void WriteString(string caption, object value)
        {
            worksheet.Cells[Offset, WidhtOffset +1].Value = caption;
            worksheet.Cells[Offset, WidhtOffset + 2].Value = value;
            Offset++;
        }

        public void WriteString(params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                worksheet.Cells[Offset, WidhtOffset + i + 1].Value = values[i];
            }
            Offset++;
        }

        public static string ToPrettyFormat(TimeSpan span)
        {
            if (span == TimeSpan.Zero) return "<0 ms";

            var sb = new StringBuilder();
            if (span.Days > 0)
                sb.AppendFormat("{0} d{1} ", span.Days, span.Days > 1 ? "s" : String.Empty);
            if (span.Hours > 0)
                sb.AppendFormat("{0} h{1} ", span.Hours, span.Hours > 1 ? "s" : String.Empty);
            if (span.Minutes > 0)
                sb.AppendFormat("{0} m{1} ", span.Minutes, span.Minutes > 1 ? "s" : String.Empty);
            if (span.Seconds > 0)
                sb.AppendFormat("{0} s{1} ", span.Seconds, span.Seconds > 1 ? "s" : String.Empty);
            if (span.Milliseconds > 0)
                sb.AppendFormat("{0} ms", span.Milliseconds);
            return sb.ToString();
        }


        public void WriteString(Color fill, Font font, Color foreColor, int[] widhts, string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                worksheet.Column(WidhtOffset + i + 1).Width = widhts[i];
                worksheet.Cells[Offset, WidhtOffset + i + 1].Value = values[i];
                /*worksheet.Cells[Offset, WidhtOffset + i + 1].Style.Fill.BackgroundColor.SetColor(fill);
                worksheet.Cells[Offset, WidhtOffset + i + 1].Style.Font.Bold = font.Bold;
                worksheet.Cells[Offset, WidhtOffset + i + 1].Style.Font.Color.SetColor(foreColor);
                worksheet.Cells[Offset, WidhtOffset + i + 1].Style.Font.Size = font.Size;*/
            }
            Offset++;
        }
    }
}
