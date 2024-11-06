using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basic_exceptiondemo
{
    internal class Program
    {
        static double SafeDevision(double a, double b)
        {
            if(b==0)
                throw new DivideByZeroException();
            return a / b;
        }

        static void TestSafeDivision()
        {
            double x = 10.0,y = 0.0,result = 0.0;
            try
            {
                result = SafeDevision(x, y);
                Console.WriteLine("result = ", result);
            }
            catch (DivideByZeroException e) 
            {
                Console.WriteLine("Attempted divide by zero.");
            }
        }

        static void TestCatch()
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(@"test.txt");
                sw.WriteLine("Hello,Test");
            }
            catch (FileNotFoundException e) 
            {
                Console.WriteLine(e.ToString());
            }
            catch (IOException e) 
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                sw.Close();
            }
        }
        static void Main(string[] args)
        {
            //TestSafeDivision();
            TestCatch();
        }
    }
}
