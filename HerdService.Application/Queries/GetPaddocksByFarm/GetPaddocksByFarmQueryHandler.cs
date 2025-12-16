using MediatR;
using HerdService.Application.DTOs;
using HerdService.Application.Interfaces;

namespace HerdService.Application.Queries.GetPaddocksByFarm;

public class GetPaddocksByFarmQueryHandler : IRequestHandler<GetPaddocksByFarmQuery, IEnumerable<PaddockResponse>>
{
    private readonly IPaddockRepository _repository;

    public GetPaddocksByFarmQueryHandler(IPaddockRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PaddockResponse>> Handle(GetPaddocksByFarmQuery request, CancellationToken cancellationToken)
    {
        var paddocks = await _repository.GetByFarmIdAsync(request.FarmId, cancellationToken);

        return paddocks.Select(p => new PaddockResponse(
            p.Id,
            p.Name,
            p.FarmId
        ));
    }
}
