using MediatR;
using ReproductionService.Application.DTOs;
using ReproductionService.Domain.Enums;

namespace ReproductionService.Application.Queries.GetReproductionEventsByType;

public record GetReproductionEventsByTypeQuery(
    ReproductionEventType Type,
    int FarmId,
    int Page = 1,
    int PageSize = 10
) : IRequest<ReproductionEventListResponse>;
