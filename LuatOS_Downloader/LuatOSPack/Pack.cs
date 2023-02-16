using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        /// 依赖的包
        /// </summary>
        public Dictionary<string,string> Dependencies { get; set; }

        /// <summary>
        /// 包功能重定向
        /// </summary>
        public PackRedirect Redirect { get; set; } = new PackRedirect();
        public Dictionary<string, string> RedirectString { get; set; }

        /// <summary>
        /// 命令行参数
        /// </summary>
        public Dictionary<string, string> CmdArgs { get; set; }

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

            //基本信息
            var packTable = (TomlTable)toml["pack"];
            Name = (string)packTable["name"];
            Version = (string)packTable["version"];
            Architecture = (string)packTable["architecture"];
            var authors = (TomlArray)packTable["authors"];
            Authors = (from author in authors select (string)author).ToArray();
            Show = (bool)packTable["show"];

            //依赖
            var dependencies = (TomlTable)toml["dependencies"];
            Dependencies = new Dictionary<string, string>();
            foreach (var d in dependencies)
                Dependencies.Add(d.Key, (string)d.Value);

            //功能重定向
            var redirect = (TomlTable)toml["redirect"];
            RedirectString = new Dictionary<string, string>();
            foreach (var d in redirect)
                RedirectString.Add(d.Key, (string)d.Value);

            //命令行参数
            var cmd_args = (TomlTable)toml["cmd_args"];
            CmdArgs = new Dictionary<string, string>();
            foreach (var d in cmd_args)
                CmdArgs.Add(d.Key, (string)d.Value);
        }
    }

    public class PackRedirect
    {
        public Pack? logger { get; set; }
        public Pack? downloader { get; set; }
        public Pack? firmware_maker { get; set; }
        public Pack? firmware { get; set; }
        public Pack? driver { get; set; }
    }

}
