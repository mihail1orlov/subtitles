using System.IO;
using System.Text.RegularExpressions;

namespace SubtitlesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = args[0];
            var text = File.ReadAllText(path);
            var items = text.Split("\r\n\r\n");

            var parser = new Parser();
            parser.Parse(items);

            var pattern = @"(\d+)(\r\n)(\d{2}:\d{2}:\d{2},\d{3})( --> )(\d{2}:\d{2}:\d{2},\d{3})";
            var regex = new Regex(pattern);
            var strings = regex.Matches(items[10]);
        }
    }
}
