using System.Collections.Generic;

namespace Promotions.Core.Models
{
    public class CartQuery
    {
        public List<CartItem> CartItems { get; set; }
    }

    public class CartItem
    {
        public int Quantity { get; set; }
        public Code CartItemCode { get; set; }
    }

    public enum Code
    {
        A,
        B,
        C,
        D,
        E
    }
}
