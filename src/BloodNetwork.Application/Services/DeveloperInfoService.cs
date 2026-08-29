using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Interfaces;

namespace BloodNetwork.Application.Services;

public class DeveloperInfoService : IDeveloperInfoService
{
    private readonly IRepository<DeveloperInfo> _repo;
    private readonly IUnitOfWork _unitOfWork;

    public DeveloperInfoService(IRepository<DeveloperInfo> repo, IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeveloperInfoDto> GetAsync()
    {
        var info = await GetOrCreateRowAsync();
        return ToDto(info);
    }

    public async Task<DeveloperInfoDto> UpdateAsync(UpdateDeveloperInfoRequest request)
    {
        var info = await GetOrCreateRowAsync();
        info.Name = request.Name.Trim();
        info.Role = request.Role.Trim();
        info.Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim();
        info.Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim();
        info.LinkedInUrl = string.IsNullOrWhiteSpace(request.LinkedInUrl) ? null : request.LinkedInUrl.Trim();
        info.GithubUrl = string.IsNullOrWhiteSpace(request.GithubUrl) ? null : request.GithubUrl.Trim();
        info.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();
        return ToDto(info);
    }

    private async Task<DeveloperInfo> GetOrCreateRowAsync()
    {
        var existing = await _repo.FirstOrDefaultAsync(_ => true);
        if (existing != null) return existing;

        // Defensive fallback in case the seeded row was ever removed manually.
        var created = new DeveloperInfo { Name = "Unknown", Role = "Developer" };
        await _repo.AddAsync(created);
        await _unitOfWork.SaveChangesAsync();
        return created;
    }

    private static DeveloperInfoDto ToDto(DeveloperInfo info) => new()
    {
        Name = info.Name,
        Role = info.Role,
        Email = info.Email,
        Phone = info.Phone,
        LinkedInUrl = info.LinkedInUrl,
        GithubUrl = info.GithubUrl,
    };
}
