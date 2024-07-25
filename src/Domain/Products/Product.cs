using Domain.Abstractions;
using Domain.Products.Events;

namespace Domain.Products;

/// <summary>
/// Represents the Product AggregateRoot.
/// </summary>
public sealed class Product : AggregateRoot, IAuditable
{
    /// <summary>
    /// Initialize a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="description">The description of the product.</param>
    /// <param name="price">The price of the product.</param>
    /// <param name="stock">The stock of the product.</param>
    private Product(string name, string description, decimal price, int stock)
        : base(Guid.NewGuid())
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
    
    /// <summary>
    /// Required by EFCore.
    /// </summary>
    private Product() { }

    /// <summary>
    /// Gets or Sets the Name of product.
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// Gets or Sets the Description of product.
    /// </summary>
    public string Description { get; private set; } = default!;

    /// <summary>
    /// Gets or Sets the Price of product.
    /// </summary>
    public decimal Price { get; private set; } 

    /// <summary>
    /// Gets or Sets the Stock of product.
    /// </summary>
    public int Stock { get; private set; }

    /// <summary>
    /// Gets or Sets the created Date Time of product.
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or Sets the Modified Date Time of product.
    /// </summary>
    public DateTime? ModifiedOnUtc { get; set; }

    /// <summary>
    /// Create a new instance of <see cref="Product"/> class.
    /// </summary>
    /// <param name="name">The name of product.</param>
    /// <param name="description">The description of product.</param>
    /// <param name="price">The price of product.</param>
    /// <param name="stock">The stock of product.</param>
    /// <returns>The new Instance of the <see cref="Product"/> class.</returns>
    public static Product Create(string name, string description, decimal price, int stock)
    {
        Product product = new Product(name, description, price, stock);

        // Raise Domain Event.....
        product.RaiseDomainEvent(new ProductUpdatedDomainEvent(product.Id, product.Name, product.Description, product.Price, product.Stock));

        return product;
    }

    /// <summary>
    /// Update the <see cref="Product"/> filed.
    /// </summary>
    /// <param name="name">The new name of product.</param>
    /// <param name="description">The new description of product.</param>
    /// <param name="price">The new price of product.</param>
    /// <param name="stock">The new Stock of product.</param>
    public void Update(string name, string description, decimal price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;

        // Raise Domain Event.....
        RaiseDomainEvent(new ProductUpdatedDomainEvent(Id, Name, Description, Price, Stock));
    }
}
