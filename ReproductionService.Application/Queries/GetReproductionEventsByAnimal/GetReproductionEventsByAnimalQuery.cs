using MediatR;
using ReproductionService.Application.DTOs;

namespace ReproductionService.Application.Queries.GetReproductionEventsByAnimal;

public record GetReproductionEventsByAnimalQuery(
    long AnimalId,
    int Page = 1,
    int PageSize = 10
) : IRequest<ReproductionEventListResponse>;
