using System;

namespace CrmApp
{
    class Program
    {
        static void Main()
        {
            
            Product myProduct = new Product
            {
                Code = "A1",
                Name = "Chocolate",
                Price = 1.2m,
                Quantity = 10
            };

            myProduct.Print();

            Product a1 = new Product
            {
                Code = "A123",
                Name = "Chicklets"
            };

            a1.Print();

            decimal total = myProduct.GetTotalCost() + a1.GetTotalCost();
            Console.WriteLine(total);

        }
    }
}
