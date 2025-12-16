using MediatR;
using HerdService.Application.DTOs;
using HerdService.Application.Interfaces;

namespace HerdService.Application.Queries;

public class GetAnimalByIdQueryHandler : IRequestHandler<GetAnimalByIdQuery, AnimalResponse?>
{
    private readonly IAnimalRepository _animalRepository;

    public GetAnimalByIdQueryHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<AnimalResponse?> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
    {
        var animal = await _animalRepository.GetByIdAsync(request.Id, cancellationToken);
        if (animal == null) return null;

        return new AnimalResponse(
            animal.Id,
            animal.TagNumber,
            animal.ElectronicId,
            animal.FarmId,
            animal.BreedId,
            animal.Breed?.Name,
            animal.CategoryId,
            animal.Category?.Name,
            animal.BatchId,
            animal.Batch?.Name,
            animal.PaddockId,
            animal.Paddock?.Name,
            animal.BirthDate,
            animal.GetAgeInMonths(),
            animal.Sex,
            animal.CurrentWeight,
            animal.LastWeightDate,
            animal.Status,
            animal.IsActive,
            animal.Notes
        );
    }
}
