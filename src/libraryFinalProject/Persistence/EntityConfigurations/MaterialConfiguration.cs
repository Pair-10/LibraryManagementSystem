using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("Materials").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.PublicationDate).HasColumnName("PublicationDate");
        builder.Property(m => m.Language).HasColumnName("Language");
        builder.Property(m => m.PageCount).HasColumnName("PageCount");
        builder.Property(m => m.Status).HasColumnName("Status");
        builder.Property(m => m.MaterialName).HasColumnName("MaterialName");
        builder.Property(m => m.Quantity).HasColumnName("Quantity");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}