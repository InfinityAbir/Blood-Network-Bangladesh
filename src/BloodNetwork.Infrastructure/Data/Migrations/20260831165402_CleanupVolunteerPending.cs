using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CleanupVolunteerPending : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Data cleanup for dead states: Volunteer (Role=2) -> Requester (1), Pending (1) -> Unverified (0)
            migrationBuilder.Sql(@"UPDATE ""Users"" SET ""Role"" = 1 WHERE ""Role"" = 2;");
            migrationBuilder.Sql(@"UPDATE ""DonorProfiles"" SET ""VerificationStatus"" = 0 WHERE ""VerificationStatus"" = 1;");
            migrationBuilder.Sql(@"UPDATE ""VerificationRecords"" SET ""Status"" = 0 WHERE ""Status"" = 1;");

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 16, 54, 1, 549, DateTimeKind.Utc).AddTicks(6073));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""Users"" SET ""Role"" = 2 WHERE ""Role"" = 1 AND ""Id"" IN (SELECT ""UserId"" FROM ""DonorProfiles"" WHERE ""VerificationStatus"" = 0); -- best-effort revert, original Volunteer rows not recoverable precisely");
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
    }
}
