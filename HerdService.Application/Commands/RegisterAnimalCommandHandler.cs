using MediatR;
using HerdService.Application.DTOs;
using HerdService.Application.Interfaces;
using HerdService.Domain.Entities;

namespace HerdService.Application.Commands;

public class RegisterAnimalCommandHandler : IRequestHandler<RegisterAnimalCommand, AnimalResponse>
{
    private readonly IAnimalRepository _animalRepository;

    public RegisterAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<AnimalResponse> Handle(RegisterAnimalCommand request, CancellationToken cancellationToken)
    {
        if (await _animalRepository.TagNumberExistsAsync(request.TagNumber, request.FarmId, cancellationToken))
            throw new InvalidOperationException($"Animal with Tag {request.TagNumber} already exists in this farm.");

        Animal animal;
        if (request.PurchasePrice.HasValue)
        {
            animal = Animal.CreatePurchased(
                request.TagNumber,
                request.FarmId,
                request.BreedId,
                request.CategoryId,
                request.BirthDate,
                request.Sex,
                request.PurchasePrice.Value,
                request.BirthWeight, // Assuming current weight = birth weight for purchased if not specified separately
                request.UserId
            );
        }
        else
        {
            animal = Animal.CreateNewBorn(
                request.TagNumber,
                request.FarmId,
                request.BreedId,
                request.CategoryId,
                request.BirthDate,
                request.Sex,
                request.BirthWeight,
                request.MotherId,
                request.FatherId,
                request.UserId
            );
        }
        
        // Handle optional Batch/Paddock assignments initially
        if (request.BatchId.HasValue) 
            animal.MoveToBatch(request.BatchId.Value, request.UserId);
            
        if (request.PaddockId.HasValue)
            animal.MoveToPaddock(request.PaddockId.Value, request.UserId);

        await _animalRepository.AddAsync(animal, cancellationToken);
        
        // Return Response (Mapping could be done via AutoMapper, but manual here for simplicity/explicitness)
        return new AnimalResponse(
            animal.Id,
            animal.TagNumber,
            animal.ElectronicId,
            animal.FarmId,
            animal.BreedId,
            null, // Navigation properties might not be loaded immediately after add, usually handled by GetById or explicit load
            animal.CategoryId,
            null,
            animal.BatchId,
            null,
            animal.PaddockId,
            null,
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
