using CavisProject.Application;
using CavisProject.Application.ViewModels.ProductViewModel;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace CavisProject.API.Validator.ProductValidator
{
    public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
    {

        public CreateProductViewModelValidator()
        {


            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.ClickMoney)
                .GreaterThan(10000).WithMessage("Click money must be greater than 10000.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must be less than or equal to 500 characters.");

            RuleFor(x => x.URL)
                .NotEmpty().WithMessage("URL is required.");
        }

    }
}
