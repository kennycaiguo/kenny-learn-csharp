using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpbasic_interface
{
    interface IEquatable<T>
    {
        bool Equals(T t);
    }
    public class Car : IEquatable<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public Car(string make, string model, string year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public bool Equals(Car t)
        {
            return (this.Make == t.Make && this.Model == t.Model && this.Year == t.Year);
        }
    }

    internal class Program
    {
        static void TestInterface()
        {
            Car c1 = new Car("TOYOTA", "COROLLA", "1987");
            Car c2 = new Car("TOYOTA", "CAMERY", "1989");
            Console.WriteLine(c1.Equals(c2));
            Car c3 = new Car("TOYOTA", "COROLLA", "1987");
            Console.WriteLine(c3.Equals(c1));
        }
        static void Main(string[] args)
        {
            TestInterface();
        }
    }
}
