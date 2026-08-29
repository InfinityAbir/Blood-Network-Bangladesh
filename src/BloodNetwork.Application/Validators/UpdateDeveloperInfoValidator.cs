using BloodNetwork.Application.DTOs;
using FluentValidation;

namespace BloodNetwork.Application.Validators;

public class UpdateDeveloperInfoValidator : AbstractValidator<UpdateDeveloperInfoRequest>
{
    public UpdateDeveloperInfoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Role).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).MaximumLength(200);
        RuleFor(x => x.Phone).MaximumLength(30);
        RuleFor(x => x.LinkedInUrl).MaximumLength(300);
        RuleFor(x => x.GithubUrl).MaximumLength(300);
    }
}
