using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models
{
    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Alias { get; set; }
        public string CategoryName { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class shoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public shoppingCart() { 
            this.Items = new List<ShoppingCartItem>();

        }
        public void AddToCard(ShoppingCartItem item, int quantity)
        {
            var check = Items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if(check != null)
            {
                check.Quantity += quantity;
                check.TotalPrice = check.Price* check.Quantity ;

            }
            else
            {
                Items.Add(item);
            }
        }
        public void remove(int id)
        {
            var checkTonTai = Items.SingleOrDefault(x => x.ProductId == id);
            if(checkTonTai != null)
            {
                Items.Remove(checkTonTai);
            }
        }
        public void updateSL(int id, int quantit)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantit;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }
        public decimal TongTien()
        {
            return Items.Sum(x=>x.TotalPrice);
        }
        public decimal TongSL()
        {
            return Items.Sum(x => x.Quantity);
        }
        public void clearCart()
        {
            Items.Clear();
        }

    }


   
}