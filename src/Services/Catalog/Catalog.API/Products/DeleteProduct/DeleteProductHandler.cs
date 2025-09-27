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

    internal class DeleteProductCommandHandler(IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductHandlerResult>
    {
        public async Task<DeleteProductHandlerResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            session.Delete(command.id);
            await session.SaveChangesAsync();

            return new DeleteProductHandlerResult(true);
        }
    }
}
