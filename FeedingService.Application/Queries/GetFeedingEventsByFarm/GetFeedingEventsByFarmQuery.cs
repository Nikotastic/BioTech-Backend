using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByFarm;

public record GetFeedingEventsByFarmQuery(
    int FarmId,
    DateTime? FromDate,
    DateTime? ToDate
) : IRequest<FeedingEventListResponse>;
