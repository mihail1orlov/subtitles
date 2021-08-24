using Subtitles.Model;
using Subtitles.Model.Enums;
using SubtitlesApp.Html;
using SubtitlesApp.Model;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SubtitlesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CreateDictionary();
            // CreateSubtitle();
        }

        private static void CreateDictionary()
        {
            var path = "D:\\repos\\victoria\\mindMaps\\dictionary.json";
            var source = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };

            var dictionary = JsonSerializer.Deserialize<Dictionary>(source, options);

            dictionary.AddRange(new[]
            {
                "",
            }.Select(x => new Word
            {
                Category = Category.PrepositionalPhrases,
                PartsOfSpeech = new[]
                {
                    PartsOfSpeech.None
                },
                Text = x
            }));

            var json = JsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(path, json);
        }

        private static void CreateSubtitle()
        {
            var path = @"M:\lessons\Mosh Hamedani - All Courses Pack\React\Mastering React\01 - Getting Started (00h28m)\1- What is React.vtt";
            var text = File.ReadAllText(path);
            var items = text.Split("\r\n\r\n");

            Subtitle[] subtitles = Parser.Parse(items);
            var sb = new StringBuilder();
            foreach (var subtitle in subtitles)
            {
                foreach (var content in subtitle.Content)
                {
                    sb.Append(content + "</br>\n");
                }
            }

            var title = "terminator 2";
            var body = sb.ToString();
            var html = string.Format(HtmlTemplate.Template, title, body);

            File.WriteAllText($"{path}.html", html);
        }
    }
}