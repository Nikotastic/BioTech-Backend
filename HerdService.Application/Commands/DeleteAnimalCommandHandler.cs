using MediatR;
using HerdService.Application.Interfaces;

namespace HerdService.Application.Commands;

public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, Unit>
{
    private readonly IAnimalRepository _animalRepository;

    public DeleteAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
    {
        var animal = await _animalRepository.GetByIdAsync(request.Id, cancellationToken);
        if (animal == null)
            throw new KeyNotFoundException($"Animal with ID {request.Id} not found.");

        await _animalRepository.DeleteAsync(animal, cancellationToken);
        
        return Unit.Value;
    }
}
