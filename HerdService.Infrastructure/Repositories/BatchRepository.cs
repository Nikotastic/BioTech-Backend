using HerdService.Application.Interfaces;
using HerdService.Domain.Entities;
using HerdService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HerdService.Infrastructure.Repositories;

public class BatchRepository : IBatchRepository
{
    private readonly HerdDbContext _context;

    public BatchRepository(HerdDbContext context)
    {
        _context = context;
    }

    public async Task<Batch?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Batches.FindAsync(new object[] { id }, ct);
    }

    public async Task<IEnumerable<Batch>> GetByFarmIdAsync(int farmId, bool includeInactive, CancellationToken ct = default)
    {
        var query = _context.Batches.AsNoTracking().Where(b => b.FarmId == farmId);
        
        if (!includeInactive)
            query = query.Where(b => b.IsActive);
            
        return await query.ToListAsync(ct);
    }

    public async Task<Batch> AddAsync(Batch batch, CancellationToken ct = default)
    {
        var entry = await _context.Batches.AddAsync(batch, ct);
        await _context.SaveChangesAsync(ct);
        return entry.Entity;
    }

    public async Task UpdateAsync(Batch batch, CancellationToken ct = default)
    {
        _context.Batches.Update(batch);
        await _context.SaveChangesAsync(ct);
    }
}
