using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_join_query
{
    public class Person
    {
        public string Name { get; set; }
    }
    public class Pet 
    { 
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    internal class Program
    {
        static void InnerJoinQuery()
        {
            Person magnus = new Person { Name = "Magnus"};
            Person terry = new Person { Name = "Terry"};
            Person charlotte = new Person { Name = "Charlotte"};
            Person arlene = new Person { Name = "Arlene" };
            Person rui = new Person { Name = "Rui"};

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = rui };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var result = from per in people join  pet in pets on per equals pet.Owner
                         select new {OwnerName = per.Name,PetName = pet.Name};
            foreach (var item in result)
            {
                Console.WriteLine($"Owner:{item.OwnerName},Pet: {item.PetName}");
            }

        }
        static void Main(string[] args)
        {
            InnerJoinQuery();
        }
    }
}
