using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Services;
using CrmMvcProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmMvcProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiCustomerController : Controller
    {

        private ICustomerManager custMangr;
        private IBasketManager bskMng;

        public ApiCustomerController(ICustomerManager _custMangr, IBasketManager _bskMng )
        {
            custMangr = _custMangr;
            bskMng = _bskMng;
        }





        [HttpPost("Add2basket")]
       public BasketItem Add2basket([FromBody] BasketProductOption baskoption)
        {
            return bskMng.AddProduct(baskoption);
       }

        [HttpPost("login")]
        public Customer LoginCustomer([FromBody] CustomerOption custOpt)
        {
            return custMangr.FindCustomerByEmail(custOpt);
        }

        [HttpDelete("DeleteCustomer")]
        public bool DeleteCustomer([FromBody] DeleteModel delModel)
        {
            if (delModel!=null )
            return custMangr.DeleteCustomerById(delModel.Id);
            else return false;
        }


        [HttpPut("updatecustomer")]
        public bool UpdateCustomer([FromBody] ACustomerModel cust)
        {
            CustomerOption c = new CustomerOption
            {
                 FirstName=cust.FirstName,
                LastName=cust.LastName,
                 Address=cust.Address,
                 Email= cust.Email
            };
            custMangr.Update(c, cust.Id);
            return true;
        }


        //   localhost:port/customer/addcustomer
        [HttpPost("AddCustomer")]
        public Customer AddCustomer([FromBody] CustomerOption custOpt)
        {
            return custMangr.CreateCustomer(custOpt);
        }

        //get all
        [HttpGet("GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            return custMangr.GetAllCustomers(10,1);
        }

        [HttpGet("FinalizeBasket")]
        public Basket Finalize(int BasketId)
        {
            //to be implemented
            return null;
        }


    }
}