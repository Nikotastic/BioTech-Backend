using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByBatch;

public record GetFeedingEventsByBatchQuery(
    int BatchId,
    int Page = 1,
    int PageSize = 10
) : IRequest<FeedingEventListResponse>;