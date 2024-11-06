using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpbasic
{
    internal class Program
    {
         static void arrTest()
        {
            int[] nums = { 1, 2, 3, 4, 5 };//这是一种简写,原来的写法是:int[] nums =new int[] { 1, 2, 3, 4, 5 };
            int len = nums.Length;//获取数组的长度
            int dimemsion = nums.Rank;//获取数组是维数
            int[] ints;
            ints = new int[]{10,20,30,40};//声明和赋值分开就不能够简写. 
            //创建多维数组需要在[]里面添加逗号,有n个逗号,说明是n+1维,如一个逗号就是2维
            int[,] ints2 = new int[3, 2] { {10,20 },{ 5,6},{7,8 }};//2维数组

        }
        static void arrTest2()
        {
            //交错数组,也叫做数组的数组
            int[][] arr= new int[2][];
            arr[0] = new int[7] {1,2,3,4,5,6,7};
            arr[1] = new int[] { 10, 29, 30 };
            foreach (var item in arr)
            {
                for(int i = 0;i < item.Length; i++)
                {
                    Console.Write("{0},", item[i]);
                }
                Console.WriteLine("\n");
            }

        }
        static void printArray(string[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write("{0} ", item);
            }
        }
        static string[] reverseArr(string[] arr)
        {
            return arr.Reverse().ToArray();
        }
        static void FillArrOut(out int[] arr)
        {
            arr = new int[] { 100, 200, 300 };//使用out的参数不需要先初始化,需要在函数里面初始化
        }


        static void testFillArrOut()
        {
            int[] ints;
            FillArrOut(out ints);
            foreach (var item in ints)
            {
                Console.Write("{0},", item);
            }
        }

        static void FillArrRef(ref int[] arr)
        {
            //arr = new int[] { 100, 200, 300 };
            arr[arr.Length-1] = 1000;
        }
        static void testFillArrRef()
        {
            int[] ints = {1,2,3};
            FillArrRef(ref ints);//使用ref的参数必须要先初始化,否则报错
            foreach (var item in ints)
            {
                Console.Write("{0},", item);
            }
        }
        static void Main(string[] args)
        {
            //arrTest();
            //arrTest2();
            //printArray(new string[] { "one", "two", "three" });
            // testArrAsParam();
            //testFillArrOut();
            testFillArrRef();
        }

        private static void testArrAsParam()
        {
            Console.WriteLine("Before Reverse\n");
            printArray(new string[] { "one", "two", "three" });
            Console.WriteLine("\n");
            string[] arr = reverseArr(new string[] { "one", "two", "three" });
            Console.WriteLine("After Reverse\n");
            printArray(arr);

        }
    }
}
