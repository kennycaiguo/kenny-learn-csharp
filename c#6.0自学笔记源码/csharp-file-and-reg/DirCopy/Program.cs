using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirCopy
{
    internal class Program
    {
        static void DirCopy(string dstPath,string srcPath)
        {
            string fileName = null;
            if (!Directory.Exists(dstPath)) //如果目标文件夹不存在,就创建
            {
                Directory.CreateDirectory(dstPath);
            }
            if (Directory.Exists(srcPath)) 
            {
                string[] files = Directory.GetFiles(srcPath);
                foreach (string file in files) 
                { 
                  fileName = Path.GetFileName(file);
                  fileName = Path.Combine(dstPath, fileName);
                  File.Copy(file, fileName,true);
                }
                string[] dirs = Directory.GetDirectories(srcPath);
                foreach (var item in dirs)
                {
                    string dstSubdir = Path.GetFileName(item);
                    dstSubdir = Path.Combine(dstPath, dstSubdir);
                  if(!Directory.Exists(dstSubdir))
                  {
                        Directory.CreateDirectory(dstSubdir);
                  }
                    DirCopy(dstSubdir, item);
                }

            }
            else
            {
                Console.WriteLine("Source path does not exist!");
                return;
            }
            
        }

        static void DirMove(string dstPath, string srcPath)
        {
            //1.先复制内容到目标文件夹
            DirCopy(dstPath, srcPath);
            //2.然后递归删除源文件夹
            Directory.Delete(srcPath, true);
        }

        static void Main(string[] args)
        {

             //DirCopy("e:\\images", "d:\\images");
            // Directory.Delete(@"e:\123cpy2",true);
            DirMove("e:\\pictures", "e:\\images");
        }
    }
}
