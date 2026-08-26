using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EntityType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    Metadata = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameBn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsPhoneVerified = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameBn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    RelatedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificationRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    VerifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upazilas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameBn = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upazilas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upazilas_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodGroup = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UnitsRequired = table.Column<int>(type: "integer", nullable: false),
                    UnitsFulfilled = table.Column<int>(type: "integer", nullable: false),
                    HospitalName = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    HospitalAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpazilaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Area = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    RequiredBy = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Urgency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    PatientName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PatientRelation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ContactPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AdditionalInformation = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodRequests_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodRequests_Upazilas_UpazilaId",
                        column: x => x.UpazilaId,
                        principalTable: "Upazilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodRequests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonorProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodGroup = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpazilaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Area = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LastDonationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AvailabilityStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VerificationStatus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastProfileConfirmedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalDonationCount = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonorProfiles_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonorProfiles_Upazilas_UpazilaId",
                        column: x => x.UpazilaId,
                        principalTable: "Upazilas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonorProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequestMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    DonorId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatchScore = table.Column<int>(type: "integer", nullable: false),
                    DistanceKm = table.Column<double>(type: "double precision", nullable: true),
                    DonorResponse = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ContactedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RespondedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AcceptedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeclinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequestMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodRequestMatches_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodRequestMatches_Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReporterUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodRequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    Reason = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ReviewedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Resolution = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReportedUserId",
                        column: x => x.ReportedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReporterUserId",
                        column: x => x.ReporterUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DonorId = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodRequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    DonationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DonationLocation = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Units = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DonorProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationRecords_BloodRequests_BloodRequestId",
                        column: x => x.BloodRequestId,
                        principalTable: "BloodRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DonationRecords_DonorProfiles_DonorProfileId",
                        column: x => x.DonorProfileId,
                        principalTable: "DonorProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DonationRecords_Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "CreatedAt", "Name", "NameBn", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(2635), "Dhaka", "ঢাকা", null },
                    { new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4355), "Rangpur", "রংপুর", null },
                    { new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4328), "Chattogram", "চট্টগ্রাম", null },
                    { new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4356), "Mymensingh", "ময়মনসিংহ", null },
                    { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4338), "Rajshahi", "রাজশাহী", null },
                    { new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4342), "Khulna", "খুলনা", null },
                    { new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4345), "Barishal", "বরিশাল", null },
                    { new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4352), "Sylhet", "সিলেট", null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CreatedAt", "DivisionId", "Name", "NameBn", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-4111-8111-111111111101"), new DateTime(2026, 8, 26, 13, 2, 13, 621, DateTimeKind.Utc).AddTicks(8608), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Dhaka", "ঢাকা", null },
                    { new Guid("11111111-1111-4111-8111-111111111102"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(195), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Gazipur", "গাজীপুর", null },
                    { new Guid("11111111-1111-4111-8111-111111111103"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(206), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Narayanganj", "নারায়ণগঞ্জ", null },
                    { new Guid("11111111-1111-4111-8111-111111111104"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(209), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Manikganj", "মানিকগঞ্জ", null },
                    { new Guid("11111111-1111-4111-8111-111111111105"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(211), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Munshiganj", "মুন্সিগঞ্জ", null },
                    { new Guid("11111111-1111-4111-8111-111111111106"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(220), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Tangail", "টাঙ্গাইল", null },
                    { new Guid("11111111-1111-4111-8111-111111111107"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(223), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Kishoreganj", "কিশোরগঞ্জ", null },
                    { new Guid("11111111-1111-4111-8111-111111111108"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(266), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Faridpur", "ফরিদপুর", null },
                    { new Guid("11111111-1111-4111-8111-111111111109"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(269), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Gopalganj", "গোপালগঞ্জ", null },
                    { new Guid("11111111-1111-4111-8111-111111111110"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(271), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Madaripur", "মাদারীপুর", null },
                    { new Guid("11111111-1111-4111-8111-111111111111"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(273), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Rajbari", "রাজবাড়ী", null },
                    { new Guid("11111111-1111-4111-8111-111111111112"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(275), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "Narsingdi", "নরসিংদী", null },
                    { new Guid("22222222-2222-4222-8222-222222222201"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(277), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Chattogram", "চট্টগ্রাম", null },
                    { new Guid("22222222-2222-4222-8222-222222222202"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(322), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Cox's Bazar", "কক্সবাজার", null },
                    { new Guid("22222222-2222-4222-8222-222222222203"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(328), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Comilla", "কুমিল্লা", null },
                    { new Guid("22222222-2222-4222-8222-222222222204"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(330), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Brahmanbaria", "ব্রাহ্মণবাড়িয়া", null },
                    { new Guid("22222222-2222-4222-8222-222222222205"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(332), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Chandpur", "চাঁদপুর", null },
                    { new Guid("22222222-2222-4222-8222-222222222206"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(334), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Lakshmipur", "লক্ষ্মীপুর", null },
                    { new Guid("22222222-2222-4222-8222-222222222207"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(337), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Noakhali", "নোয়াখালী", null },
                    { new Guid("22222222-2222-4222-8222-222222222208"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(339), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Feni", "ফেনী", null },
                    { new Guid("22222222-2222-4222-8222-222222222209"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(341), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Khagrachhari", "খাগড়াছড়ি", null },
                    { new Guid("22222222-2222-4222-8222-222222222210"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(342), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Rangamati", "রাঙ্গামাটি", null },
                    { new Guid("22222222-2222-4222-8222-222222222211"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(344), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Bandarban", "বান্দরবান", null },
                    { new Guid("33333333-3333-4333-8333-333333333301"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(345), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Rajshahi", "রাজশাহী", null },
                    { new Guid("33333333-3333-4333-8333-333333333302"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(347), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Natore", "নাটোর", null },
                    { new Guid("33333333-3333-4333-8333-333333333303"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(350), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Bogura", "বগুড়া", null },
                    { new Guid("33333333-3333-4333-8333-333333333304"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(352), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Chapainawabganj", "চাঁপাইনবাবগঞ্জ", null },
                    { new Guid("33333333-3333-4333-8333-333333333305"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(353), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Naogaon", "নওগাঁ", null },
                    { new Guid("33333333-3333-4333-8333-333333333306"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(355), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Sirajganj", "সিরাজগঞ্জ", null },
                    { new Guid("33333333-3333-4333-8333-333333333307"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(356), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Pabna", "পাবনা", null },
                    { new Guid("33333333-3333-4333-8333-333333333308"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(358), new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Joypurhat", "জয়পুরহাট", null },
                    { new Guid("44444444-4444-4444-8444-444444444401"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(359), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Khulna", "খুলনা", null },
                    { new Guid("44444444-4444-4444-8444-444444444402"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(373), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Satkhira", "সাতক্ষীরা", null },
                    { new Guid("44444444-4444-4444-8444-444444444403"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(375), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Jessore", "যশোর", null },
                    { new Guid("44444444-4444-4444-8444-444444444404"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(377), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Bagerhat", "বাগেরহাট", null },
                    { new Guid("44444444-4444-4444-8444-444444444405"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(378), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Jhenaidah", "ঝিনাইদহ", null },
                    { new Guid("44444444-4444-4444-8444-444444444406"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(380), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Magura", "মাগুরা", null },
                    { new Guid("44444444-4444-4444-8444-444444444407"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(381), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Narail", "নড়াইল", null },
                    { new Guid("44444444-4444-4444-8444-444444444408"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(383), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Kushtia", "কুষ্টিয়া", null },
                    { new Guid("44444444-4444-4444-8444-444444444409"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(385), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Meherpur", "মেহেরপুর", null },
                    { new Guid("44444444-4444-4444-8444-444444444410"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(386), new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Chuadanga", "চুয়াডাঙ্গা", null },
                    { new Guid("55555555-5555-4555-8555-555555555501"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(388), new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), "Barishal", "বরিশাল", null },
                    { new Guid("55555555-5555-4555-8555-555555555502"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(389), new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), "Patuakhali", "পটুয়াখালী", null },
                    { new Guid("55555555-5555-4555-8555-555555555503"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(391), new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), "Bhola", "ভোলা", null },
                    { new Guid("55555555-5555-4555-8555-555555555504"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(392), new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), "Pirojpur", "পিরোজপুর", null },
                    { new Guid("55555555-5555-4555-8555-555555555505"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(394), new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), "Jhalakathi", "ঝালকাঠি", null },
                    { new Guid("55555555-5555-4555-8555-555555555506"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(395), new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"), "Barguna", "বরগুনা", null },
                    { new Guid("66666666-6666-4666-8666-666666666601"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(397), new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), "Sylhet", "সিলেট", null },
                    { new Guid("66666666-6666-4666-8666-666666666602"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(398), new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), "Habiganj", "হবিগঞ্জ", null },
                    { new Guid("66666666-6666-4666-8666-666666666603"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(400), new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), "Moulvibazar", "মৌলভীবাজার", null },
                    { new Guid("66666666-6666-4666-8666-666666666604"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(402), new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"), "Sunamganj", "সুনামগঞ্জ", null },
                    { new Guid("77777777-7777-4777-8777-777777777701"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(403), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Rangpur", "রংপুর", null },
                    { new Guid("77777777-7777-4777-8777-777777777702"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(405), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Dinajpur", "দিনাজপুর", null },
                    { new Guid("77777777-7777-4777-8777-777777777703"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(406), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Thakurgaon", "ঠাকুরগাঁও", null },
                    { new Guid("77777777-7777-4777-8777-777777777704"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(408), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Kurigram", "কুড়িগ্রাম", null },
                    { new Guid("77777777-7777-4777-8777-777777777705"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(409), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Gaibandha", "গাইবান্ধা", null },
                    { new Guid("77777777-7777-4777-8777-777777777706"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(411), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Lalmonirhat", "লালমনিরহাট", null },
                    { new Guid("77777777-7777-4777-8777-777777777707"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(412), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Nilphamari", "নীলফামারী", null },
                    { new Guid("77777777-7777-4777-8777-777777777708"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(414), new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"), "Panchagarh", "পঞ্চগড়", null },
                    { new Guid("88888888-8888-4888-8888-888888888801"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(415), new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), "Mymensingh", "ময়মনসিংহ", null },
                    { new Guid("88888888-8888-4888-8888-888888888802"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(417), new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), "Jamalpur", "জামালপুর", null },
                    { new Guid("88888888-8888-4888-8888-888888888803"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(427), new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), "Sherpur", "শেরপুর", null },
                    { new Guid("88888888-8888-4888-8888-888888888804"), new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(428), new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"), "Netrokona", "নেত্রকোণা", null }
                });

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "CreatedAt", "DistrictId", "Name", "NameBn", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aa000001-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 637, DateTimeKind.Utc).AddTicks(8258), new Guid("11111111-1111-4111-8111-111111111101"), "Dhanmondi", "ধানমন্ডি", null },
                    { new Guid("aa000001-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(1957), new Guid("11111111-1111-4111-8111-111111111101"), "Gulshan", "গুলশান", null },
                    { new Guid("aa000001-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(2745), new Guid("11111111-1111-4111-8111-111111111101"), "Mirpur", "মিরপুর", null },
                    { new Guid("aa000001-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(3346), new Guid("11111111-1111-4111-8111-111111111101"), "Uttara", "উত্তরা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(4502), new Guid("11111111-1111-4111-8111-111111111101"), "Mohammadpur", "মোহাম্মদপুর", null },
                    { new Guid("aa000001-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(5562), new Guid("11111111-1111-4111-8111-111111111101"), "Savar", "সাভার", null },
                    { new Guid("aa000002-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(6198), new Guid("11111111-1111-4111-8111-111111111102"), "Gazipur Sadar", "গাজীপুর সদর", null },
                    { new Guid("aa000002-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(7258), new Guid("11111111-1111-4111-8111-111111111102"), "Tongi", "টঙ্গী", null },
                    { new Guid("aa000002-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(7842), new Guid("11111111-1111-4111-8111-111111111102"), "Kaliakair", "কালিয়াইর", null },
                    { new Guid("aa000003-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(8373), new Guid("11111111-1111-4111-8111-111111111103"), "Narayanganj Sadar", "নারায়ণগঞ্জ সদর", null },
                    { new Guid("aa000003-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(8896), new Guid("11111111-1111-4111-8111-111111111103"), "Sonargaon", "সোনারগাঁও", null },
                    { new Guid("aa000003-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(9426), new Guid("11111111-1111-4111-8111-111111111103"), "Bandar", "বন্দর", null },
                    { new Guid("aa000004-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(9981), new Guid("11111111-1111-4111-8111-111111111104"), "Manikganj Sadar", "মানিকগঞ্জ সদর", null },
                    { new Guid("aa000004-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(562), new Guid("11111111-1111-4111-8111-111111111104"), "Singair", "সিঙ্গাইর", null },
                    { new Guid("aa000005-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(1274), new Guid("11111111-1111-4111-8111-111111111105"), "Munshiganj Sadar", "মুন্সিগঞ্জ সদর", null },
                    { new Guid("aa000005-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(1906), new Guid("11111111-1111-4111-8111-111111111105"), "Sreenagar", "শ্রীনগর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(2513), new Guid("11111111-1111-4111-8111-111111111106"), "Tangail Sadar", "টাঙ্গাইল সদর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(2989), new Guid("11111111-1111-4111-8111-111111111106"), "Delduar", "দেলদুয়ার", null },
                    { new Guid("aa000007-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(3506), new Guid("11111111-1111-4111-8111-111111111107"), "Kishoreganj Sadar", "কিশোরগঞ্জ সদর", null },
                    { new Guid("aa000007-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(4040), new Guid("11111111-1111-4111-8111-111111111107"), "Hossainpur", "হোসেনপুর", null },
                    { new Guid("aa000008-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(4595), new Guid("11111111-1111-4111-8111-111111111108"), "Faridpur Sadar", "ফরিদপুর সদর", null },
                    { new Guid("aa000008-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(5107), new Guid("11111111-1111-4111-8111-111111111108"), "Boalmari", "বোয়ালমারী", null },
                    { new Guid("aa000009-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(5684), new Guid("11111111-1111-4111-8111-111111111109"), "Gopalganj Sadar", "গোপালগঞ্জ সদর", null },
                    { new Guid("aa000009-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(6173), new Guid("11111111-1111-4111-8111-111111111109"), "Kotalipara", "কোটালিপাড়া", null },
                    { new Guid("aa000010-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(6606), new Guid("11111111-1111-4111-8111-111111111110"), "Madaripur Sadar", "মাদারীপুর সদর", null },
                    { new Guid("aa000010-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(7021), new Guid("11111111-1111-4111-8111-111111111110"), "Shibchar", "শিবচর", null },
                    { new Guid("aa000011-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(7399), new Guid("11111111-1111-4111-8111-111111111111"), "Rajbari Sadar", "রাজবাড়ী সদর", null },
                    { new Guid("aa000011-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(7798), new Guid("11111111-1111-4111-8111-111111111111"), "Baliakandi", "বালিয়াকান্দি", null },
                    { new Guid("aa000012-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(8310), new Guid("11111111-1111-4111-8111-111111111112"), "Narsingdi Sadar", "নরসিংদী সদর", null },
                    { new Guid("aa000012-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(8807), new Guid("11111111-1111-4111-8111-111111111112"), "Palash", "পলাশ", null },
                    { new Guid("aa000013-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(9372), new Guid("22222222-2222-4222-8222-222222222201"), "Chattogram Sadar", "চট্টগ্রাম সদর", null },
                    { new Guid("aa000013-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(9886), new Guid("22222222-2222-4222-8222-222222222201"), "Pahartali", "পাহাড়তলী", null },
                    { new Guid("aa000013-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(310), new Guid("22222222-2222-4222-8222-222222222201"), "Sitakunda", "সীতাকুণ্ড", null },
                    { new Guid("aa000013-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(2520), new Guid("22222222-2222-4222-8222-222222222201"), "Mirsharai", "মীরসরাই", null },
                    { new Guid("aa000014-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(3352), new Guid("22222222-2222-4222-8222-222222222202"), "Cox's Bazar Sadar", "কক্সবাজার সদর", null },
                    { new Guid("aa000014-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(3945), new Guid("22222222-2222-4222-8222-222222222202"), "Teknaf", "টেকনাফ", null },
                    { new Guid("aa000014-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(4458), new Guid("22222222-2222-4222-8222-222222222202"), "Ukhia", "উখিয়া", null },
                    { new Guid("aa000015-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(4938), new Guid("22222222-2222-4222-8222-222222222203"), "Comilla Sadar", "কুমিল্লা সদর", null },
                    { new Guid("aa000015-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(5463), new Guid("22222222-2222-4222-8222-222222222203"), "Daudkandi", "দাউদকান্দি", null },
                    { new Guid("aa000015-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(5923), new Guid("22222222-2222-4222-8222-222222222203"), "Chandina", "চান্দিনা", null },
                    { new Guid("aa000016-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(6442), new Guid("22222222-2222-4222-8222-222222222204"), "Brahmanbaria Sadar", "ব্রাহ্মণবাড়িয়া সদর", null },
                    { new Guid("aa000016-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(6924), new Guid("22222222-2222-4222-8222-222222222204"), "Ashuganj", "আশুগঞ্জ", null },
                    { new Guid("aa000017-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(7435), new Guid("22222222-2222-4222-8222-222222222205"), "Chandpur Sadar", "চাঁদপুর সদর", null },
                    { new Guid("aa000017-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(7838), new Guid("22222222-2222-4222-8222-222222222205"), "Faridganj", "ফরিদগঞ্জ", null },
                    { new Guid("aa000018-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(8329), new Guid("22222222-2222-4222-8222-222222222206"), "Lakshmipur Sadar", "লক্ষ্মীপুর সদর", null },
                    { new Guid("aa000018-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(8775), new Guid("22222222-2222-4222-8222-222222222206"), "Raipur", "রায়পুর", null },
                    { new Guid("aa000019-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(9390), new Guid("22222222-2222-4222-8222-222222222207"), "Noakhali Sadar", "নোয়াখালী সদর", null },
                    { new Guid("aa000019-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(9862), new Guid("22222222-2222-4222-8222-222222222207"), "Sonaimuri", "সোনাইমুরী", null },
                    { new Guid("aa000020-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(378), new Guid("22222222-2222-4222-8222-222222222208"), "Feni Sadar", "ফেনী সদর", null },
                    { new Guid("aa000020-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(855), new Guid("22222222-2222-4222-8222-222222222208"), "Daganbhuiyan", "দাগনভূঁইয়া", null },
                    { new Guid("aa000021-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(1349), new Guid("22222222-2222-4222-8222-222222222209"), "Khagrachhari Sadar", "খাগড়াছড়ি সদর", null },
                    { new Guid("aa000021-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(1813), new Guid("22222222-2222-4222-8222-222222222209"), "Mahalchhari", "মহালছড়ি", null },
                    { new Guid("aa000022-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(2291), new Guid("22222222-2222-4222-8222-222222222210"), "Rangamati Sadar", "রাঙ্গামাটি সদর", null },
                    { new Guid("aa000022-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(2774), new Guid("22222222-2222-4222-8222-222222222210"), "Kaptai", "কাপ্তাই", null },
                    { new Guid("aa000023-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(3231), new Guid("22222222-2222-4222-8222-222222222211"), "Bandarban Sadar", "বান্দরবান সদর", null },
                    { new Guid("aa000023-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(3721), new Guid("22222222-2222-4222-8222-222222222211"), "Ali Kadam", "আলীকদম", null },
                    { new Guid("aa000024-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(4164), new Guid("33333333-3333-4333-8333-333333333301"), "Rajshahi Sadar", "রাজশাহী সদর", null },
                    { new Guid("aa000024-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(4537), new Guid("33333333-3333-4333-8333-333333333301"), "Godagari", "গোদাগারী", null },
                    { new Guid("aa000025-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(5014), new Guid("33333333-3333-4333-8333-333333333302"), "Natore Sadar", "নাটোর সদর", null },
                    { new Guid("aa000025-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(5478), new Guid("33333333-3333-4333-8333-333333333302"), "Baraigram", "বড়াইগ্রাম", null },
                    { new Guid("aa000026-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(5941), new Guid("33333333-3333-4333-8333-333333333303"), "Bogura Sadar", "বগুড়া সদর", null },
                    { new Guid("aa000026-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(6410), new Guid("33333333-3333-4333-8333-333333333303"), "Shibganj", "শিবগঞ্জ", null },
                    { new Guid("aa000027-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(6878), new Guid("33333333-3333-4333-8333-333333333304"), "Chapainawabganj Sadar", "চাঁপাইনবাবগঞ্জ সদর", null },
                    { new Guid("aa000027-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(7252), new Guid("33333333-3333-4333-8333-333333333304"), "Rohanpur", "রহনপুর", null },
                    { new Guid("aa000028-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(7695), new Guid("33333333-3333-4333-8333-333333333305"), "Naogaon Sadar", "নওগাঁ সদর", null },
                    { new Guid("aa000028-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(8073), new Guid("33333333-3333-4333-8333-333333333305"), "Atrai", "আত্রাই", null },
                    { new Guid("aa000029-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(8503), new Guid("33333333-3333-4333-8333-333333333306"), "Sirajganj Sadar", "সিরাজগঞ্জ সদর", null },
                    { new Guid("aa000029-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(9308), new Guid("33333333-3333-4333-8333-333333333306"), "Raiganj", "রায়গঞ্জ", null },
                    { new Guid("aa000030-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(270), new Guid("33333333-3333-4333-8333-333333333307"), "Pabna Sadar", "পাবনা সদর", null },
                    { new Guid("aa000030-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(894), new Guid("33333333-3333-4333-8333-333333333307"), "Atgharia", "আটঘরিয়া", null },
                    { new Guid("aa000031-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(1489), new Guid("33333333-3333-4333-8333-333333333308"), "Joypurhat Sadar", "জয়পুরহাট সদর", null },
                    { new Guid("aa000031-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(2043), new Guid("33333333-3333-4333-8333-333333333308"), "Akkelpur", "আক্কেলপুর", null },
                    { new Guid("aa000032-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(2567), new Guid("44444444-4444-4444-8444-444444444401"), "Khulna Sadar", "খুলনা সদর", null },
                    { new Guid("aa000032-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(3032), new Guid("44444444-4444-4444-8444-444444444401"), "Terokhada", "তেরখাদা", null },
                    { new Guid("aa000033-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(3555), new Guid("44444444-4444-4444-8444-444444444402"), "Satkhira Sadar", "সাতক্ষীরা সদর", null },
                    { new Guid("aa000033-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(4075), new Guid("44444444-4444-4444-8444-444444444402"), "Assasuni", "আসসানি", null },
                    { new Guid("aa000034-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(4624), new Guid("44444444-4444-4444-8444-444444444403"), "Jessore Sadar", "যশোর সদর", null },
                    { new Guid("aa000034-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(5083), new Guid("44444444-4444-4444-8444-444444444403"), "Jhikargacha", "ঝিকারগাছা", null },
                    { new Guid("aa000035-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(6106), new Guid("44444444-4444-4444-8444-444444444404"), "Bagerhat Sadar", "বাগেরহাট সদর", null },
                    { new Guid("aa000035-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(6747), new Guid("44444444-4444-4444-8444-444444444404"), "Mongla", "মোংলা", null },
                    { new Guid("aa000036-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(7894), new Guid("44444444-4444-4444-8444-444444444405"), "Jhenaidah Sadar", "ঝিনাইদহ সদর", null },
                    { new Guid("aa000036-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(8600), new Guid("44444444-4444-4444-8444-444444444405"), "Shakhipur", "শাখিপুর", null },
                    { new Guid("aa000037-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(9126), new Guid("44444444-4444-4444-8444-444444444406"), "Magura Sadar", "মাগুরা সদর", null },
                    { new Guid("aa000037-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(9698), new Guid("44444444-4444-4444-8444-444444444406"), "Shalikha", "শালিখা", null },
                    { new Guid("aa000038-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(183), new Guid("44444444-4444-4444-8444-444444444407"), "Narail Sadar", "নড়াইল সদর", null },
                    { new Guid("aa000038-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(662), new Guid("44444444-4444-4444-8444-444444444407"), "Lohagara", "লোহাগাড়া", null },
                    { new Guid("aa000039-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(1109), new Guid("44444444-4444-4444-8444-444444444408"), "Kushtia Sadar", "কুষ্টিয়া সদর", null },
                    { new Guid("aa000039-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(1624), new Guid("44444444-4444-4444-8444-444444444408"), "Kumarkhali", "কুমারখালী", null },
                    { new Guid("aa000040-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(2131), new Guid("44444444-4444-4444-8444-444444444409"), "Meherpur Sadar", "মেহেরপুর সদর", null },
                    { new Guid("aa000040-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(2617), new Guid("44444444-4444-4444-8444-444444444409"), "Gangni", "গাংনী", null },
                    { new Guid("aa000041-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(3144), new Guid("44444444-4444-4444-8444-444444444410"), "Chuadanga Sadar", "চুয়াডাঙ্গা সদর", null },
                    { new Guid("aa000041-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(3629), new Guid("44444444-4444-4444-8444-444444444410"), "Alamdanga", "আলমডাঙ্গা", null },
                    { new Guid("aa000042-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(4168), new Guid("55555555-5555-4555-8555-555555555501"), "Barishal Sadar", "বরিশাল সদর", null },
                    { new Guid("aa000042-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(4662), new Guid("55555555-5555-4555-8555-555555555501"), "Bakerganj", "বাকেরগঞ্জ", null },
                    { new Guid("aa000043-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(5143), new Guid("55555555-5555-4555-8555-555555555502"), "Patuakhali Sadar", "পটুয়াখালী সদর", null },
                    { new Guid("aa000043-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(5658), new Guid("55555555-5555-4555-8555-555555555502"), "Dumki", "দুমকি", null },
                    { new Guid("aa000044-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(6135), new Guid("55555555-5555-4555-8555-555555555503"), "Bhola Sadar", "ভোলা সদর", null },
                    { new Guid("aa000044-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(6650), new Guid("55555555-5555-4555-8555-555555555503"), "Burhanuddin", "বুরহানউদ্দিন", null },
                    { new Guid("aa000045-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(7132), new Guid("55555555-5555-4555-8555-555555555504"), "Pirojpur Sadar", "পিরোজপুর সদর", null },
                    { new Guid("aa000045-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(7620), new Guid("55555555-5555-4555-8555-555555555504"), "Mathbaria", "মাঠবাড়িয়া", null },
                    { new Guid("aa000046-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(8143), new Guid("55555555-5555-4555-8555-555555555505"), "Jhalakathi Sadar", "ঝালকাঠি সদর", null },
                    { new Guid("aa000046-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(8617), new Guid("55555555-5555-4555-8555-555555555505"), "Nalchity", "নালচিত্য", null },
                    { new Guid("aa000047-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(9128), new Guid("55555555-5555-4555-8555-555555555506"), "Barguna Sadar", "বরগুনা সদর", null },
                    { new Guid("aa000047-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(9608), new Guid("55555555-5555-4555-8555-555555555506"), "Amtali", "আমতলী", null },
                    { new Guid("aa000048-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(105), new Guid("66666666-6666-4666-8666-666666666601"), "Sylhet Sadar", "সিলেট সদর", null },
                    { new Guid("aa000048-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(608), new Guid("66666666-6666-4666-8666-666666666601"), "Beanibazar", "বিয়ানীবাজার", null },
                    { new Guid("aa000048-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(1079), new Guid("66666666-6666-4666-8666-666666666601"), "Zakiganj", "জকিগঞ্জ", null },
                    { new Guid("aa000049-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(1583), new Guid("66666666-6666-4666-8666-666666666602"), "Habiganj Sadar", "হবিগঞ্জ সদর", null },
                    { new Guid("aa000049-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(2085), new Guid("66666666-6666-4666-8666-666666666602"), "Lakhai", "লাখাই", null },
                    { new Guid("aa000050-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(2600), new Guid("66666666-6666-4666-8666-666666666603"), "Moulvibazar Sadar", "মৌলভীবাজার সদর", null },
                    { new Guid("aa000050-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(3186), new Guid("66666666-6666-4666-8666-666666666603"), "Barlekha", "বড়লেখা", null },
                    { new Guid("aa000051-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(3713), new Guid("66666666-6666-4666-8666-666666666604"), "Sunamganj Sadar", "সুনামগঞ্জ সদর", null },
                    { new Guid("aa000051-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(4210), new Guid("66666666-6666-4666-8666-666666666604"), "Tahirpur", "তাহিরপুর", null },
                    { new Guid("aa000052-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(4881), new Guid("77777777-7777-4777-8777-777777777701"), "Rangpur Sadar", "রংপুর সদর", null },
                    { new Guid("aa000052-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(5488), new Guid("77777777-7777-4777-8777-777777777701"), "Gangachara", "গঙ্গাচরা", null },
                    { new Guid("aa000053-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(5994), new Guid("77777777-7777-4777-8777-777777777702"), "Dinajpur Sadar", "দিনাজপুর সদর", null },
                    { new Guid("aa000053-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(6514), new Guid("77777777-7777-4777-8777-777777777702"), "Parbatipur", "পার্বতীপুর", null },
                    { new Guid("aa000054-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(7058), new Guid("77777777-7777-4777-8777-777777777703"), "Thakurgaon Sadar", "ঠাকুরগাঁও সদর", null },
                    { new Guid("aa000054-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(7589), new Guid("77777777-7777-4777-8777-777777777703"), "Pirganj", "পীরগঞ্জ", null },
                    { new Guid("aa000055-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(8088), new Guid("77777777-7777-4777-8777-777777777704"), "Kurigram Sadar", "কুড়িগ্রাম সদর", null },
                    { new Guid("aa000055-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(8577), new Guid("77777777-7777-4777-8777-777777777704"), "Nageshwari", "নাগেশ্বরী", null },
                    { new Guid("aa000056-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(9080), new Guid("77777777-7777-4777-8777-777777777705"), "Gaibandha Sadar", "গাইবান্ধা সদর", null },
                    { new Guid("aa000056-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(9584), new Guid("77777777-7777-4777-8777-777777777705"), "Sundarganj", "সুন্দরগঞ্জ", null },
                    { new Guid("aa000057-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(105), new Guid("77777777-7777-4777-8777-777777777706"), "Lalmonirhat Sadar", "লালমনিরহাট সদর", null },
                    { new Guid("aa000057-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(592), new Guid("77777777-7777-4777-8777-777777777706"), "Aditmari", "আদিতমারী", null },
                    { new Guid("aa000058-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(1123), new Guid("77777777-7777-4777-8777-777777777707"), "Nilphamari Sadar", "নীলফামারী সদর", null },
                    { new Guid("aa000058-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(1670), new Guid("77777777-7777-4777-8777-777777777707"), "Saidpur", "সৈদপুর", null },
                    { new Guid("aa000059-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(2181), new Guid("77777777-7777-4777-8777-777777777708"), "Panchagarh Sadar", "পঞ্চগড় সদর", null },
                    { new Guid("aa000059-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(2719), new Guid("77777777-7777-4777-8777-777777777708"), "Tetulia", "তেতুলিয়া", null },
                    { new Guid("aa000060-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(3228), new Guid("88888888-8888-4888-8888-888888888801"), "Mymensingh Sadar", "ময়মনসিংহ সদর", null },
                    { new Guid("aa000060-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(3768), new Guid("88888888-8888-4888-8888-888888888801"), "Trishal", "ত্রিশাল", null },
                    { new Guid("aa000061-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(4268), new Guid("88888888-8888-4888-8888-888888888802"), "Jamalpur Sadar", "জামালপুর সদর", null },
                    { new Guid("aa000061-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(4804), new Guid("88888888-8888-4888-8888-888888888802"), "Melandaha", "মেলান্দহ", null },
                    { new Guid("aa000062-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(5334), new Guid("88888888-8888-4888-8888-888888888803"), "Sherpur Sadar", "শেরপুর সদর", null },
                    { new Guid("aa000062-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(5842), new Guid("88888888-8888-4888-8888-888888888803"), "Nalitabari", "নালিতাবাড়ী", null },
                    { new Guid("aa000063-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(6388), new Guid("88888888-8888-4888-8888-888888888804"), "Netrokona Sadar", "নেত্রকোণা সদর", null },
                    { new Guid("aa000063-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(6889), new Guid("88888888-8888-4888-8888-888888888804"), "Kalmakanda", "কালমাকান্দা", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_CreatedAt",
                table: "AuditLogs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_EntityType_EntityId",
                table: "AuditLogs",
                columns: new[] { "EntityType", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestMatches_BloodRequestId",
                table: "BloodRequestMatches",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestMatches_DonorId",
                table: "BloodRequestMatches",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_BloodGroup",
                table: "BloodRequests",
                column: "BloodGroup");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_CreatedAt",
                table: "BloodRequests",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_DistrictId",
                table: "BloodRequests",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_RequesterId",
                table: "BloodRequests",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_RequiredBy",
                table: "BloodRequests",
                column: "RequiredBy");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_Status",
                table: "BloodRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_UpazilaId",
                table: "BloodRequests",
                column: "UpazilaId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequests_Urgency",
                table: "BloodRequests",
                column: "Urgency");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_DivisionId",
                table: "Districts",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRecords_BloodRequestId",
                table: "DonationRecords",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRecords_DonorId",
                table: "DonationRecords",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationRecords_DonorProfileId",
                table: "DonationRecords",
                column: "DonorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_AvailabilityStatus",
                table: "DonorProfiles",
                column: "AvailabilityStatus");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_BloodGroup",
                table: "DonorProfiles",
                column: "BloodGroup");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_DistrictId",
                table: "DonorProfiles",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_LastDonationDate",
                table: "DonorProfiles",
                column: "LastDonationDate");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_UpazilaId",
                table: "DonorProfiles",
                column: "UpazilaId");

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_UserId",
                table: "DonorProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonorProfiles_VerificationStatus",
                table: "DonorProfiles",
                column: "VerificationStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId_IsRead",
                table: "Notifications",
                columns: new[] { "UserId", "IsRead" });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BloodRequestId",
                table: "Reports",
                column: "BloodRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedUserId",
                table: "Reports",
                column: "ReportedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReporterUserId",
                table: "Reports",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Upazilas_DistrictId",
                table: "Upazilas",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "\"Email\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IsActive",
                table: "Users",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role",
                table: "Users",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationRecords_UserId",
                table: "VerificationRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "BloodRequestMatches");

            migrationBuilder.DropTable(
                name: "DonationRecords");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "VerificationRecords");

            migrationBuilder.DropTable(
                name: "DonorProfiles");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "Upazilas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Divisions");
        }
    }
}
