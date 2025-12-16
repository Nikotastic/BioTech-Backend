using Microsoft.EntityFrameworkCore;
using ReproductionService.Application.Interfaces;
using ReproductionService.Domain.Entities;
using ReproductionService.Domain.Enums;
using ReproductionService.Infrastructure.Persistence;

namespace ReproductionService.Infrastructure.Repositories;

public class ReproductionEventRepository : IReproductionEventRepository
{
    private readonly ReproductionDbContext _context;

    public ReproductionEventRepository(ReproductionDbContext context)
    {
        _context = context;
    }

    public async Task<ReproductionEvent?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _context.ReproductionEvents
            .FirstOrDefaultAsync(e => e.Id == id, ct);
    }

    public async Task<IEnumerable<ReproductionEvent>> GetByAnimalIdAsync(long animalId, int page, int pageSize, CancellationToken ct = default)
    {
        return await _context.ReproductionEvents
            .Where(e => e.AnimalId == animalId && !e.IsCancelled)
            .OrderByDescending(e => e.EventDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<ReproductionEvent>> GetByFarmIdAsync(int farmId, DateTime? from, DateTime? to, int page, int pageSize, CancellationToken ct = default)
    {
        var query = _context.ReproductionEvents
            .Where(e => e.FarmId == farmId && !e.IsCancelled);

        if (from.HasValue)
            query = query.Where(e => e.EventDate >= from.Value.Date);

        if (to.HasValue)
            query = query.Where(e => e.EventDate <= to.Value.Date);

        return await query
            .OrderByDescending(e => e.EventDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<ReproductionEvent>> GetByTypeAsync(ReproductionEventType type, int farmId, int page, int pageSize, CancellationToken ct = default)
    {
        return await _context.ReproductionEvents
            .Where(e => e.EventType == type && e.FarmId == farmId && !e.IsCancelled)
            .OrderByDescending(e => e.EventDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<ReproductionEvent> AddAsync(ReproductionEvent reproductionEvent, CancellationToken ct = default)
    {
        await _context.ReproductionEvents.AddAsync(reproductionEvent, ct);
        await _context.SaveChangesAsync(ct);
        return reproductionEvent;
    }

    public async Task UpdateAsync(ReproductionEvent reproductionEvent, CancellationToken ct = default)
    {
        _context.ReproductionEvents.Update(reproductionEvent);
        await _context.SaveChangesAsync(ct);
    }
}
