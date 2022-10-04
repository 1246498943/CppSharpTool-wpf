using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPloteAutoBuild
{
    public class XPloteConfig
    {
        private static string CreatDir(string dir)
        {
            if(!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }
        public static string baseDir = $"{AppDomain.CurrentDomain.BaseDirectory}OutDir";
        public static string OutNet6Proj = CreatDir($"{baseDir}\\XPloteCsharpProjp");
        public static string OutNet6ProjExe = CreatDir($"{baseDir}\\XPloteCsharpProjpExe");
        public static string OutCsharpLib = CreatDir($"{baseDir}\\XPloteCsharpLib");
    }
}
