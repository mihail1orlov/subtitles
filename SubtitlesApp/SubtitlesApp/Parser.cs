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
        private const string TimeSpanFormat = @"hh\:mm\:ss\,fff";
        private const string Pattern = @"(\d+)(\r\n)(\d{2}:\d{2}:\d{2},\d{3})( --> )(\d{2}:\d{2}:\d{2},\d{3})";

        public Subtitles[] Parse(string[] items)
        {
            var subtitles = new List<Subtitles>();
            var regex = new Regex(Pattern);
            foreach (var item in items)
            {
                MatchCollection matches = regex.Matches(item);
                var match = matches.First();
                var number = match.Groups[1].Value;
                var startTime = match.Groups[3].Value;
                var endTime = match.Groups[5].Value;
                var content = item.Split("\r\n").Skip(2).ToArray();

                var subtitle = Parse(number, startTime, endTime, content);

                subtitles.Add(subtitle);
            }
            return subtitles.ToArray();
        }

        private static Subtitles Parse(string number, string startTime, string endTime, string[] content)
        {
            var subtitle = new Subtitles
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