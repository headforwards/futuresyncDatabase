using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace futuresyncDatabase.Tests
{
    [TestClass]
    public class DataTransformationTests
    {
        private IEnumerable<dynamic> Speakers;

        [TestInitialize]
        public void Init()
        {
            var speakerArray = File.ReadAllText("sample.json");

            var json = $"{{speakers: {speakerArray}}}";

            var data = JObject.Parse(json) as dynamic;

            Speakers = data?.speakers as IEnumerable<dynamic>;
        }

        [TestMethod]
        public void Extract_Tracks()
        {
            var tracks = Speakers
                .Select(s => s.track)
                .Distinct();

            Assert.AreEqual(5, tracks.Count());
        }

        [TestMethod]
        public void Extract_Talks()
        {
            var talks = Speakers
                .Select(s => new { s.talk.title, s.talk.talkUrl })
                .Distinct();

            Assert.AreEqual(27, talks.Count());
        }
    }
}
