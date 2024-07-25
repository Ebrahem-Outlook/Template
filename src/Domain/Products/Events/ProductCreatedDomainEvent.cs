using Domain.Abstractions;

namespace Domain.Products.Events;

/// <summary>
/// Represents the <see cref="ProductCreatedDomainEvent"/> record.
/// </summary>
public sealed record ProductCreatedDomainEvent : DomainEvent
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ProductCreatedDomainEvent"/> record.
    /// </summary>
    /// <param name="name">The name of product.</param>
    /// <param name="description">The description of product.</param>
    /// <param name="price">The price of product.</param>
    /// <param name="stock">The stock of product.</param>
    public ProductCreatedDomainEvent(string name, string description, decimal price, int stock)
        : base(Guid.NewGuid(), DateTime.UtcNow)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    /// <summary>
    /// Gets the name of product created.
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
