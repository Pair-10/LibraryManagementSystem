using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications").HasKey(n => n.Id);

        builder.Property(n => n.Id).HasColumnName("Id").IsRequired();
        builder.Property(n => n.NotificationDesc).HasColumnName("NotificationDesc");
        builder.Property(n => n.NotificationType).HasColumnName("NotificationType");
        builder.Property(n => n.NotificationStatus).HasColumnName("NotificationStatus");
        builder.Property(n => n.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(n => n.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(n => n.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(n => !n.DeletedDate.HasValue);
    }
}