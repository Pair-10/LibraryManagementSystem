using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmaterialConfiguration : IEntityTypeConfiguration<Ematerial>
{
    public void Configure(EntityTypeBuilder<Ematerial> builder)
    {
        builder.ToTable("Ematerials").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeId");
        builder.Property(e => e.Price).HasColumnName("Price");
        builder.Property(e => e.PdfUrl).HasColumnName("PdfUrl");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}