using MediatR;

namespace HerdService.Application.Commands;

public record DeleteAnimalCommand(long Id) : IRequest<Unit>;
