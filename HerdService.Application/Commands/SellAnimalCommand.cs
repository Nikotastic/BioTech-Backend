using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Commands;

public record SellAnimalCommand(
    long AnimalId,
    decimal SalePrice,
    DateOnly SaleDate,
    int? UserId
) : IRequest<AnimalResponse>;
