using System.Collections;
using System.Collections.Generic;

namespace WebBanHang.Models
{
    public class CartModel
    {
        public CartModel()
        {
            Items = new List<GioHang>();
        }

        public IList<GioHang> Items { get; set; }

        public int TotalPrice { get; set; }

        public string CartTotal => this.TotalPrice.ToString("C");
    }
}