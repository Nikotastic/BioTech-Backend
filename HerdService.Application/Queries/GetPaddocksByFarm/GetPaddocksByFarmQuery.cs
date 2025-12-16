using MediatR;
using HerdService.Application.DTOs;

namespace HerdService.Application.Queries.GetPaddocksByFarm;

public record GetPaddocksByFarmQuery(int FarmId) : IRequest<IEnumerable<PaddockResponse>>;
