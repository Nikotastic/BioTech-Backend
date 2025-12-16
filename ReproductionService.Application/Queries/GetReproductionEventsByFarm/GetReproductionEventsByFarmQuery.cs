using MediatR;
using ReproductionService.Application.DTOs;

namespace ReproductionService.Application.Queries.GetReproductionEventsByFarm;

public record GetReproductionEventsByFarmQuery(
    int FarmId,
    DateTime? FromDate,
    DateTime? ToDate,
    int Page = 1,
    int PageSize = 10
) : IRequest<ReproductionEventListResponse>;
