using FeedingService.Application.DTOs;
using MediatR;

namespace FeedingService.Application.Queries.GetFeedingEventsByAnimal;

public record GetFeedingEventsByAnimalQuery(
    long AnimalId,
    int Page = 1,
    int PageSize = 10
) : IRequest<FeedingEventListResponse>;
