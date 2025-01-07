using FluentValidation;
using HospitalManagementApp.BL.DTOs.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalManagementApp.BL.Validators.PatientValidators;

public class PatientPutDtoValidator : AbstractValidator<PatientPutDto>
{
    public PatientPutDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(30).WithMessage("First name cannot be more than 30 characters");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Last name cannot be empty")
            .MaximumLength(30).WithMessage("Last name cannot be more than 30 characters");

        RuleFor(x => x.Email)
            .NotEmpty().NotNull().WithMessage("Email cannot be empty")
            .Must(e => BeValidEmailAddress(e)).WithMessage("Invalid email address");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().NotNull().WithMessage("PhoneNumber cannot be empty")
            .Must(pn => BeValidPhoneNumber(pn)).WithMessage("Invalid phone number");

        RuleFor(x => x.RegistrationAddress)
            .NotEmpty().WithMessage("First name cannot be empty")
            .MinimumLength(10).WithMessage("Registration Adress cannot be little than 10 characters");

        RuleFor(x => x.CurrentAddress)
            .NotEmpty().WithMessage("Last name cannot be empty")
            .MinimumLength(10).WithMessage("Current Adress cannot be little than 10 characters");

        RuleFor(x => x.SeriaNumber)
            .NotEmpty().WithMessage("SeriaNumber cannot be empty");

        RuleFor(x => x.DOB)
            .NotEmpty().WithMessage("SeriaNumber cannot be empty")
            .Must(pn => DateTime.UtcNow.AddHours(4).Year - pn.Year <= 168 || DateTime.UtcNow.AddHours(4).Year - pn.Year >= 0)
            .WithMessage("Age must be 0 - 168");

    }

    public bool BeValidPhoneNumber(string phoneNumber)
    {
        Regex regex = new Regex(@"^\+994(50|51|55|70|77)\d{7}$");
        Match match = regex.Match(phoneNumber);
        return match.Success;
    }

    public bool BeValidEmailAddress(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success) { return true; }
        return false;
    }
}
