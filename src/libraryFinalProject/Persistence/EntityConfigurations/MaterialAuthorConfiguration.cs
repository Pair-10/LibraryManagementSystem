using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialAuthorConfiguration : IEntityTypeConfiguration<MaterialAuthor>
{
    public void Configure(EntityTypeBuilder<MaterialAuthor> builder)
    {
        builder.ToTable("MaterialAuthors").HasKey(ma => ma.Id);

        builder.Property(ma => ma.Id).HasColumnName("Id").IsRequired();
        builder.Property(ma => ma.MaterialId).HasColumnName("MaterialId");
        builder.Property(ma => ma.AuthorId).HasColumnName("AuthorId");
        builder.Property(ma => ma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ma => ma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ma => ma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ma => !ma.DeletedDate.HasValue);
    }
}