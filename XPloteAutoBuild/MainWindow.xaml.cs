using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XPloteAutoBuild
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            autoVM = IocHelper.gDefaultIoc.gViewModel;
            autoM= IocHelper.gDefaultIoc.gModel;
            XPlote.Expand.WindowLog.Default.BindLogCommon((str) => {

                this.Dispatcher.BeginInvoke(() => {
                    LogText.Text = str;
                });
            
            });
            this.DataContext = this;
        }

        public AutoBuildViewModel autoVM { get; set; }
        public AutoBuildModel autoM { get; set; }
    }
}
