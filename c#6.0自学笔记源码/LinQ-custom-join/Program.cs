using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_custom_join
{

    internal class Program
    {
        #region Data

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
        static List<Category> categories = new List<Category>()
         {
             new Category(){Name="Beverages", ID=001},
             new Category(){ Name="Condiments", ID=002},
             new Category(){ Name="Vegetables", ID=003},
         };

        // Specify the second data source.
        static List<Product> products = new List<Product>()
        {
           new Product{Name="Tea",  CategoryID=001},
           new Product{Name="Mustard", CategoryID=002},
           new Product{Name="Pickles", CategoryID=002},
           new Product{Name="Carrots", CategoryID=003},
           new Product{Name="Bok Choy", CategoryID=003},
           new Product{Name="Peaches", CategoryID=005},
           new Product{Name="Melons", CategoryID=005},
           new Product{Name="Ice Cream", CategoryID=007},
           new Product{Name="Mackerel", CategoryID=012},
         };
        #endregion
        static void CustomJoinDemo()
        {
            var cjoinRes = from prod in products
                           let catids = from c in categories select c.ID
                           where catids.Contains(prod.CategoryID) == true
                           select new {
                               Product = prod.Name,ID = prod.CategoryID
                           };
            foreach (var item in cjoinRes)
            {
                Console.WriteLine($"{item.Product} : {item.ID}");
            }
        }
        static void Main(string[] args)
        {
            CustomJoinDemo();
        }
    }
}
