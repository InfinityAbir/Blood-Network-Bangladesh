using BloodNetwork.Domain.Entities;
using BloodNetwork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodNetwork.IntegrationTests;

/// <summary>
/// The Testing environment creates its InMemory database lazily on first SaveChanges
/// (programmatic path, no EnsureCreated), so HasData location seeds never run. This
/// helper inserts the minimal Dhaka location chain used by request-creation tests.
/// </summary>
public static class TestDataSeeder
{
    public static readonly Guid DhakaDivision = new("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d");
    public static readonly Guid DhakaDistrict = new("11111111-1111-4111-8111-111111111101");
    public static readonly Guid GulshanUpazila = new("aa000001-0000-4000-8000-000000000012");

    private static readonly object Gate = new();

    public static void EnsureDhakaLocations(IServiceProvider services)
    {
        // Guard against parallel test classes seeding the shared in-memory DB.
        lock (Gate)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();

            if (db.Districts.Any(d => d.Id == DhakaDistrict)) return;

            db.Divisions.Add(new Division
            {
                Id = DhakaDivision,
                Name = "Dhaka",
                NameBn = "ঢাকা",
                CreatedAt = DateTime.UtcNow
            });
            db.SaveChanges();

            db.Districts.Add(new District
            {
                Id = DhakaDistrict,
                DivisionId = DhakaDivision,
                Name = "Dhaka",
                NameBn = "ঢাকা",
                CreatedAt = DateTime.UtcNow
            });
            db.SaveChanges();

            db.Upazilas.Add(new Upazila
            {
                Id = GulshanUpazila,
                DistrictId = DhakaDistrict,
                Name = "Gulshan",
                NameBn = "গুলশান",
                CreatedAt = DateTime.UtcNow
            });
            db.SaveChanges();
        }
    }
}