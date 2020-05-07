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

        static void AnotherMain()
        {

        }


        static void Main()
        {
            AnotherMain();
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
            customer = custMangr.FindCustomerById(2);
            if (customer!=null)
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


        }
    }
}
