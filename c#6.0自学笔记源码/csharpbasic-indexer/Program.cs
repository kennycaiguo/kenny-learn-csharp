using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpbasic_indexer
{
    public class MyCollection<T>
    {
        private T[] arr = new T[100];
        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }

    }      
    internal class Program
    {
        static void TestIndexer()
        {
            MyCollection<string> strs = new MyCollection<string>();
            for(int i=0;i<5;i++)
            {
                strs[i] = $"String Value{i + 1}";
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(strs[i]);
            }
        }
        static void Main(string[] args)
        {
            TestIndexer();
        }
    }
}
