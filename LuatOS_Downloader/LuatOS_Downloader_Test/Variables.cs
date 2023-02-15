using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuatOS_Downloader_Test
{
    public class Variables
    {
        /// <summary>
        /// sln文件所在的目录路径
        /// </summary>
        public static string RootPath = "../../../../";

        public static string PackPath = $"{RootPath}../test-win_x64/";

    }

    [TestClass]
    public class VariablesTest
    {
        [TestMethod]
        public void CheckPathCurrect()
        {
            var existence = File.Exists(Variables.RootPath + "LuatOS_Downloader.sln");
            Assert.IsTrue(existence);
        }
        [TestMethod]
        public void CheckPackExist()
        {
            var existence = File.Exists(Variables.PackPath + "config.toml");
            Assert.IsTrue(existence);
        }
    }
}
