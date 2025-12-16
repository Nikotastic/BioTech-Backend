using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class Breed : IAuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Species { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }

    private Breed() { }

    public Breed(string name, string species)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
        if (string.IsNullOrWhiteSpace(species)) throw new ArgumentException("Species required");

        Name = name;
        Species = species;
        CreatedAt = DateTime.UtcNow;
    }
}
