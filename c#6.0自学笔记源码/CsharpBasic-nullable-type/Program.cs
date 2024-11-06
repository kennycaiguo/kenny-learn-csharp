using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasic_nullable_type
{
    internal class Program
    {
        static void NullableTest()
        {
            int? num = null;
            //num = 100;
            if (num.HasValue)
            {
                Console.WriteLine($"the value is{num.Value} ");//有值输出这一句
            }
            else
            {
                Console.WriteLine("the value is null");//没有值输出这一句
            }
        }
        static void NullableTest2()
        {
            //int? a = null;
            int? a = 10;
            int b = a ?? -1;//表示如果a不为空,b就等于a的值,否则b等于-1
            Console.WriteLine($"b={b}");
        }
        static void Main(string[] args)
        {
           // NullableTest();
            NullableTest2();
        }
    }
}
