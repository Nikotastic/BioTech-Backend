using System.Collections.Generic;
using MediatR;
using InventoryService.Application.DTOs;

namespace InventoryService.Application.Queries;

public record GetInventoryItemsQuery(int FarmId, int Page, int PageSize) : IRequest<IEnumerable<InventoryItemDto>>;
