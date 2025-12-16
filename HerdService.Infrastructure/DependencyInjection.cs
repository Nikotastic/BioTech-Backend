using DotNetEnv;
using HerdService.Application.Interfaces;
using HerdService.Infrastructure.Persistence;
using HerdService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HerdService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext
        services.AddDbContext<HerdDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        // Repositories
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<IBreedRepository, BreedRepository>();
        services.AddScoped<IAnimalCategoryRepository, AnimalCategoryRepository>();
        services.AddScoped<IBatchRepository, BatchRepository>();
        services.AddScoped<IPaddockRepository, PaddockRepository>();
        services.AddScoped<IMovementTypeRepository, MovementTypeRepository>();
        services.AddScoped<IAnimalMovementRepository, AnimalMovementRepository>();
        // Add other repositories when implemented
        
        return services;
    }
}
