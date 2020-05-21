using CrmApp;
using CrmApp.Options;
using CrmApp.Services;

using CrmMvcProj.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace CrmMvcProj.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerManager custMangr;
        private IBasketManager bskMng;

        public CustomerController(ICustomerManager _custMangr, IBasketManager _bskMng)
        {
            custMangr = _custMangr;
            bskMng = _bskMng;
        }

        [HttpPost]
        public BasketItem Add2basket([FromBody] BasketProductOption baskoption)
        {
            return new BasketItem { Name = bskMng.AddProduct(baskoption).Product.Name };
        }

        [HttpPost]
        public Customer AddCustomer([FromBody] CustomerOption custOpt)
        {
            return custMangr.CreateCustomer(custOpt);
        }

        public List<Customer> GetAllCustomers()
        {
            return custMangr.GetAllCustomers();
        }
    }
}