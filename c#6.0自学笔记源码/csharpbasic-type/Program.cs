using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace csharpbasic_type
{
    public class Animal
    {
        public void Eat() { Console.WriteLine("Animal Eat food"); }
        public override string ToString()
        {
            return "This is An Instance of Animal";
        }
    }

    public class Mammal : Animal { }
    public class Cow : Mammal 
    {
        public new void Eat() { Console.WriteLine("Cow Eats Grass"); }
        public override string ToString() 
        {
            return "This is An Instance of Cow";
        }
    }


    internal class Program
    {
        static void TypeDemo1()
        {
            string intstr = "12345";
            int num;
            if (Int32.TryParse(intstr, out num))//这个方法比较安全可以转换返回true,不可以转换返回false.
            {
                Console.WriteLine("字符串\"12345\"转换为整数是:{0}",num);
            }
        }
        //装箱和拆箱
        static void TypeDemo2() 
        {
            int a = 10;
            Object b = a; //装箱
            Console.WriteLine(b);
            b = 200;
            a = (int)b;//拆箱
            Console.WriteLine(a);
        }
        static void TestDynamic()
        {
            dynamic d1 = 10;
            dynamic d2 = "hello";
            int i1 = d1;
            string s = d2;
            Console.WriteLine("d1==i1?:{0}",d1==i1); //true
            Console.WriteLine("d1是int吗?:{0}",d1 is Int32); //true
            Console.WriteLine("i1是dynamic吗?:{0}",i1 is dynamic); //true
        }
        static void TestAsIs()
        {
            Cow c = new Cow();
            if(c is Animal)
            {
                Animal a = (Animal)c;
                a.Eat();
                Console.WriteLine(a);
            }

            Mammal m = c as Mammal;
            if(m!=null)
            {
                Console.WriteLine("牛是哺乳动物");
            }
            else
            {
                Console.WriteLine("转换失败");
            }
            
        }
        static void Main(string[] args)
        {
            //TypeDemo1();
            //TypeDemo2();
            // TestDynamic();
            TestAsIs();
        }
    }
}
