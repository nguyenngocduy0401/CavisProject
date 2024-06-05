using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.UserViewModels;
using FluentValidation;

namespace CavisProject.API.Validator.SkinTypeValdator
{
    public class CreateSkinTypeValidator: AbstractValidator<CreateSkinTypeViewModel>
    {
        public CreateSkinTypeValidator()
        {
            RuleFor(x => x.SkinsName)
              .NotEmpty().WithMessage("Name cannot be empty")
              .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(250).WithMessage("Description cannot exceed 250 characters");
        }
    }
}
