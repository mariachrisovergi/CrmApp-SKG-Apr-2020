using CrmApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmMvcProj.Models
{
    public class DataModels
    {
        public List<Product> Products { get; set; }

    }

    public class CustomerModel
    {
        public List<Customer> Customers { get; set; }
    }

    public class ACustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }

    }




}
