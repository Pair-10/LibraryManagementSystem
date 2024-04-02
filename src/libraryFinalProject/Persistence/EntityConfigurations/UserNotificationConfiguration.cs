using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.ToTable("UserNotifications").HasKey(un => un.Id);

        builder.Property(un => un.Id).HasColumnName("Id").IsRequired();
        builder.Property(un => un.UserId).HasColumnName("UserId");
        builder.Property(un => un.NotificationId).HasColumnName("NotificationId");
        builder.Property(un => un.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(un => un.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(un => un.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(un => !un.DeletedDate.HasValue);
    }
}