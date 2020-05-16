using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Models;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmMvcProj.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager prodMan;
       
        public ProductController(IProductManager _prodMan  )
        {
            prodMan = _prodMan;
          
        }


        public List<Product> GetAll()
        {
            
 
            return prodMan.GetAll();
        }


    }
}