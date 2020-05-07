using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Services
{
    public class ProductManagement
    {
        private CrmDbContext db;

        public ProductManagement(CrmDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public Product CreateProduct(ProductOption prodOption)
        {
            Product product = new Product
            {
                 Name = prodOption.Name,
                 Price = prodOption.Price,
                 Quantity = prodOption.Quantity,
            };


            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }


    }
}
