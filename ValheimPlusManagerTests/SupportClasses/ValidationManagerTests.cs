using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValheimPlusManager.Data;
using ValheimPlusManager.Models;

namespace ValheimPlusManager.SupportClasses.Tests
{
    [TestClass()]
    public class ValidationManagerTests
    {
        [TestMethod()]
        public void CheckInstallationStatusTest()
        {
            // Fetching path settings
            Settings settings = SettingsDAL.GetSettings();
            Assert.IsNotNull(settings);

            Assert.IsTrue(ValidationManager.CheckInstallationStatus(settings.ClientInstallationPath));
            Assert.IsTrue(ValidationManager.CheckInstallationStatus(settings.ServerInstallationPath));
        }

        [TestMethod()]
        public void CheckClientInstallationPathTest()
        {
            // Fetching path settings
            Settings settings = SettingsDAL.GetSettings();
            Assert.IsNotNull(settings);

            Assert.IsTrue(ValidationManager.CheckClientInstallationPath(settings.ClientInstallationPath));
        }

        [TestMethod()]
        public void CheckServerInstallationPathTest()
        {
            // Fetching path settings
            Settings settings = SettingsDAL.GetSettings();
            Assert.IsNotNull(settings);

            Assert.IsTrue(ValidationManager.CheckServerInstallationPath(settings.ServerInstallationPath));
        }
    }
}