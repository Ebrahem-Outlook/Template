using Domain.Abstractions;

namespace Domain.Products.Events;

/// <summary>
/// Represents the <see cref="ProductUpdatedDomainEvent"/> record.
/// </summary>
public sealed record ProductUpdatedDomainEvent : DomainEvent
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ProductUpdatedDomainEvent"/> record.
    /// </summary>
    /// <param name="productId">The identifier of product.</param>
    /// <param name="name">The name of product.</param>
    /// <param name="description">The description of product.</param>
    /// <param name="price">The price of product.</param>
    /// <param name="stock">The stock of product.</param>
    public ProductUpdatedDomainEvent(Guid productId, string name, string description, decimal price, int stock)
        : base(Guid.NewGuid(), DateTime.UtcNow)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }


    /// <summary>
    /// Gets the identifier of product created.
    /// /// </summary>
    public Guid ProductId { get; }

    /// <summary>
    /// Gets the Name of product created.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of product created.
    /// </summary>
    public string Description { get; } 
    
    /// <summary>
    /// Gets the price of product created.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// Gets the stock of product created.
    /// </summary>
    public int Stock { get; }
}
