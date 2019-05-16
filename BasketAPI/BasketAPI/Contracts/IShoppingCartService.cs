using System;
using System.Collections.Generic;
using BasketAPI.Model;

namespace BasketAPI.Contracts
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingItem> GetAllItems();
        ShoppingItem Add(ShoppingItem newItem);
        ShoppingItem GetById(Guid id);
        void Remove(Guid id);
        void ChangeQuantityById(Guid id, int quantity);
        void Clear();
    }
}
