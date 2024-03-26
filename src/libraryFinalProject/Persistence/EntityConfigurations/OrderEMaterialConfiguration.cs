using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderEMaterialConfiguration : IEntityTypeConfiguration<OrderEMaterial>
{
    public void Configure(EntityTypeBuilder<OrderEMaterial> builder)
    {
        builder.ToTable("OrderEMaterials").HasKey(oem => oem.Id);

        builder.Property(oem => oem.Id).HasColumnName("Id").IsRequired();
        builder.Property(oem => oem.EMaterialId).HasColumnName("EMaterialId");
        builder.Property(oem => oem.OrderId).HasColumnName("OrderId");
        builder.Property(oem => oem.QuantityPrice).HasColumnName("QuantityPrice");
        builder.Property(oem => oem.Quantity).HasColumnName("Quantity");
        builder.Property(oem => oem.TotalPrice).HasColumnName("TotalPrice");
        builder.Property(oem => oem.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oem => oem.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oem => oem.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oem => !oem.DeletedDate.HasValue);
    }
}