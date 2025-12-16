using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class MovementType : IAuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }

    private MovementType() { }

    public MovementType(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");

        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}
