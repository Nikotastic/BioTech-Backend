using HerdService.Domain.Common;

namespace HerdService.Domain.Entities;

public class Animal : IAuditableEntity
{
    // Identity
    public long Id { get; private set; }
    public string TagNumber { get; private set; } = string.Empty; // Unique identifier
    public string? ElectronicId { get; private set; } // RFID, chip, etc.
    
    // Classification
    public int FarmId { get; private set; }
    public int BreedId { get; private set; }
    public int CategoryId { get; private set; } // Calf, Heifer, Cow, Bull, etc.
    public int? BatchId { get; private set; } // Current batch/lot
    public int? PaddockId { get; private set; } // Current location
    
    // Biological Information
    public DateOnly BirthDate { get; private set; }
    public string Sex { get; private set; } = string.Empty; // "Male", "Female"
    public decimal? BirthWeight { get; private set; } // kg
    public decimal? CurrentWeight { get; private set; } // kg
    public DateOnly? LastWeightDate { get; private set; }
    
    // Genealogy
    public long? MotherId { get; private set; }
    public long? FatherId { get; private set; }
    
    // Status
    public string Status { get; private set; } = "Active"; // "Active", "Sold", "Dead", "Transferred"
    public DateOnly? StatusDate { get; private set; }
    public bool IsActive { get; private set; }
    
    // Business Information
    public decimal? PurchasePrice { get; private set; }
    public decimal? SalePrice { get; private set; }
    public DateOnly? SaleDate { get; private set; }
    public string? Notes { get; private set; }
    
    // Audit
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int? CreatedBy { get; private set; }
    public int? LastModifiedBy { get; private set; }
    
    // Navigation properties (EF Core only, nullable)
    public virtual Breed? Breed { get; private set; }
    public virtual AnimalCategory? Category { get; private set; }
    public virtual Batch? Batch { get; private set; }
    public virtual Paddock? Paddock { get; private set; }
    public virtual Animal? Mother { get; private set; }
    public virtual Animal? Father { get; private set; }
    public virtual ICollection<AnimalMovement>? Movements { get; private set; }
    
    // Private constructor for EF Core
    private Animal() { }
    
    // Factory method for new born animal
    public static Animal CreateNewBorn(
        string tagNumber,
        int farmId,
        int breedId,
        int categoryId,
        DateOnly birthDate,
        string sex,
        decimal? birthWeight = null,
        long? motherId = null,
        long? fatherId = null,
        int? createdBy = null)
    {
        // Validation and business rules
        if (string.IsNullOrWhiteSpace(tagNumber))
            throw new ArgumentException("Tag number is required");
            
        if (birthDate > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("Birth date cannot be in the future");
            
        var validSexes = new[] { "Male", "Female" };
        if (!validSexes.Contains(sex))
            throw new ArgumentException($"Sex must be one of: {string.Join(", ", validSexes)}");
            
        if (birthWeight.HasValue && birthWeight.Value < 0)
            throw new ArgumentException("Birth weight cannot be negative");
            
        return new Animal
        {
            TagNumber = tagNumber,
            FarmId = farmId,
            BreedId = breedId,
            CategoryId = categoryId,
            BirthDate = birthDate,
            Sex = sex,
            BirthWeight = birthWeight,
            CurrentWeight = birthWeight,
            LastWeightDate = birthWeight.HasValue ? birthDate : null,
            MotherId = motherId,
            FatherId = fatherId,
            Status = "Active",
            StatusDate = birthDate,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = createdBy
        };
    }
    
    // Factory method for purchased animal
    public static Animal CreatePurchased(
        string tagNumber,
        int farmId,
        int breedId,
        int categoryId,
        DateOnly birthDate,
        string sex,
        decimal purchasePrice,
        decimal? currentWeight = null,
        int? createdBy = null)
    {
        var animal = CreateNewBorn(tagNumber, farmId, breedId, categoryId, birthDate, sex, currentWeight, createdBy: createdBy);
        animal.PurchasePrice = purchasePrice;
        return animal;
    }
    
    // Domain behaviors
    public void UpdateWeight(decimal newWeight, DateOnly weighDate, int? modifiedBy)
    {
        if (newWeight <= 0)
            throw new ArgumentException("Weight must be greater than zero");
            
        if (weighDate > DateOnly.FromDateTime(DateTime.UtcNow))
            throw new ArgumentException("Weigh date cannot be in the future");
            
        if (weighDate < BirthDate)
            throw new ArgumentException("Weigh date cannot be before birth date");
            
        CurrentWeight = newWeight;
        LastWeightDate = weighDate;
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }
    
    public void MoveToBatch(int batchId, int? modifiedBy)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot move an inactive animal");
            
        BatchId = batchId;
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }
    
    public void MoveToPaddock(int paddockId, int? modifiedBy)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot move an inactive animal");
            
        PaddockId = paddockId;
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }
    
    public void ChangeCategory(int newCategoryId, int? modifiedBy)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot change category of inactive animal");
            
        CategoryId = newCategoryId;
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }
    
    public void MarkAsSold(decimal salePrice, DateOnly saleDate, int? modifiedBy)
    {
        if (salePrice <= 0)
            throw new ArgumentException("Sale price must be greater than zero");
            
        if (saleDate < BirthDate)
            throw new ArgumentException("Sale date cannot be before birth date");
            
        Status = "Sold";
        StatusDate = saleDate;
        SalePrice = salePrice;
        SaleDate = saleDate;
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }
    
    public void MarkAsDead(DateOnly deathDate, string? reason, int? modifiedBy)
    {
        if (deathDate < BirthDate)
            throw new ArgumentException("Death date cannot be before birth date");
            
        Status = "Dead";
        StatusDate = deathDate;
        IsActive = false;
        Notes = string.IsNullOrWhiteSpace(Notes) ? reason : $"{Notes}\n{reason}";
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }
    
    public void Transfer(DateOnly transferDate, int? modifiedBy)
    {
        Status = "Transferred";
        StatusDate = transferDate;
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }

    public void UpdateDetails(string tagNumber, string? electronicId, int? breedId, int? categoryId, DateOnly birthDate, string sex, string? notes, int? modifiedBy)
    {
        if (string.IsNullOrWhiteSpace(tagNumber)) throw new ArgumentException("Tag number is required");
        // Simplified validation for update
        
        TagNumber = tagNumber;
        ElectronicId = electronicId;
        if (breedId.HasValue) BreedId = breedId.Value;
        if (categoryId.HasValue) CategoryId = categoryId.Value;
        BirthDate = birthDate;
        Sex = sex;
        Notes = notes;
        
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = modifiedBy;
    }

    public void AddMovement(int movementTypeId, int? toPaddockId, DateOnly date, string? notes, int? userId)
    {
        if (Movements == null) Movements = new List<AnimalMovement>();
        
        var movement = new AnimalMovement(Id, movementTypeId, date, PaddockId, toPaddockId, notes, userId);
        Movements.Add(movement);
        
        // Update state if moving to a paddock
        if (toPaddockId.HasValue)
        {
             PaddockId = toPaddockId;
        }
        
        UpdatedAt = DateTime.UtcNow;
        LastModifiedBy = userId;
    }
    
    public int GetAgeInDays()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        return today.DayNumber - BirthDate.DayNumber;
    }
    
    public int GetAgeInMonths()
    {
        return GetAgeInDays() / 30;
    }
    
    public decimal? GetWeightGain()
    {
        if (!BirthWeight.HasValue || !CurrentWeight.HasValue)
            return null;
            
        return CurrentWeight.Value - BirthWeight.Value;
    }
}
