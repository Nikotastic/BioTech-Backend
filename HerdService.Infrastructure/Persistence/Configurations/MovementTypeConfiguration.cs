using HerdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HerdService.Infrastructure.Persistence.Configurations;

public class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>
{
    public void Configure(EntityTypeBuilder<MovementType> builder)
    {
        builder.ToTable("movement_types");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(e => e.Description).HasColumnName("description").HasColumnType("text");

        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp with time zone");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");

        builder.HasIndex(e => e.Name).IsUnique();
    }
}
