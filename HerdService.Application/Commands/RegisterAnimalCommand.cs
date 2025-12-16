using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record RegisterAnimalCommand(
    string TagNumber,
    int FarmId,
    int BreedId,
    int CategoryId,
    DateOnly BirthDate,
    string Sex,
    decimal? BirthWeight,
    long? MotherId,
    long? FatherId,
    int? BatchId,
    int? PaddockId,
    string? ElectronicId,
    decimal? PurchasePrice,
    int? UserId // From Gateway
) : IRequest<AnimalResponse>;
