//功能描述.
/*
设计一个c++ dll的导出接口.和c#交互的功能.

*/

1.生成
    public enum GeneratorKind
    {
        CLI = 1,
        CSharp = 2,
        C = 3,
        CPlusPlus = 4,
        ObjectiveC = 5,
        Java = 6,
        Swift = 7,
        QuickJS = 8,
        NAPI = 9,
        TypeScript = 10
    }
几种编码方式.

2.设置C++编译版本.
    public enum LanguageVersion
    {
        C99 = 0,
        C99_GNU = 1,
        CPP98 = 2,
        CPP98_GNU = 3,
        CPP11 = 4,
        CPP11_GNU = 5,
        CPP14 = 6,
        CPP14_GNU = 7,
        CPP17 = 8,
        CPP17_GNU = 9,
        CPP20 = 10,
        CPP20_GNU = 11
    }

3.输入:  库的名称.
4.输入:  命名空间.

5.输入:  1.设置头文件包含的目录. 2.添加头文件列表(只需要testB1.h 不带路径). 
         注意:该头文件引入的 .h文件,也要尽量包含在内(否则容易出错)
6:输入:  1.添加静态库路径. 2.添加静态库(testB1.lib 这样.不带路径)

7:注意目前这个程序:  一个api导出模块(包含include,lib这两块内容). 单独DLL导出.

8:设计一个标准c# Net6.0自动项目创建的模板(字符串 添加. 占位的方式...)

9:引入的库.XPlote.Themes 这套框架.

第一天:先实现UI程序界面.View模块(梳理逻辑)
第二天:实现ViewModel中的每个具体功能.
第三天:测试.

/*注意事项: 要做一个清空XPloteCsharpLib 文件夹下所有文件的操作*/

/*c++ 导出dll 设置的时候,尽量用 extern "C" 来包裹内容.*/
