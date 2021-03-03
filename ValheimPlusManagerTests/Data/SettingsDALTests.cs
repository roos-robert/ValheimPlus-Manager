using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValheimPlusManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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