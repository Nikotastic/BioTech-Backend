using FeedingService.Application.DTOs;
using FeedingService.Application.Interfaces;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventById;


public class GetFeedingEventByIdQueryHandler 
    : IRequestHandler<GetFeedingEventByIdQuery, FeedingEventResponse?>
{
    private readonly IFeedingEventRepository _repository;

    public GetFeedingEventByIdQueryHandler(IFeedingEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<FeedingEventResponse?> Handle(
        GetFeedingEventByIdQuery request, 
        CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Id, ct);
        
        if (entity == null) return null;

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