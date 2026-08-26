using BloodNetwork.Application.DTOs;
using FluentValidation;

namespace BloodNetwork.Application.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^01[3-9]\d{8}$").WithMessage("Invalid Bangladeshi phone number format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
