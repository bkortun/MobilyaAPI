using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BasketService
{
    public interface IBasketService
    {
        Task<Order> CloseBasketAsync(Basket basket);
        Task CreateNewActiveBasket(User user);
        Task CalculateAddedBasketItemAsync(BasketItem basketItem);
        Task CalculateRemovedBasketItemAsync(BasketItem basketItem);
        
    }
}
