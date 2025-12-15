using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByBatch;


public record GetFeedingEventsByBatchQuery(int BatchId) : IRequest<FeedingEventListResponse>;