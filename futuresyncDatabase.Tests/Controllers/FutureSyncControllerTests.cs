using futuresyncDatabase.Controllers;
using futuresyncDatabase.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.IO;
using System.Linq;

namespace futuresyncDatabase.Tests.Controllers
{
    [TestClass]
    public class FutureSyncControllerTests
    {
        private IWebClientProvider webClientProvider;
        private IWebClient webClient;
        private FutureSyncController futureSyncController;

        [TestInitialize]
        public void Init()
        {
            webClient = Substitute.For<IWebClient>();
            webClientProvider = Substitute.For<IWebClientProvider>();
            webClient.DownloadString(Arg.Any<string>()).Returns(File.ReadAllText("sample.json"));
            webClientProvider.WebClient().Returns(webClient);
            futureSyncController = new FutureSyncController(webClientProvider);
        }

        [TestMethod]
        public void Tracks()
        {
            var tracks = futureSyncController
                .GetTracks();

            Assert.IsTrue(tracks.Any());
            Assert.IsTrue(tracks.Contains("software development"));
        }

        [TestMethod]
        public void Speakers()
        {
            var speakers = futureSyncController
                .GetSpeakers();

            Assert.IsTrue(speakers.Any(s=>s.Name == "Paul Donovan"));
        }
    }
}
