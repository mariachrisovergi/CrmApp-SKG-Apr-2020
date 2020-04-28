using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp
{
    class Basket
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
            decimal totalCost = 0;
            foreach (Product p in products)
            {
                totalCost+=p.TotalCost;
            }
            return totalCost;
        }

    }
}
