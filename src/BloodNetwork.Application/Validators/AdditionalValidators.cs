using BloodNetwork.Application.DTOs;
using FluentValidation;

namespace BloodNetwork.Application.Validators;

public class FulfillBloodRequestRequestValidator : AbstractValidator<FulfillBloodRequestRequest>
{
    public FulfillBloodRequestRequestValidator()
    {
        RuleFor(x => x.UnitsFulfilled)
            .GreaterThan(0).WithMessage("Units fulfilled must be at least 1")
            .LessThanOrEqualTo(10).WithMessage("Cannot fulfill more than 10 units at once");
    }
}

public class RespondToMatchRequestValidator : AbstractValidator<RespondToMatchRequest>
{
    public RespondToMatchRequestValidator()
    {
        RuleFor(x => x.Response)
            .Must(r => r == Domain.Enums.DonorResponse.Accepted || r == Domain.Enums.DonorResponse.Declined)
            .WithMessage("Response must be Accepted or Declined");
    }
}

public class ToggleAvailabilityRequestValidator : AbstractValidator<ToggleAvailabilityRequest>
{
    public ToggleAvailabilityRequestValidator()
    {
        RuleFor(x => x.AvailabilityStatus)
            .IsInEnum().WithMessage("Invalid availability status");
    }
}

public class ToggleUserActiveRequestValidator : AbstractValidator<ToggleUserActiveRequest>
{
    // No complex rules needed; just ensures the property is bound
}

public class VerifyDonorRequestValidator : AbstractValidator<VerifyDonorRequest>
{
    public VerifyDonorRequestValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid verification status");
    }
}

public class ResolveReportRequestValidator : AbstractValidator<ResolveReportRequest>
{
    public ResolveReportRequestValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid report status");
        RuleFor(x => x.Resolution)
            .MaximumLength(2000).WithMessage("Resolution must not exceed 2000 characters")
            .When(x => !string.IsNullOrEmpty(x.Resolution));
    }
}

public class DonorSearchRequestValidator : AbstractValidator<DonorSearchRequest>
{
    public DonorSearchRequestValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page must be at least 1");
        RuleFor(x => x.PageSize).InclusiveBetween(1, 50).WithMessage("Page size must be between 1 and 50");
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue).WithMessage("Latitude must be between -90 and 90");
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue).WithMessage("Longitude must be between -180 and 180");
    }
}

public class BloodRequestSearchRequestValidator : AbstractValidator<BloodRequestSearchRequest>
{
    public BloodRequestSearchRequestValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page must be at least 1");
        RuleFor(x => x.PageSize).InclusiveBetween(1, 50).WithMessage("Page size must be between 1 and 50");
    }
}
