using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRMApi.Controllers
{
    [ApiController]
    [Route("[controller]/customer")]
    public class CrmController : ControllerBase
    {
        

        private readonly ILogger<CrmController> _logger;
        private readonly ICustomerManager custMangr;
        private readonly IProductManager prodMangr;

        public CrmController(ILogger<CrmController> logger, 
            ICustomerManager _custMangr,IProductManager _prodMangr )
        {
            _logger = logger;
            custMangr = _custMangr;
            prodMangr = _prodMangr;
        }

        [HttpGet("")]
        public string Get()
        {
               return "Welcome to our site";
        }

        [HttpGet("all")]
        public List<Customer> GetAllCustomers()
        {
            
            return custMangr.GetAllCustomers();
        } 



        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
          
            return custMangr.FindCustomerById(id);
        }

         

        [HttpPost("")]
        public Customer PostCustomer([FromForm] CustomerOption custOpt)
        {
            return custMangr.CreateCustomer(custOpt);
        }

        [HttpPut("{id}")]
        public Customer PutCustomer(int id, CustomerOption custOpt)
        {
            return custMangr.Update(custOpt, id);
        }

        [HttpDelete("hard/{id}")]
        public bool HardDeleteCustomer(int id)
        {
            return custMangr.DeleteCustomerById(id);
        }

        [HttpDelete("soft/{id}")]
        public bool SoftDeleteCustomer(int id)
        {
            return custMangr.SoftDeleteCustomerById( id);
        }


    }
}
