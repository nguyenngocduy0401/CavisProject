using CavisProject.Application.ViewModels.SkinTypeViewModel;
using FluentValidation;

namespace CavisProject.API.Validator.SkinTypeValidator
{
    public class CreateSkinTypeValidation : AbstractValidator<CreateSkinTypeViewModel>
    {
        public CreateSkinTypeValidation()
        {
            RuleFor(s => s.SkinTypeName)
                .NotEmpty().WithMessage("SkinTypeName cannot be empty.")
                .MaximumLength(50).WithMessage("SkinTypeName must be 50 characters or fewer.");

            RuleFor(s => s.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(250).WithMessage("Description must be 250 characters or fewer.");
        }
    }
}
