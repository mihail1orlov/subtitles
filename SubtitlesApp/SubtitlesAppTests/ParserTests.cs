using System;
using SubtitlesApp;
using SubtitlesApp.Model;
using Xunit;

namespace SubtitlesAppTests
{
    public class ParserTests
    {
        [Fact]
        public void ParseTest()
        {
            var items = new[]{ "11\r\n00:03:24,204 --> 00:03:27,834\r\n'The computer which controlled\r\nthe machines, Skynet," };

            var actual = Parser.Parse(items)[0];

            var expected = new Subtitle
            {
                Number = 11,
                StartTime = new TimeSpan(0, 0, 3, 24, 204),
                EndTime = new TimeSpan(0, 0, 3, 27, 834),
                Content = new[]
                {
                    "'The computer which controlled",
                    "the machines, Skynet,"
                }
            };

            Assert.Equal(expected.StartTime, actual.StartTime);
            Assert.Equal(expected.EndTime, actual.EndTime);
            Assert.Equal(expected.Number, actual.Number);
            Assert.Equal(expected.Content, actual.Content);
        }

        [Fact]
        public void ParseVvtTest()
        {
            var items = new[]{ "9\n11:22:33.444 --> 21:31:41.511\nReact is a JavaScript library for building fast and interactive\nuser interfaces. It was developed at Facebook in 2011," };

            var actual = Parser.Parse(items)[0];

            var expected = new Subtitle
            {
                Number = 9,
                StartTime = new TimeSpan(0,11, 22, 33, 444),
                EndTime = new TimeSpan(0, 21, 31, 41, 511),
                Content = new[]
                {
                    "React is a JavaScript library for building fast and interactive",
                    "user interfaces. It was developed at Facebook in 2011,"
                }
            };

            Assert.Equal(expected.StartTime, actual.StartTime);
            Assert.Equal(expected.EndTime, actual.EndTime);
            Assert.Equal(expected.Number, actual.Number);
            Assert.Equal(expected.Content, actual.Content);
        }
    }
}