using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEligibilityState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEligibilityStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswersJson = table.Column<string>(type: "jsonb", nullable: false),
                    ResultJson = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEligibilityStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEligibilityStates_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserEligibilityStates_UserId",
                table: "UserEligibilityStates",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEligibilityStates");

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9574));

            migrationBuilder.UpdateData(
                table: "EligibilityQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9577));
        }
    }
}
