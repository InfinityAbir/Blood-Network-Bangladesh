using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Application.Services;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace BloodNetwork.UnitTests;

public class MatchingServiceTests
{
    private readonly Mock<IRepository<BloodRequest>> _requestRepoMock = new();
    private readonly Mock<IRepository<BloodRequestMatch>> _matchRepoMock = new();
    private readonly Mock<IRepository<DonorProfile>> _donorProfileRepoMock = new();
    private readonly Mock<IRepository<User>> _userRepoMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IMapService> _mapServiceMock = new();
    private readonly Mock<INotificationService> _notificationServiceMock = new();
    private readonly Mock<ILogger<MatchingService>> _loggerMock = new();

    private readonly MatchingService _service;

    public MatchingServiceTests()
    {
        var options = Options.Create(new MatchScoreWeightsOptions
        {
            ExactBloodGroup = 30,
            CompatibleBloodGroup = 0,
            Available = 30,
            Unknown = 0,
            Verified = 15,
            Pending = 5,
            Unverified = 0,
            ProfileFreshness = 10,
            Distance0to3km = 15,
            Distance3to10km = 10,
            Distance10to25km = 5,
            DistanceOver25km = 0
        });

        _service = new MatchingService(
            _requestRepoMock.Object,
            _matchRepoMock.Object,
            _donorProfileRepoMock.Object,
            _userRepoMock.Object,
            _unitOfWorkMock.Object,
            _mapServiceMock.Object,
            _notificationServiceMock.Object,
            options,
            _loggerMock.Object);
    }

    [Fact]
    public async Task MatchRequestAsync_RequestNotFound_ReturnsEmpty()
    {
        _requestRepoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((BloodRequest?)null);

        var result = await _service.MatchRequestAsync(Guid.NewGuid());

        Assert.Empty(result);
    }

    [Fact]
    public async Task MatchRequestAsync_APositiveDonor_MatchesAPositiveRequest()
    {
        var requestId = Guid.NewGuid();
        var donorUserId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive,
            Latitude = 23.8103,
            Longitude = 90.4125
        };

        var donorProfile = new DonorProfile
        {
            UserId = donorUserId,
            BloodGroup = BloodGroup.APositive,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified,
            Latitude = 23.8200,
            Longitude = 90.4200
        };

        var donorUser = new User { Id = donorUserId, IsActive = true };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { donorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { donorUser });
        _mapServiceMock.Setup(m => m.CalculateDistanceKm(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
            .Returns(2.5);

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Single(result);
        Assert.Equal(donorUserId, result[0].DonorId);
        Assert.True(result[0].MatchScore > 0);
    }

    [Fact]
    public async Task MatchRequestAsync_BNegativeDonor_DoesNotMatchAPositiveRequest()
    {
        var requestId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive
        };

        var donorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.BNegative,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified
        };

        var donorUser = new User { Id = donorProfile.UserId, IsActive = true };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { donorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { donorUser });

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Empty(result);
    }

    [Fact]
    public async Task MatchRequestAsync_UNegativeDonor_MatchesAllRequestGroups()
    {
        var requestId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive
        };

        var donorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.ONegative,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified
        };

        var donorUser = new User { Id = donorProfile.UserId, IsActive = true };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { donorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { donorUser });
        _mapServiceMock.Setup(m => m.CalculateDistanceKm(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
            .Returns(1.0);

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Single(result);
    }

    [Fact]
    public async Task MatchRequestAsync_ABPositiveDonor_OnlyMatchesABPositiveRequest()
    {
        var requestId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.ABPositive
        };

        var donorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.ABPositive,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified
        };

        var donorUser = new User { Id = donorProfile.UserId, IsActive = true };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { donorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { donorUser });
        _mapServiceMock.Setup(m => m.CalculateDistanceKm(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()))
            .Returns(1.0);

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Single(result);
    }

    [Fact]
    public async Task MatchRequestAsync_UnavailableDonor_Skipped()
    {
        var requestId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive
        };

        var donorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive,
            AvailabilityStatus = AvailabilityStatus.Unavailable,
            VerificationStatus = VerificationStatus.Verified
        };

        var donorUser = new User { Id = donorProfile.UserId, IsActive = true };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { donorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { donorUser });

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Empty(result);
    }

    [Fact]
    public async Task MatchRequestAsync_InactiveUser_Skipped()
    {
        var requestId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive
        };

        var donorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.APositive,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified
        };

        var donorUser = new User { Id = donorProfile.UserId, IsActive = false };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { donorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { donorUser });

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Empty(result);
    }

    [Fact]
    public async Task MatchRequestAsync_CloseDonorGetsHigherScore()
    {
        var requestId = Guid.NewGuid();

        var request = new BloodRequest
        {
            Id = requestId,
            RequesterId = Guid.NewGuid(),
            BloodGroup = BloodGroup.OPositive,
            Latitude = 23.8103,
            Longitude = 90.4125
        };

        var closeDonorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.OPositive,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified,
            Latitude = 23.8150,
            Longitude = 90.4150
        };

        var farDonorProfile = new DonorProfile
        {
            UserId = Guid.NewGuid(),
            BloodGroup = BloodGroup.OPositive,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Verified,
            Latitude = 23.9000,
            Longitude = 90.5000
        };

        var closeUser = new User { Id = closeDonorProfile.UserId, IsActive = true };
        var farUser = new User { Id = farDonorProfile.UserId, IsActive = true };

        _requestRepoMock.Setup(r => r.GetByIdAsync(requestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(request);
        _matchRepoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<BloodRequestMatch, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Array.Empty<BloodRequestMatch>());
        _donorProfileRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<DonorProfile> { closeDonorProfile, farDonorProfile });
        _userRepoMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<User> { closeUser, farUser });
        _mapServiceMock.Setup(m => m.CalculateDistanceKm(closeDonorProfile.Latitude!.Value, closeDonorProfile.Longitude!.Value, request.Latitude!.Value, request.Longitude!.Value))
            .Returns(1.0);
        _mapServiceMock.Setup(m => m.CalculateDistanceKm(farDonorProfile.Latitude!.Value, farDonorProfile.Longitude!.Value, request.Latitude!.Value, request.Longitude!.Value))
            .Returns(20.0);

        var result = await _service.MatchRequestAsync(requestId);

        Assert.Equal(2, result.Count);
        Assert.True(result[0].MatchScore > result[1].MatchScore);
    }

    [Fact]
    public async Task RespondToMatchAsync_ValidAccept_UpdatesStatus()
    {
        var matchId = Guid.NewGuid();
        var userId = Guid.NewGuid();

        var match = new BloodRequestMatch
        {
            Id = matchId,
            DonorId = userId,
            BloodRequestId = Guid.NewGuid(),
            DonorResponse = DonorResponse.Pending
        };

        _matchRepoMock.Setup(r => r.GetByIdAsync(matchId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(match);
        _requestRepoMock.Setup(r => r.GetByIdAsync(match.BloodRequestId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BloodRequest { Id = match.BloodRequestId, RequesterId = Guid.NewGuid(), HospitalName = "Test Hospital" });
        _userRepoMock.Setup(r => r.GetByIdAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User { Id = userId, FirstName = "Donor", LastName = "Test" });

        var result = await _service.RespondToMatchAsync(matchId, userId, DonorResponse.Accepted);

        Assert.NotNull(result);
        Assert.Equal(DonorResponse.Accepted, result!.DonorResponse);
        Assert.NotNull(result.AcceptedAt);
    }

    [Fact]
    public async Task RespondToMatchAsync_WrongUser_ReturnsNull()
    {
        var matchId = Guid.NewGuid();

        var match = new BloodRequestMatch
        {
            Id = matchId,
            DonorId = Guid.NewGuid(),
            BloodRequestId = Guid.NewGuid(),
            DonorResponse = DonorResponse.Pending
        };

        _matchRepoMock.Setup(r => r.GetByIdAsync(matchId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(match);

        var result = await _service.RespondToMatchAsync(matchId, Guid.NewGuid(), DonorResponse.Accepted);

        Assert.Null(result);
    }
}
