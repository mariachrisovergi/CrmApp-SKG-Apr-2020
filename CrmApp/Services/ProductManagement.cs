using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmApp.Services
{
    public class ProductManagement: IProductManager
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
            try { 
            Product product = new Product
            {
                 Name = prodOption.Name,
                 Price = Decimal.Parse( prodOption.Price),
                 Quantity = Int32.Parse(prodOption.Quantity),
            };


            db.Products.Add(product);
            db.SaveChanges();

            return product;
            }           
            catch(Exception)
            { return null; }

        }

        public Product FindProductById(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }
    }
}
