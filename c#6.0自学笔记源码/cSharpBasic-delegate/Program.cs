using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate int ChangeNumber(int num1,int num2);//声明委托类型需要delegate关键字,只需要返回值,委托名称,参数即可
namespace cSharpBasic_delegate
{
    public delegate void Output(String str);
    public delegate void MyDelegate(int i, double j);
    internal class Program
    {
        public static void PrintInfo(string str)
        {
            Console.WriteLine(str);
        }

        public static void TestWithCallBack(int a,int b,Output cb)
        {
            cb($"The result is:{a + b}");
        }
        static int AddNum(int num1,int num2)
        {
            return num1 + num2;
        }
        static int MultiplyNum(int num1, int num2)
        {
            return num1 * num2;
        }

        static void Hello(string s)
        {
            System.Console.WriteLine("  Hello function is called");
            System.Console.WriteLine("  Hello, {0}!", s);
        }

        static void Goodbye(string s)
        {
            System.Console.WriteLine("  Goodbye function is called");
            System.Console.WriteLine("  Goodbye, {0}!", s);
        }

        static void TestDelegate()
        {
            int a = 5, b = 3;
            ChangeNumber method1 = new ChangeNumber(AddNum);
            ChangeNumber method2 = new ChangeNumber(MultiplyNum);
            Console.WriteLine("Add Result:{0}", method1(a, b));//8
            Console.WriteLine("Mul Result:{0}", method2(a, b));//15
        }

        public void MyMethod(int i,double j)
        {
            Console.WriteLine($"Inside Instance method,{i}*{j}={i * j}");
        }

        static void TwoAdd(int a, double b)
        {
            Console.WriteLine($"Inside static method,{a}+{b}={a+b}");
        }

        //多路委托,委托可以+ -
        static void TestMultiDeletegate()
        {
            Output op1, op2, MultiOp;
            op1 = Hello;
            op2 = Goodbye;
            MultiOp = null;
            MultiOp += op1;
            MultiOp += op2;
            MultiOp("Linda");
        }
        static void Main(string[] args)
        {
            //TestDelegate();
            //MyDelegate del = new Program().MyMethod;
            //del(3, 5);
            //MyDelegate del2 = Program.TwoAdd;
            //del2(100, 80.5);
            //TestWithCallBack(2, 3, PrintInfo);
            TestMultiDeletegate();
        }
    }
}
