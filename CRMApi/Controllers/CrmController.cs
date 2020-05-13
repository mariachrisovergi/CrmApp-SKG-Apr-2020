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
        private readonly IBasketManager baskMangr;


        public CrmController(ILogger<CrmController> logger, 
            ICustomerManager _custMangr,IProductManager _prodMangr,
            IBasketManager _baskMangr
            )
        {
            _logger = logger;
            custMangr = _custMangr;
            prodMangr = _prodMangr;
            baskMangr = _baskMangr;
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

        //           [FromForm]    [FromBody]   [FromRoute]
        /*
         The FromForm attribute is for incoming data from a submitted form sent 
        by the content type application/x-www-url-formencoded w
            hile the FromBody will parse the model the default way, 
            which in most cases are sent by the content type application/json,
 */


        [HttpPost("")]
        public Customer PostCustomer( CustomerOption custOpt)
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

        [HttpPost("{customerId}/basket")]
        public Basket CreateBasket(int customerId)
        {
            BasketOption bskOption = new BasketOption
            {
                CustomerId = customerId
        };

            return baskMangr.CreateBasket(bskOption);
        }

        [HttpPost("basket/{basketId}/product/{productId}")]
        public BasketProduct AddToBasket(int basketId, int productId)
        {
            BasketProductOption bskProd = new BasketProductOption
            {
                BasketId = basketId, ProductId = productId
            };

            return baskMangr.AddProduct(bskProd);
        }

    }
}
