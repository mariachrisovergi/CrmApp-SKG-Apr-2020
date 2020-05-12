using CrmApp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Services
{
    public interface ICustomerManager
    {
        Customer CreateCustomer(CustomerOption custOption);
        Customer FindCustomerById(int customerId);
        List<Customer> FindCustomerByName(CustomerOption custOption);
        Customer Update(CustomerOption custOption, int customerId);
        bool DeleteCustomerById(int id);
        bool SoftDeleteCustomerById(int id);
        List<Customer> GetAllCustomers();
    }
}
