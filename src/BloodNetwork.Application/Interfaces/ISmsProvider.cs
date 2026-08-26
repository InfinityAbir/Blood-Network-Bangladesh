namespace BloodNetwork.Application.Interfaces;

public interface ISmsProvider
{
    Task<bool> SendSmsAsync(string phoneNumber, string message);
}
