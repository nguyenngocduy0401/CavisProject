using CavisProject.Application.ViewModels.AppointmentViewModel;
using FluentValidation;

namespace CavisProject.API.Validator.AppointmentValidator
{
    public class CreateAppointmentValidator: AbstractValidator<CreateAppointmentViewModel>
    {
        public CreateAppointmentValidator ()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
                .GreaterThan(DateTime.Today).WithMessage("Date must be in the future.");

           

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone Number is not valid.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            
        }
    }
}
