using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basic_generic_interface
{
    public interface IOutputable<T> //泛型接口
    {
        void output(T t);
    }
    class MyOutput<T> : IOutputable<T>//这个泛型类实现泛型接口
    {
        public void output(T t)
        {
            Console.WriteLine(t);
        }
    }
    public class Person : IComparable
    {
        string name;
        int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Person(string s, int i)
        {
            name = s;
            age = i;
        }

        // This will cause list elements to be sorted on age values.
       
        public override string ToString()
        {
            return name + ":" + age;
        }

        // Must implement Equals.
        public bool Equals(Person p)
        {
            return (this.age == p.age && this.name == p.name);
        }

        public int CompareTo(object obj)
        {
            Person p = (Person)obj;
            return this.age - p.age;
        }
    }

    public class Book : IComparable
    {
        private int id;
        private string title;
        public Book()
        {

        }
        public Book(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int CompareTo(object obj)
        {
            Book book = (Book)obj;
            return this.ID.CompareTo(book.ID);
        }
    }

    public class SortHelper<T> where T : IComparable
    {
        public void BubbleSort(T[] array)
        {
            int length = array.Length;
            for (int i = 0; i <= length - 2; i++)
            {
                for (int j = length - 1; j >= 1; j--)
                {
                    //如果前面的元素较大，交换相邻两个元素
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;

                    }
                }
            }
        }
    }
    

    internal class Program
    {
        
        static void TestInfterface()
        {
            SortHelper<string> sortHper = new SortHelper<string>();
            string[] arr = new string[3] { "A", "c", "b" };
            sortHper.BubbleSort(arr);
            foreach (string s in arr)
            {
                Console.WriteLine(s);
            }
            Console.Read();

        }

        static void TestInfterface2()
        {
            Book[] bookArr = new Book[2];

            Book book1 = new Book(2, "语文");
            Book book2 = new Book(1, "数学");

            bookArr[0] = book1;
            bookArr[1] = book2;

            SortHelper<Book> Sort = new SortHelper<Book>();

            Sort.BubbleSort(bookArr);
            foreach (Book b in bookArr)
            {
                Console.WriteLine("ID={0},Title={1}", b.ID, b.Title);
            }
            Console.Read();

        }
        static void TestInfterface3()
        {
            Person[] persons = { new Person("Jack", 20), new Person("Mary", 19), new Person("Linda", 21) };
            SortHelper<Person> helper = new SortHelper<Person>();
            helper.BubbleSort(persons);
            foreach (Person p in persons)
            {
                Console.WriteLine("Name:{0},Age:{1}",p.Name,p.Age);
            }
            Console.Read();
        }
        static void TestMyOutput()
        {
            Person[] persons = { new Person("Jack", 20), new Person("Mary", 19), new Person("Linda", 21) };
            MyOutput<Person> output = new MyOutput<Person>();
            foreach (var item in persons)
            {
                output.output(item);
            }
        }
        static void Main(string[] args)
        {
            //TestInfterface();
            //TestInfterface2();
            //TestInfterface3();
            TestMyOutput();
        }
    }
}
