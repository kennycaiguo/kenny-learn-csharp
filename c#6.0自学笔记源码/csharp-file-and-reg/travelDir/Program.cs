using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace travelDir
{
    internal class Program
    {
        static StringCollection log = new StringCollection();
        static void TravelDir()
        {
            
            string[] drives = System.Environment.GetLogicalDrives();
            foreach (string drive in drives) {
                DriveInfo di = new DriveInfo(drive);
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                DirectoryInfo rootDir = di.RootDirectory;
                WalkDirectory(rootDir);
                Console.WriteLine("Files with restricted access:");
                foreach (var item in log)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press any key");
                Console.ReadKey();

            }
        }

        private static void WalkDirectory(DirectoryInfo rootDir)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            try
            {
                files = rootDir.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e) 
            {
                log.Add(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                foreach (FileInfo file in files) 
                {
                    Console.WriteLine(file.FullName);
                }
                subDirs = rootDir.GetDirectories();
                if (subDirs != null)
                {
                    foreach (var item in subDirs)
                    {
                        WalkDirectory(item);//递归调用
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            TravelDir();
        }
    }
}
