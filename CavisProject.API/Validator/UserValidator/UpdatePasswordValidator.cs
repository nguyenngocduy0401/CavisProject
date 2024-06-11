using CavisProject.Application.ViewModels.UserViewModels;
using FluentValidation;

namespace CavisProject.API.Validator.UserValidator
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordModel>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.OldPassword).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6)
               .WithMessage("Password must be at least 6 characters long!")
               .Matches(@"^(?=.*[a-zA-Z])(?=.*\d).+$")
               .WithMessage("Your password must contain at least one number!");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.ConfirmPassword)
                .WithMessage("Your password confirmed is wrong!");
        }
    }
}

