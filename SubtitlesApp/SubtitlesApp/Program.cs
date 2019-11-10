using System.IO;
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
        }
    }
}