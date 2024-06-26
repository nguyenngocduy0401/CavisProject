using CavisProject.Application.ViewModels.PackagePremiumViewModels;
using FluentValidation;

namespace CavisProject.API.Validator.PackageValidator
{
    public class CreatePackagePremiumViewModelValidator : AbstractValidator<CreatePackagePremiumViewModel>
    {
        public CreatePackagePremiumViewModelValidator()
        {
            RuleFor(x => x.PackagePremiumName)
                .NotEmpty().WithMessage("Package name cannot be empty")
                .MaximumLength(50).WithMessage("Package name cannot exceed 50 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Duration)
                .GreaterThan(0).WithMessage("Duration must be greater than 0");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
        }
    }
}
