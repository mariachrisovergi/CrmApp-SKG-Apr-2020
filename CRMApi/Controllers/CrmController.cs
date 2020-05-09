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
    [Route("[controller]")]
    public class CrmController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CrmController> _logger;

        public CrmController(ILogger<CrmController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public string Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            return "Welcome to our site";
        }

        [HttpGet("now")]
        public DateTime getInfo()
        {
            return   DateTime.Now;
        }
        [HttpGet("customer/{id}")]
        public Customer getCustomer(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            CustomerManagement custMangr = new CustomerManagement(db);
            return custMangr.FindCustomerById(id);
        }

        [HttpGet("product/{id}")]
        public Product getProduct(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);
            return prodMangr.FindProductById(id);
        }

        [HttpPost("product")]
        public Product PostProduct(ProductOption prOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);

            return prodMangr.CreateProduct(prOpt);
        }
    }
}
