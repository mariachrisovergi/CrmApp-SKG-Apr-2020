using CrmApp.Models;
using CrmApp.Options;
using CrmApp.Repository;
using CrmMvcProj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmApp.Services
{
    public class BasketManagement : IBasketManager
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
            Basket basket = new Basket();
           if (baskOption.CustomerId !=null )
            {
                Customer customer  = cstMng.FindCustomerById(baskOption.CustomerId.GetValueOrDefault());
                if (customer == null) return null;
                basket.Customer = customer;
            }

            db.Baskets.Add(basket);
            db.SaveChanges();
            return basket;
         }

         //AddProduct
         public BasketItem AddProduct(BasketProductOption bskProd)
        {
            Product product = db.Products.Find(bskProd.ProductId);

            BasketProduct basketProduct = new BasketProduct
            {
                  Basket = db.Baskets.Find(bskProd.BasketId),
                  Product =product
            };

            db.BasketProducts.Add(basketProduct);
            db.SaveChanges();

            BasketItem baskItem = new BasketItem { Name = basketProduct.Product.Name };
            return baskItem;
        }

        //FindBasketById
        public Basket FindBasketById(int basketId)
        {
            return db.Baskets
                .Include(basket => basket.BasketProducts)
                .Where(basket => basket.Id== basketId)
                .First();
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
