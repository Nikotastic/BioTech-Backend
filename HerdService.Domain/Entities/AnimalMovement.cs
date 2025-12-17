using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class AnimalMovement
{
    public long Id { get; private set; }
    public int FarmId { get; private set; }
    public long AnimalId { get; private set; }
    public int MovementTypeId { get; private set; }

    public DateOnly MovementDate { get; private set; }

    public int? PreviousBatchId { get; private set; }
    public int? NewBatchId { get; private set; }
    public int? PreviousPaddockId { get; private set; }
    public int? NewPaddockId { get; private set; }

    public long? ThirdPartyId { get; private set; }
    public decimal? TransactionValue { get; private set; }
    public decimal? WeightAtMovement { get; private set; }

    public string? Observations { get; private set; }
    public int? RegisteredBy { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }

    // Navigation
    public virtual Animal? Animal { get; private set; }
    public virtual MovementType? MovementType { get; private set; }
    public virtual Batch? PreviousBatch { get; private set; }
    public virtual Batch? NewBatch { get; private set; }
    public virtual Paddock? PreviousPaddock { get; private set; }
    public virtual Paddock? NewPaddock { get; private set; }

    private AnimalMovement() { }

    public AnimalMovement(
        int farmId,
        long animalId,
        int movementTypeId,
        DateOnly movementDate,
        int? previousBatchId = null,
        int? newBatchId = null,
        int? previousPaddockId = null,
        int? newPaddockId = null,
        long? thirdPartyId = null,
        decimal? transactionValue = null,
        decimal? weightAtMovement = null,
        string? observations = null,
        int? registeredBy = null)
    {
        if (farmId <= 0) throw new ArgumentException("Invalid FarmId");
        if (animalId <= 0) throw new ArgumentException("Invalid AnimalId");
        if (movementTypeId <= 0) throw new ArgumentException("Invalid MovementTypeId");

        FarmId = farmId;
        AnimalId = animalId;
        MovementTypeId = movementTypeId;
        MovementDate = movementDate;
        PreviousBatchId = previousBatchId;
        NewBatchId = newBatchId;
        PreviousPaddockId = previousPaddockId;
        NewPaddockId = newPaddockId;
        ThirdPartyId = thirdPartyId;
        TransactionValue = transactionValue;
        WeightAtMovement = weightAtMovement;
        Observations = observations;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = registeredBy; // Assuming RegisteredBy is the initial CreatedBy
        RegisteredBy = registeredBy;
    }
}
