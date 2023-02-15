using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomlyn;
using Tomlyn.Model;

namespace LuatOSPack
{
    /// <summary>
    /// 芯片支持包的基本信息
    /// </summary>
    public class Pack
    {
        /// <summary>
        /// 包名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 支持的系统架构
        /// </summary>
        public string Architecture { get; set; }
        /// <summary>
        /// 作者列表
        /// </summary>
        public string[] Authors { get; set; }
        /// <summary>
        /// 是否显示在支持的芯片列表中？
        /// </summary>
        public bool Show { get; set; }

        /// <summary>
        /// 从文件中加载一个Pack配置信息
        /// </summary>
        /// <param name="config_path">pack所在文件夹的路径</param>
        /// <returns></returns>
        public Pack(string config_path)
        {
            var text = File.ReadAllText(Path.Combine(config_path, "config.toml"));
            var option = new TomlModelOptions();
            var toml = Toml.ToModel(text);

            var packTable = (TomlTable)toml["pack"];
            Name = (string)packTable["name"];
            Version = (string)packTable["version"];
            Architecture = (string)packTable["architecture"];
            var authors = (TomlArray)packTable["authors"];
            Authors = (from author in authors select (string)author).ToArray();
            Show = (bool)packTable["show"];
        }
    }



}
