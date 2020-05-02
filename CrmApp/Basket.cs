using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrmApp
{
    public class Basket
    {
        private List<Product> products;
        public Customer Customer { get; set; }

        public Basket()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void Print()
        {
            foreach (Product p in products)
            {
                Console.WriteLine(p);
            }
        }


        public void ShowCategories()
        {
            int howManyLow = 0;
            int howManyMedium = 0;
            int howManyHi = 0;
            foreach (Product p in products)
            {
                if (p.GetRange() == "low") howManyLow++;
                if (p.GetRange() == "medium") howManyMedium++;
                if (p.GetRange() == "hi") howManyHi++;

            }
            Console.WriteLine($"howManyLow= {howManyLow}");
            Console.WriteLine($"howManyMedium= {howManyMedium}");
            Console.WriteLine($"howManyHi= {howManyHi}");
        }


        public decimal TotalCost()
        {
            decimal totalCost = 0m;
            foreach (Product p in products)
            {
                //totalCost += p.TotalCost;
            }
            return totalCost;
        }

        public string Save(string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename, true);
                foreach (Product product in products)
                {
                    //sw.WriteLine(product.Code + "," +
                    //    product.Name + "," +
                    //    product.Price + "," +
                    //    product.Quantity);
                }
                sw.Close();
            }
            catch (Exception)
            {
                return "An error occured";
            }
            return "The data have been saved";
        }


        public string Load(string filename)
        {
            try
            {
                products.Clear();
                StreamReader sr = new StreamReader(filename);
                string line;

                line = sr.ReadLine();
                while (line != null)
                {
                    string[] words = line.Split(",");
                    Product product = new Product{
                        //Code = words[0],
                        //Name = words[1],
                        //Price = Decimal.Parse(words[2]),
                        //Quantity = Int32.Parse( words[3])
                    };
                    products.Add(product);
                    line = sr.ReadLine();
                }
            }
            catch (Exception)
            {
                return "An error occured";
            }

            return "The file has benn read";

        }
    }
}
