namespace XPloteAutoBuild
{
    /// <summary>
    /// 封装全局唯一Ioc容器.通过该帮助类,进行服务的提取...
    /// </summary>
    public static class IocHelper
    {

        private static AutoBuildIoc mDefault = null;
        public static AutoBuildIoc gDefaultIoc
        {
            get
            {
                if (mDefault==null)
                {
                    mDefault= new AutoBuildIoc();
                }
                return mDefault;
            }

        }
    }

}
