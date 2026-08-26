using BloodNetwork.Domain.Entities;
using BloodNetwork.Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BloodNetwork.Infrastructure.Data;

public class BloodNetworkDbContext : DbContext
{
    public BloodNetworkDbContext(DbContextOptions<BloodNetworkDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<DonorProfile> DonorProfiles => Set<DonorProfile>();
    public DbSet<Division> Divisions => Set<Division>();
    public DbSet<District> Districts => Set<District>();
    public DbSet<Upazila> Upazilas => Set<Upazila>();
    public DbSet<BloodRequest> BloodRequests => Set<BloodRequest>();
    public DbSet<BloodRequestMatch> BloodRequestMatches => Set<BloodRequestMatch>();
    public DbSet<DonationRecord> DonationRecords => Set<DonationRecord>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<VerificationRecord> VerificationRecords => Set<VerificationRecord>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloodNetworkDbContext).Assembly);
        SeedLocations(modelBuilder);
        ConfigureIndexes(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void ConfigureIndexes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(u => u.PhoneNumber).IsUnique();
            e.HasIndex(u => u.Role);
            e.HasIndex(u => u.IsActive);
        });

        modelBuilder.Entity<DonorProfile>(e =>
        {
            e.HasIndex(p => p.UserId).IsUnique();
            e.HasIndex(p => p.DistrictId);
            e.HasIndex(p => p.UpazilaId);
            e.HasIndex(p => p.VerificationStatus);
            e.HasIndex(p => p.AvailabilityStatus);
            e.HasIndex(p => new { p.DistrictId, p.UpazilaId });
        });

        modelBuilder.Entity<BloodRequest>(e =>
        {
            e.HasIndex(r => r.RequesterId);
            e.HasIndex(r => r.Status);
            e.HasIndex(r => r.DistrictId);
            e.HasIndex(r => r.BloodGroup);
            e.HasIndex(r => new { r.Status, r.BloodGroup });
        });

        modelBuilder.Entity<BloodRequestMatch>(e =>
        {
            e.HasIndex(m => m.BloodRequestId);
            e.HasIndex(m => m.DonorId);
            e.HasIndex(m => m.DonorResponse);
        });

        modelBuilder.Entity<Notification>(e =>
        {
            e.HasIndex(n => n.UserId);
            e.HasIndex(n => new { n.UserId, n.IsRead });
        });

        modelBuilder.Entity<AuditLog>(e =>
        {
            e.HasIndex(l => l.EntityType);
            e.HasIndex(l => l.UserId);
            e.HasIndex(l => l.CreatedAt);
        });

        modelBuilder.Entity<RefreshToken>(e =>
        {
            e.HasIndex(t => t.Token).IsUnique();
            e.HasIndex(t => t.UserId);
            e.HasIndex(t => new { t.UserId, t.IsRevoked });
        });
    }

    private static void SeedLocations(ModelBuilder modelBuilder)
    {
        var divisions = BangladeshLocationSeed.GetDivisions();
        var districts = BangladeshLocationSeed.GetDistricts();
        var upazilas = BangladeshLocationSeed.GetUpazilas();

        modelBuilder.Entity<Division>().HasData(divisions);
        modelBuilder.Entity<District>().HasData(districts);
        modelBuilder.Entity<Upazila>().HasData(upazilas);
    }
}
