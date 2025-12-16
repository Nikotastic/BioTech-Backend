using HerdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HerdService.Infrastructure.Persistence.Configurations;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("animals");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.TagNumber)
            .HasColumnName("tag_number")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.ElectronicId)
            .HasColumnName("electronic_id")
            .HasMaxLength(50);

        builder.Property(e => e.FarmId).HasColumnName("farm_id").IsRequired();
        builder.Property(e => e.BreedId).HasColumnName("breed_id").IsRequired();
        builder.Property(e => e.CategoryId).HasColumnName("category_id").IsRequired();
        builder.Property(e => e.BatchId).HasColumnName("batch_id");
        builder.Property(e => e.PaddockId).HasColumnName("paddock_id");

        builder.Property(e => e.BirthDate).HasColumnName("birth_date").HasColumnType("date").IsRequired();
        builder.Property(e => e.Sex).HasColumnName("sex").HasMaxLength(10).IsRequired();
        
        builder.Property(e => e.BirthWeight).HasColumnName("birth_weight").HasColumnType("decimal(10,2)");
        builder.Property(e => e.CurrentWeight).HasColumnName("current_weight").HasColumnType("decimal(10,2)");
        builder.Property(e => e.LastWeightDate).HasColumnName("last_weight_date").HasColumnType("date");

        builder.Property(e => e.MotherId).HasColumnName("mother_id");
        builder.Property(e => e.FatherId).HasColumnName("father_id");

        builder.Property(e => e.Status).HasColumnName("status").HasMaxLength(50).IsRequired();
        builder.Property(e => e.StatusDate).HasColumnName("status_date").HasColumnType("date");
        builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);

        builder.Property(e => e.PurchasePrice).HasColumnName("purchase_price").HasColumnType("decimal(12,2)");
        builder.Property(e => e.SalePrice).HasColumnName("sale_price").HasColumnType("decimal(12,2)");
        builder.Property(e => e.SaleDate).HasColumnName("sale_date").HasColumnType("date");
        builder.Property(e => e.Notes).HasColumnName("notes").HasColumnType("text");

        // Audit
        builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone").HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp with time zone");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");

        // Indexes
        builder.HasIndex(e => new { e.FarmId, e.TagNumber }).IsUnique().HasDatabaseName("ix_animals_farm_tag");
        builder.HasIndex(e => e.FarmId).HasDatabaseName("ix_animals_farm_id");
        builder.HasIndex(e => e.BatchId).HasDatabaseName("ix_animals_batch_id");
        builder.HasIndex(e => e.Status).HasDatabaseName("ix_animals_status");
        builder.HasIndex(e => new { e.FarmId, e.IsActive }).HasDatabaseName("ix_animals_farm_active");

        // Relationships
        builder.HasOne(e => e.Breed)
            .WithMany()
            .HasForeignKey(e => e.BreedId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Batch)
            .WithMany()
            .HasForeignKey(e => e.BatchId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Paddock)
            .WithMany()
            .HasForeignKey(e => e.PaddockId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Mother)
            .WithMany()
            .HasForeignKey(e => e.MotherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Father)
            .WithMany()
            .HasForeignKey(e => e.FatherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Movements)
            .WithOne(m => m.Animal)
            .HasForeignKey(m => m.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
