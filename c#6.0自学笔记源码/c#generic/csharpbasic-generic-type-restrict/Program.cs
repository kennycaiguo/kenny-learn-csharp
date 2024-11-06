using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpbasic_generic_type_restrict
{
    public class Employee
    {
        private string name;
        private int id;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public Employee(string n,int a)
        {
            name = n;
            id = a;
        }
        public override string ToString()
        {
            return $"name:{Name},id:{ID}";
        }
    }
    public class GenericList<T> where T: Employee//泛型类约束,表明泛型的测试只能够是Employee类型的对象
    {
        private class Node //泛型类的嵌套类也是泛型的
        {
            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            private T data;
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
            public Node(T t)
            {
                next = null;
                data = t;
            }
        }
        private Node head, body;
        public GenericList()
        {
            head = null;
        }
        public void AddHead(T t) //头插法,就是新节点会插入到链表的头部
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }
        public void AddTail(T t) //尾插法,需要一个辅助变量body,头是不能移动的,需要移动body
        {
            Node n = new Node(t);
            if (head == null) head = body = n;
            body.Next = n;
            body = n;

        }
        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    internal class Program
    {
        static void TestGenericList()
        {
            GenericList<Employee> list = new GenericList<Employee>();
            for (int i = 0; i < 10; i++)
            {

                list.AddHead(new Employee($"emp{i+1}",i));
            }
            foreach (var j in list)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("\nDone");
        }
        static void TestGenericListTail()
        {
            GenericList<Employee> list = new GenericList<Employee>();
            for (int i = 0; i < 10; i++)
            {
                list.AddTail(new Employee($"emp{i + 1}", i));
            }
            foreach (var j in list)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("\nDone");
        }
        static void Main(string[] args)
        {
            TestGenericList();
            //TestGenericListTail();
        }
    }
}
