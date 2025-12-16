using HerdService.Domain.Entities;

namespace HerdService.Application.Interfaces;

public interface IBatchRepository
{
    Task<Batch?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Batch>> GetByFarmIdAsync(int farmId, bool includeInactive, CancellationToken ct = default);
    Task<Batch> AddAsync(Batch batch, CancellationToken ct = default);
    Task UpdateAsync(Batch batch, CancellationToken ct = default);
}
