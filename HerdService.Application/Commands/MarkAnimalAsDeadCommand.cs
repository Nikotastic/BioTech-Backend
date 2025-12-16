using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record MarkAnimalAsDeadCommand(
    long AnimalId,
    DateOnly DeathDate,
    string? Reason,
    int? UserId
) : IRequest<AnimalResponse>;
