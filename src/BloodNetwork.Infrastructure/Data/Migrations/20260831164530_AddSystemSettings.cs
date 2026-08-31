using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MinimumDonationIntervalDays = table.Column<int>(type: "integer", nullable: false),
                    DonorProfileConfirmationDays = table.Column<int>(type: "integer", nullable: false),
                    MaxActiveRequestsPerUser = table.Column<int>(type: "integer", nullable: false),
                    ContactCooldownHours = table.Column<int>(type: "integer", nullable: false),
                    ExactBloodGroupWeight = table.Column<int>(type: "integer", nullable: false),
                    CompatibleBloodGroupWeight = table.Column<int>(type: "integer", nullable: false),
                    AvailableWeight = table.Column<int>(type: "integer", nullable: false),
                    UnknownWeight = table.Column<int>(type: "integer", nullable: false),
                    VerifiedWeight = table.Column<int>(type: "integer", nullable: false),
                    UnverifiedWeight = table.Column<int>(type: "integer", nullable: false),
                    ProfileFreshnessWeight = table.Column<int>(type: "integer", nullable: false),
                    Distance0to3kmWeight = table.Column<int>(type: "integer", nullable: false),
                    Distance3to10kmWeight = table.Column<int>(type: "integer", nullable: false),
                    Distance10to25kmWeight = table.Column<int>(type: "integer", nullable: false),
                    DistanceOver25kmWeight = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 45, 26, 522, DateTimeKind.Utc).AddTicks(6675));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 72, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(624));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 30, 12, 0, 8, 73, DateTimeKind.Utc).AddTicks(1041));
        }
    }
}
