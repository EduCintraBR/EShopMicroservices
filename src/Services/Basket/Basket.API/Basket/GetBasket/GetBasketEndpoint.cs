namespace Basket.API.Basket.GetBasket
{
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var query = new GetBasketRequest(userName);

                //var basket = await repository.GetBasket(userName);

                var result = await sender.Send(query);

                var response = result.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            });
        }
    }
}
