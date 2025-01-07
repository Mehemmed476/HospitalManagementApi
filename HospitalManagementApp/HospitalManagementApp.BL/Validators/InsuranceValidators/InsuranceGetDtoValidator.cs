using FluentValidation;
using HospitalManagementApp.BL.DTOs.InsuranceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Validators.InsuranceValidators;

public class InsuranceGetDtoValidator : AbstractValidator<InsuranceGetDto>
{
    public InsuranceGetDtoValidator()
    {
        RuleFor(x => x.PersonInsurance)
            .NotNull().NotEmpty().WithMessage("Person Insurance cannot be empty or null.")
            .MinimumLength(3).WithMessage("Person Insurance must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Person Insurance cannot exceed 100 characters.");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be little than zero");

        RuleFor(x => x.Patients)
            .NotNull().WithMessage("Products collection cannot be null.")
            .Must(products => products == null || products.Any())
            .WithMessage("Products collection cannot be empty if assigned.");
    }
}
