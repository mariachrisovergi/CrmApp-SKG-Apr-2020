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

     
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy was selected");
             return View( );
        }


        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult Customers()
        {
            CustomerModel mycustomers = new CustomerModel
            {
                Customers = _custMng.GetAllCustomers()
            };
            return View(mycustomers);
        }

        public IActionResult Shopping()
        {
            BasketOption baskOption = new BasketOption {  CustomerId=3};
            Basket basket = _bskMng.CreateBasket(baskOption);

            Shopping shopping = new Models.Shopping {
                availableProducts = _db.Products.ToList() ,
                BasketId = basket.Id
            };

            return View(shopping);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
