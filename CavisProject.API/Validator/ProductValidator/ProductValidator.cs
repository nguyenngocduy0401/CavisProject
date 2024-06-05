using CavisProject.Application;
using CavisProject.Application.ViewModels.ProductViewModel;
using FluentValidation;

namespace CavisProject.API.Validator.ProductValidator
{
    public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductViewModelValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.ClickMoney)
                .GreaterThan(10000).WithMessage("Click money must be greater than 10000.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must be less than or equal to 500 characters.");

            RuleFor(x => x.URL)
                .NotEmpty().WithMessage("URL is required.");

            RuleFor(x => x.SupplierId)
                .NotNull().WithMessage("Supplier is required.")
                .MustAsync(BeValidSupplierId).WithMessage("Supplier does not exist.");

            RuleFor(x => x.ProductCategoryId)
                .NotNull().WithMessage("Product category is required.")
                .MustAsync(BeValidProductCategoryId).WithMessage("Product category does not exist.");
        }

        private async Task<bool> BeValidSupplierId(Guid? supplierId, CancellationToken cancellationToken)
        {
            if (supplierId == null)
                return false;

            return await _unitOfWork.SupplierRepository.GetByIdAsync(supplierId.Value) != null;
        }

        private async Task<bool> BeValidProductCategoryId(Guid? productCategoryId, CancellationToken cancellationToken)
        {
            if (productCategoryId == null)
                return false;

            return await _unitOfWork.ProductCategoryRepository.GetByIdAsync(productCategoryId.Value) != null;
        }
    }
}