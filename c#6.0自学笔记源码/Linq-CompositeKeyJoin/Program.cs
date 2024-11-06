using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_CompositeKeyJoin
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeID { get; set; }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
    }


    internal class Program
    {
        static void CompositeKeyJoinDemo()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{FirstName="Jack",LastName="Daniel",EmployeeID=1001},
                new Employee{FirstName="Jade",LastName="Linda",EmployeeID=1002},
                new Employee{FirstName="Maria",LastName="Linn",EmployeeID=2001},
                new Employee{FirstName="Breford",LastName="Stone",EmployeeID=2002}
            };
            List<Student> students = new List<Student> 
            { 
                new Student{FirstName="Jade",LastName="Linda",StudentID=101},
                new Student{FirstName="Jessie",LastName="Linda",StudentID=102},
                new Student{FirstName="Jack",LastName="Mar",StudentID=103},
                new Student{FirstName="kate",LastName="Stone",StudentID=104},
                new Student{FirstName="Breford",LastName="Stone",StudentID=105}
            };

            IEnumerable<string> query = from emp in employees
                                        join stu in students
                                         on new { emp.FirstName, emp.LastName }
                                         equals new { stu.FirstName, stu.LastName }
                                        select emp.FirstName + " " + emp.LastName;

            Console.WriteLine("Person is Both employee and student:");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            CompositeKeyJoinDemo();
        }
    }
}
