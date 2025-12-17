using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class MovementType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }

    public bool AffectsInventory { get; private set; }
    public int InventorySign { get; private set; }

    private MovementType() { }

    public MovementType(string name, string? description, bool affectsInventory = false, int inventorySign = 0)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");

        Name = name;
        Description = description;
        AffectsInventory = affectsInventory;
        InventorySign = inventorySign;
    }
}
