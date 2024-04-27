using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
{
    public void Configure(EntityTypeBuilder<CategoryType> builder)
    {
        builder.ToTable("CategoryTypes").HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id).HasColumnName("Id").IsRequired();
        builder.Property(ct => ct.MaterialId).HasColumnName("MaterialId");
        builder.Property(ct => ct.CategoryId).HasColumnName("CategoryId");
        builder.Property(ct => ct.MaterialTypeId).HasColumnName("MaterialTypeId");
        builder.Property(ct => ct.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ct => ct.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ct => ct.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ct => !ct.DeletedDate.HasValue);
    }
}