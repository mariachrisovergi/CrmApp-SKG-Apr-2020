using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Services
{
    public class CustomerManagement
    {
        //CRUD
        // create read update delete
        public Customer CreateCustomer(CustomerOption custOption)
        {
            Customer customer = new Customer
            {
                FirstName = custOption.FirstName,
                LastName  = custOption.LastName,
                Address  = custOption.Address,
                Dob  = custOption.Dob,
                Email  = custOption.Email,
                Active = true,
                Balance = 0,
            };

            using CrmDbContext db = new CrmDbContext();
            db.Customers.Add(customer);
            db.SaveChanges();
      
            return customer;
        }
    }
}
