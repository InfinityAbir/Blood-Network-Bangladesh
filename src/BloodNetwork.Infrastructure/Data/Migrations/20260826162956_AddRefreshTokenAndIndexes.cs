using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenAndIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "VerificationRecords",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VerificationRecords",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Upazilas",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Upazilas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Reports",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notifications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DonorProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DonorProfiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "DonationRecords",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DonationRecords",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Divisions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Divisions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Districts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Districts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BloodRequests",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BloodRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BloodRequestMatches",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BloodRequestMatches",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AuditLogs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AuditLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111101"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(3710), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111102"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4667), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111103"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4698), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111104"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4700), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111105"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4702), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111106"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4710), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111107"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4712), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111108"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4713), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111109"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4715), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111110"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4717), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4719), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4720), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222201"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4722), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222202"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4740), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222203"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4745), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222204"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4747), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222205"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4748), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222206"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4751), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222207"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4752), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222208"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4754), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222209"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4755), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222210"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4767), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4769), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333301"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4770), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333302"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4772), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333303"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4773), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333304"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4775), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333305"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4776), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333306"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4778), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333307"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4779), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333308"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4781), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444401"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4782), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444402"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4784), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444403"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4798), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444404"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4799), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444405"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4801), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444406"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4802), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444407"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4803), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444408"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4805), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444409"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4806), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444410"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4819), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555501"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4821), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555502"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4822), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555503"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4824), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555504"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4825), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555505"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4827), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555506"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4828), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666601"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4830), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666602"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4831), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666603"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4832), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666604"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4834), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777701"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4836), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777702"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4837), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777703"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4839), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777704"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4840), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777705"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4841), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777706"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4843), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777707"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4844), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777708"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4846), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888801"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4847), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888802"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4849), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888803"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4850), null, false });

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888804"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4853), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(4719), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6442), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6412), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6444), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6418), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6421), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6425), null, false });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6439), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(720), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(2785), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(3164), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(3494), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000005"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(3815), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000006"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(4138), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(4454), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(4777), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(5090), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(5426), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(5747), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(6154), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(6481), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(6839), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(7158), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(7473), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(7778), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(8103), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(8418), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(8780), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(9105), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(9417), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(9722), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(28), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(335), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(642), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(960), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(1264), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(1565), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(1872), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(2179), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(2489), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(2794), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000004"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(3099), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(3432), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(3744), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4049), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4356), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4663), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4968), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(5269), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(5572), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(5886), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(6195), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(6500), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(6811), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(7114), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(7423), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(7728), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(8064), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(8375), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(8744), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9060), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9368), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9674), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9979), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(285), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(594), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(902), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(1219), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(1527), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(1832), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(2411), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(2875), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(3346), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(3759), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(4074), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(4389), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(4819), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(5165), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(5496), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(5807), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(6193), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(6524), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(6831), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(7138), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(7461), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(7770), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(8149), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(8490), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(8827), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(9165), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(9546), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(94), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(613), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(1067), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(1546), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(1983), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(2409), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(2838), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(3267), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(3716), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(4148), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(4604), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(5046), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(6274), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(8005), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(8918), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(9499), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(3), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(412), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(1200), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(1879), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(2577), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(3105), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(3733), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000003"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(5743), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(273), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(1824), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(2418), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(3135), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(3660), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(4247), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(4667), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(5152), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(6055), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(6494), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(6952), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(7464), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(8076), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(8673), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(9124), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(9661), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(257), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(645), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(1022), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(1398), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(1795), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(2169), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(2572), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(2951), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(3327), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(3709), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(4087), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(4469), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000001"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(4844), null, false });

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000002"),
                columns: new[] { "CreatedAt", "DeletedAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(5223), null, false });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_DistrictId_UpazilaId",
                table: "DonorProfiles",
                columns: new[] { "DistrictId", "UpazilaId" });

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_Status_BloodGroup",
                table: "BloodRequests",
                columns: new[] { "Status", "BloodGroup" });

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestMatches_DonorResponse",
                table: "BloodRequestMatches",
                column: "DonorResponse");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityType",
                table: "AuditLogs",
                column: "EntityType");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId_IsRevoked",
                table: "RefreshTokens",
                columns: new[] { "UserId", "IsRevoked" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId1",
                table: "RefreshTokens",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_DonorProfiles_DistrictId_UpazilaId",
                table: "DonorProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequests_Status_BloodGroup",
                table: "BloodRequests");

            migrationBuilder.DropIndex(
                name: "IX_BloodRequestMatches_DonorResponse",
                table: "BloodRequestMatches");

            migrationBuilder.DropIndex(
                name: "IX_AuditLogs_EntityType",
                table: "AuditLogs");

            migrationBuilder.DropIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "VerificationRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VerificationRecords");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Upazilas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Upazilas");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DonorProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DonorProfiles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "DonationRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DonationRecords");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BloodRequests");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BloodRequestMatches");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BloodRequestMatches");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AuditLogs");

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111101"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111102"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111103"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111104"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111105"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111106"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111107"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111108"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111109"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111110"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222201"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222202"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222203"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222204"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222205"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222206"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222207"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222208"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222209"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222210"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333301"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333302"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333303"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333304"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333305"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333306"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333307"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333308"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4640));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444401"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444402"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444403"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444404"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4652));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444405"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444406"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444407"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444408"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444409"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444410"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555501"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555502"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555503"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555504"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555505"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555506"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666601"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666602"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666603"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666604"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777701"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777702"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777703"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777704"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777705"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777706"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777707"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777708"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888801"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888802"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4794));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888803"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888804"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 403, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 398, DateTimeKind.Utc).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 399, DateTimeKind.Utc).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 419, DateTimeKind.Utc).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 420, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 421, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(3616));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 422, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(3469));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 423, DateTimeKind.Utc).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(1257));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(2711));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(4462));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 14, 18, 47, 424, DateTimeKind.Utc).AddTicks(5150));
        }
    }
}
