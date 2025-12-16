using HerdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HerdService.Infrastructure.Persistence.Configurations;

public class AnimalMovementConfiguration : IEntityTypeConfiguration<AnimalMovement>
{
    public void Configure(EntityTypeBuilder<AnimalMovement> builder)
    {
        builder.ToTable("animal_movements");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.AnimalId).HasColumnName("animal_id").IsRequired();
        builder.Property(e => e.MovementTypeId).HasColumnName("movement_type_id").IsRequired();
        builder.Property(e => e.FromPaddockId).HasColumnName("from_paddock_id");
        builder.Property(e => e.ToPaddockId).HasColumnName("to_paddock_id");
        builder.Property(e => e.MovementDate).HasColumnName("movement_date").HasColumnType("date").IsRequired();
        builder.Property(e => e.Notes).HasColumnName("notes").HasColumnType("text");

        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp with time zone");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");

        builder.HasOne(e => e.MovementType)
            .WithMany()
            .HasForeignKey(e => e.MovementTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FromPaddock)
            .WithMany()
            .HasForeignKey(e => e.FromPaddockId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ToPaddock)
            .WithMany()
            .HasForeignKey(e => e.ToPaddockId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
