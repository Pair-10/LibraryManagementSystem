using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserActivityConfiguration : IEntityTypeConfiguration<UserActivity>
{
    public void Configure(EntityTypeBuilder<UserActivity> builder)
    {
        builder.ToTable("UserActivities").HasKey(ua => ua.Id);

        builder.Property(ua => ua.Id).HasColumnName("Id").IsRequired();
        builder.Property(ua => ua.UserId).HasColumnName("UserId");
        builder.Property(ua => ua.ActivityId).HasColumnName("ActivityId");
        builder.Property(ua => ua.ParticipationStatus).HasColumnName("ParticipationStatus");
        builder.Property(ua => ua.ParticipationDate).HasColumnName("ParticipationDate");
        builder.Property(ua => ua.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ua => ua.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ua => ua.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ua => !ua.DeletedDate.HasValue);
    }
}