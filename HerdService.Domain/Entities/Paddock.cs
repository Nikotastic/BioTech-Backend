using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class Paddock : IAuditableEntity
{
    public int Id { get; private set; }
    public int FarmId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int? Capacity { get; private set; }
    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }

    private Paddock() { }

    public Paddock(int farmId, string name, int? capacity)
    {
        if (farmId <= 0) throw new ArgumentException("Invalid FarmId");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");

        FarmId = farmId;
        Name = name;
        Capacity = capacity;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}
