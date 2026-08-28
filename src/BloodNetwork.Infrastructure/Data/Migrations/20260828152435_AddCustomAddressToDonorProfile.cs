using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomAddressToDonorProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000003"));

            migrationBuilder.AddColumn<string>(
                name: "CustomAddress",
                table: "DonorProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000006"),
                column: "NameBn",
                value: "হাতিয়া");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomAddress",
                table: "DonorProfiles");

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000006"),
                column: "NameBn",
                value: "পটিয়া");

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DistrictId", "IsDeleted", "Name", "NameBn", "UpdatedAt" },
                values: new object[] { new Guid("aa000050-0000-4000-8000-000000000003"), new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Baralekha", "বড়লেখা", null });
        }
    }
}
