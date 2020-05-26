using CrmApp.Models;
using CrmApp.Options;
using CrmMvcProj.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmApp.Services
{
    public interface IBasketManager
    {
        Basket CreateBasket(BasketOption baskOption);
        BasketItem AddProduct(BasketProductOption bskProd);
        Basket FindBasketById(int basketId);
        List<Basket> FindCustomerBaskets(int custId);
        bool RemoveProduct(BasketProductOption bskProdOpt);

    }
}
