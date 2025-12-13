using FeedingService.Application.DTOs;
using FeedingService.Application.Interfaces;
using FeedingService.Domain.Entities;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByFarm;

public class GetFeedingEventsByFarmQueryHandler 
    : IRequestHandler<GetFeedingEventsByFarmQuery, FeedingEventListResponse>
{
    private readonly IFeedingEventRepository _repository;

    public GetFeedingEventsByFarmQueryHandler(IFeedingEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<FeedingEventListResponse> Handle(
        GetFeedingEventsByFarmQuery request, 
        CancellationToken ct)
    {
        var events = await _repository.GetByFarmIdAsync(
            request.FarmId, 
            request.FromDate, 
            request.ToDate, 
            ct);

        var responses = events.Select(MapToResponse).ToList();

        return new FeedingEventListResponse(responses, responses.Count);
    }

    private static FeedingEventResponse MapToResponse(FeedingEvent entity)
    {
        return new FeedingEventResponse(
            entity.Id,
            entity.FarmId,
            entity.SupplyDate,
            entity.DietId,
            entity.BatchId,
            entity.AnimalId,
            entity.ProductId,
            entity.TotalQuantity,
            entity.AnimalsFedCount,
            entity.UnitCostAtMoment.Amount,
            entity.CalculatedTotalCost?.Amount,
            entity.Observations,
            entity.RegisteredBy,
            entity.CreatedAt,
            entity.UpdatedAt
        );
    }
}