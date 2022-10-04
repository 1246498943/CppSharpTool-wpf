using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace XPloteAutoBuild
{
    /// <summary>
    /// 实现思路:
    /// 1.NetProj6.0 项目配置模板.
    /// 2.路径...(先暂时不要设置.只需要将 dirlib内的三个文件自动拷贝到 proj所在目录.)
    /// </summary>
    public class AutoBuildNet6ProjHelper
    {
        public AutoBuildNet6ProjHelper(AutoBuildModel mModel)
        {
            model = mModel;
            string libName = model.gLibName;
            if (libName==null || libName.Length<1) libName = "XPloteLib";
            XCppSharpProjLib = $"{libName}_Lib.csproj";
            XCppSharpProjExe = $"{libName}_Exe.csproj";
        }
        private  AutoBuildModel model { get; set; }
        public  string XCppSharpProjLib;
        public string XCppSharpProjExe;

        //该模板生成Library库.
        public  string Net60ProjTemplate =
            "<Project Sdk=\"Microsoft.NET.Sdk\">\r\n"+
            " <PropertyGroup>\r\n   " +
            " <TargetFramework>net6.0</TargetFramework>\r\n   " +
            "<AllowUnsafeBlocks>True</AllowUnsafeBlocks>\r\n  " +
            " <OutputType>Library</OutputType>" +
            "</PropertyGroup>\r\n " +
            " <ItemGroup>\r\n    " +
            "<PackageReference Include=\"CppSharp.Runtime\" Version=\"1.0.3\" />\r\n  " +
            "</ItemGroup> \r\n"+
            "</Project> \r\n";

        public string Net60ProjTemplateExe =
          "<Project Sdk=\"Microsoft.NET.Sdk\">\r\n"+
          " <PropertyGroup>\r\n   " +
          " <TargetFramework>net6.0</TargetFramework>\r\n   " +
          "<AllowUnsafeBlocks>True</AllowUnsafeBlocks>\r\n  " +
          " <OutputType>Exe</OutputType>" +
          "</PropertyGroup>\r\n " +
          " <ItemGroup>\r\n    " +
          "<PackageReference Include=\"CppSharp.Runtime\" Version=\"1.0.3\" />\r\n  " +
          "</ItemGroup> \r\n"+
          "</Project> \r\n";

        public string NetProgramMain = "" +
            "using System;\r\n" +
            "using System.Collections.Generic;\r\n" +
            "using System.Linq;\r\n" +
            "using System.Text;\r\n" +
            "using System.Threading.Tasks;\r\n" +
            "namespace program\r\n" +
            "{\r\n     " +
            "public class program\r\n   " +
            " {\r\n    " +
            " public static void Main()\r\n       " +
            " {\r\n           " +
            " Console.Read();\r\n       " +
            " }\r\n   " +
            " }\r\n" +
            "}";


        /// <summary>
        /// 生成库文件
        /// </summary>
        public  void BuildNet6ProjLib()
        {
            //删除 gOutNet6PropDir 文件夹下所有文件的操作.
            var dir = model.gOutNet6PropDir;
            if (System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.Delete(dir,true);
                Thread.Sleep(100);
                System.IO.Directory.CreateDirectory(dir);
            }
           var filePath = $"{model.gOutNet6PropDir}\\{XCppSharpProjLib}";
            BuildProjctFile(filePath, Net60ProjTemplate);
            Task.Run(() => {

                Thread.Sleep(10);
                CopyFileAndDir(model.gOutCsharpLibPath, model.gOutNet6PropDir);
            });
        }

        /// <summary>
        /// 生成exe测试项目.
        /// </summary>
        public void BuildNet6ProjExe()
        {
            var filePath = $"{XPloteConfig.OutNet6ProjExe}\\{XCppSharpProjExe}";
            BuildProjctFile(filePath, Net60ProjTemplateExe);
            var mainfile = $"{XPloteConfig.OutNet6ProjExe}\\program.cs";
            BuildProjctFile(mainfile, NetProgramMain);
            Task.Run(() => {

                Thread.Sleep(10);
                CopyFileAndDir(model.gOutCsharpLibPath, XPloteConfig.OutNet6ProjExe);
            });
        }

        /// <summary>
        /// 例子  fileName = $"Csharp{model.gLibName}.csproj";
        ///  content = Net60ProjTemplate.项目配置内容.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        public void BuildProjctFile(string fileName,string content)
        {
            var filePath = fileName;
            var fileStream = File.Create(filePath);
            TextWriter writer = new StreamWriter(fileStream);
            {
                writer.Write(content);
            }
            writer.Close();
            fileStream.Close();
        }
 
        /// <summary>
        /// 复制文件夹下的所有文件、目录到指定的文件夹
        /// </summary>
        /// <param name="dir">源文件夹地址</param>
        /// <param name="desDir">指定的文件夹地址</param>
        public static void CopyFileAndDir(string dir, string desDir)
        {
            if (!System.IO.Directory.Exists(desDir))
            {
                System.IO.Directory.CreateDirectory(desDir);
            }
            IEnumerable<string> files = System.IO.Directory.EnumerateFileSystemEntries(dir);
            if (files != null && files.Count() > 0)
            {
                foreach (var item in files)
                {
                    string desPath = System.IO.Path.Combine(desDir, System.IO.Path.GetFileName(item));

                    //如果是文件
                    var fileExist = System.IO.File.Exists(item);
                    if (fileExist)
                    {
                        //复制文件到指定目录下                     
                        System.IO.File.Copy(item, desPath, true);
                        continue;
                    }

                    //如果是文件夹                   
                    CopyFileAndDir(item, desPath);

                }
            }
        }

    }
}
