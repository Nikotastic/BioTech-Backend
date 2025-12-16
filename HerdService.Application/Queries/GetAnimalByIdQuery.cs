using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Queries;

public record GetAnimalByIdQuery(long Id) : IRequest<AnimalResponse?>;
