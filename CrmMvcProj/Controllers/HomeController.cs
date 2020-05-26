using CrmApp;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using CrmMvcProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CrmMvcProj.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrmDbContext _db;
        private ICustomerManager _custMng;
        private IBasketManager _bskMng;
        public HomeController(ILogger<HomeController> logger, CrmDbContext db,
           ICustomerManager custMng, IBasketManager bskMng)
        {
            _logger = logger;
            _db = db;
            _custMng = custMng;
            _bskMng = bskMng;
        }


        [HttpGet("")]
        public IActionResult Home()
        {
            return View("Index");
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy was selected");
             return View( );
        }

        [HttpGet("AddCustomer")]
        public IActionResult AddCustomer()
        {
            return View();
        }

         [HttpGet("AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("Customer")]
        public IActionResult Customers()
        {
            CustomerModel mycustomers = new CustomerModel
            {
                Customers = _custMng.GetAllCustomers()
            };
            return View(mycustomers);
        }


        //[FromBody] [FromForm] [FromRoute]

        [HttpGet("Shopping")]
        public IActionResult Shopping([FromRoute]  int? customerId)
        {
            //if customerId==null goto login page

            BasketOption baskOption = new BasketOption {  CustomerId=  customerId  };
            Basket basket = _bskMng.CreateBasket(baskOption);

            Shopping shopping = new Models.Shopping {
                availableProducts = _db.Products.ToList() ,
                BasketId = basket.Id
            };

            return View(shopping);
        }




        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
