using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("Activities").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.ActivityDate).HasColumnName("ActivityDate");
        builder.Property(a => a.Desc).HasColumnName("Desc");
        builder.Property(a => a.Status).HasColumnName("Status");
        builder.Property(a => a.ActivityName).HasColumnName("ActivityName");
        builder.Property(a => a.Location).HasColumnName("Location");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}