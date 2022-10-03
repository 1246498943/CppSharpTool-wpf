using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlote.Framework.WPF;
using XPlote.Expand;
using Autofac;
using System.Runtime.CompilerServices;

namespace XPloteAutoBuild
{
    /// <summary>
    /// 放置IOC容器接口
    /// </summary>
    public class AutoBuildIoc:IocBase
    {

        public AutoBuildIoc()
        {

        }

        protected override void InitServersConfig()
        {
            base.InitServersConfig();
            //添加并注册两个模块.
            this.gServerceBuilder.RegisterType<AutoBuildModel>().As<AutoBuildModel>().InstancePerLifetimeScope();
            this.gServerceBuilder.RegisterType<AutoBuildViewModel>().As<AutoBuildViewModel>().InstancePerLifetimeScope();

        }


        public AutoBuildModel gModel => this.GetServer<AutoBuildModel>();
        public AutoBuildViewModel gViewModel => this.GetServer<AutoBuildViewModel>();
    }

}
