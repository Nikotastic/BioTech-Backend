using MediatR;
using HerdService.Application.DTOs;
using HerdService.Application.Interfaces;

namespace HerdService.Application.Commands;

public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, AnimalResponse>
{
    private readonly IAnimalRepository _animalRepository;

    public UpdateAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<AnimalResponse> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        var animal = await _animalRepository.GetByIdAsync(request.Id, cancellationToken);
        if (animal == null)
            throw new KeyNotFoundException($"Animal with ID {request.Id} not found.");

        animal.UpdateDetails(
            request.TagNumber,
            request.ElectronicId,
            request.BreedId,
            request.CategoryId,
            request.BirthDate,
            request.Sex,
            request.Notes,
            request.UserId
        );
        
        await _animalRepository.UpdateAsync(animal, cancellationToken);

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
