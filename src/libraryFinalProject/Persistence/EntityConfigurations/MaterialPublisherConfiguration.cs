using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaterialPublisherConfiguration : IEntityTypeConfiguration<MaterialPublisher>
{
    public void Configure(EntityTypeBuilder<MaterialPublisher> builder)
    {
        builder.ToTable("MaterialPublishers").HasKey(mp => mp.Id);

        builder.Property(mp => mp.Id).HasColumnName("Id").IsRequired();
        builder.Property(mp => mp.MaterialId).HasColumnName("MaterialId");
        builder.Property(mp => mp.PuslisherId).HasColumnName("PuslisherId");
        builder.Property(mp => mp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mp => mp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mp => mp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mp => !mp.DeletedDate.HasValue);
    }
}