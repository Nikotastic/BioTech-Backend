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

        builder.Property(e => e.AffectsInventory).HasColumnName("affects_inventory").HasDefaultValue(false);
        builder.Property(e => e.InventorySign).HasColumnName("inventory_sign").HasDefaultValue(0);

        builder.HasIndex(e => e.Name).IsUnique();
    }
}
