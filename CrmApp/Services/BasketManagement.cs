using CrmApp.Models;
using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmApp.Services
{
    public class BasketManagement
    {
        private CrmDbContext db;

        public BasketManagement(CrmDbContext _db)
        {
            db = _db;
        }

        //CreateBasket
        public Basket CreateBasket(BasketOption baskOption)
        {
            CustomerManagement cstMng = new CustomerManagement(db);
            Basket basket = new Basket
            {
                Customer= cstMng.FindCustomerById(baskOption.CustomerId)
            };

            db.Baskets.Add(basket);
            db.SaveChanges();
            return basket;
         }

         //AddProduct
         public BasketProduct AddProduct(BasketProductOption bskProd)
        {
            BasketProduct basketProduct = new BasketProduct
            {
                  Basket = db.Baskets.Find(bskProd.BasketId),
                  Product =db.Products.Find(bskProd.ProductId)
            };

            db.BasketProducts.Add(basketProduct);
            db.SaveChanges();
            return basketProduct;
        }

        //FindBasketById
        public Basket FindBasketById(int basketId)
        {
            return db.Baskets.Find(basketId);
        }

        //FindCustomerBaskets
        public List<Basket> FindCustomerBaskets(int custId)
        {
            return db.Baskets
                .Where(basket => basket.Customer.Id == custId)
                .ToList();
         }

        //RemoveProduct

        public bool RemoveProduct(BasketProductOption bskProdOpt)
        {

            BasketProduct bskProd = db.BasketProducts.Find( bskProdOpt   );

            if (bskProd != null)
            {
                db.BasketProducts.Remove(bskProd);
                db.SaveChanges();
                return true;
            }
            return false;

        }



    }
}
