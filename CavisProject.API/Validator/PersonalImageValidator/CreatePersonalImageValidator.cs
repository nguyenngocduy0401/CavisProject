using CavisProject.Application.ViewModels.PersonalImageViewModels;
using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using FluentValidation;

namespace CavisProject.API.Validator.PersonalImageValidator
{
    public class CreatePersonalImageValidator : AbstractValidator<CreatePersonalImageViewModel>
    {
        public CreatePersonalImageValidator()
        { 
            RuleFor(x => x.URL)
             .NotEmpty().WithMessage("URL cannot be empty");
        }
    }
}