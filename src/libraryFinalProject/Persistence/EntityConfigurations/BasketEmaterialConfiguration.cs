using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BasketEmaterialConfiguration : IEntityTypeConfiguration<BasketEmaterial>
{
    public void Configure(EntityTypeBuilder<BasketEmaterial> builder)
    {
        builder.ToTable("BasketEmaterials").HasKey(be => be.Id);

        builder.Property(be => be.Id).HasColumnName("Id").IsRequired();
        builder.Property(be => be.EmaterialId).HasColumnName("EmeterialId");
        builder.Property(be => be.BasketId).HasColumnName("BasketId");
        builder.Property(be => be.TotalPrice).HasColumnName("TotalPrice");
        builder.Property(be => be.Quantity).HasColumnName("Quantity");
        builder.Property(be => be.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(be => be.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(be => be.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(be => !be.DeletedDate.HasValue);
    }
}