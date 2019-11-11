using System.IO;
using System.Text;
using SubtitlesApp.Model;

namespace SubtitlesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = args[0];
            var text = File.ReadAllText(path);
            var items = text.Split("\r\n\r\n");

            Subtitle[] subtitles = Parser.Parse(items);
            var sb = new StringBuilder();
            foreach (var subtitle in subtitles)
            {
                foreach (var content in subtitle.Content)
                {
                    sb.Append(content + "</br>");
                }
            }

            var title = "terminator 2";
            var body = sb.ToString();
            var html = "<!DOCTYPE html><html lang=\"en\"xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta charset=\"utf-8\"/>" +
                       $"<title>{title}</title>" +
                       $"</head><body>{body}</body></html>";

            File.WriteAllText($"{path}.html", html);
        }
    }
}