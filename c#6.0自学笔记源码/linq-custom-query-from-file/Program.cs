using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace linq_custom_query_from_file
{
    internal class Program
    {
        static void CustomQueryFromFile()
        {
            string[] names = File.ReadAllLines(@"names.csv");
            string[] scores = File.ReadAllLines(@"scores.csv");
            try
            {
                var scoreQuery = from name in names
                                 let nameFields = name.Split(',')
                                 from score in scores
                                 let scoreFields = score.Split(',')
                                 where nameFields[2] == scoreFields[0]
                                 select $"{nameFields[0]},{scoreFields[1]},{scoreFields[2]},{scoreFields[3]},{scoreFields[4]}";
                foreach (var item in scoreQuery)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"{scoreQuery.Count()} records");
            }
            catch (Exception ex) {
                Console.WriteLine("there is an exception");
            }
            
        }
        static void Main(string[] args)
        {
            CustomQueryFromFile();
        }
    }
}
