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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloodNetworkDbContext).Assembly);
        SeedLocations(modelBuilder);
        base.OnModelCreating(modelBuilder);
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
