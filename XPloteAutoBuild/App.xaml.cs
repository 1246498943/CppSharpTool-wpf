using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using XPlote.Expand;
using XPlote.Framework.WPF;

namespace XPloteAutoBuild
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
#if false
    public partial class App : XPloteApplication
    {

        public App() : base()
        {

        }
        protected override Window CreateMainWindow(StartupEventArgs e)
        {
            return new MainWindow();
        }
    } 

#else
    public partial class App : Application
    {
        /// <summary>
        /// 异常捕捉处理.
        /// </summary>
        public App() : base()
        {
            this.DispatcherUnhandledException += ApplicationUnErrorException;               //捕捉UI异常状态.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //当前应用程序异常状态.
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException; //严重的线程错误

        }

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            PrintLog(e.Exception.Message);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            PrintLog(e.ExceptionObject.ToString());
        }

        private void ApplicationUnErrorException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            PrintLog(e.Exception.Message);
            e.Handled = true;//终止信号传递.
        }
        private void PrintLog(string str)
        {
            XPlote.Expand.WindowLog.Default.Log(str);
        }
    }

#endif
}

