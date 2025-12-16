using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class AnimalMovement : IAuditableEntity
{
    public long Id { get; private set; }
    public long AnimalId { get; private set; }
    public int MovementTypeId { get; private set; }
    public int? FromPaddockId { get; private set; }
    public int? ToPaddockId { get; private set; }
    public DateOnly MovementDate { get; private set; }
    public string? Notes { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }
    
    // Navigation
    public virtual Animal? Animal { get; private set; }
    public virtual MovementType? MovementType { get; private set; }
    public virtual Paddock? FromPaddock { get; private set; }
    public virtual Paddock? ToPaddock { get; private set; }

    private AnimalMovement() { }

    public AnimalMovement(
        long animalId, 
        int movementTypeId, 
        DateOnly movementDate,
        int? fromPaddockId, 
        int? toPaddockId, 
        string? notes,
        int? createdBy)
    {
        if (animalId <= 0) throw new ArgumentException("Invalid AnimalId");
        if (movementTypeId <= 0) throw new ArgumentException("Invalid MovementTypeId");
        
        AnimalId = animalId;
        MovementTypeId = movementTypeId;
        MovementDate = movementDate;
        FromPaddockId = fromPaddockId;
        ToPaddockId = toPaddockId;
        Notes = notes;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }
}
