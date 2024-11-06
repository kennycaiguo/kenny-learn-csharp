using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqOneToManyQuery
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    internal class Program
    {
        public static void GroupJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            // Create a list where each element is an anonymous type
            // that contains the person's first name and a collection of 
            // pets that are owned by them.
            //一对多查询,先将同一个主人的宠物放到一个组,然后选出这个主人和它的宠物组
            var query = from p in people
                        join pet in pets
                        on p equals pet.Owner into petGroup
                        select new { OwnerName = p.FirstName, Pets = petGroup };
            foreach (var item in query)
            {
                Console.WriteLine($"Owner:{item.OwnerName}");
                foreach(Pet pet in item.Pets)
                {
                    Console.Write($" {pet.Name}, ");
                }
                Console.WriteLine();
            }
        }
        //做一对多连接查询并且创建xml节点
        public static void GroupJoinXMLExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            XElement PetsAndOwner = new XElement("PetOwners",
                from person in people join pet in pets
                on person equals pet.Owner into pg
                select new XElement("Person",
                   new XAttribute("FirstName",person.FirstName),
                   new XAttribute("LastName",person.LastName),
                   from subpet in pg 
                   select new XElement("PetName",subpet.Name))//xml节点名称不能有空格
                );
            PetsAndOwner.Save("petsandowner.xml");
            Console.WriteLine(PetsAndOwner);
        }

        public static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets
                        on person equals pet.Owner into pg
                        from subpet in pg.DefaultIfEmpty()
                        select new { OwnerName = person.FirstName, PetName = (subpet == null ? " " : subpet.Name) };
            
            foreach (var v in query)
            {
                Console.WriteLine("{0,-15}{1}", v.OwnerName + ":", v.PetName);
            }


        }

            static void Main(string[] args)
        {
            //GroupJoinExample();
            //GroupJoinXMLExample();
            LeftOuterJoinExample();
        }
    }
}
