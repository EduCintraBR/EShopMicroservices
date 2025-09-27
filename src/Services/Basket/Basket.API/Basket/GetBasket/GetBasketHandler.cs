using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketRequest(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart cart);

    public class GetBasketQueryHandler : IQueryHandler<GetBasketRequest, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketRequest request, CancellationToken cancellationToken)
        {
            //TODO: Implement actual logic to get basket from database or cache
            // var basket = await _repository.GetBasketAsync(request.UserName);

            return new GetBasketResult(new ShoppingCart("swn"));
        }
    }
}
