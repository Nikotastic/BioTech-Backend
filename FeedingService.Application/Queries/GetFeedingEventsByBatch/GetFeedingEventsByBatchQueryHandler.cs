using FeedingService.Application.DTOs;
using FeedingService.Application.Interfaces;
using FeedingService.Domain.Entities;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByBatch;

public class GetFeedingEventsByBatchQueryHandler : IRequestHandler<GetFeedingEventsByBatchQuery, FeedingEventListResponse>
{
    private readonly IFeedingEventRepository _repository;

    public GetFeedingEventsByBatchQueryHandler(IFeedingEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<FeedingEventListResponse> Handle(GetFeedingEventsByBatchQuery request, CancellationToken ct)
    {
        var pageSize = request.PageSize > 10 ? 10 : request.PageSize;
        var events = await _repository.GetByBatchIdAsync(request.BatchId, request.Page, pageSize, ct);
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
