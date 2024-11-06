using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_object_query
{
    public class StudentClass
    {
        protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };
        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public GradeLevel Year;
            public List<int> ExamScores;
        }

        protected static List<Student> students = new List<Student>
       {
        new Student {FirstName = "Terry", LastName = "Adams", ID = 120,
            Year = GradeLevel.SecondYear,
            ExamScores = new List<int>{ 99, 82, 81, 79}},
        new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116,
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 99, 86, 90, 94}},
        new Student {FirstName = "Hanying", LastName = "Feng", ID = 117,
            Year = GradeLevel.FirstYear,
            ExamScores = new List<int>{ 93, 92, 80, 87}},
        new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114,
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 97, 89, 85, 82}},
        new Student {FirstName = "Debra", LastName = "Garcia", ID = 115,
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 35, 72, 91, 70}},
        new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118,
            Year = GradeLevel.SecondYear,
            ExamScores = new List<int>{ 92, 90, 83, 78}},
        new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113,
            Year = GradeLevel.FirstYear,
            ExamScores = new List<int>{ 88, 94, 65, 91}},
        new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112,
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 75, 84, 91, 39}},
        new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111,
            Year = GradeLevel.SecondYear,
            ExamScores = new List<int>{ 97, 92, 81, 60}},
        new Student {FirstName = "Lance", LastName = "Tucker", ID = 119,
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 68, 79, 88, 92}},
        new Student {FirstName = "Michael", LastName = "Tucker", ID = 122,
            Year = GradeLevel.FirstYear,
            ExamScores = new List<int>{ 94, 92, 91, 91}},
        new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 96, 85, 91, 60}}
       };
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }
        public void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam]>score 
                             select new {Name=student.FirstName,Score = student.ExamScores[exam] };
            foreach (var item in highScores) 
            {
                Console.WriteLine("{0,-15}{1}", item.Name, item.Score);
            }
        }
        public static void QueryById(string[] ids)
        {
            var result = from stu in students
                         where ids.Contains(stu.ID.ToString())
                         select stu;
            foreach (var item in result)
            {
                Console.WriteLine($"{item.LastName}:{item.ID}");
            }
        }
        public static void QueryById2(string[] ids)//第二种写法
        {
            var result = from stu in students
                         where ids.Contains(stu.ID.ToString())
                         select new {stu.LastName,stu.ID };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.LastName}:{item.ID}");
            }
        }
       public static void QueryByYear(string level)
        {
            GradeLevel year = (GradeLevel)Convert.ToInt32(level);
            IEnumerable<Student> studentQuery = null;
            switch (year)
            {
                case GradeLevel.FirstYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.FirstYear
                                   select student;
                    break;
                case GradeLevel.SecondYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.SecondYear
                                   select student;
                    break;
                case GradeLevel.ThirdYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.ThirdYear
                                   select student;
                    break;
                case GradeLevel.FourthYear:
                    studentQuery = from student in students
                                   where student.Year == GradeLevel.FourthYear
                                   select student;
                    break;

                default:
                    break;
            }
            Console.WriteLine("The following students are at level {0}", year.ToString());
            foreach (Student name in studentQuery)
            {
                Console.WriteLine("{0}: {1}", name.LastName, name.ID);
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //StudentClass sc = new StudentClass();
            //sc.QueryHighScores(0, 90);
            //StudentClass.QueryById(new[] { "111", "114", "112" });
            //StudentClass.QueryById2(new[] { "111", "114", "112","122","120" });
            StudentClass.QueryByYear("1");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
