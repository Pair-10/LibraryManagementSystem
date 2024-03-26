using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("UserAddresses").HasKey(ua => ua.Id);

        builder.Property(ua => ua.Id).HasColumnName("Id").IsRequired();
        builder.Property(ua => ua.UserId).HasColumnName("UserId");
        builder.Property(ua => ua.AdressId).HasColumnName("AdressId");
        builder.Property(ua => ua.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ua => ua.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ua => ua.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ua => !ua.DeletedDate.HasValue);
    }
}