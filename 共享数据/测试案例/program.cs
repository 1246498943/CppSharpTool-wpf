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

            ///����float double bool �ṹ�� �� �ַ���  �ص�. ����, ָ��.
            TestB1 tba = new TestB1();
            tba.Num = "hellow c++";
            Console.WriteLine(tba.Num);
            Console.WriteLine(tba.getSum(200,200));

            Console.WriteLine(StandardLib.Sum(20,30));
            Console.WriteLine(StandardLib.Sum2((a2, a3) => { 
            
            return 10+a2+ a3;   
            },20, 30));

            StandardLib.print_text("print english .....");//����ʹ�� w_string ����.

            Console.WriteLine("�������..");
            Console.Read();
        }
    }
}