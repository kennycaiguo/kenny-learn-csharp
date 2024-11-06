using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_orderby
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }
        }

        public class Category
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        // Specify the first data source.
        public static List<Category> categories = new List<Category>()
         {
             new Category(){Name="Beverages", ID=001},
             new Category(){ Name="Condiments", ID=002},
             new Category(){ Name="Vegetables", ID=003},
             new Category() {  Name="Grains", ID=004},
             new Category() {  Name="Fruit", ID=005}
         };

        // Specify the second data source.
        public static List<Product> products = new List<Product>()
        {
           new Product{Name="Cola",  CategoryID=001},
           new Product{Name="Tea",  CategoryID=001},
           new Product{Name="Mustard", CategoryID=002},
           new Product{Name="Pickles", CategoryID=002},
           new Product{Name="Carrots", CategoryID=003},
           new Product{Name="Bok Choy", CategoryID=003},
           new Product{Name="Peaches", CategoryID=005},
           new Product{Name="Melons", CategoryID=005},
           new Product{Name="Rice", CategoryID=004},
         };
        static void OrderByDemo()
        {
            var query = from c in categories
                        join prod in products on c.ID equals prod.CategoryID into pg
                        orderby c.Name
                        select new
                        {
                            Category = c.Name,
                            Products = from prod2 in pg
                                      orderby prod2.Name
                                      select prod2
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item.Category);
                foreach (var p in item.Products)
                {
                    Console.WriteLine("  {0,-10} {1}", p.Name, p.CategoryID);
                }
            }
        }
        static void Main(string[] args)
        {
            OrderByDemo();
        }
    }
}
