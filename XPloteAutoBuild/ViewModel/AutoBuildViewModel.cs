using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlote.Framework.WPF;
using XPlote.Expand;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CppSharp.Generators;
using CppSharp.Parser;

namespace XPloteAutoBuild
{
    /// <summary>
    /// 主要的操作,计算逻辑在这里.
    /// </summary>
    public class AutoBuildViewModel : XBindingBase
    {
#if true
        public AutoBuildViewModel(AutoBuildModel autoModel)
        {
            gAutoModel = autoModel;
            initSouce();
        }
        private AutoBuildModel gAutoModel { get; set; }

#else

    public AutoBuildViewModel()
        {
            initSouce();
        }
        private AutoBuildModel gAutoModel => IocHelper.gDefaultIoc.gModel;


#endif

        #region 操作命令封装.
        public ICommand ISelectedHeadFiles { get; set; }
        public ICommand IClearnHeadFiles { get; set; }
        public ICommand IClearnSelectedHeadFile { get; set; }

        public ICommand ISelectedLibFiles { get; set; }
        public ICommand IClearnLibFiles { get; set; }
        public ICommand IClearnSelectedLibFile { get; set; }

        public ICommand IBuildNet6Proj { get; set; }

        public ICommand IBuildCsharpLib { get; set; }

        #endregion

        private void initSouce()
        {
            initModelSource();
            ISelectedHeadFiles = new RelayCommand(() =>
            {

                GetError(() =>
                {

                    var files = XPlote.Expand.FileHelper.OpenFiles("*.h|*.h");
                    foreach (var item in files)
                    {
                        gAutoModel.gIncludeLists.Add(item);
                    }

                });

            });
            IClearnSelectedHeadFile = new RelayCommand(() =>
            {

                GetError(() =>
                {
                    var selectedFile = gAutoModel.gSelectedIncludeFile;
                    gAutoModel.gIncludeLists.Remove(selectedFile);
                });

            });
            IClearnHeadFiles = new RelayCommand(() =>
            {
                gAutoModel?.gIncludeLists.Clear();
            });

            ISelectedLibFiles     = new RelayCommand(() =>
            {

                GetError(() =>
                {

                    var files = XPlote.Expand.FileHelper.OpenFiles("*.lib|*.lib");
                    foreach (var item in files)
                    {
                        gAutoModel.gLibLists.Add(item);
                    }

                });

            });
            IClearnLibFiles   = new RelayCommand(() =>
            {

                GetError(() =>
                {
                    gAutoModel.gLibLists.Clear();

                });

            });
            IClearnSelectedLibFile= new RelayCommand(() =>
            {

                GetError(() =>
                {
                    var file = gAutoModel.gSelectedLibFile;
                    gAutoModel.gLibLists.Remove(file);

                });

            });

            IBuildNet6Proj  = new RelayCommand(()=> { 
            

            
            });
            IBuildCsharpLib = new RelayCommand(()=>{
            

            
            });


        }

        private void initModelSource()
        {
            //语言列表
            gAutoModel?.gLanguageLists.Clear();
            var languagelists = Enum.GetValues(typeof(LanguageVersion));
            foreach (var languagelist in languagelists)
            {
                gAutoModel?.gLanguageLists.Add(languagelist.ToString());
            }

            //cpp版本>
            gAutoModel?.gCppVersionLists.Clear();
            var cpplists = Enum.GetValues(typeof(GeneratorKind));
            foreach (var cppitem in cpplists)
            {
                gAutoModel?.gCppVersionLists.Add(cppitem.ToString());
            }
        }
        #region 辅助类.
        private void GetError(Action action)
        {
            XPlote.Expand.ActionHelper.GetErrorInfo(action);
        }


        private void PrintLog(string str)
        {
            XPlote.Expand.WindowLog.Default.Log(str);
        }
        #endregion

    }
}
