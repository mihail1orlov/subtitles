using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubtitlesApp;
using SubtitlesApp.Model;

namespace SubtitlesAppTests
{
    [TestClass]
    public class ParserTests
    {
        private Parser _target;

        [TestInitialize]
        public void Init()
        {
            _target = new Parser();
        }

        [TestMethod]
        public void ParseTest()
        {
            var items = new[]{ "11\r\n00:03:24,204 --> 00:03:27,834\r\n'The computer which controlled\r\nthe machines, Skynet," };

            var actual = _target.Parse(items)[0];

            var expected = new Subtitles
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
    }
}