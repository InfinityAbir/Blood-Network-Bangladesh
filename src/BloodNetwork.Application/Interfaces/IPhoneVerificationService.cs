namespace BloodNetwork.Application.Interfaces;

public interface IPhoneVerificationService
{
    Task<bool> SendOtpAsync(string phoneNumber);
    Task<bool> VerifyOtpAsync(string phoneNumber, string code);
}
