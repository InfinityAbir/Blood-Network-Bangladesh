using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDhakaMetroThanas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DistrictId", "IsDeleted", "Name", "NameBn", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aa000001-0000-4000-8000-000000000011"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Uttara", "উত্তরা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000012"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Gulshan", "গুলশান", null },
                    { new Guid("aa000001-0000-4000-8000-000000000013"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Banani", "বনানী", null },
                    { new Guid("aa000001-0000-4000-8000-000000000014"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Badda", "বাড্ডা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000015"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Khilgaon", "খিলগাঁও", null },
                    { new Guid("aa000001-0000-4000-8000-000000000016"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Rampura", "রামপুরা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000017"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Mirpur", "মিরপুর", null },
                    { new Guid("aa000001-0000-4000-8000-000000000018"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Pallabi", "পল্লবী", null },
                    { new Guid("aa000001-0000-4000-8000-000000000019"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Kafrul", "কাফরুল", null },
                    { new Guid("aa000001-0000-4000-8000-000000000020"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Cantonment", "ক্যান্টনমেন্ট", null },
                    { new Guid("aa000001-0000-4000-8000-000000000021"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Tejgaon", "তেজগাঁও", null },
                    { new Guid("aa000001-0000-4000-8000-000000000022"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Mohammadpur", "মোহাম্মদপুর", null },
                    { new Guid("aa000001-0000-4000-8000-000000000023"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Dhanmondi", "ধানমন্ডি", null },
                    { new Guid("aa000001-0000-4000-8000-000000000024"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Shahbagh", "শাহবাগ", null },
                    { new Guid("aa000001-0000-4000-8000-000000000025"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Ramna", "রমনা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000026"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Motijheel", "মতিঝিল", null },
                    { new Guid("aa000001-0000-4000-8000-000000000027"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Paltan", "পল্টন", null },
                    { new Guid("aa000001-0000-4000-8000-000000000028"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Sabujbagh", "সবুজবাগ", null },
                    { new Guid("aa000001-0000-4000-8000-000000000029"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Lalbagh", "লালবাগ", null },
                    { new Guid("aa000001-0000-4000-8000-000000000030"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Kotwali", "কোতয়ালী", null },
                    { new Guid("aa000001-0000-4000-8000-000000000031"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Sutrapur", "সূত্রাপুর", null },
                    { new Guid("aa000001-0000-4000-8000-000000000032"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Hazaribagh", "হাজারীবাগ", null },
                    { new Guid("aa000001-0000-4000-8000-000000000033"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Demra", "ডেমরা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000034"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Jatrabari", "যাত্রাবাড়ী", null },
                    { new Guid("aa000001-0000-4000-8000-000000000035"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Kamrangirchar", "কামরাঙ্গীরচর", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000035"));
        }
    }
}
