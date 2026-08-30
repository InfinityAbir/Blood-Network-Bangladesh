using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Platform = table.Column<int>(type: "integer", nullable: false),
                    LastActiveAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTokens_Token",
                table: "DeviceTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTokens_UserId_Platform",
                table: "DeviceTokens",
                columns: new[] { "UserId", "Platform" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceTokens");

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 17, 40, 7, 416, DateTimeKind.Utc).AddTicks(9756));
        }
    }
}
