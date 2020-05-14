using CrmApp.Models;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrmApp
{
    class Program
    {

        static void Main()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();
            optionsBuilder.UseSqlServer(CrmDbContext.ConnectionString);
            using CrmDbContext db = new CrmDbContext(optionsBuilder.Options );
            
            
            IBasketManager baskMangr = new BasketManagement(db);
            IProductManager pmng = new ProductManagement(db);


            Basket basket = baskMangr.FindBasketById(1);

            basket.BasketProducts.ForEach(
                baskProduct =>
                   Console.WriteLine(
                       db.BasketProducts
                       .Include(b => b.Product)
                       .Where(b => b.Id == baskProduct.Id)
                       .First()
                       .Product.Name
                   )
            );





        }
        static void Main2()
        {

            var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();
            optionsBuilder.UseSqlServer(CrmDbContext.ConnectionString);
            using CrmDbContext db = new CrmDbContext(optionsBuilder.Options);

            ICustomerManager custMangr = new CustomerManagement(db);

            CustomerOption custOpt = new CustomerOption
            {
                FirstName = "Maria",
                LastName = "Pentagiotissa",
                Address = "Athens",
                Email = "maria@gmail.com",

            };

           


            // testing the creation of a customer
            Customer customer = custMangr.CreateCustomer(custOpt);
            Console.WriteLine(
                $"Id= {customer.Id} Name= {customer.FirstName} Address= {customer.Address}");


            //testing reading a customer
            customer = custMangr.FindCustomerById(2);
            if (customer != null)
                Console.WriteLine(
                    $"Id= {customer.Id} Name= {customer.FirstName} Address= {customer.Address}");


            //testing updating
            CustomerOption custChangingAddress = new CustomerOption
            {
                Address = "Lamia"
            };
            customer = custMangr.Update(custChangingAddress, 1);
            Console.WriteLine(
                $"Id= {customer.Id} Name= {customer.FirstName} Address= {customer.Address}");


            //testing deletion

            bool result = custMangr.DeleteCustomerById(2);
            Console.WriteLine($"Result = {result}");
            customer = custMangr.FindCustomerById(2);
            if (customer != null)
            {
                Console.WriteLine(
                $"Id= {customer.Id} Name= {customer.FirstName} Address= {customer.Address}");

            }
            else
            {
                Console.WriteLine("not found");
            }

            ProductOption prOpt = new ProductOption
            {
                Name = "mila",
                Price = 1.20m,
                Quantity = 10
            };

            IProductManager prodMangr = new ProductManagement(db);

            Product product = prodMangr.CreateProduct(prOpt);

            IBasketManager baskMangr = new BasketManagement(db);

            BasketOption baskOption = new BasketOption
            {
                CustomerId = 3
            };

            Basket basket = baskMangr.CreateBasket(baskOption);
            BasketProductOption bskProdOpt = new BasketProductOption
            {
                BasketId = basket.Id,
                ProductId = 1
            };


            BasketProduct baskProd = baskMangr.AddProduct(bskProdOpt);

            basket.BasketProducts.ForEach(p =>
               Console.WriteLine(p.Product.Name));


        }


    }
}
 
