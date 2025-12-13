using FeedingService.Application.Commands;
using FluentValidation;

namespace FeedingService.Application.Validators;

public class UpdateFeedingEventCommandValidator : AbstractValidator<UpdateFeedingEventCommand>
{
    public UpdateFeedingEventCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than zero");

        RuleFor(x => x.FarmId)
            .GreaterThan(0)
            .WithMessage("FarmId must be greater than zero");

        RuleFor(x => x.SupplyDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow.Date)
            .WithMessage("SupplyDate cannot be in the future");

        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than zero");

        RuleFor(x => x.TotalQuantity)
            .GreaterThan(0)
            .WithMessage("TotalQuantity must be greater than zero");

        RuleFor(x => x.AnimalsFedCount)
            .GreaterThan(0)
            .WithMessage("AnimalsFedCount must be greater than zero");

        RuleFor(x => x.UnitCostAtMoment)
            .GreaterThanOrEqualTo(0)
            .WithMessage("UnitCostAtMoment cannot be negative");

        RuleFor(x => x)
            .Must(x => x.BatchId.HasValue || x.AnimalId.HasValue)
            .WithMessage("Either BatchId or AnimalId must be provided");

        RuleFor(x => x)
            .Must(x => !(x.BatchId.HasValue && x.AnimalId.HasValue))
            .WithMessage("Cannot specify both BatchId and AnimalId");

        RuleFor(x => x.Observations)
            .MaximumLength(2000)
            .When(x => !string.IsNullOrWhiteSpace(x.Observations))
            .WithMessage("Observations cannot exceed 2000 characters");
    }
}
