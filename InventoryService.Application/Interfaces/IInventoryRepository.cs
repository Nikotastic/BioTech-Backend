using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryService.Domain.Entities;

namespace InventoryService.Application.Interfaces;

public interface IInventoryRepository
{
    Task<InventoryItem> GetByIdAsync(int id);
    Task<IEnumerable<InventoryItem>> GetByFarmIdAsync(int farmId, int page, int pageSize);
    Task AddAsync(InventoryItem item);
    Task UpdateAsync(InventoryItem item);
    Task DeleteAsync(InventoryItem item);
}
