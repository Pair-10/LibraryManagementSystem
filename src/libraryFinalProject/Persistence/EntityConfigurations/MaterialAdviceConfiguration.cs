using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialAdviceConfiguration : IEntityTypeConfiguration<MaterialAdvice>
{
    public void Configure(EntityTypeBuilder<MaterialAdvice> builder)
    {
        builder.ToTable("MaterialAdvices").HasKey(ma => ma.Id);

        builder.Property(ma => ma.Id).HasColumnName("Id").IsRequired();
        builder.Property(ma => ma.UserId).HasColumnName("UserId");
        builder.Property(ma => ma.AuthorName).HasColumnName("AuthorName");
        builder.Property(ma => ma.Status).HasColumnName("Status");
        builder.Property(ma => ma.MaterialName).HasColumnName("MaterialName");
        builder.Property(ma => ma.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ma => ma.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ma => ma.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ma => !ma.DeletedDate.HasValue);
    }
}