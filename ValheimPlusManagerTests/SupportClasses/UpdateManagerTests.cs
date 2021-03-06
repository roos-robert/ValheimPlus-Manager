using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ValheimPlusManager.SupportClasses.Tests
{
    [TestClass()]
    public class UpdateManagerTests
    {
        [TestMethod()]
        [Timeout(5000)]
        public async Task CheckForValheimPlusUpdatesUpdateAvailable()
        {
            var updateAvailable = await UpdateManager.CheckForValheimPlusUpdatesAsync("0.8.5");

            Assert.IsTrue(updateAvailable.NewVersion);
        }

        [TestMethod()]
        [Timeout(5000)]
        public async Task CheckForValheimPlusUpdatesUpdateNotAvailable()
        {
            var updateAvailable = await UpdateManager.CheckForValheimPlusUpdatesAsync("987423.8.5");

            Assert.IsFalse(updateAvailable.NewVersion);
        }
    }
}