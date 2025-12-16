using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record UpdateAnimalWeightCommand(
    long AnimalId,
    decimal NewWeight,
    DateOnly WeighDate,
    int? UserId 
) : IRequest<AnimalResponse>;
