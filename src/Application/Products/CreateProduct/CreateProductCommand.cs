using Application.Abstractions.Messaging;
using Domain.Products;
using Marten;

namespace Application.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    List<string> Tages) : ICommand;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IDocumentSession _session;

    public CreateProductCommandHandler(IDocumentSession session)
    {
        _session = session;
    }

    public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = Product.Create(request.Name, request.Description, request.Price, request.Stock, request.Tages);

        _session.Store(product);

        _session.SaveChangesAsync();
    }
}