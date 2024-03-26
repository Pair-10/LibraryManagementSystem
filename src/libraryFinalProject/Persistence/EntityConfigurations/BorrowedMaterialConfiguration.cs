using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BorrowedMaterialConfiguration : IEntityTypeConfiguration<BorrowedMaterial>
{
    public void Configure(EntityTypeBuilder<BorrowedMaterial> builder)
    {
        builder.ToTable("BorrowedMaterials").HasKey(bm => bm.Id);

        builder.Property(bm => bm.Id).HasColumnName("Id").IsRequired();
        builder.Property(bm => bm.MaterialId).HasColumnName("MaterialId");
        builder.Property(bm => bm.UserId).HasColumnName("UserId");
        builder.Property(bm => bm.Deadline).HasColumnName("Deadline");
        builder.Property(bm => bm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bm => bm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bm => bm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bm => !bm.DeletedDate.HasValue);
    }
}