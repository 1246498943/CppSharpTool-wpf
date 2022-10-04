namespace XPloteAutoBuild
{
    public class CppSharpBuild
    {
        public static void Build()
        {
            var autoModle = IocHelper.gDefaultIoc.gModel;
            CppSharp.ConsoleDriver.Run(new CppSharpLibHelper(autoModle));

        }

    }


}
