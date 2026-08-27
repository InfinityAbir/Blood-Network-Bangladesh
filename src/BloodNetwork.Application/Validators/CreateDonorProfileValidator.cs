using BloodNetwork.Application.DTOs;
using FluentValidation;

namespace BloodNetwork.Application.Validators;

public class CreateDonorProfileRequestValidator : AbstractValidator<CreateDonorProfileRequest>
{
    public CreateDonorProfileRequestValidator()
    {
        RuleFor(x => x.BloodGroup)
            .IsInEnum().WithMessage("Invalid blood group");

        RuleFor(x => x.DistrictId)
            .NotEmpty().WithMessage("District is required");

        RuleFor(x => x.UpazilaId)
            .NotEmpty().WithMessage("Upazila is required");

        RuleFor(x => x.Area)
            .MaximumLength(200).WithMessage("Area must not exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.Area));

        RuleFor(x => x.Gender)
            .MaximumLength(20).WithMessage("Gender must not exceed 20 characters")
            .When(x => !string.IsNullOrEmpty(x.Gender));

        RuleFor(x => x.DateOfBirth)
            .Must(dt => dt!.Value < DateTime.UtcNow.AddYears(-16)).WithMessage("Donor must be at least 16 years old")
            .When(x => x.DateOfBirth.HasValue);

        When(x => x.Latitude.HasValue, () =>
        {
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90");
        });

        When(x => x.Longitude.HasValue, () =>
        {
            RuleFor(x => x.Longitude).InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180");
        });
    }
}
