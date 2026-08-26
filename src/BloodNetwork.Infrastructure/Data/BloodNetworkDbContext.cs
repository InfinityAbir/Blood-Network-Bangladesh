using BloodNetwork.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodNetwork.Infrastructure.Data;

public class BloodNetworkDbContext : DbContext
{
    public BloodNetworkDbContext(DbContextOptions<BloodNetworkDbContext> options) : base(options) { }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloodNetworkDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
