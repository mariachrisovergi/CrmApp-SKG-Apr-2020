using CrmApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmMvcProj.Models
{
    public class Shopping
    {

        public int BasketId { get; set; }
        public int CustomerId { get; set; }
        public List<Product> availableProducts { get; set; }

        public List<Product> inBasketProducts { get; set; }
    }
}
