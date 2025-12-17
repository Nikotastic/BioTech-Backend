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

        builder.Property(e => e.FarmId).HasColumnName("farm_id").IsRequired();
        builder.Property(e => e.AnimalId).HasColumnName("animal_id").IsRequired();
        builder.Property(e => e.MovementTypeId).HasColumnName("movement_type_id").IsRequired();
        builder.Property(e => e.MovementDate).HasColumnName("movement_date").HasColumnType("date").HasDefaultValueSql("CURRENT_DATE");

        builder.Property(e => e.PreviousBatchId).HasColumnName("previous_batch_id");
        builder.Property(e => e.NewBatchId).HasColumnName("new_batch_id");
        builder.Property(e => e.PreviousPaddockId).HasColumnName("previous_paddock_id");
        builder.Property(e => e.NewPaddockId).HasColumnName("new_paddock_id");

        builder.Property(e => e.ThirdPartyId).HasColumnName("third_party_id");
        builder.Property(e => e.TransactionValue).HasColumnName("transaction_value").HasColumnType("numeric(12,2)").HasDefaultValue(0m);
        builder.Property(e => e.WeightAtMovement).HasColumnName("weight_at_movement").HasColumnType("numeric(6,2)");

        builder.Property(e => e.Observations).HasColumnName("observations").HasColumnType("text");
        builder.Property(e => e.RegisteredBy).HasColumnName("registered_by");

        builder.HasOne(e => e.MovementType)
            .WithMany()
            .HasForeignKey(e => e.MovementTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.PreviousBatch)
            .WithMany()
            .HasForeignKey(e => e.PreviousBatchId);

        builder.HasOne(e => e.NewBatch)
            .WithMany()
            .HasForeignKey(e => e.NewBatchId);

        builder.HasOne(e => e.PreviousPaddock)
            .WithMany()
            .HasForeignKey(e => e.PreviousPaddockId);

        builder.HasOne(e => e.NewPaddock)
            .WithMany()
            .HasForeignKey(e => e.NewPaddockId);
    }
}
