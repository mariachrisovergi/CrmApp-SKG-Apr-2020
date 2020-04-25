using System;

namespace CrmApp
{
      class AnotherClass
    {
         static void Main()
        {
            string returnProduct;
            string message = "Give the name of the product";
            //method invocation or method call or method usage
            returnProduct =  DoWork(message);
            Console.WriteLine(returnProduct);
        }

        //declaration of a method
        static string DoWork(string message)
        {
            string product;
            Console.WriteLine(message);
            product = Console.ReadLine();
            return product;
        }

    }
}
