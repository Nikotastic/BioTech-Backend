using FeedingService.Application.Queries.GetFeedingEventsByFarm;
using FluentValidation;

namespace FeedingService.Application.Validators;

public class GetFeedingEventsByFarmQueryValidator : AbstractValidator<GetFeedingEventsByFarmQuery>
{
    public GetFeedingEventsByFarmQueryValidator()
    {
        RuleFor(x => x.FarmId)
            .GreaterThan(0)
            .WithMessage("FarmId must be greater than zero");

        RuleFor(x => x)
            .Must(x => !x.FromDate.HasValue || !x.ToDate.HasValue || x.FromDate <= x.ToDate)
            .WithMessage("FromDate must be less than or equal to ToDate");
    }
}