using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp
{
    class Product
    {
        //fields
        private int category;
        private String code;

        //property that wraps the field code
        public string Code
        {
            get { return "GR" + code; }
            set { code = value; }
        }
        //other properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        //calculated property
        public decimal TotalCost { get { return Price * Quantity; } }


        //constructors
        //constructor overloading
        public Product(int _category)
        {
             category = _category;
        }

        //default constructor or empty
        public Product()
        {

        }

        //method ToString inherented by the Object class
        public override string ToString()
        {
            //return "Name= " + Name +"\n"
            //   + " Price= "+Price
            //   + " Quantity= " + Quantity
            //   + " TotalCost= " + TotalCost;
            // preferrable way using $
            return $"Name= {Name} Price= {Price} Quantity= {Quantity} TotalCost= {TotalCost}";

        }


        //methods
        public void IncreasePrice(decimal percentage)
        {
            if (category == 1) { 
                Price *= (1 + 0.1m);
            }
            else
            {
                Price *= (1 + percentage);
            }
                
        }

        public void Print()
        {
            Console.WriteLine( ToString());
            Console.WriteLine();
        }

        public string GetRange()
        {
            if ( Price < 1)
                return "low";
            else if (Price  < 10)
                return "medium";
            else
                return "hi";

            
        }
 
    }


    
}
