using HerdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HerdService.Infrastructure.Persistence.Configurations;

public class PaddockConfiguration : IEntityTypeConfiguration<Paddock>
{
    public void Configure(EntityTypeBuilder<Paddock> builder)
    {
        builder.ToTable("paddocks");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.FarmId).HasColumnName("farm_id").IsRequired();
        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(e => e.Code).HasColumnName("code").HasMaxLength(20).IsRequired();
        builder.Property(e => e.AreaHectares).HasColumnName("area_hectares").HasColumnType("numeric(10,2)").HasDefaultValue(0m);
        builder.Property(e => e.GaugedCapacity).HasColumnName("gauged_capacity");
        builder.Property(e => e.GrassType).HasColumnName("grass_type").HasMaxLength(50);
        builder.Property(e => e.CurrentStatus).HasColumnName("current_status").HasDefaultValue("AVAILABLE");

        builder.HasIndex(e => new { e.FarmId, e.Code }).HasDatabaseName("uk_paddock_code_farm").IsUnique();

        // Audit removed
    }
}
