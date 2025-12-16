using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Queries;

public record GetAnimalsByFarmQuery(
    int FarmId,
    string? Status,
    bool IncludeInactive
) : IRequest<IEnumerable<AnimalResponse>>;
