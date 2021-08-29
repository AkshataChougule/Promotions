using Promotions.Core.Models;
using System.Collections.Generic;

namespace Promotions.Core.Dto
{
    public class CartDto
    {
        public List<CartItemDto> CartItems { get; set; }
        public int CartValue { get; set; }
    }

    public class CartItemDto
    {
        public CartItemDto(Code code)
        {
            CartItemCode = code;
        }
        public Code CartItemCode { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get {  return FetchUnitPrice();  } }
        private int FetchUnitPrice()
        {
            switch (CartItemCode)
            {
                case Code.A:
                    return 50;
                case Code.B:
                    return 30;
                case Code.C:
                    return 20;
                case Code.D:
                    return 15;
                default:
                    return 0;
            }
        }
    }
}
