using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> builder)
    {
        builder.ToTable("PaymentTypes").HasKey(pt => pt.Id);

        builder.Property(pt => pt.Id).HasColumnName("Id").IsRequired();
        builder.Property(pt => pt.Name).HasColumnName("Name");
        builder.Property(pt => pt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pt => pt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pt => pt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pt => !pt.DeletedDate.HasValue);
    }
}