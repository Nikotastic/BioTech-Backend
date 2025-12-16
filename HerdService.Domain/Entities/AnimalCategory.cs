using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class AnimalCategory : IAuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    
    // Audit (Implementation of IAuditableEntity - setters managed by EF/Logic)
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }

    private AnimalCategory() { } // For EF Core

    public AnimalCategory(string name, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty", nameof(name));

        Name = name;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}
