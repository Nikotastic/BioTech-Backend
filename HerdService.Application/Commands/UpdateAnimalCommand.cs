using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record UpdateAnimalCommand(
    long Id,
    string TagNumber,
    string? ElectronicId,
    int? BreedId,
    int? CategoryId,
    DateOnly BirthDate,
    string Sex,
    string? Notes,
    int? UserId
) : IRequest<AnimalResponse>;
