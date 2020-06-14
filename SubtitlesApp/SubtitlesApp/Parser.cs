using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using SubtitlesApp.Model;

namespace SubtitlesApp
{
    public class Parser
    {
        private const string TimeSpanFormat = @"hh\:mm\:ss\.fff";
        private const string Pattern = @"(\d+)(\n|\r\n)(\d{2}:\d{2}:\d{2}(.|,)\d{3})( --> )(\d{2}:\d{2}:\d{2}(.|,)\d{3})";

        public static Subtitle[] Parse(string[] items)
        {
            var subtitles = new List<Subtitle>();
            var regex = new Regex(Pattern);
            foreach (var item in items)
            {
                MatchCollection matches = regex.Matches(item);
                if (matches.Any())
                {
                    var match = matches.First();
                    var number = match.Groups[1].Value;
                    var startTime = match.Groups[3].Value.Replace(",", ".");
                    var endTime = match.Groups[6].Value.Replace(",", ".");
                    var content = item.Replace("\r\n", "\n").Split("\n").Skip(2).ToArray();

                    var subtitle = Parse(number, startTime, endTime, content);

                    subtitles.Add(subtitle);
                }
            }

            return subtitles.ToArray();
        }

        private static Subtitle Parse(string number, string startTime, string endTime, string[] content)
        {
            var subtitle = new Subtitle
            {
                Number = int.Parse(number),
                StartTime = TimeSpan.ParseExact(startTime, TimeSpanFormat, CultureInfo.InvariantCulture),
                EndTime = TimeSpan.ParseExact(endTime, TimeSpanFormat, CultureInfo.InvariantCulture),
                Content = content
            };

            return subtitle;
        }
    }
}