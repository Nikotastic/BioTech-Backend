using System;

namespace InventoryService.Domain.Entities;

public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int FarmId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public InventoryItem(string name, decimal quantity, string unit, int farmId)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty", nameof(name));
        if (quantity < 0) throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
        if (string.IsNullOrWhiteSpace(unit)) throw new ArgumentException("Unit cannot be empty", nameof(unit));
        if (farmId <= 0) throw new ArgumentException("FarmId must be greater than zero", nameof(farmId));

        Name = name;
        Quantity = quantity;
        Unit = unit;
        FarmId = farmId;
    }

    // For EF Core
    protected InventoryItem() { }

    public void UpdateQuantity(decimal newQuantity)
    {
        if (newQuantity < 0) throw new ArgumentException("Quantity cannot be negative", nameof(newQuantity));
        Quantity = newQuantity;
        UpdatedAt = DateTime.UtcNow;
    }
}
