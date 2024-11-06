using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace csharpbasic_string
{
    internal class Program
    {
        static void StringTest1(string s) //反向输出字符串
        {
            for (int i = s.Length-1; i >=0; i--)
            {
                Console.Write(s[i]); 
            }
            
            Console.WriteLine();
        }
        static void StringTest2(string s) //大小写互换
        {
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i++)
            {
                if (Char.IsLower(sb[i]) == true)
                {
                    sb[i] = Char.ToUpper(sb[i]);
                }
                else if (Char.IsUpper(sb[i]) == true)
                {
                    sb[i] = Char.ToLower(sb[i]);
                }
            }
            Console.WriteLine(sb.ToString());
        }
        static void StringTest3()
        {
            string str = "Visual c# Programming";
            Console.WriteLine(str.Substring(7,2));//c#
            Console.WriteLine(str.Replace("c#","c++")); //Visual c++ Programming
            Console.WriteLine(str.IndexOf('c')); //7
        }
        static void NullStringTest() //null字符串是没有长度属性的,空字符串有长度属性,空字符串长度为0
        {
            string s1 = "Hello Girls";
            string nullstr = null; //null字符串和空字符串是不一样的,它变量使用字符串的方法,单是可以和字符串相加
            string emptystr = string.Empty; //空字符串仍然是游戏字符串,可以使用字符串的使用方法.

            var str = s1 + nullstr;
            Console.WriteLine(str); //Hello Girls
            Console.WriteLine($"null字符串等于空字符串吗:{nullstr == emptystr}"); //null字符串等于空字符串吗:False
        }

        static void ModifyStrings() //直接使用string.Replace方法不就完了吗?
        {
            string str = "The crazy brown fox jump over the fence";
            char[] chars = str.ToCharArray();
            int index = str.IndexOf("fox");
            if(index != -1)
            {
                chars[index++] = 'c';
                chars[index++] = 'a';
                chars[index] = 't';
            }
            Console.WriteLine(new string(chars)); //The crazy brown cat jump over the fence
        }
        unsafe static void CharPointerTest()
        {
            // Compiler will store (intern) 
            // these strings in same location.
            string s1 = "Hello";
            string s2 = "Hello";

            // Change one string using unsafe code.
            fixed (char* p = s1) //c#也能够使用指针,不过系统是不推荐的,必须标记为不安全,而且需要设置项目允许允许不安全代码才行
            {
                p[0] = 'C';
            }

            //  Both strings have changed.
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static void StringCmpdemo(string s1,string s2)
        {
            //bool isEqual = s1.Equals(s2,StringComparison.Ordinal);
            //Console.WriteLine("string1和string2{0}",isEqual? "相等.": "不相等"); //string1和string2不相等
            bool isEqual = s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine("string1和string2{0}", isEqual ? "相等." : "不相等");//string1和string2相等.
        }

        static void TestStringCmpdemo()
        {
            string s1 = "Hello";
            string s2 = "hello";
            StringCmpdemo(s1, s2);
        }
        static void TestRefEquals()
        {
            string a = "The computer ate my source code.";
            string b = "The computer ate my source code.";
            bool eq = String.ReferenceEquals(a,b);
            Console.WriteLine("字符串a和字符串b的地址{0}",eq? "相等" : "不相等"); //字符串a和字符串b的地址相等,因为都在在常量区
            string c = String.Copy(a);//这是一个深拷贝,但是这个方法已经过时,不推荐使用
            eq = String.ReferenceEquals(a, c);
            Console.WriteLine("字符串a和字符串c的地址{0}", eq ? "相等" : "不相等"); //字符串a和字符串c的地址不相等
        }
        static void SplitTest()
        {
            string str = "Hello?is\tit me,you are-looking:for?";
            char[] delim = { '?', '\t', ' ', ',', '-',':' };//分隔符可以是一个字符数组
            string[] res = str.Split(delim);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        static void TestUsefulMethods()
        {
            string str = "Extension methods have all the capabilities of regular static methods.";

            // Write the string and include the quotation marks.
            System.Console.WriteLine("str:\"{0}\"", str);
            Console.WriteLine("str Starts With extension : {0}",str.StartsWith("extension"));
            Console.WriteLine("str Starts With extension (ignore case): {0}",str.StartsWith("extension",StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("str Ends With '.' : {0}",str.EndsWith("."));
            int first = str.IndexOf("methods")+ "methods".Length;
            int last = str.LastIndexOf("methods");
            string substr = str.Substring(first, last - first);
            Console.WriteLine("between first methods and last methods is sub string:{0}",substr);
        }

        static void TestRegexp1()
        {
            string[] sentences =
            {
                "C# code",
                "Chapter 2: Writing Code",
                "Unicode",
                "no match here"
            };
            string pattern = "code";
            foreach (var s in sentences)
            {
                Console.Write(s+":"); 
                if(Regex.IsMatch(s,pattern,RegexOptions.IgnoreCase))//忽略大小写
                {
                    Console.WriteLine("Match for {0} Found.",pattern);
                }
                else
                {
                    Console.WriteLine("No Match for {0} Found.", pattern);
                }
            }
            Console.WriteLine();
        }

        static void TestRegexp2()
        {
            string[] numbers =
           {
                "123-555-0190",
                "444-234-22450",
                "690-555-0178",
                "146-893-232",
                "146-555-0122",
                "4007-555-0111",
                "407-555-0111",
                "407-2-5555",
            };
            string pattern = "^\\d{3}-\\d{3}-\\d{4}$";
            Console.WriteLine("Match result:");
            foreach (var item in numbers)
            {
               if(Regex.IsMatch(item,pattern))
               {
                    Console.WriteLine(item);
               }
            }
        }
        static void Main(string[] args)
        {
            // StringTest1("hello world!!!"); ////!!!dlrow olleh
            //StringTest2("hOW DOES mICROSOFT wORD DEAL WITH THE cAPS lOCK KEY?"); //How does Microsoft Word deal with the Caps Lock key?
            // NullStringTest();
            //StringTest3();
            //ModifyStrings();
            //CharPointerTest();
            //TestStringCmpdemo();
            // TestRefEquals();
            //SplitTest();
            //TestUsefulMethods();
            //TestRegexp1();
            TestRegexp2();
        }
    }
}
