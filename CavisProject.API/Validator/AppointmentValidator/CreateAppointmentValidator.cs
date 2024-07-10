using CavisProject.Application.ViewModels.AppointmentViewModel;
using FluentValidation;
using System.Globalization;

namespace CavisProject.API.Validator.AppointmentValidator
{
    public class CreateAppointmentValidator: AbstractValidator<CreateAppointmentViewModel>
    {
        public CreateAppointmentValidator ()
        {
            

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.")
            .Must(BeValidDate).WithMessage("Invalid date format or date is not in future.");



            RuleFor(x => x.PhoneNumber).
                NotEmpty().Matches(@"^0[0-9]{9}$")
                .WithMessage("The phone number must have 10 digits and start with 0!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

        }
        private bool BeValidDate(string dateStr)
        {
            if (!DateTime.TryParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return false;
            }
             return date.Date > DateTime.UtcNow.Date;
        }
    }
}
