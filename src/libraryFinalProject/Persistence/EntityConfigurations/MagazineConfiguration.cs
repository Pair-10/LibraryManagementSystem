using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MagazineConfiguration : IEntityTypeConfiguration<Magazine>
{
    public void Configure(EntityTypeBuilder<Magazine> builder)
    {
        builder.ToTable("Magazines").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.CategoryId).HasColumnName("CategoryId");
        builder.Property(m => m.ISSN).HasColumnName("ISSN");
        builder.Property(m => m.Issue).HasColumnName("Issue");
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}