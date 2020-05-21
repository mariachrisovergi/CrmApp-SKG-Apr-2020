using CrmApp;
using CrmApp.Services;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace CrmMvcProj.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager prodMan;

        public ProductController(IProductManager _prodMan)
        {
            prodMan = _prodMan;
        }

        public List<Product> GetAll()
        {
            return prodMan.GetAll();
        }
    }
}