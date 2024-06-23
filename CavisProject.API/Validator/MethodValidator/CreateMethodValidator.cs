﻿using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.PackagePremium;
using FluentValidation;

namespace CavisProject.API.Validator.MethodValidator
{
    public class CreateMethodValidator: AbstractValidator<CreateMethodViewModel>
    {
       
            public CreateMethodValidator()
            {
                RuleFor(x => x.MethodName)
                    .NotEmpty().WithMessage("Method name cannot be empty")
                    .MaximumLength(50).WithMessage("Method name cannot exceed 50 characters");

                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Description cannot be empty")
                    .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
            }
        }
    }

