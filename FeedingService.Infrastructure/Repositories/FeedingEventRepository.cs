using Microsoft.EntityFrameworkCore;
using FeedingService.Application.Interfaces;
using FeedingService.Domain.Entities;
using FeedingService.Infrastructure.Persistence;

namespace FeedingService.Infrastructure.Repositories;

public class FeedingEventRepository : IFeedingEventRepository
{
    private readonly FeedingDbContext _context;

    public FeedingEventRepository(FeedingDbContext context)
    {
        _context = context;
    }

    public async Task<FeedingEvent?> GetByIdAsync(long id, CancellationToken ct = default)
    {
        return await _context.FeedingEvents
            .FirstOrDefaultAsync(e => e.Id == id, ct);
    }

    public async Task<IEnumerable<FeedingEvent>> GetByFarmIdAsync(int farmId, DateTime? from, DateTime? to, int page, int pageSize, CancellationToken ct = default)
    {
        var query = _context.FeedingEvents
            .Where(e => e.FarmId == farmId && !e.IsCancelled);

        if (from.HasValue)
            query = query.Where(e => e.SupplyDate >= from.Value.Date);

        if (to.HasValue)
            query = query.Where(e => e.SupplyDate <= to.Value.Date);

        return await query
            .OrderByDescending(e => e.SupplyDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<FeedingEvent>> GetByBatchIdAsync(int batchId, int page, int pageSize, CancellationToken ct = default)
    {
        return await _context.FeedingEvents
            .Where(e => e.BatchId == batchId && !e.IsCancelled)
            .OrderByDescending(e => e.SupplyDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<FeedingEvent>> GetByAnimalIdAsync(long animalId, int page, int pageSize, CancellationToken ct = default)
    {
        return await _context.FeedingEvents
            .Where(e => e.AnimalId == animalId && !e.IsCancelled)
            .OrderByDescending(e => e.SupplyDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<IEnumerable<FeedingEvent>> GetByProductIdAsync(int productId, int page, int pageSize, CancellationToken ct = default)
    {
        return await _context.FeedingEvents
            .Where(e => e.ProductId == productId && !e.IsCancelled)
            .OrderByDescending(e => e.SupplyDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public async Task<FeedingEvent> AddAsync(FeedingEvent feedingEvent, CancellationToken ct = default)
    {
        await _context.FeedingEvents.AddAsync(feedingEvent, ct);
        await _context.SaveChangesAsync(ct);
        return feedingEvent;
    }

    public async Task UpdateAsync(FeedingEvent feedingEvent, CancellationToken ct = default)
    {
        _context.FeedingEvents.Update(feedingEvent);
        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(long id, CancellationToken ct = default)
    {
        var entity = await GetByIdAsync(id, ct);
        if (entity != null)
        {
            entity.Cancel();
            await UpdateAsync(entity, ct);
        }
    }
}