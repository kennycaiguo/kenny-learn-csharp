using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace csharpbasic_linqdemo
{
    public class School
    {
        #region data
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
        #endregion
        //根据LastName来分组
        public static void GroupByLastName()
        {
            var groupResut = from stu in students group stu by
                             stu.LastName into newGroup orderby newGroup.Key select newGroup;
            foreach (var item in groupResut)
            {
                Console.WriteLine($"Key:{item.Key}");
                foreach (var it in item)
                {
                    Console.WriteLine($"  {it.LastName},{it.FirstName}");
                }
            }
            
        }
        public static void QueryNestedGroups()
        {
            var queryNestedGroups =
                from student in students
                group student by student.Year into newGroup1
                from newGroup2 in
                    (from student in newGroup1
                     group student by student.LastName)
                group newGroup2 by newGroup1.Key;

            // Three nested foreach loops are required to iterate 
            // over all elements of a grouped group. Hover the mouse 
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    }
                }
            }
        }

    }
    static class Program //必须是静态类
    {
        static IEnumerable<string> Suits()//生成扑克牌辅助函数一
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "spades";
            yield return "hearts";
        }
        static IEnumerable<string> Ranks()//生成扑克牌辅助函数二
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
        static void LinQCardDemo() //用linq生成一幅扑克牌
        {
            //一对多查询
            var deckCards = Suits().SelectMany(suit=>Ranks().Select(rank=>new {Suit = suit,Rank = rank}));
            foreach (var item in deckCards)
            {
                Console.WriteLine(item);
            }
        }

        //洗牌函数,这个函数是扩展方法,必须把类的声明改为static,必须是非泛型静态类
        public static IEnumerable<T> ShaffulCard<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstItor = first.GetEnumerator();//获取第一个迭代器
            var secondItor = second.GetEnumerator();//获取第二个迭代器
            while (firstItor.MoveNext() && secondItor.MoveNext())
            {
                yield return firstItor.Current;
                yield return secondItor.Current;
            }

        }
        static void ShuffleDemo()
        {
            var deckCards = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));
            Console.WriteLine("Before Shuffle\n");
            foreach (var item in deckCards)
            {
                Console.WriteLine(item);
            }
            var first = deckCards.Take(26);
            var second = deckCards.Skip(26);
            var result = first.ShaffulCard(second);
            Console.WriteLine("After Shuffle\n");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        static void TestLinQ()
        {
            int[] nums = { 100, 75, 81, 60, 91, 85 };
            Console.WriteLine("----------Number greater than 80----------------");
            IEnumerable<int> query = from x in nums where x > 80 select x;
            foreach (var item in query)
            {
                Console.Write($"{item} ");
            }
           
            Console.WriteLine("\n-----------End---------------");
        }
        static void TestLinqToXML()
        {
            var fileName = "PurchaseOrder.xml";
            var currDir = Environment.CurrentDirectory;
            var filePath = Path.Combine(currDir, fileName);
            XElement purchaseOrder = XElement.Load(filePath);
            IEnumerable<XElement> pricesByPartNos = from item in purchaseOrder.Descendants("Item")
                                                    where (int)item.Element("Quantity") * (decimal)item.Element("USPrice")>100
                                                    orderby (string)item.Element("PartNumber")
                                                    select item;
            foreach (var item in pricesByPartNos)
            {
                Console.WriteLine(item);
            }
            
        }

        static void TestLinqToXMLLambda()
        {
            var filepath = Environment.CurrentDirectory+ "\\PurchaseOrder.xml";
            XElement parchaseOrder = XElement.Load(filepath);
            IEnumerable<XElement> pricesByPartNos = parchaseOrder.Descendants("Item")
                .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100)
                .OrderBy(order=>order.Element("PartNumber"));
            foreach (var item in pricesByPartNos)
            {
                Console.WriteLine(item);
            }
        }
        static void CreateXMLTree()
        {
            XElement stu1 = new XElement("Student", new XElement("Name", "Jack"), new XElement("Age", 18),new XElement("Gender", "Male"));
            XElement stu2 = new XElement("Student", new XElement("Name", "Mary"), new XElement("Age", 16),new XElement("Gender", "Female"));
            XElement stu3 = new XElement("Student", new XElement("Name", "Jesse"), new XElement("Age", 19),new XElement("Gender", "Female"));
            XElement stu4 = new XElement("Student", new XElement("Name", "Betty"), new XElement("Age", 17),new XElement("Gender", "Female"));

            XElement xtree = new XElement("Students", stu1, stu2, stu3, stu4);
            Console.WriteLine(xtree);
            xtree.Save("students.xml");
        }
        static void LoadXMLTree()
        {
            XElement xtree =XElement.Load(Environment.CurrentDirectory+"\\students.xml");
            IEnumerable<XElement> stus = xtree.Descendants("Student");
            foreach (var item in stus)
            {
                //Console.WriteLine(item);
                IEnumerable<XNode> nodes = item.Nodes();
                foreach (var node in nodes)
                {
                    XElement xe = (XElement)node;
                    Console.Write(xe.Name+":"+ xe.Value+" ");
                }
                Console.WriteLine();
            }
        }

        static void LoadXMLTreeXMLDoc()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Environment.CurrentDirectory + "\\students.xml");
            //XmlNode xe = doc.SelectSingleNode("Students");//获取根节点
            XmlNode xe = doc.DocumentElement;//获取根节点
            XmlNodeList nlist = xe.ChildNodes;
            foreach (XmlNode n in nlist) 
            {
                XmlNodeList attrlist = n.ChildNodes;
                Console.WriteLine($"Name:{attrlist[0].InnerText},Age:{attrlist[1].InnerText}," +
                    $"Gender:{attrlist[2].InnerText}");
               
            }
        }

        static void TestLinq2()
        {
            List<int> nlist = new List<int>(){ 5, 4, 1, 3, 6, 7, 8, 9, 10, 2, 0 };
            var qRes = from x in nlist
                       where x < 3 || x > 7
                       select x;
            foreach (var item in qRes)
            {
                Console.Write($"{item} "); //没有排序 1 8 9 10 2 0
            }
            Console.WriteLine();
        }
        static void TestLinq3()
        {
            List<int> nlist = new List<int>() { 5, 4, 1, 3, 6, 7, 8, 9, 10, 2, 0 };
            var qRes = from x in nlist
                       where x < 3 || x > 7
                       orderby x ascending //0  1  2  8  9  10 升序排列
                       select x;
            foreach (var item in qRes)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
        }

        //从方法中返回查询
        static IEnumerable<string> DoQuery1(int[] nums)
        {
            var inToString = from x in nums
                             where x > 6
                             select x.ToString();
            return inToString.ToList();
        }

        static void TestDoQuery()
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var strs = DoQuery1(ints);
            foreach (var str in strs)
            {
                Console.Write($"{str} ");
            }
            //7 8 9 10 11 12 13 14
            Console.WriteLine("\n");
        }

        static void DoQuery2(in int[] nums,out IEnumerable<string> strs)
        {
            var querystr = from x in nums where x > 6 orderby x ascending select x.ToString();
            strs = querystr;
        }

        static void TestDoQuery2()
        {
            IEnumerable<string> strs;
            int[] ints = { 10, 20, 13, 4, 5, 6, 7, 8, 9, 1,-100 };
            DoQuery2(ints, out strs);
            foreach (var item in strs)
            {
                Console.Write($"{item} "); 
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //LinQCardDemo();

            //ShuffleDemo();
            //TestLinQ();
            //TestLinq2();
            //TestLinq3();
            //TestLinqToXML();
            //TestLinqToXMLLambda();
            //CreateXMLTree();
            //LoadXMLTree();
            //LoadXMLTreeXMLDoc();
            //TestDoQuery();
            //TestDoQuery2();
            //School.GroupByLastName();
            School.QueryNestedGroups();
        }
    }
}
