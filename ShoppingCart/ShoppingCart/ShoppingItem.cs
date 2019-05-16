using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartLibrary
{
    public class ShoppingItem
    {
        public Guid Id { get; set; }        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
