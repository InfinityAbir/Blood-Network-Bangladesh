using BloodNetwork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations;

/// <summary>
/// Removes historical soft-deleted FCM tokens. They still occupy the unique Token index and
/// otherwise prevent the same Android installation from registering after logout/login.
/// </summary>
[DbContext(typeof(BloodNetworkDbContext))]
[Migration("20260902201500_RemoveSoftDeletedDeviceTokens")]
public partial class RemoveSoftDeletedDeviceTokens : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM \"DeviceTokens\" WHERE \"IsDeleted\" = TRUE;");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Deleted token values are intentionally not recoverable.
    }
}
