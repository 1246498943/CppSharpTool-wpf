using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlote.Framework.WPF;
using System.Collections.ObjectModel;
namespace XPloteAutoBuild
{
    public class AutoBuildModel:XBindingBase
    {

		public AutoBuildModel()
		{
			gIncludeLists = new ObservableCollection<string>();
			gLibLists = new ObservableCollection<string>();
			gCppVersionLists = new ObservableCollection<string>();
			gLanguageLists = new ObservableCollection<string>();

        }

        private string mLibName;
		public string gLibName
		{
			get => mLibName;
			set
			{
				if (mLibName != value)
				{
					mLibName = value;
					this.OnPropertyChanging();
				}
			}
		}


		private string mNamespaceName = "XPloteSharpNameSpace";
		public string gNamespaceName
		{
			get => mNamespaceName;
			set
			{
				if (mNamespaceName != value)
				{
					mNamespaceName = value;
					this.OnPropertyChanging();
				}
			}
		}

		/// <summary>
		/// 头文件列表,每个子模块都带有具体的路径.
		/// </summary>
		public ObservableCollection<string> gIncludeLists { get; set; }

		private string mSelectedIncludeFile;
		public string gSelectedIncludeFile
		{
			get => mSelectedIncludeFile;
			set
			{
				if (mSelectedIncludeFile != value)
				{
					mSelectedIncludeFile = value;
					this.OnPropertyChanging();
				}
			}
		}


		/// <summary>
		/// 库文件列表
		/// </summary>
		public ObservableCollection<string> gLibLists { get; set; }

		private string mSelectedLibFile;
		public string gSelectedLibFile
		{
			get => mSelectedLibFile;
			set
			{
				if (mSelectedLibFile != value)
				{
					mSelectedLibFile = value;
					this.OnPropertyChanging();
				}
			}
		}




		private string mSelectedVersion = "CPP11";
		
		/// <summary>
		/// 选择cpp语言版本.
		/// </summary>
		public string gSelectedVersion
		{
			get => mSelectedVersion;
			set
			{
				if (mSelectedVersion != value)
				{
					mSelectedVersion = value;
					this.OnPropertyChanging();
				}
			}
		}

		/// <summary>
		/// cpp语言版本.
		/// </summary>
		public ObservableCollection<string> gCppVersionLists { get; set; }



		/// <summary>
		/// 选择的语言版本.
		/// </summary>
		private string  mSelectedLanguage = "CSharp";
		public string gSelectedLanguage
        {
			get => mSelectedLanguage;
			set
			{
				if (mSelectedLanguage != value)
				{
					mSelectedLanguage = value;
					this.OnPropertyChanging();
				}
			}
		}

		/// <summary>
		/// 语言版本列表.
		/// </summary>
		public ObservableCollection<string> gLanguageLists { get; set; } 



		private string mOutNet6PropDir = XPloteConfig.OutNet6Proj;
		/// <summary>
		/// 自动创建的.Net6项目所在的文件夹以及路径.
		/// </summary>
		public string gOutNet6PropDir
        {
			get => mOutNet6PropDir;
			set
			{
				if (mOutNet6PropDir != value)
				{
					mOutNet6PropDir = value;
					this.OnPropertyChanging();
				}
			}
		}


		/// <summary>
		/// 自动转换的cSharpLib等文件所在的目录.
		/// </summary>
		private string mOutCsharpLibPath = XPloteConfig.OutCsharpLib;
		public string gOutCsharpLibPath
        {
			get => mOutCsharpLibPath;
			set
			{
				if (mOutCsharpLibPath != value)
				{
					mOutCsharpLibPath = value;
					this.OnPropertyChanging();
				}
			}
		}



	}
}
