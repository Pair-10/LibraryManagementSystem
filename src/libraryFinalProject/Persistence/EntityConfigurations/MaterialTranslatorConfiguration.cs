using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialTranslatorConfiguration : IEntityTypeConfiguration<MaterialTranslator>
{
    public void Configure(EntityTypeBuilder<MaterialTranslator> builder)
    {
        builder.ToTable("MaterialTranslators").HasKey(mt => mt.Id);

        builder.Property(mt => mt.Id).HasColumnName("Id").IsRequired();
        builder.Property(mt => mt.TranslatorId).HasColumnName("TranslatorId");
        builder.Property(mt => mt.MaterialId).HasColumnName("MaterialId");
        builder.Property(mt => mt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mt => mt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mt => mt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mt => !mt.DeletedDate.HasValue);
    }
}