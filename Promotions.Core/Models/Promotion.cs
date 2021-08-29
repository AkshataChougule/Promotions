using Promotions.Core.Dto;
using System.Collections.Generic;

namespace Promotions.Core.Models
{
    public class Promotion
    {
        public List<CartItemDto> PromotionItems { get; set; }
        public int Difference { get; set; }
        public bool CanPromotionBeApplied { get; set; }
        public bool IsActive { get; set; }
        public int Price { get; set; }
    }
}
