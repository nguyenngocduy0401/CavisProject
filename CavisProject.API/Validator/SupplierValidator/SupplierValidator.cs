using CavisProject.Application.ViewModels.SupplierViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;

namespace CavisProject.API.Validator.SupplierValidator
{
    public class SupplierValidator : AbstractValidator<CreateSupplierViewModel>
    {
        public SupplierValidator()
        {
            // SupplierName: not null and maximum 50 characters
            RuleFor(x => x.SupplierName)
                .NotNull().WithMessage("SupplierName cannot be null")
                .MaximumLength(50).WithMessage("SupplierName cannot be longer than 50 characters");

            // PhoneNumber: not null, exactly 10 characters, numeric, starts with '0'
            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("PhoneNumber cannot be null")
                .Matches(@"^\d{10}$").WithMessage("PhoneNumber must be exactly 10 digits")
                .Must(x => x.StartsWith("0")).WithMessage("PhoneNumber must start with '0'");

            // Email: not null and maximum 25 characters
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email cannot be null")
                .MaximumLength(25).WithMessage("Email cannot be longer than 25 characters");

            // Address: not null and maximum 100 characters
            RuleFor(x => x.Address)
                .NotNull().WithMessage("Address cannot be null")
                .MaximumLength(100).WithMessage("Address cannot be longer than 100 characters");
        }
    }
}
