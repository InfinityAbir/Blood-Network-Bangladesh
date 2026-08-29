using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEligibilityQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EligibilityQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionEn = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    QuestionBn = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    QuestionBanglish = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    QuestionType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    MinValue = table.Column<int>(type: "integer", nullable: true),
                    MaxValue = table.Column<int>(type: "integer", nullable: true),
                    PassOnYes = table.Column<bool>(type: "boolean", nullable: true),
                    IsCritical = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    PassMessageEn = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PassMessageBn = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FailMessageEn = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FailMessageBn = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityQuestions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EligibilityQuestions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DisplayOrder", "FailMessageBn", "FailMessageEn", "IsActive", "IsCritical", "IsDeleted", "MaxValue", "MinValue", "PassMessageBn", "PassMessageEn", "PassOnYes", "QuestionBanglish", "QuestionBn", "QuestionEn", "QuestionType", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(4200), null, 1, "বয়স {value} যোগ্য পরিসীমার বাইরে (১৮-৬৫)।", "Age {value} is outside eligible range (18-65).", true, true, false, 65, 18, "বয়স যোগ্য পরিসীমার মধ্যে (১৮-৬৫)।", "Age is within eligible range (18-65).", null, "Apnar boyosh koto?", "আপনার বয়স কত?", "What is your age?", "number", null, null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(8791), null, 2, "ওজন {value} কেজি ন্যূনতমের কম (৫০ কেজি)।", "Weight {value} kg is below minimum (50 kg).", true, true, false, null, 50, "ওজন ন্যূনতম চাহিদা পূরণ করে (≥৫০ কেজি)।", "Weight meets minimum requirement (≥50 kg).", null, "Apnar ojonoto koto kg?", "আপনার ওজন কত কেজি?", "What is your weight in kg?", "number", "kg", null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9160), null, 3, "গত ৩ মাসের মধ্যে রক্তদান করেছেন। অপেক্ষা করুন।", "Donated blood within the last 3 months. Must wait.", true, true, false, null, null, "গত ৩ মাসে কোনো রক্তদান হয়নি।", "No recent donation within 3 months.", false, "Apni goto 3 mase rokto dan korechen?", "আপনি গত ৩ মাসে রক্তদান করেছেন?", "Did you donate blood in the last 3 months?", "yesno", null, null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9551), null, 4, "বর্তমানে ওষুধ সেবন করছেন। দয়া করে চিকিৎসকের পরামর্শ নিন।", "Currently taking medication. Please consult a doctor.", true, false, false, null, null, "বর্তমানে কোনো ওষুধ সেবন করছেন না।", "Not currently taking medication.", false, "Apni ki kono rog er osudh sebon korchen?", "আপনি কি কোনো রোগের ওষুধ সেবন করছেন?", "Are you currently taking any medication?", "yesno", null, null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9558), null, 5, "গর্ভবতী বা স্তন্যদানকারী মাদের যোগ্য নন।", "Pregnant or breastfeeding donors are not eligible.", true, true, false, null, null, "গর্ভবতী বা স্তন্যদানকারী মা নন।", "Not pregnant or breastfeeding.", false, "Apni garhobati ba stanyodankari ma?", "আপনি গর্ভবতী বা স্তন্যদানকারী মা?", "Are you pregnant or breastfeeding?", "yesno", null, null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9570), null, 6, "গত ১ বছরে অস্ত্রপচার হয়েছে। কমপক্ষে ১ বছর অপেক্ষা করুন।", "Had surgery in the last year. Must wait at least 1 year.", true, true, false, null, null, "গত ১ বছরে কোনো অস্ত্রপচার হয়নি।", "No surgery in the last year.", false, "Apnar goto 1 bochore ostropochar hoyeche?", "আপনার গত ১ বছরে অস্ত্রপচার হয়েছে?", "Have you had surgery in the last year?", "yesno", null, null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9574), null, 7, "এখন অসুস্থ বা জ্বর আছে। সুস্থ না হওয়া পর্যন্ত অপেক্ষা করুন।", "Currently sick or have a fever. Wait until recovered.", true, true, false, null, null, "এখন অসুস্থ বা জ্বর নেই।", "Not currently sick or feverish.", false, "Apni ki ekhon osustho ba jhor ache?", "আপনি কি এখন অসুস্থ বা জ্বর আছে?", "Are you currently sick or have a fever?", "yesno", null, null },
                    { new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"), new DateTime(2026, 8, 29, 13, 27, 52, 557, DateTimeKind.Utc).AddTicks(9577), null, 8, "ওজন স্থিতিশীল নয়। রক্তদানের জন্য স্থিতিশীল ওজন প্রয়োজন।", "Weight is not stable. Must have stable weight to donate.", true, false, false, null, null, "সাম্প্রতিক ওজন স্থিতিশীল।", "Weight is stable recently.", true, "Apnar samprotik ojon ki sthitishil?", "আপনার সাম্প্রতিক ওজন কি স্থিতিশীল?", "Is your weight stable recently?", "yesno", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EligibilityQuestions_DisplayOrder",
                table: "EligibilityQuestions",
                column: "DisplayOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EligibilityQuestions");
        }
    }
}
