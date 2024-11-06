using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpBasic_class_and_struct
{
    class Human
    {
        private int age; //私有字段,字段名称必须全部小写
        public string Name { get; set; }

        public int Age //属性就是同名字段把首字母大写
        {
            get { return age; }
            set
            {
                if (value >= 1 && value <= 120) //人的年龄一般在1-110之间
                {
                    age = value;
                }
                else
                {
                    MessageBox.Show("人的年龄必须在1-120之间");
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public string Gender { get; set; }
        public Human() { }
        public Human(string n, int a, string g)
        {
            Name = n;
            Age = a;
            Gender = g;
        }
    }
    public struct Person
    {
        public string Name;//结构体属性的写法和类属性的写法不太一样
        public int Age;
        public string Gender;
        public Person(string n, int a, string g)
        {
            Name = n;
            Age = a;
            Gender = g;
        }
     
    }

    class Boy
    {
        // Auto-implemented properties.
        public int Age { get; set; }
        public string Name { get; set; }
    }
    
    internal class Program
    { 
        static void TestHuman()
        {
            Human human1 = new Human("Jack",20,"male");
            Human human2 = human1;
            Console.WriteLine("Before change\n");
            PrintHumen(human1);
            PrintHumen(human2);
            human2.Name = "Tracy";
            human2.Gender = "female";
            Console.WriteLine("After change\n");
            PrintHumen(human1);
            PrintHumen(human2);//类是引用类型,如果2个变量指向同一个对象,在一个变量中修改内存值会在另外一个变量上体现出来
        }

        static void TestHuman2()
        {
            Human human1 = new Human();
            human1.Name = "Stuward";
            human1.Age = 90;
            human1.Gender = "male";
            PrintHumen(human1);
        }

        private static void PrintHumen(Human human)
        {
            Console.WriteLine("Human(name:{0},age:{1},gender:{2})\n",human.Name,human.Age,human.Gender);
        }
        private static void PrintPerson(Person human)
        {
            Console.WriteLine("Human(name:{0},age:{1},gender:{2})\n", human.Name, human.Age, human.Gender);
        }

        static void TestPerson()
        {
            Person p1 = new Person("Linda", 18, "female");
            Person p2 = p1;//p2 是p1的副本.
            Console.WriteLine("Before change\n");
            PrintPerson(p1);
            PrintPerson(p2);
            p2.Name = "Jack";
            p2.Gender = "male";
            Console.WriteLine("After change\n");
            PrintPerson(p1);
            PrintPerson(p2);//结构体是值类型,改变副本的值不影响原来的值
        }

        static void ChangeHumanAge(Human h)
        {
            h.Age = 25;
        }
        static void TestHuman3()
        {
            Human human1 = new Human("Jack", 20, "male");
            Console.WriteLine("Before function call,Age:{0}\n", human1.Age);//20
            ChangeHumanAge(human1);//由于C#中类是引用类型,所以在函数里面的修改也会响应到外面的值
            Console.WriteLine("Before function call,Age:{0}\n", human1.Age);//25
        }

        static void TestBoy()
        {
            //Boy boy = new Boy { Age = 11, Name = "Oscar chang" };//初始值设定项
            //Console.WriteLine($"Boy(Name:{boy.Name},Age:{boy.Age})");
            var b = new { Age = 15, Name = "Oscar zhihua" };//初始值设定项
            Console.WriteLine($"Object(Name:{b.Name},Age:{b.Age})");
        }
        static void Main(string[] args)
        {
            TestBoy();
            //TestHuman();
            //TestHuman2();
            //TestHuman3();
            //TestPerson();
        }
    }
}
