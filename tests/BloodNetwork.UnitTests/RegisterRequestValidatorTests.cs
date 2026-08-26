using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Validators;
using BloodNetwork.Domain.Enums;
using FluentValidation.TestHelper;

namespace BloodNetwork.UnitTests;

public class RegisterRequestValidatorTests
{
    private readonly RegisterRequestValidator _validator = new();

    private static RegisterRequest ValidRequest(
        string phone = "01712345678",
        string password = "Password1",
        UserRole role = UserRole.Requester,
        string firstName = "Test",
        string lastName = "User",
        string? email = null)
        => new(firstName, lastName, phone, password, email, role);

    [Theory]
    [InlineData("01712345678")]
    [InlineData("01812345678")]
    [InlineData("01912345678")]
    [InlineData("01312345678")]
    public void ValidPhone_Passes(string phone)
    {
        var result = _validator.TestValidate(ValidRequest(phone: phone));
        result.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber);
    }

    [Theory]
    [InlineData("1234567890")]
    [InlineData("01234567890")]
    [InlineData("01112345678")]
    [InlineData("")]
    public void InvalidPhone_Fails(string phone)
    {
        var result = _validator.TestValidate(ValidRequest(phone: phone));
        result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
    }

    [Theory]
    [InlineData("Password1")]
    [InlineData("StrongP@ss1")]
    public void ValidPassword_Passes(string password)
    {
        var result = _validator.TestValidate(ValidRequest(password: password));
        result.ShouldNotHaveValidationErrorFor(x => x.Password);
    }

    [Theory]
    [InlineData("short")]
    [InlineData("nouppercase1")]
    [InlineData("NOLOWERCASE1")]
    [InlineData("NoDigit")]
    public void InvalidPassword_Fails(string password)
    {
        var result = _validator.TestValidate(ValidRequest(password: password));
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void AdminRole_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(role: UserRole.Admin));
        result.ShouldHaveValidationErrorFor(x => x.Role);
    }

    [Fact]
    public void DonorRole_Passes()
    {
        var result = _validator.TestValidate(ValidRequest(role: UserRole.Donor));
        result.ShouldNotHaveValidationErrorFor(x => x.Role);
    }

    [Fact]
    public void RequesterRole_Passes()
    {
        var result = _validator.TestValidate(ValidRequest(role: UserRole.Requester));
        result.ShouldNotHaveValidationErrorFor(x => x.Role);
    }

    [Fact]
    public void EmptyFirstName_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(firstName: ""));
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void ValidEmail_Passes()
    {
        var result = _validator.TestValidate(ValidRequest(email: "test@example.com"));
        result.ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void InvalidEmail_Fails()
    {
        var result = _validator.TestValidate(ValidRequest(email: "not-an-email"));
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }
}
