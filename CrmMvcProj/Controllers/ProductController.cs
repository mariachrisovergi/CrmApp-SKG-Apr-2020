using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Models;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmMvcProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductManager prodMan;
       
        public ProductController(IProductManager _prodMan  )
        {
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
            Product product =  prodMan.CreateProduct(option);
            if (product == null)
            {
                return new Product { Name = "Error" };
            }
                return product;
        }



    }
}