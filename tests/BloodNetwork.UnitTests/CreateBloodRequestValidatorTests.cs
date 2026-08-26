using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Validators;
using BloodNetwork.Domain.Enums;
using FluentValidation.TestHelper;

namespace BloodNetwork.UnitTests;

public class CreateBloodRequestValidatorTests
{
    private readonly CreateBloodRequestRequestValidator _validator = new();

    private static CreateBloodRequestRequest ValidRequest(
        BloodGroup bloodGroup = BloodGroup.OPositive,
        int units = 2,
        string hospitalName = "Square Hospital",
        string hospitalAddress = "Dhaka",
        Urgency urgency = Urgency.Urgent,
        string contactPhone = "01712345678")
        => new(bloodGroup, units, hospitalName, hospitalAddress,
            Guid.NewGuid(), Guid.NewGuid(), null,
            DateTime.UtcNow.AddDays(1), urgency,
            null, null, contactPhone, null, null, null);

    [Fact]
    public void ValidRequest_Passes()
    {
        var result = _validator.TestValidate(ValidRequest());
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void ZeroUnits_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(units: 0));
        result.ShouldHaveValidationErrorFor(x => x.UnitsRequired);
    }

    [Fact]
    public void MoreThan10Units_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(units: 11));
        result.ShouldHaveValidationErrorFor(x => x.UnitsRequired);
    }

    [Fact]
    public void EmptyHospitalName_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(hospitalName: ""));
        result.ShouldHaveValidationErrorFor(x => x.HospitalName);
    }

    [Fact]
    public void InvalidPhone_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(contactPhone: "12345"));
        result.ShouldHaveValidationErrorFor(x => x.ContactPhone);
    }
}
