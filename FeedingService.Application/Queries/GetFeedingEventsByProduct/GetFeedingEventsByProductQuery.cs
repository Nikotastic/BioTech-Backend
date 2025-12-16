using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByProduct;

public record GetFeedingEventsByProductQuery(
    int ProductId,
    int Page = 1,
    int PageSize = 10
) : IRequest<FeedingEventListResponse>;
