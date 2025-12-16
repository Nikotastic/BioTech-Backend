using HerdService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HerdService.Infrastructure.Persistence;

public class HerdDbContext : DbContext
{
    public HerdDbContext(DbContextOptions<HerdDbContext> options) : base(options)
    {
    }

    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<Batch> Batches => Set<Batch>();
    public DbSet<AnimalCategory> AnimalCategories => Set<AnimalCategory>();
    public DbSet<Breed> Breeds => Set<Breed>();
    public DbSet<Paddock> Paddocks => Set<Paddock>();
    public DbSet<MovementType> MovementTypes => Set<MovementType>();
    public DbSet<AnimalMovement> AnimalMovements => Set<AnimalMovement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
