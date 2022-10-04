using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPloteSharpNameSpace;
namespace program
{
    public class program
    {
        public static void Main()
        {

            ///测试float double bool 结构体 类 字符串  回调. 引用, 指针.
            TestB1 tba = new TestB1();
            tba.Num = "hellow c++";
            Console.WriteLine(tba.Num);
            Console.WriteLine(tba.getSum(200,200));

            Console.WriteLine(StandardLib.Sum(20,30));
            Console.WriteLine(StandardLib.Sum2((a2, a3) => { 
            
            return 10+a2+ a3;   
            },20, 30));

            StandardLib.print_text("print english .....");//中文使用 w_string 类型.

            Console.WriteLine("测试完成..");
            Console.Read();
        }
    }
}