using ShoppingCartLibrary;
using System;
using System.Collections.Generic;

namespace ShoppingCartUsePrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            ShoppingItem shoppingItem = new ShoppingItem();
            shoppingItem.Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            shoppingItem.Name = "orange";
            shoppingItem.Price = 2;
            shoppingItem.Quantity = 10;

            cart.AddItem(shoppingItem).Wait();
            cart.ChangeQuantity(shoppingItem.Id, 15).Wait();
            //cart.Clear().Wait();
            //cart.RemoveItem(shoppingItem.Id).Wait();

            List<ShoppingItem> items = cart.GetAllItems().GetAwaiter().GetResult();
            foreach(ShoppingItem item in items)
            {
                Console.WriteLine(item.Name + " " + item.Price + " " + item.Quantity);
            }
            Console.ReadLine();
        }
    }
}
