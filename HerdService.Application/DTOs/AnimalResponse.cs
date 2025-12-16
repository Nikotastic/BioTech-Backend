namespace HerdService.Application.DTOs;

public record AnimalResponse(
    long Id,
    string TagNumber,
    string? ElectronicId,
    int FarmId,
    int BreedId,
    string? BreedName,
    int CategoryId,
    string? CategoryName,
    int? BatchId,
    string? BatchName,
    int? PaddockId,
    string? PaddockName,
    DateOnly BirthDate,
    int AgeInMonths,
    string Sex,
    decimal? CurrentWeight,
    DateOnly? LastWeightDate,
    string Status,
    bool IsActive,
    string? Notes
);
