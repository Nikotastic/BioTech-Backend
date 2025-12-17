using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class AnimalCategory
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }

    // Audit removed

    public string? Sex { get; private set; }
    public int MinAgeMonths { get; private set; }
    public int? MaxAgeMonths { get; private set; }

    private AnimalCategory() { } // For EF Core

    public AnimalCategory(string name, string? description = null, string? sex = null, int minAgeMonths = 0, int? maxAgeMonths = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty", nameof(name));

        if (sex != null && sex != "M" && sex != "F")
            throw new ArgumentException("Sex must be 'M' or 'F'");

        Name = name;
        Description = description;
        Sex = sex;
        MinAgeMonths = minAgeMonths;
        MaxAgeMonths = maxAgeMonths;
    }
}
