using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record RegisterAnimalMovementCommand(
    long AnimalId,
    int MovementTypeId,
    int? ToPaddockId,
    DateOnly MovementDate,
    string? Notes,
    int? UserId
) : IRequest<AnimalResponse>;
