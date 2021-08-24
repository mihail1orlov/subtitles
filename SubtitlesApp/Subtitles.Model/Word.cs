using Subtitles.Model.Enums;

namespace Subtitles.Model
{
    public class Word
    {
        public string Text { get; set; }
        public PartsOfSpeech[] PartsOfSpeech { get; set; }
        public Category Category { get; set; }
    }
}