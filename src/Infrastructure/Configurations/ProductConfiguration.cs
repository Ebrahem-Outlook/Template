using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "Template");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("Product_Name")
               .HasColumnOrder(1)
               .IsUnicode(false);

        builder.Property(p => p.Description)
               .IsRequired(false)
               .HasMaxLength(500)
               .HasColumnName("Product_Description")
               .IsUnicode(false);

        builder.Property(p => p.Price)
               .IsRequired()
               .HasColumnName<decimal>("Product_Price")
               .HasColumnType("decimal(18,2)")
               .HasPrecision(18, 2);
               

        builder.Property(p => p.Stock)
               .IsRequired()
               .HasColumnName("Product_Stock")
               .HasPrecision(3);
               


    }
}
