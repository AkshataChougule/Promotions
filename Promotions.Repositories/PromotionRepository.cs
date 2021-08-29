using Promotions.Core.Dto;
using Promotions.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotions.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        public async Task<IList<Promotion>> FetchEligiblePromotions(IList<CartItemDto> cartItems)
        {
            var promotions = await FetchAllPromotions();
            foreach (var item in cartItems)
            {
                foreach (var promotion in promotions)
                {
                    var promotionItem = promotion.PromotionItems.Where(x => x.CartItemCode == item.CartItemCode).FirstOrDefault();
                    if (promotionItem?.Quantity <= item.Quantity)
                    {
                        promotion.CanPromotionBeApplied = true;
                        continue;
                    }
                }
            }
            var eligiblePromotions = promotions.Where(x => x.CanPromotionBeApplied == true).ToList();
            return eligiblePromotions;
        }
        public async Task<IList<Promotion>> FetchAllPromotions()
        {
            List<Promotion> promotions = new List<Promotion>();
            promotions.Add(new Promotion
            {
                PromotionItems = new List<CartItemDto>() { new CartItemDto(Code.A) { Quantity = 3 } },
                IsActive = true,
                Price = 130
            });
            promotions.Add(new Promotion
            {
                PromotionItems = new List<CartItemDto>() { new CartItemDto(Code.B) { Quantity = 2 } },
                IsActive = true,
                Price = 45
            });
            promotions.Add(new Promotion
            {
                PromotionItems = new List<CartItemDto>() { new CartItemDto(Code.A) { Quantity = 3 },
                new CartItemDto(Code.B) { Quantity = 3 }},
                IsActive = true,
                Price = 130
            });
            promotions.Add(new Promotion
            {
                PromotionItems = new List<CartItemDto>() { new CartItemDto(Code.D) { Quantity = 2 } },
                IsActive = true,
                Price = 20
            });
            promotions.Add(new Promotion
            {
                PromotionItems = new List<CartItemDto>() { new CartItemDto(Code.C) {  Quantity = 1 } ,
                new CartItemDto(Code.D) { Quantity = 1 }},
                IsActive = true,
                Price = 15
            });
            CalculateDifferenceValueForPromotions(promotions);
            return promotions;
        }

        private void CalculateDifferenceValueForPromotions(IList<Promotion> promotions)
        {
            foreach (var promotion in promotions)
            {
                var totalProductValueAtUnitPrice = promotion.PromotionItems.Select(x => x.Quantity * x.UnitPrice).Sum();
                promotion.Difference = totalProductValueAtUnitPrice - promotion.Price;
            }
        }

       
    }
}
