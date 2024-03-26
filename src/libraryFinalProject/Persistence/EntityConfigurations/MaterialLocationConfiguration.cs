using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialLocationConfiguration : IEntityTypeConfiguration<MaterialLocation>
{
    public void Configure(EntityTypeBuilder<MaterialLocation> builder)
    {
        builder.ToTable("MaterialLocations").HasKey(ml => ml.Id);

        builder.Property(ml => ml.Id).HasColumnName("Id").IsRequired();
        builder.Property(ml => ml.LocationId).HasColumnName("LocationId");
        builder.Property(ml => ml.MaterialId).HasColumnName("MaterialId");
        builder.Property(ml => ml.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ml => ml.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ml => ml.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ml => !ml.DeletedDate.HasValue);
    }
}