using FeedingService.Application.DTOs;
using FeedingService.Application.Interfaces;
using FeedingService.Domain.ValueObjects;
using MediatR;

namespace FeedingService.Application.Commands.UpdateFeedingEvent;

public class UpdateFeedingEventCommandHandler 
    : IRequestHandler<UpdateFeedingEventCommand, FeedingEventResponse>
{
    private readonly IFeedingEventRepository _repository;

    public UpdateFeedingEventCommandHandler(IFeedingEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<FeedingEventResponse> Handle(
        UpdateFeedingEventCommand request, 
        CancellationToken ct)
    {
        var existing = await _repository.GetByIdAsync(request.Id, ct)
                       ?? throw new KeyNotFoundException($"FeedingEvent with id {request.Id} not found");

        existing.FarmId = request.FarmId;
        existing.SupplyDate = request.SupplyDate.Date;
        existing.DietId = request.DietId;
        existing.BatchId = request.BatchId;
        existing.AnimalId = request.AnimalId;
        existing.ProductId = request.ProductId;
        existing.TotalQuantity = request.TotalQuantity;
        existing.AnimalsFedCount = request.AnimalsFedCount;
        existing.UnitCostAtMoment = Money.FromDecimal(request.UnitCostAtMoment);
        existing.Observations = request.Observations;
        existing.UpdatedAt = DateTime.UtcNow;
        existing.LastModifiedBy = request.UserId;

        existing.Validate();

        await _repository.UpdateAsync(existing, ct);

        return new FeedingEventResponse(
            existing.Id,
            existing.FarmId,
            existing.SupplyDate,
            existing.DietId,
            existing.BatchId,
            existing.AnimalId,
            existing.ProductId,
            existing.TotalQuantity,
            existing.AnimalsFedCount,
            existing.UnitCostAtMoment.Amount,
            existing.CalculatedTotalCost?.Amount,
            existing.Observations,
            existing.RegisteredBy,
            existing.CreatedAt,
            existing.UpdatedAt
        );
    }
}