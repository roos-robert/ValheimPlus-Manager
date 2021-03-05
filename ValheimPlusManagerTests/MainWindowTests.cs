using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValheimPlusManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusManager.Models;

namespace ValheimPlusManager.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void MainWindowTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Settings()
        {
            var settingsModel = new Settings()
            {
                ClientInstallationPath = "C:/Program Files (x86)/Steam/steamapps/common/Valheim/",
                ServerInstallationPath = "C:/Program Files (x86)/Steam/steamapps/common/Valheim dedicated server/",
                ClientPath = "Data/ValheimPlusGameClient/Extracted",
                ServerPath = "Data/ValheimPlusServerClient/Extracted",
                ValheimPlusGameClientVersion = "0.9.0",
                ValheimPlusServerClientVersion = "0.9.0",
            };

            Assert.IsNotNull(settingsModel.ClientInstallationPath);
            Assert.IsNotNull(settingsModel.ServerInstallationPath);
            Assert.IsNotNull(settingsModel.ClientPath);
            Assert.IsNotNull(settingsModel.ServerPath);
            Assert.IsNotNull(settingsModel.ValheimPlusGameClientVersion);
            Assert.IsNotNull(settingsModel.ValheimPlusServerClientVersion);
        }
    }
}