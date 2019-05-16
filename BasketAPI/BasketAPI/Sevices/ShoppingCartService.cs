using System;
using System.Collections.Generic;
using BasketAPI.Contracts;
using BasketAPI.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace BasketAPI.Sevices
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IMemoryCache _cache;        

        public ShoppingCartService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public ShoppingItem Add(ShoppingItem newItem)
        {
            List<ShoppingItem> cart = _cache.Get<List<ShoppingItem>>("cart");
            if (cart == null)
            {
                cart = new List<ShoppingItem>();
            }

            ShoppingItem item = cart.FirstOrDefault(a => a.Id == newItem.Id);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(newItem);
            }
            _cache.Set<List<ShoppingItem>>("cart", cart);
            return newItem;
        }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            List<ShoppingItem> cart = _cache.Get<List<ShoppingItem>>("cart");
            if (cart == null)
            {
                cart = new List<ShoppingItem>();
            }
            return cart;            
        }

        public ShoppingItem GetById(Guid id)
        {
            List<ShoppingItem> cart = _cache.Get<List<ShoppingItem>>("cart");
            if (cart == null || cart.Count == 0)
            {
                return null;
            }
            return cart.FirstOrDefault(a => a.Id == id);

        }

        public void Remove(Guid id)
        {
            List<ShoppingItem> cart = _cache.Get<List<ShoppingItem>>("cart");
            if (cart != null && cart.Count > 0)
            {
                var item = cart.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    cart.Remove(item);
                    _cache.Set<List<ShoppingItem>>("cart", cart);
                }
            }
        }

        public void ChangeQuantityById(Guid id, int quantity)
        {
            List<ShoppingItem> cart = _cache.Get<List<ShoppingItem>>("cart");
            if (cart != null && cart.Count > 0)
            {
                var item = cart.FirstOrDefault(a => a.Id == id);
                if (item != null)
                {
                    item.Quantity = quantity;
                }
                _cache.Set<List<ShoppingItem>>("cart", cart);
            }
        }

        public void Clear()
        {
            _cache.Remove("cart");
        }
    }
}
