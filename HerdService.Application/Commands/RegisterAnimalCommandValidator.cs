using FluentValidation;

namespace HerdService.Application.Commands;

public class RegisterAnimalCommandValidator : AbstractValidator<RegisterAnimalCommand>
{
    public RegisterAnimalCommandValidator()
    {
        RuleFor(x => x.TagNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.FarmId).GreaterThan(0);
        RuleFor(x => x.BreedId).GreaterThan(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
        RuleFor(x => x.BirthDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
        RuleFor(x => x.Sex).Must(x => x == "Male" || x == "Female").WithMessage("Sex must be 'Male' or 'Female'");
        RuleFor(x => x.BirthWeight).GreaterThanOrEqualTo(0).When(x => x.BirthWeight.HasValue);
    }
}
