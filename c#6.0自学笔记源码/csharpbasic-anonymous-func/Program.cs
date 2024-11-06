using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharpbasic_anonymous_func
{
    internal class Program
    {
        public delegate void MyDele(string s);
        static void PrintStr(string s)
        {
            Console.WriteLine(s);
        }

        static void TestDelegate1() //最古老的使用delegate的方法
        {
            MyDele fun = new MyDele(PrintStr);
            fun("Hello,Old Fashion Delegate!!!");
        }
        
        static void TestDelegate2() ////笔记老的使用delegate的方法
        {
            MyDele dele = delegate (string s) { Console.WriteLine(s); };
            dele("Newer Method of delegate");
        }
        
        static void TestDelegate3()//最新使用delegate的方法,直接传递一个lambda表达式
        {
            MyDele dele = (string s) => { Console.WriteLine(s); };
            dele("Hello ,Lambda delegate");
        }
        static void Main(string[] args)
        {
            //TestDelegate1();
            //TestDelegate2();
            TestDelegate3();
        }
    }
}
