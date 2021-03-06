using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ValheimPlusManager.SupportClasses.Tests
{
    [TestClass()]
    public class FileManagerTests
    {
        [TestMethod()]
        public void CopyFromToServerBackupTest()
        {
            bool success = FileManager.CopyFromTo(String.Format("C:/Users/{0}/AppData/LocalLow/IronGate", Environment.UserName), String.Format("C:/ValheimServerBackups/{0}", DateTime.Now.ToString("yyyy-MM-dd-HHmm")));

            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void CopyFromToGameBackupTest()
        {
            bool success = FileManager.CopyFromTo(String.Format("C:/Users/{0}/AppData/LocalLow/IronGate", Environment.UserName), String.Format("C:/ValheimGameBackups/{0}", DateTime.Now.ToString("yyyy-MM-dd-HHmm")));

            Assert.IsTrue(success);
        }
    }
}