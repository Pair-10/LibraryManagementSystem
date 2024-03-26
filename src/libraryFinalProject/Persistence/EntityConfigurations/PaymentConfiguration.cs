using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.UserId).HasColumnName("UserId");
        builder.Property(p => p.PaymentTypeId).HasColumnName("PaymentTypeId");
        builder.Property(p => p.PaymentPrice).HasColumnName("PaymentPrice");
        builder.Property(p => p.Desc).HasColumnName("Desc");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

        builder.HasOne(p => p.Penalty)
       .WithOne(p => p.Payment)
       .HasForeignKey<Penalty>(p => p.PaymentId);
    }
}