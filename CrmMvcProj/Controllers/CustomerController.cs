using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmMvcProj.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerManager custMangr;

        public CustomerController(ICustomerManager _custMangr)
        {
              custMangr = _custMangr;
        }

        public IActionResult Index()
        {
            return View();
        }

        //addcustomer
        [HttpPost]
        public Customer AddCustomer([FromBody] CustomerOption custOpt)
        {
            return custMangr.CreateCustomer(custOpt);
        }

        //get all
        public List<Customer> GetAllCustomers()
        {
            return custMangr.GetAllCustomers();
        }


    }
}