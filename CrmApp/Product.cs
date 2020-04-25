using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp
{
    class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public decimal GetTotalCost()
        {
            //decimal totalCost;
            //totalCost = Price * Quantity;
            //return totalCost;
            return Price * Quantity;

        }

        public void IncreasePrice(decimal percentage)
        {
            Price *= (1 + percentage);
        }

        public void Print()
        {
            Console.WriteLine( Code);
            Console.WriteLine( Name);
            Console.WriteLine( Price);
            Console.WriteLine( Quantity);
            Console.WriteLine( GetTotalCost());
            Console.WriteLine();
        }
 
    }


    class Shop
    {

    }
}
