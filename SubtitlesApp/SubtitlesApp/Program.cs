using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Subtitles.Model;
using Subtitles.Model.Enums;
using SubtitlesApp.Model;

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
            var path = "dictionary.json";
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
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            }.Select(x => new Word
            {
                Category = Category.WordPattern,
                PartsOfSpeech = new[]
                {
                    PartsOfSpeech.Noun
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
            var txt = text.Replace("\r\n", "\n");
            var items = txt.Split("\n\n");

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