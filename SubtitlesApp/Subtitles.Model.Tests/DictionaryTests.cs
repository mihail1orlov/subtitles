using Xunit;

namespace Subtitles.Model.Tests
{
    public class DictionaryTests
    {
        private readonly Dictionary _target;

        public DictionaryTests()
        {
            _target = new Dictionary();
        }

        [Fact]
        public void Test()
        {
            // assert
            // action
            _target.Add(new Word
            {
                
            });
            // assert
        }
    }
}