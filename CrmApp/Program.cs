using System;
using System.Collections;
using System.Collections.Generic;

namespace CrmApp
{
    class Program
    {
        static void Main()
        {





            Ui ui = new Ui();

            Product apple = ui.CreateProduct();
            apple.Print();

            Product orange = ui.CreateProduct();
            Product pear = ui.CreateProduct();


            List<Product> products = new List<Product>
            {
                apple,
                pear,
                orange
            };


            int howManyLow = 0;
            int howManyMedium = 0;
            int howManyHi = 0;
            foreach (Product p in products)
            {
                Console.WriteLine(p.GetRange());
                if (p.GetRange() == "low") howManyLow++;
                if (p.GetRange() == "medium") howManyMedium++;
                if (p.GetRange() == "hi") howManyHi++;

            }
            Console.WriteLine($"howManyLow= {howManyLow}");
            Console.WriteLine($"howManyMedium= {howManyMedium}");
            Console.WriteLine($"howManyHi= {howManyHi}");

            Console.WriteLine("----Not preferred approach------");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }

            Console.WriteLine("-------Not preferred approach-------");
            int index = 0;
            while (index < products.Count)
            {
                Console.WriteLine(products[index]);
                index++;
            }

        }
    }
}
