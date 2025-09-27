namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid id) : ICommand<DeleteProductHandlerResult>;
    public record DeleteProductHandlerResult(bool Success);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("Product ID is required.");
        }
    }

    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductHandlerResult>
    {
        public async Task<DeleteProductHandlerResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", command);

            var product = await session.LoadAsync<Product>(command.id, cancellationToken);
            
            if (product is null)
            {
                throw new ProductNotFoundException(command.id);
            }

            session.Delete(product);
            await session.SaveChangesAsync();

            return new DeleteProductHandlerResult(true);
        }
    }
}
