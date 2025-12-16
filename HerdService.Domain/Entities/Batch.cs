using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class Batch : IAuditableEntity
{
    public int Id { get; private set; }
    public int FarmId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }

    private Batch() { }

    public Batch(int farmId, string name, string? description)
    {
        if (farmId <= 0) throw new ArgumentException("Invalid FarmId");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");

        FarmId = farmId;
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}
