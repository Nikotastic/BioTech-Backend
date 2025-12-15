using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Commands;

public record UpdateFeedingEventCommand(
    long Id,
    int FarmId,
    DateTime SupplyDate,
    int? DietId,
    int? BatchId,
    long? AnimalId,
    int ProductId,
    decimal TotalQuantity,
    int AnimalsFedCount,
    decimal UnitCostAtMoment,
    string? Observations,
    int? UserId
) : IRequest<FeedingEventResponse>;