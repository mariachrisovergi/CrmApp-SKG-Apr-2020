using CrmApp.Options;
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

            CustomerManagement custMangr = new CustomerManagement();
            Customer customer = custMangr.CreateCustomer(custOpt);

            Console.WriteLine(
                $"Id= {customer.Id} Name= {customer.FirstName}");


        }
    }
}
