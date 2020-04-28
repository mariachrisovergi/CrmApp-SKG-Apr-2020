using System;
using System.Collections;
using System.Collections.Generic;

namespace CrmApp
{
    class Program
    {
        static void Main()
        {
            Ui ui = new Ui();
            Customer customer = ui.CreateCustomer();
            Basket basket = ui.CreateBasket();

            
        }
    }
}
