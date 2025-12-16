using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record MoveAnimalToBatchCommand(
    long AnimalId,
    int BatchId,
    int? UserId
) : IRequest<AnimalResponse>;
