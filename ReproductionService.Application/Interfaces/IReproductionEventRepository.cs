using ReproductionService.Domain.Entities;
using ReproductionService.Domain.Enums;

namespace ReproductionService.Application.Interfaces;

public interface IReproductionEventRepository
{
    Task<ReproductionEvent?> GetByIdAsync(long id, CancellationToken ct = default);
    Task<IEnumerable<ReproductionEvent>> GetByAnimalIdAsync(long animalId, int page, int pageSize, CancellationToken ct = default);
    Task<IEnumerable<ReproductionEvent>> GetByFarmIdAsync(int farmId, DateTime? from, DateTime? to, int page, int pageSize, CancellationToken ct = default);
    Task<IEnumerable<ReproductionEvent>> GetByTypeAsync(ReproductionEventType type, int farmId, int page, int pageSize, CancellationToken ct = default);
    Task<ReproductionEvent> AddAsync(ReproductionEvent reproductionEvent, CancellationToken ct = default);
    Task UpdateAsync(ReproductionEvent reproductionEvent, CancellationToken ct = default);
}
