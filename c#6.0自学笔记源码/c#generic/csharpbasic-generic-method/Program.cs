using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpbasic_generic_method
{
    //泛型函数(方法)
    
    internal class Program
    {
        static void swap<T>(ref T a, ref T b)
        {
            T tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
        static void TestSwapInt()
        {
            int x = 100, y = 20;
            Console.WriteLine($"Before swap x={x},y={y}");
            swap(ref x, ref y);
            Console.WriteLine($"After swap x={x},y={y}");
        }
        static void TestSwapStr()
        {
            string str1 = "Word", str2 = "Hello";
            Console.WriteLine($"Before swap str1={str1},str2={str2}");
            swap(ref str1, ref str2);
            Console.WriteLine($"After swap str1={str1},str2={str2}");
        }
        static void Main(string[] args)
        {
            //TestSwapInt();
            TestSwapStr();
        }
    }
}
