using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EmaterialInvoiceConfiguration : IEntityTypeConfiguration<EmaterialInvoice>
{
    public void Configure(EntityTypeBuilder<EmaterialInvoice> builder)
    {
        builder.ToTable("EmaterialInvoices").HasKey(ei => ei.Id);

        builder.Property(ei => ei.Id).HasColumnName("Id").IsRequired();
        builder.Property(ei => ei.EmaterialId).HasColumnName("EmaterialId");
        builder.Property(ei => ei.InvoiceId).HasColumnName("InvoiceId");
        builder.Property(ei => ei.Quantity).HasColumnName("Quantity");
        builder.Property(ei => ei.QuantityPrice).HasColumnName("QuantityPrice");
        builder.Property(ei => ei.TotalPrice).HasColumnName("TotalPrice");
        builder.Property(ei => ei.PaymentType).HasColumnName("PaymentType");
        builder.Property(ei => ei.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ei => ei.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ei => ei.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ei => !ei.DeletedDate.HasValue);
    }
}