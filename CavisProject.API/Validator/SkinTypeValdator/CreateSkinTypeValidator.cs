using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using FluentValidation;

namespace CavisProject.API.Validator.SkinTypeValdator
{
    public class CreateSkinTypeValidator: AbstractValidator<CreateSkinTypeViewModel>
    {
        public CreateSkinTypeValidator()
        {
            RuleFor(x => x.SkinTypeName)
              .NotEmpty().WithMessage("SkinTypeName cannot be empty")
              .MaximumLength(50).WithMessage("SkinTypeName cannot exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(250).WithMessage("Description cannot exceed 250 characters");
        }
    }
}
