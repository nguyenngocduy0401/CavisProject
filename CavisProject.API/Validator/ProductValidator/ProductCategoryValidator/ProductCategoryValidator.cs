using CavisProject.Application.ViewModels.ProductCategoryViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using FluentValidation;

namespace CavisProject.API.Validator.ProductValidator.ProductCategoryValidator
{
    public class ProductCategoryValidator: AbstractValidator<CreateProductCategoryViewModel>
    {
        public ProductCategoryValidator() {
            RuleFor(x => x.ProductCategoryName)
             .NotEmpty().WithMessage("Product categoryy name cannot be empty")
             .MaximumLength(50).WithMessage("Product categoryy name exceed 50 characters");
        }
    }
}
