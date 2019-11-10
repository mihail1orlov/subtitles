using System;

namespace SubtitlesApp.Model
{
    public class Subtitle
    {
        public int Number { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string[] Content { get; set; }
    }
}