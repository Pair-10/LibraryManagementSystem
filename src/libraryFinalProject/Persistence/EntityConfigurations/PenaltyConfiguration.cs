using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder.ToTable("Penalties").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.PenaltyPrice).HasColumnName("PenaltyPrice");
        builder.Property(p => p.TotalPenaltyDays).HasColumnName("TotalPenaltyDays");
        builder.Property(p => p.PenaltyStatus).HasColumnName("PenaltyStatus");
        builder.Property(p => p.UserId).HasColumnName("UserId");
        builder.Property(p => p.MaterialId).HasColumnName("MaterialId");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);

        builder.HasOne(p => p.Payment)
       .WithOne(p => p.Penalty)
       .HasForeignKey<Payment>(p => p.PenaltyId);


    }
}