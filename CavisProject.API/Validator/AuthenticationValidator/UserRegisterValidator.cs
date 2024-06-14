﻿using CavisProject.Application.ViewModels.UserViewModels;
using FluentValidation;

namespace CavisProject.API.Validator.AuthenticationValidator
{
    public class UserRegisterValidation : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress()
                .WithMessage("Email is invalid format!");
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^0[0-9]{9}$")
                .WithMessage("The phone number must have 10 digits and start with 0!");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6)
               .WithMessage("Password must be at least 6 characters long!")
           .Matches(@"^(?=.*[a-zA-Z])(?=.*\d).+$")
               .WithMessage("Your password must contain at least one number!");
            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password)
                .WithMessage("Your password confirmed is wrong!");
        }
    }
}