using LuatOSPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuatOS_Downloader_Test
{
    [TestClass]
    public class PackTest
    {
        [TestMethod]
        public void LoadConfigToml()
        {
            var pack = new Pack(Variables.PackPath);
            Assert.AreEqual(pack.Name, "test");
            Assert.AreEqual(pack.Version, "0.0.0");
            Assert.AreEqual(pack.Show, true);
            Assert.AreEqual(pack.Architecture, "win_x64");
            Assert.AreEqual(pack.Authors[0], "chenxuuu");
        }
    }
}
