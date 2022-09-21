using Subtitles.Model;
using Subtitles.Model.Enums;
using SubtitlesApp.Html;
using SubtitlesApp.Model;
using System;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SubtitlesApp
{
    internal class Program
    {
        private static void Main()
        {
            //Tupilka();
            //new TestSpeechRecognizer().Start();
            //Speak();
            //CreateDictionary();
            //CreateHtmlFromDictionary();
            CreateSubtitle();
        }

        private static void Tupilka()
        {
            using var tupilka = new Tupilka();
            tupilka.Start();
            do
            {
                Console.Clear();
                Console.Write("Enter any line: ");
                tupilka.Pause();
                var line = Console.ReadLine();
                tupilka.UnPause();
                Console.Write($"You entered the {line}");
            } while (Console.ReadKey().Key != ConsoleKey.Q);
        }

        private static void Speak()
        {
            var devid = new SpeechSynthesizer();
            var irina = new SpeechSynthesizer();
            irina.SelectVoice("Microsoft David Desktop");
            // irina.SelectVoice("Microsoft Zira");
            devid.SelectVoice("Microsoft David Desktop");

            devid.Speak("look after");
            irina.Speak("присматривать за");
            devid.Speak("split up");
            irina.Speak("разделить");
            devid.Speak("in common");
            irina.Speak("в общем");
            devid.Speak("in contract (with)");
            irina.Speak("в контракте");
            devid.Speak("in love (with)");
            irina.Speak("влюблена");
            devid.Speak("on purpose");
            irina.Speak("нарочно");
            devid.Speak("by yourself");
            irina.Speak("самостоятельно");
            devid.Speak("on your own");
            irina.Speak("самостоятельно");

            Console.ReadKey();
        }

        private static void CreateHtmlFromDictionary()
        {
            GetDictionary(out var options, out var dictionary);

            var body = new StringBuilder();
            body.Append("<h3><ignore>Unit 12</ignore></h3>");
            body.Append("<p style=\"font-size: larger;\">");
            foreach (var item in dictionary)
            {
                body.Append($"{item.Text}.</br>");
            }

            body.Append("</p>");
            var html = string.Format(HtmlTemplate.Template, "Unit 3", body);
            File.WriteAllText("D:\\tmp\\slovoSite\\dictionary\\unit_3.html", html);
        }

        private static void CreateDictionary()
        {
            var path = GetDictionary(out var options, out var dictionary);


            dictionary.Add(new Word{Text = "apologise", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb}});
            dictionary.Add(new Word{Text = "boyfriend", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "close", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "confident", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "cool", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "couple", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "decorate", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb}});
            dictionary.Add(new Word{Text = "defend", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb}});
            dictionary.Add(new Word{Text = "divorced", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "flat", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "generous", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "girlfriend", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "grateful", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "guest", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "independent", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "introduce", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "loving", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "loyal", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "mood", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "neighborhood", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "ordinary", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "patient", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "private", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "recognize", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb}});
            dictionary.Add(new Word{Text = "relation", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "rent", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb, PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "respect", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb, PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "single", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Adjective}});
            dictionary.Add(new Word{Text = "stranger", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Noun}});
            dictionary.Add(new Word{Text = "trust", Category = Category.Word, PartsOfSpeech = new [] {PartsOfSpeech.Verb, PartsOfSpeech.Noun}});

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

        private static string GetDictionary(out JsonSerializerOptions options, out Dictionary? dictionary)
        {
            var path = "D:\\repos\\victoria\\mindMaps\\dictionary_Unit12.json";
            options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };

            if (File.Exists(path))
            {
                var source = File.ReadAllText(path);


                dictionary = JsonSerializer.Deserialize<Dictionary>(source, options);
            }
            else
            {
                dictionary = new Dictionary();
            }

            return path;
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