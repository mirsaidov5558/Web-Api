using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(255); 

            builder.Property(x => x.Description).HasMaxLength(255);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)") 
                .IsRequired();

            builder.HasOne(x => x.Category) // Один продукт принадлежит одной категории
                .WithMany(c => c.Products)  // Одна категория может содержать много продуктов
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OrderItems)
                .WithOne(r => r.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
