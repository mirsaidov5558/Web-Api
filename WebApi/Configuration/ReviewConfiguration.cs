using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Rating).HasMaxLength(50);
            builder.Property(x => x.Comment).HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


                
                
        }
    }
}
