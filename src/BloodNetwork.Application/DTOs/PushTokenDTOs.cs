using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public record RegisterPushTokenRequest(
    string Token,
    DevicePlatform Platform = DevicePlatform.Android
);