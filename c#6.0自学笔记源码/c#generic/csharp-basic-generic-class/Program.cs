using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basic_generic_class
{
    public class MyStack<T> //自己实现一个模拟栈的类
    {
        private T[] _stack;
        private int _size;
        private int _stackPoint;
        public MyStack(int size)
       {
            _stack = new T[size];
            _size = size;
            _stackPoint = 0;
       }
        public void Push(T t)
        {
            if(_stackPoint ==_size)
            {
                Console.WriteLine("栈已经满了,不能添加新数据");
            }
            else
            {
                _stack[_stackPoint] = t;
                _stackPoint++;
            }
           
        }
        public void show()
        {
            for(int i=_size-1;i>=0;i--)//栈需要后进先出
            {
                Console.WriteLine(_stack[i]);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyStack<int> nums = new MyStack<int>(3);
            //for(int i=0; i<4;i++)//这里设置越界.最后一个无法添加
            //{
            //    nums.Push(i);
            //}
            //nums.show();
            MyStack<string> names = new MyStack<string>(3);
            for (int i = 0; i < 3; i++)
            {
                names.Push($"names{i}");
            }
            names.show();
        }
    }
}
