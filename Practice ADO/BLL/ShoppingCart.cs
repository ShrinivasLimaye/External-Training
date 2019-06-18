using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShoppingCart
    {
        private List<Item> items = new List<Item>();
        public ShoppingCart()
        { }
        public void AddToCart(Item theItem)
        { items.Add(theItem); }
        public void RemoveFromCart(Item theItem)
        { items.Remove(theItem); }
        public List<Item> GetAllItems()
        { return items; }
    }
}
