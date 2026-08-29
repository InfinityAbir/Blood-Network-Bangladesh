using BloodNetwork.Application.DTOs;

namespace BloodNetwork.Application.Interfaces;

public interface IDeveloperInfoService
{
    Task<DeveloperInfoDto> GetAsync();
    Task<DeveloperInfoDto> UpdateAsync(UpdateDeveloperInfoRequest request);
}
