using futuresyncDatabase.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace futuresyncDatabase.Tests.Controllers
{
    [TestClass]
    public class FutureSyncControllerTests
    {
        [TestMethod]
        public void Tracks()
        {
            var tracks = new FutureSyncController()
                .GetTracks();

            Assert.IsTrue(tracks.Any());
        }
    }
}
