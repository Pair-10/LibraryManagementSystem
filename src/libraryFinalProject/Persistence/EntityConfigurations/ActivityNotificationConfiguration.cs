using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ActivityNotificationConfiguration : IEntityTypeConfiguration<ActivityNotification>
{
    public void Configure(EntityTypeBuilder<ActivityNotification> builder)
    {
        builder.ToTable("ActivityNotifications").HasKey(an => an.Id);

        builder.Property(an => an.Id).HasColumnName("Id").IsRequired();
        builder.Property(an => an.ActivityId).HasColumnName("ActivityId");
        builder.Property(an => an.NotificationId).HasColumnName("NotificationId");
        builder.Property(an => an.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(an => an.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(an => an.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(an => !an.DeletedDate.HasValue);
    }
}