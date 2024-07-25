using Application.Products.CreateProduct;
using Carter;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Presentation.Contracts.Product;

namespace Presentation;

public sealed class ProductModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Product", async (CreateProductRequest request, ISender sender) =>
        {
            CreateProductCommand command = request.Adapt<CreateProductRequest>();

            Result result = await sender.Send(command);

            return Results.Ok();
        });
    }
}
