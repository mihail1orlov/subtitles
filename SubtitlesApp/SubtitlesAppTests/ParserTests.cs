using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubtitlesApp;
using SubtitlesApp.Model;

namespace SubtitlesAppTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
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

            Assert.AreEqual(expected.StartTime, actual.StartTime);
            Assert.AreEqual(expected.EndTime, actual.EndTime);
            Assert.AreEqual(expected.Number, actual.Number);
            CollectionAssert.AreEqual(expected.Content, actual.Content);
        }

        [TestMethod]
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

            Assert.AreEqual(expected.StartTime, actual.StartTime);
            Assert.AreEqual(expected.EndTime, actual.EndTime);
            Assert.AreEqual(expected.Number, actual.Number);
            CollectionAssert.AreEqual(expected.Content, actual.Content);
        }
    }
}