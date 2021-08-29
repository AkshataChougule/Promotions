using Promotions.Core.Dto;
using Promotions.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotions.Repositories
{
    public interface IPromotionRepository
    {
        Task<IList<Promotion>> FetchEligiblePromotions(IList<CartItemDto> cartItems);
    }
}
