using MediatR;
using HealthService.Application.DTOs;
using HealthService.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HealthService.Application.Queries.GetHealthEventsByFarm;

public class GetHealthEventsByFarmQueryHandler : IRequestHandler<GetHealthEventsByFarmQuery, List<HealthEventResponse>>
{
    private readonly IHealthEventRepository _repository;

    public GetHealthEventsByFarmQueryHandler(IHealthEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<HealthEventResponse>> Handle(GetHealthEventsByFarmQuery request, CancellationToken cancellationToken)
    {
        var events = await _repository.GetByFarmIdAsync(request.FarmId, request.Page, request.PageSize, cancellationToken);

        return events.Select(e => new HealthEventResponse(
            e.Id,
            e.FarmId,
            e.AnimalId,
            e.BatchId,
            e.EventType,
            e.EventDate,
            e.Disease,
            e.Treatment,
            e.Medication,
            e.Dosage,
            e.DosageUnit,
            e.VeterinarianName,
            e.Cost,
            e.Notes,
            e.NextFollowUpDate,
            e.RequiresFollowUp,
            e.FollowUpNotes,
            e.CreatedAt,
            e.UpdatedAt
        )).ToList();
    }
}
