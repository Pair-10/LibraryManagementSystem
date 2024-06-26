using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ReturnedConfiguration : IEntityTypeConfiguration<Returned>
{
    public void Configure(EntityTypeBuilder<Returned> builder)
    {
        builder.ToTable("Returneds").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.BorrowedMaterialId).HasColumnName("BorrowedMaterialId");
        builder.Property(r => r.IsPenalised).HasColumnName("IsPenalised");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);

        builder.HasOne(r => r.Penalty)
       .WithOne(p => p.Returned)
       .HasForeignKey<Penalty>(p => p.ReturnedId).OnDelete(DeleteBehavior.Restrict);
    }
}