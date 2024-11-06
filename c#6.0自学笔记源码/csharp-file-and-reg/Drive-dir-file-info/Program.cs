using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Drive_dir_file_info
{
    internal class Program
    {
        static void GetInfos()
        {
            DriveInfo dri = new DriveInfo(@"e:\");
            DirectoryInfo di = dri.RootDirectory;
            string currDir = di.FullName;
            Console.WriteLine("当前路径: "+currDir);
            string[] files = Directory.GetFiles(currDir);//获取到的只是文件没有目录
            foreach (string file in files) 
            {
                Console.WriteLine(file);
            }
            //string[] dirs = Directory.GetDirectories(currDir);//获取文件夹
            //foreach (string dir in dirs) 
            //{
            //    Console.WriteLine(dir);
            //}
            DirectoryInfo[] dirInfos = di.GetDirectories(@"123");//注意这里是二级目录不能有驱动器号,否则报错
            foreach (var info in dirInfos)
            {

                FileInfo[] fileNames = info.GetFiles("*.*");
                foreach (FileInfo fi in fileNames) 
                {
                    Console.WriteLine("{0}:{1}",fi.Name,fi.Length);
                }
               
            }
        }
        static void Main(string[] args)
        {
            GetInfos();
        }
    }
}
