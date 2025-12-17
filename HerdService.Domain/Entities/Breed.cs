using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class Breed
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    // Audit removed

    public string? Description { get; private set; }
    public bool Active { get; private set; }

    private Breed() { }

    public Breed(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");

        Name = name;
        Description = description;
        Active = true;
    }
}
