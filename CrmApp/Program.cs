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
            Basket basket = new Basket();
            string askUser = "y";
           while(askUser=="y")
            {
                Product product = ui.CreateProduct();
                basket.AddProduct(product);
                Console.WriteLine("Do you want to continue? (y to continue)");
                askUser = Console.ReadLine();
            }

            basket.Print() ;
            basket.ShowCategories();
 
  


        }
    }
}
