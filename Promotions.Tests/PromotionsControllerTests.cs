using Moq;
using NUnit.Framework;
using Promotions.Business.Handlers;
using Promotions.Controllers;
using Promotions.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotions.Tests
{
    [TestFixture]
    public class Tests
    {
        private  Mock<IPromotionsHandler> _PromotionHandlerMock;
        [SetUp]
        public void Setup()
        {
            _PromotionHandlerMock = new Mock<IPromotionsHandler>();
            _PromotionHandlerMock.Setup(x => x.FetchCartValue(It.IsAny<CartQuery>())).Returns(Task.FromResult(new CartValueResponse() { Msg="50"}));
        }

        [Test]
        public async Task When_Request_Is_Sent_To_Apply_Promotions_On_Cart_Which_Is_Ineligible_Returns_Original_Value_of_The_Cart()
        {
            CartQuery cart = new CartQuery
            {
                CartItems = new List<CartItem>()
            };
            cart.CartItems.Add(new CartItem()
            {
                CartItemCode = Code.A,
                Quantity = 1
            });
            PromotionsController promotionsController = new PromotionsController(_PromotionHandlerMock.Object);
            var result = await promotionsController.ApplyPromotions(cart);
            Assert.AreEqual(result.Msg, "50");
        }
    }
}