using BloodNetwork.Application.DTOs;
using FluentValidation;

namespace BloodNetwork.Application.Validators;

public class UpdateBloodRequestRequestValidator : AbstractValidator<UpdateBloodRequestRequest>
{
    public UpdateBloodRequestRequestValidator()
    {
        RuleFor(x => x.BloodGroup)
            .IsInEnum().WithMessage("Invalid blood group");

        RuleFor(x => x.UnitsRequired)
            .GreaterThan(0).WithMessage("Units required must be at least 1")
            .LessThanOrEqualTo(10).WithMessage("Cannot request more than 10 units at once");

        RuleFor(x => x.HospitalName)
            .NotEmpty().WithMessage("Hospital name is required")
            .MaximumLength(300).WithMessage("Hospital name must not exceed 300 characters");

        RuleFor(x => x.HospitalAddress)
            .NotEmpty().WithMessage("Hospital address is required")
            .MaximumLength(500).WithMessage("Hospital address must not exceed 500 characters");

        RuleFor(x => x.DistrictId)
            .NotEmpty().WithMessage("District is required");

        RuleFor(x => x.UpazilaId)
            .NotEmpty().WithMessage("Upazila is required");

        RuleFor(x => x.RequiredBy)
            .Must(dt => dt > DateTime.UtcNow).WithMessage("Required date must be in the future");

        When(x => x.Latitude.HasValue, () =>
        {
            RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90");
        });

        When(x => x.Longitude.HasValue, () =>
        {
            RuleFor(x => x.Longitude).InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180");
        });

        RuleFor(x => x.Urgency)
            .IsInEnum().WithMessage("Invalid urgency level");

        RuleFor(x => x.ContactPhone)
            .NotEmpty().WithMessage("Contact phone is required")
            .Matches(@"^01[3-9]\d{8}$").WithMessage("Invalid Bangladeshi phone number");

        RuleFor(x => x.PatientName)
            .MaximumLength(200).WithMessage("Patient name must not exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.PatientName));

        RuleFor(x => x.PatientRelation)
            .MaximumLength(100).WithMessage("Patient relation must not exceed 100 characters")
            .When(x => !string.IsNullOrEmpty(x.PatientRelation));

        RuleFor(x => x.Area)
            .MaximumLength(200).WithMessage("Area must not exceed 200 characters")
            .When(x => !string.IsNullOrEmpty(x.Area));

        RuleFor(x => x.AdditionalInformation)
            .MaximumLength(2000).WithMessage("Additional information must not exceed 2000 characters")
            .When(x => !string.IsNullOrEmpty(x.AdditionalInformation));
    }
}
