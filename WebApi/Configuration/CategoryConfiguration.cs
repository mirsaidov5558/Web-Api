using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); // Автоинкремент
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ParentCategoryId).IsRequired(false);
            
        }
    }
}
