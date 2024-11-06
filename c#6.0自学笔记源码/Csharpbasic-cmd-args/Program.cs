using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpbasic_cmd_args
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length == 0) 
            //{
            //    Console.WriteLine("这个程序需要命令行参数");
            //}
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
}
