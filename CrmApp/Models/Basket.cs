using CrmApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrmApp
{
    public class Basket
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }


        //dummy methods to be implemented for console app

        public void Load(string filename)
        {

        }

        public void Save(string filename)
        {

        }

        public void AddProduct(Product product)
        {
        }

        public void Print ()
        {
        }

        public void ShowCategories()
        {
        }
        public decimal TotalCost()
        {
            return 0m;
        }

    }
}
