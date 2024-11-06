using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace csharpbasic_file_and_reg
{
    internal class Program
    {
        static void WriteFileDemo1()
        {
            string[] lines = { "恭喜发财,红包拿来", "但愿人长久,千里共婵娟","好好学习,天天向上" };
            DirectoryInfo pathinfo = Directory.CreateDirectory(@"e:\filetest");
            string filename = Path.Combine(pathinfo.FullName, "test.txt");
            if (!File.Exists(filename))
            {
               File.WriteAllLines(filename, lines);//c#可以直接创建文件并且写入数据.
            }
        }
        static void WriteFileDemo2()
        {
            string[] lines = { "你好我好大家好", "恭喜发财,万事如意", "耶耶耶" };
            DirectoryInfo pathinfo = Directory.CreateDirectory(@"e:\filetest");
            string filename = Path.Combine(pathinfo.FullName, "test.txt");
            using (StreamWriter sw = new StreamWriter(filename,true))//true表示一追加的方式写入.
            {
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
                
            }
        }
        static void WriteFileDemo3()//使用这种方法需要在每一行后加换行符
        {
            string[] lines = { "床前明月光\n", "疑是地上霜\n", "No No No\n" };
            DirectoryInfo pathinfo = Directory.CreateDirectory(@"e:\filetest");
            string filename = Path.Combine(pathinfo.FullName, "test.txt");
            using (FileStream fs = new FileStream(filename,FileMode.Append))//.
            {
                foreach (var line in lines)
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(line);//c#字符串转化为字节的方法
                    fs.Write(info, 0, info.Length);
                }

            }
        }

        static void ReadFileDemo1() //使用File类
        {
            string text = File.ReadAllText(Path.Combine(@"e:\filetest","test.txt"));
            Console.WriteLine($"File Content:\n============================\n{text}");
        }
        static void ReadFileDemo2() 
        {
            string[] lines = File.ReadAllLines(Path.Combine(@"e:\filetest", "test.txt"));
            Console.WriteLine("File Content:\n============================");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("===============End=============\n");
        }

        static void ReadFileDemoSR()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(Path.Combine(@"e:\filetest", "test.txt")))
                {
                    string line;
                    Console.WriteLine("File Content:\n=========================");
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("==================End=================");
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
        }
        static void ReadFileDemoFS()
        {
            using (FileStream fs = 
                new FileStream(Path.Combine(@"e:\filetest", "test.txt"), FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                int bytesToRead  = (int)(fs.Length);
                int bytesRead = 0;
                Console.WriteLine("File Content:\n=========================");
                while (bytesToRead>0)
                {
                    int n = fs.Read(bytes, bytesRead, bytesToRead);
                    Console.WriteLine(new UTF8Encoding(true).GetString(bytes));//c#把byte数组转化为字符串
                    if (n == 0)//读取不到就跳出循环
                        break;
                    bytesRead += n;
                    bytesToRead -= n;
                }
                Console.WriteLine("==================End=================");
            }
        }
        static void Main(string[] args)
        {
            //WriteFileDemo1();
            //WriteFileDemo2();
            //WriteFileDemo3();
            // ReadFileDemo1();
            //ReadFileDemo2();
            //ReadFileDemoSR();
            ReadFileDemoFS();
        }
    }
}
