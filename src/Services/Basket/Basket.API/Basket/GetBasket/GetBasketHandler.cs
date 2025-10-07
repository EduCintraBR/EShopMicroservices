namespace Basket.API.Basket.GetBasket
{
    public record GetBasketRequest(string UserName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);

    public class GetBasketQueryHandler(IBasketRepository repository)
        : IQueryHandler<GetBasketRequest, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketRequest request, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasketAsync(request.UserName);

            return new GetBasketResult(basket);
        }
    }
}
