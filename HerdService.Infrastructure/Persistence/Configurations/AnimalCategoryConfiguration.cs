using HerdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HerdService.Infrastructure.Persistence.Configurations;

public class AnimalCategoryConfiguration : IEntityTypeConfiguration<AnimalCategory>
{
    public void Configure(EntityTypeBuilder<AnimalCategory> builder)
    {
        builder.ToTable("animal_categories");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(e => e.Description).HasColumnName("description").HasColumnType("text");
        builder.Property(e => e.Sex).HasColumnName("sex").HasMaxLength(1);
        builder.Property(e => e.MinAgeMonths).HasColumnName("min_age_months").HasDefaultValue(0);
        builder.Property(e => e.MaxAgeMonths).HasColumnName("max_age_months");

        // Audit removed

        builder.HasIndex(e => e.Name).IsUnique();
    }
}
