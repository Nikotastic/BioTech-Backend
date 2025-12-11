using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventById;

public record GetFeedingEventByIdQuery(long Id) : IRequest<FeedingEventResponse?>;