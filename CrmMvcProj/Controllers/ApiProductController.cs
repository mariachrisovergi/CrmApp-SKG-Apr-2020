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
    public class ApiProductController : Controller
    {

        private ICustomerManager custMangr;
        private IProductManager prodMan;

        public ApiProductController(ICustomerManager _custMangr, IProductManager _prodMan)
        {
            custMangr = _custMangr;
            prodMan = _prodMan;
        }
 


        [HttpGet("GetAll")]
        public List<Product> GetAll()
        {


            return prodMan.GetAll();
        }

        [HttpPost("AddProduct")]
        public Product AddProduct([FromBody] ProductOption option)
        {
            Product product = prodMan.CreateProduct(option);
            if (product == null)
            {
                return new Product { Name = "Error" };
            }
            return product;
        }



    }


}