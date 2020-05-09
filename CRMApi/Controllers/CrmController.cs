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

        public CrmController(ILogger<CrmController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public string Get()
        {
               return "Welcome to our site";
        }

        [HttpGet("all")]
        public List<Customer> GetAllCustomers()
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.GetAllCustomers();
        } 



        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.FindCustomerById(id);
        }

         

        [HttpPost("")]
        public Customer PostCustomer(CustomerOption custOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);

            return custMangr.CreateCustomer(custOpt);
        }

        [HttpPut("{id}")]
        public Customer PutCustomer(int id, CustomerOption custOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.Update(custOpt, id);
        }

        [HttpDelete("hard/{id}")]
        public bool HardDeleteCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.DeleteCustomerById(id);
        }

        [HttpDelete("soft/{id}")]
        public bool SoftDeleteCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.SoftDeleteCustomerById( id);
        }


    }
}
