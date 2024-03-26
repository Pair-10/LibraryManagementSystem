using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.TotalPrice).HasColumnName("TotalPrice");
        builder.Property(o => o.Status).HasColumnName("Status");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
        builder.HasOne(i => i.Invoice)
       .WithOne(o => o.Order)
       .HasForeignKey<Invoice>(i => i.OrderId);

        builder.HasOne(p => p.Payment) 
       .WithOne(o => o.Order) 
       .HasForeignKey<Payment>(p => p.OrderId);
    }
}