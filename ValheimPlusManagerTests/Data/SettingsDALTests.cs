using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValheimPlusManager.Data.Tests
{
    [TestClass()]
    public class SettingsDALTests
    {
        [TestMethod()]
        [Timeout(2000)]
        public void GetSettingsTest()
        {
            Assert.IsNotNull(SettingsDAL.GetSettings());
        }
    }
}