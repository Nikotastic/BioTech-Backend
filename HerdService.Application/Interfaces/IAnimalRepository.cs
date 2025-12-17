using HerdService.Domain.Entities;

namespace HerdService.Application.Interfaces;

public interface IAnimalRepository
{
    Task<Animal?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<Animal?> GetByVisualCodeAsync(string visualCode, int farmId, CancellationToken ct = default);
    Task<IEnumerable<Animal>> GetByFarmIdAsync(int farmId, string? status, bool includeInactive, CancellationToken ct = default);
    Task<IEnumerable<Animal>> GetByBatchIdAsync(int batchId, CancellationToken ct = default);
    Task<IEnumerable<Animal>> GetByPaddockIdAsync(int paddockId, CancellationToken ct = default);
    Task<Animal> AddAsync(Animal animal, CancellationToken ct = default);
    Task UpdateAsync(Animal animal, CancellationToken ct = default);
    Task DeleteAsync(Animal animal, CancellationToken ct = default);
    Task<bool> VisualCodeExistsAsync(string visualCode, int farmId, CancellationToken ct = default);
}
