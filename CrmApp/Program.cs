using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CrmApp
{
    class Program
    {
        static void Main()
        {
            CustomerOption custOpt = new CustomerOption
            {
                 FirstName = "Maria",
                 LastName = "Pentagiotissa",
                 Address = "Athens",
                 Email ="maria@gmail.com",

            };

            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);


            // testing the creation of a customer
            Customer customer = custMangr.CreateCustomer(custOpt);
            Console.WriteLine(
                $"Id= {customer.Id} Name= {customer.FirstName} Address= {customer.Address}");


            //testing reading a customer
            Customer cx = custMangr.FindCustomerById(2);
            Console.WriteLine(
                $"Id= {cx.Id} Name= {cx.FirstName} Address= {cx.Address}");


            //testing updating
            CustomerOption custChangingAddress = new CustomerOption
            {
                 Address = "Lamia"
            };
            Customer c2 = custMangr.Update(custChangingAddress, 1);
            Console.WriteLine(
                $"Id= {c2.Id} Name= {c2.FirstName} Address= {c2.Address}");


            //testing deletion

            bool result = custMangr.DeleteCustomerById(2);
            Console.WriteLine($"Result = {result}");
            Customer cx2 = custMangr.FindCustomerById(2);
            if (cx2 != null)
            {
                Console.WriteLine(
                $"Id= {cx2.Id} Name= {cx2.FirstName} Address= {cx2.Address}");

            }
            else
            {
                Console.WriteLine("not found");
            }


        }
    }
}
