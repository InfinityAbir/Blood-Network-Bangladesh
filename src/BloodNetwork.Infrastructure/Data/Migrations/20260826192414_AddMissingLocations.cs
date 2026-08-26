using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000005"));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111101"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111102"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111103"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111104"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111105"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111106"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111107"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111108"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111109"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111110"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222201"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222202"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222203"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222204"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222205"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222206"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222207"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222208"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222209"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222210"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333301"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333302"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333303"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333304"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333305"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333306"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333307"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333308"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444401"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444402"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444403"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444404"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444405"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444406"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444407"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444408"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444409"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444410"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555501"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555502"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555503"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555504"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555505"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555506"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666601"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666602"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666603"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666604"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777701"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777702"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777703"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777704"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777705"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777706"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777707"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777708"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888801"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888802"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888803"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888804"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6440));

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DivisionId", "IsDeleted", "Name", "NameBn", "UpdatedAt" },
                values: new object[] { new Guid("11111111-1111-4111-8111-111111111113"), new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6318), null, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), false, "Shariatpur", "শরীয়তপুর", null });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1529));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1534));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 293, DateTimeKind.Utc).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(5823));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(6492));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(390));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(1687));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(1532));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(5244));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DistrictId", "IsDeleted", "Name", "NameBn", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aa000001-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(7217), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Dhamrai", "ধামরাই", null },
                    { new Guid("aa000001-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(7615), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Dohar", "দোহার", null },
                    { new Guid("aa000001-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(8040), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Keraniganj", "কেরাণীগঞ্জ", null },
                    { new Guid("aa000001-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(8382), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Nawabganj", "নবাবগঞ্জ", null },
                    { new Guid("aa000002-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(9675), null, new Guid("11111111-1111-4111-8111-111111111102"), false, "Kaliganj", "কালীগঞ্জ", null },
                    { new Guid("aa000002-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(9995), null, new Guid("11111111-1111-4111-8111-111111111102"), false, "Kapasia", "কাপাসিয়া", null },
                    { new Guid("aa000002-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(323), null, new Guid("11111111-1111-4111-8111-111111111102"), false, "Sreepur", "শ্রীপুর", null },
                    { new Guid("aa000003-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(1575), null, new Guid("11111111-1111-4111-8111-111111111103"), false, "Araihazar", "আড়াইহাজার", null },
                    { new Guid("aa000003-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(1879), null, new Guid("11111111-1111-4111-8111-111111111103"), false, "Rupganj", "রূপগঞ্জ", null },
                    { new Guid("aa000004-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(2802), null, new Guid("11111111-1111-4111-8111-111111111104"), false, "Daulatpur", "দৌলতপুর", null },
                    { new Guid("aa000004-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(3104), null, new Guid("11111111-1111-4111-8111-111111111104"), false, "Ghior", "ঘিওর", null },
                    { new Guid("aa000004-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(3424), null, new Guid("11111111-1111-4111-8111-111111111104"), false, "Harirampur", "হরিরামপুর", null },
                    { new Guid("aa000004-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(3732), null, new Guid("11111111-1111-4111-8111-111111111104"), false, "Saturia", "সাটুরিয়া", null },
                    { new Guid("aa000004-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(4050), null, new Guid("11111111-1111-4111-8111-111111111104"), false, "Shibalay", "শিবালয়", null },
                    { new Guid("aa000005-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(5129), null, new Guid("11111111-1111-4111-8111-111111111105"), false, "Gazaria", "গজারিয়া", null },
                    { new Guid("aa000005-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(5465), null, new Guid("11111111-1111-4111-8111-111111111105"), false, "Louhajang", "লৌহজং", null },
                    { new Guid("aa000005-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(5803), null, new Guid("11111111-1111-4111-8111-111111111105"), false, "Sirajdikhan", "সিরাজদিখান", null },
                    { new Guid("aa000005-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(6136), null, new Guid("11111111-1111-4111-8111-111111111105"), false, "Tongibari", "টংগীবাড়ি", null },
                    { new Guid("aa000006-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(8207), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Basail", "বাসাইল", null },
                    { new Guid("aa000006-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(598), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Bhuanpur", "ভূঞাপুর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(1472), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Dhanbari", "ধনবাড়ী", null },
                    { new Guid("aa000006-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(2181), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Ghatail", "ঘাটাইল", null },
                    { new Guid("aa000006-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(3002), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Gopalpur", "গোপালপুর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(3710), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Kalihati", "কালিহাতী", null },
                    { new Guid("aa000006-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(4379), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Madhupur", "মধুপুর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(5069), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Mirzapur", "মির্জাপুর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(6012), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Nagarpur", "নাগরপুর", null },
                    { new Guid("aa000006-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(7402), null, new Guid("11111111-1111-4111-8111-111111111106"), false, "Sakhipur", "সখিপুর", null },
                    { new Guid("aa000007-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(9097), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Austagram", "অষ্টগ্রাম", null },
                    { new Guid("aa000007-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(9612), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Bajitpur", "বাজিতপুর", null },
                    { new Guid("aa000007-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(161), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Bhairab", "ভৈরব", null },
                    { new Guid("aa000007-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(747), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Itna", "ইটনা", null },
                    { new Guid("aa000007-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(1246), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Karimganj", "করিমগঞ্জ", null },
                    { new Guid("aa000007-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(1797), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Katiadi", "কটিয়াদী", null },
                    { new Guid("aa000007-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(2321), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Kuliarchar", "কুলিয়ারচর", null },
                    { new Guid("aa000007-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(2884), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Mithamain", "মিঠামইন", null },
                    { new Guid("aa000007-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(3505), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Nikli", "নিকলী", null },
                    { new Guid("aa000007-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(4089), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Pakundia", "পাকুন্দিয়া", null },
                    { new Guid("aa000007-0000-4000-8000-000000000013"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(4676), null, new Guid("11111111-1111-4111-8111-111111111107"), false, "Tarail", "তাড়াইল", null },
                    { new Guid("aa000008-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(6417), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Alfadanga", "আলফাডাঙ্গা", null },
                    { new Guid("aa000008-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(7099), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Bhanga", "ভাঙ্গা", null },
                    { new Guid("aa000008-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(7785), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Char Bhadrasan", "চরভদ্রাসন", null },
                    { new Guid("aa000008-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(8324), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Madhukhali", "মধুখালী", null },
                    { new Guid("aa000008-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(8806), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Nagarkanda", "নগরকান্দা", null },
                    { new Guid("aa000008-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(9213), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Sadarpur", "সদরপুর", null },
                    { new Guid("aa000008-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(9659), null, new Guid("11111111-1111-4111-8111-111111111108"), false, "Saltha", "সালথা", null },
                    { new Guid("aa000009-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(1682), null, new Guid("11111111-1111-4111-8111-111111111109"), false, "Kashiani", "কাশিয়ানী", null },
                    { new Guid("aa000009-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(2592), null, new Guid("11111111-1111-4111-8111-111111111109"), false, "Muksudpur", "মুকসুদপুর", null },
                    { new Guid("aa000009-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(3965), null, new Guid("11111111-1111-4111-8111-111111111109"), false, "Tungipara", "টুংগীপাড়া", null },
                    { new Guid("aa000010-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(6218), null, new Guid("11111111-1111-4111-8111-111111111110"), false, "Dasar", "ডাসার", null },
                    { new Guid("aa000010-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(6822), null, new Guid("11111111-1111-4111-8111-111111111110"), false, "Kalkini", "কালকিনি", null },
                    { new Guid("aa000010-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(7395), null, new Guid("11111111-1111-4111-8111-111111111110"), false, "Rajoir", "রাজৈর", null },
                    { new Guid("aa000011-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(8659), null, new Guid("11111111-1111-4111-8111-111111111111"), false, "Goalanda", "গোয়ালন্দ", null },
                    { new Guid("aa000011-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(9020), null, new Guid("11111111-1111-4111-8111-111111111111"), false, "Kalukhali", "কালুখালী", null },
                    { new Guid("aa000011-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(9379), null, new Guid("11111111-1111-4111-8111-111111111111"), false, "Pangsha", "পাংশা", null },
                    { new Guid("aa000012-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(489), null, new Guid("11111111-1111-4111-8111-111111111112"), false, "Belabo", "বেলাবো", null },
                    { new Guid("aa000012-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(796), null, new Guid("11111111-1111-4111-8111-111111111112"), false, "Manohardi", "মনোহরদী", null },
                    { new Guid("aa000012-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(1108), null, new Guid("11111111-1111-4111-8111-111111111112"), false, "Raipura", "রায়পুরা", null },
                    { new Guid("aa000012-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(1416), null, new Guid("11111111-1111-4111-8111-111111111112"), false, "Shibpur", "শিবপুর", null },
                    { new Guid("aa000013-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(4824), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Anwara", "আনোয়ারা", null },
                    { new Guid("aa000013-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(5129), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Banshkhali", "বাঁশখালী", null },
                    { new Guid("aa000013-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(5451), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Boalkhali", "বোয়ালখালী", null },
                    { new Guid("aa000013-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(5753), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Chandanaish", "চন্দনাইশ", null },
                    { new Guid("aa000013-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(6062), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Fatikchhari", "ফটিকছড়ি", null },
                    { new Guid("aa000013-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(6445), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Hathazari", "হাটহাজারী", null },
                    { new Guid("aa000013-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(6771), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Karnaphuli", "কর্ণফুলী", null },
                    { new Guid("aa000013-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(7077), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Lohagara", "লোহাগড়া", null },
                    { new Guid("aa000013-0000-4000-8000-000000000013"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(7384), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Patiya", "পটিয়া", null },
                    { new Guid("aa000013-0000-4000-8000-000000000014"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(7738), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Rangunia", "রাঙ্গুনিয়া", null },
                    { new Guid("aa000013-0000-4000-8000-000000000015"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8069), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Raozan", "রাউজান", null },
                    { new Guid("aa000013-0000-4000-8000-000000000016"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8377), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Sandwip", "সন্দ্বীপ", null },
                    { new Guid("aa000013-0000-4000-8000-000000000017"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8682), null, new Guid("22222222-2222-4222-8222-222222222201"), false, "Satkania", "সাতকানিয়া", null },
                    { new Guid("aa000014-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(9907), null, new Guid("22222222-2222-4222-8222-222222222202"), false, "Chakaria", "চকরিয়া", null },
                    { new Guid("aa000014-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(209), null, new Guid("22222222-2222-4222-8222-222222222202"), false, "Eidgaon", "ঈদগাঁও", null },
                    { new Guid("aa000014-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(512), null, new Guid("22222222-2222-4222-8222-222222222202"), false, "Kutubdia", "কুতুবদিয়া", null },
                    { new Guid("aa000014-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(830), null, new Guid("22222222-2222-4222-8222-222222222202"), false, "Maheshkhali", "মহেশখালী", null },
                    { new Guid("aa000014-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(1138), null, new Guid("22222222-2222-4222-8222-222222222202"), false, "Pekua", "পেকুয়া", null },
                    { new Guid("aa000014-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(1441), null, new Guid("22222222-2222-4222-8222-222222222202"), false, "Ramu", "রামু", null },
                    { new Guid("aa000015-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(2675), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Adarsha Sadar", "আদর্শ সদর", null },
                    { new Guid("aa000015-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(2985), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Barura", "বরুড়া", null },
                    { new Guid("aa000015-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(3307), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Brahmanpara", "ব্রাহ্মণপাড়া", null },
                    { new Guid("aa000015-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(3701), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Burichang", "বুড়িচং", null },
                    { new Guid("aa000015-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4020), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Chauddagram", "চৌদ্দগ্রাম", null },
                    { new Guid("aa000015-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4326), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Debidwar", "দেবিদ্বার", null },
                    { new Guid("aa000015-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4639), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Homna", "হোমনা", null },
                    { new Guid("aa000015-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4950), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Laksam", "লাকসাম", null },
                    { new Guid("aa000015-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(5255), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Lalmai", "লালমাই", null },
                    { new Guid("aa000015-0000-4000-8000-000000000013"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(5558), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Manoharganj", "মনোহরগঞ্জ", null },
                    { new Guid("aa000015-0000-4000-8000-000000000014"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(5873), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Meghna", "মেঘনা", null },
                    { new Guid("aa000015-0000-4000-8000-000000000015"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(6196), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Muradnagar", "মুরাদনগর", null },
                    { new Guid("aa000015-0000-4000-8000-000000000016"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(6550), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Nangalkot", "নাঙ্গলকোট", null },
                    { new Guid("aa000015-0000-4000-8000-000000000017"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(6867), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Sadar Dakkhin", "সদর দক্ষিণ", null },
                    { new Guid("aa000015-0000-4000-8000-000000000018"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(7175), null, new Guid("22222222-2222-4222-8222-222222222203"), false, "Titas", "তিতাস", null },
                    { new Guid("aa000016-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(8111), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Akhaura", "আখাউড়া", null },
                    { new Guid("aa000016-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(8417), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Banchharampur", "বাঞ্ছারামপুর", null },
                    { new Guid("aa000016-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(8747), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Bijoynagar", "বিজয়নগর", null },
                    { new Guid("aa000016-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9076), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Kasba", "কসবা", null },
                    { new Guid("aa000016-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9392), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Nabinagar", "নবীনগর", null },
                    { new Guid("aa000016-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9693), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Nasirnagar", "নাসিরনগর", null },
                    { new Guid("aa000016-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9999), null, new Guid("22222222-2222-4222-8222-222222222204"), false, "Sarail", "সরাইল", null },
                    { new Guid("aa000017-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(913), null, new Guid("22222222-2222-4222-8222-222222222205"), false, "Haimchar", "হাইমচর", null },
                    { new Guid("aa000017-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(1222), null, new Guid("22222222-2222-4222-8222-222222222205"), false, "Hajiganj", "হাজীগঞ্জ", null },
                    { new Guid("aa000017-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(1541), null, new Guid("22222222-2222-4222-8222-222222222205"), false, "Kachua", "কচুয়া", null },
                    { new Guid("aa000017-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(1847), null, new Guid("22222222-2222-4222-8222-222222222205"), false, "Matlab Dakkhin", "মতলব দক্ষিণ", null },
                    { new Guid("aa000017-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(2153), null, new Guid("22222222-2222-4222-8222-222222222205"), false, "Matlab Uttar", "মতলব উত্তর", null },
                    { new Guid("aa000017-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(2457), null, new Guid("22222222-2222-4222-8222-222222222205"), false, "Shahrasti", "শাহরাস্তি", null },
                    { new Guid("aa000018-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3364), null, new Guid("22222222-2222-4222-8222-222222222206"), false, "Kamalnagar", "কমলনগর", null },
                    { new Guid("aa000018-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3665), null, new Guid("22222222-2222-4222-8222-222222222206"), false, "Ramganj", "রামগঞ্জ", null },
                    { new Guid("aa000018-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3990), null, new Guid("22222222-2222-4222-8222-222222222206"), false, "Ramgati", "রামগতি", null },
                    { new Guid("aa000019-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(4905), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Begumganj", "বেগমগঞ্জ", null },
                    { new Guid("aa000019-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(5205), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Chatkhil", "চাটখিল", null },
                    { new Guid("aa000019-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(5655), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Companiganj", "কোম্পানীগঞ্জ", null },
                    { new Guid("aa000019-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(5967), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Hatiya", "পটিয়া", null },
                    { new Guid("aa000019-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(6271), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Kabirhat", "কবিরহাট", null },
                    { new Guid("aa000019-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(6642), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Senbag", "সেনবাগ", null },
                    { new Guid("aa000019-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(6964), null, new Guid("22222222-2222-4222-8222-222222222207"), false, "Subarnachar", "সুবর্ণচর", null },
                    { new Guid("aa000020-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(7879), null, new Guid("22222222-2222-4222-8222-222222222208"), false, "Chhagalnaiya", "ছাগলনাইয়া", null },
                    { new Guid("aa000020-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(8181), null, new Guid("22222222-2222-4222-8222-222222222208"), false, "Fulgazi", "ফুলগাজী", null },
                    { new Guid("aa000020-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(8489), null, new Guid("22222222-2222-4222-8222-222222222208"), false, "Parashuram", "পরশুরাম", null },
                    { new Guid("aa000020-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(8829), null, new Guid("22222222-2222-4222-8222-222222222208"), false, "Sonagazi", "সোনাগাজী", null },
                    { new Guid("aa000021-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(9762), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Dighinala", "দিঘীনালা", null },
                    { new Guid("aa000021-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(68), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Guimara", "গুইমারা", null },
                    { new Guid("aa000021-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(376), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Lakkhichhari", "লক্ষ্মীছড়ি", null },
                    { new Guid("aa000021-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(709), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Manikchhari", "ফটিকছড়ি", null },
                    { new Guid("aa000021-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1022), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Matiranga", "মাটিরাঙ্গা", null },
                    { new Guid("aa000021-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1327), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Panchhari", "পানছড়ি", null },
                    { new Guid("aa000021-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1629), null, new Guid("22222222-2222-4222-8222-222222222209"), false, "Ramgarh", "রামগড়", null },
                    { new Guid("aa000022-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(2578), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Baghaichhari", "বাঘাইছড়ি", null },
                    { new Guid("aa000022-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(2880), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Barkal", "বরকল", null },
                    { new Guid("aa000022-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(3183), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Belaichhari", "বিলাইছড়ি", null },
                    { new Guid("aa000022-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(3572), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Jurachhari", "জুরাছড়ি", null },
                    { new Guid("aa000022-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(3908), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Kawkhali", "কাউখালী", null },
                    { new Guid("aa000022-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(4218), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Langadu", "লংগদু", null },
                    { new Guid("aa000022-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(4522), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Naniarchar", "নানিয়ারচর", null },
                    { new Guid("aa000022-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(4848), null, new Guid("22222222-2222-4222-8222-222222222210"), false, "Rajasthali", "রাজস্থলী", null },
                    { new Guid("aa000023-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(5777), null, new Guid("22222222-2222-4222-8222-222222222211"), false, "Lama", "লামা", null },
                    { new Guid("aa000023-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(6085), null, new Guid("22222222-2222-4222-8222-222222222211"), false, "Naikkhongchhari", "নাইক্ষ্যংছড়ি", null },
                    { new Guid("aa000023-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(6401), null, new Guid("22222222-2222-4222-8222-222222222211"), false, "Rowangchhari", "রোয়াংছড়ি", null },
                    { new Guid("aa000023-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(6759), null, new Guid("22222222-2222-4222-8222-222222222211"), false, "Ruma", "রুমা", null },
                    { new Guid("aa000023-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(7078), null, new Guid("22222222-2222-4222-8222-222222222211"), false, "Thanchi", "থানচি", null },
                    { new Guid("aa000024-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8012), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Bagha", "বাঘা", null },
                    { new Guid("aa000024-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8316), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Bagmara", "বাগমারা", null },
                    { new Guid("aa000024-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8621), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Charghat", "চারঘাট", null },
                    { new Guid("aa000024-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8923), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Durgapur", "দুর্গাপুর", null },
                    { new Guid("aa000024-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(9232), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Mohanpur", "লালমোহন", null },
                    { new Guid("aa000024-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(9536), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Paba", "পবা", null },
                    { new Guid("aa000024-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(9853), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Puthia", "পুঠিয়া", null },
                    { new Guid("aa000024-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(159), null, new Guid("33333333-3333-4333-8333-333333333301"), false, "Tanore", "তানোর", null },
                    { new Guid("aa000025-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1074), null, new Guid("33333333-3333-4333-8333-333333333302"), false, "Bagatipara", "বাগাতিপাড়া", null },
                    { new Guid("aa000025-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1377), null, new Guid("33333333-3333-4333-8333-333333333302"), false, "Gurudaspur", "গুরুদাসপুর", null },
                    { new Guid("aa000025-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1682), null, new Guid("33333333-3333-4333-8333-333333333302"), false, "Lalpur", "লালপুর", null },
                    { new Guid("aa000025-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1984), null, new Guid("33333333-3333-4333-8333-333333333302"), false, "Naldanga", "নলডাঙ্গা", null },
                    { new Guid("aa000025-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(2464), null, new Guid("33333333-3333-4333-8333-333333333302"), false, "Singra", "সিংড়া", null },
                    { new Guid("aa000026-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(3429), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Adamdighi", "আদমদিঘি", null },
                    { new Guid("aa000026-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(3733), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Dhunat", "ধুনট", null },
                    { new Guid("aa000026-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4037), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Dupchachia", "দুপচাঁচিয়া", null },
                    { new Guid("aa000026-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4343), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Gabtali", "গাবতলী", null },
                    { new Guid("aa000026-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4647), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Kahaloo", "কাহালু", null },
                    { new Guid("aa000026-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4952), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Nandigram", "নন্দিগ্রাম", null },
                    { new Guid("aa000026-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(5271), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Sariakandi", "সারিয়াকান্দি", null },
                    { new Guid("aa000026-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(5577), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Shajahanpur", "শাজাহানপুর", null },
                    { new Guid("aa000026-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(5881), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Sherpur", "শেরপুর", null },
                    { new Guid("aa000026-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(6189), null, new Guid("33333333-3333-4333-8333-333333333303"), false, "Sonatala", "সোনাতলা", null },
                    { new Guid("aa000027-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(7158), null, new Guid("33333333-3333-4333-8333-333333333304"), false, "Bholahat", "ভোলাহাট", null },
                    { new Guid("aa000027-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(7463), null, new Guid("33333333-3333-4333-8333-333333333304"), false, "Gomastapur", "গোমস্তাপুর", null },
                    { new Guid("aa000027-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(7766), null, new Guid("33333333-3333-4333-8333-333333333304"), false, "Nachole", "নাচোল", null },
                    { new Guid("aa000027-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(8088), null, new Guid("33333333-3333-4333-8333-333333333304"), false, "Shibganj", "শিবগঞ্জ", null },
                    { new Guid("aa000028-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(8997), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Badalgachhi", "বদলগাছী", null },
                    { new Guid("aa000028-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(9301), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Dhamoirhat", "ধামইরহাট", null },
                    { new Guid("aa000028-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(9605), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Mahadebpur", "মহাদেবপুর", null },
                    { new Guid("aa000028-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(9906), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Manda", "মান্দা", null },
                    { new Guid("aa000028-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(206), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Niamatpur", "নিয়ামতপুর", null },
                    { new Guid("aa000028-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(621), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Patnitala", "পত্নিতলা", null },
                    { new Guid("aa000028-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(930), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Porsha", "পোরশা", null },
                    { new Guid("aa000028-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(1235), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Raninagar", "রাণীনগর", null },
                    { new Guid("aa000028-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(1538), null, new Guid("33333333-3333-4333-8333-333333333305"), false, "Sapahar", "সাপাহার", null },
                    { new Guid("aa000029-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(2463), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Belkuchi", "বেলকুচি", null },
                    { new Guid("aa000029-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(2768), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Chouhali", "চৌহালি", null },
                    { new Guid("aa000029-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(3087), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Kamarkhanda", "কামারখন্দ", null },
                    { new Guid("aa000029-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(3393), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Kazipur", "কাজীপুর", null },
                    { new Guid("aa000029-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(3800), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Rayganj", "রায়গঞ্জ", null },
                    { new Guid("aa000029-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(4137), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Shahjadpur", "শাহজাদপুর", null },
                    { new Guid("aa000029-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(4448), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Tarash", "তাড়াশ", null },
                    { new Guid("aa000029-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(4755), null, new Guid("33333333-3333-4333-8333-333333333306"), false, "Ullapara", "উল্লাপাড়া", null },
                    { new Guid("aa000030-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(5679), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Bera", "বেড়া", null },
                    { new Guid("aa000030-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6002), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Bhangura", "ভাঙ্গুড়া", null },
                    { new Guid("aa000030-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6323), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Chatmohar", "চাটমোহর", null },
                    { new Guid("aa000030-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6630), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Faridpur", "ফরিদপুর", null },
                    { new Guid("aa000030-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6985), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Ishwardi", "ঈশ্বরদী", null },
                    { new Guid("aa000030-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(7310), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Santhia", "সাঁথিয়া", null },
                    { new Guid("aa000030-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(7618), null, new Guid("33333333-3333-4333-8333-333333333307"), false, "Sujanagar", "সুজানগর", null },
                    { new Guid("aa000031-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(8554), null, new Guid("33333333-3333-4333-8333-333333333308"), false, "Kalai", "কালাই", null },
                    { new Guid("aa000031-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(8864), null, new Guid("33333333-3333-4333-8333-333333333308"), false, "Khetlal", "ক্ষেতলাল", null },
                    { new Guid("aa000031-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(9176), null, new Guid("33333333-3333-4333-8333-333333333308"), false, "Panchbibi", "পাঁচবিবি", null },
                    { new Guid("aa000032-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(105), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Batiaghata", "বটিয়াঘাটা", null },
                    { new Guid("aa000032-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(409), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Dacope", "দাকোপ", null },
                    { new Guid("aa000032-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(714), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Dighalia", "কাঠালিয়া", null },
                    { new Guid("aa000032-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1020), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Dumuria", "ডুমুরিয়া", null },
                    { new Guid("aa000032-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1340), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Koyra", "কয়রা", null },
                    { new Guid("aa000032-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1646), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Paikgachha", "চৌগাছা", null },
                    { new Guid("aa000032-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1955), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Phultala", "ফুলতলা", null },
                    { new Guid("aa000032-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(2261), null, new Guid("44444444-4444-4444-8444-444444444401"), false, "Rupsa", "রূপসা", null },
                    { new Guid("aa000033-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(3180), null, new Guid("44444444-4444-4444-8444-444444444402"), false, "Debhata", "দেবহাটা", null },
                    { new Guid("aa000033-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(3483), null, new Guid("44444444-4444-4444-8444-444444444402"), false, "Kalaroa", "কলারোয়া", null },
                    { new Guid("aa000033-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(3804), null, new Guid("44444444-4444-4444-8444-444444444402"), false, "Kaliganj", "কালীগঞ্জ", null },
                    { new Guid("aa000033-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(4109), null, new Guid("44444444-4444-4444-8444-444444444402"), false, "Shyamnagar", "শ্যামনগর", null },
                    { new Guid("aa000033-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(4413), null, new Guid("44444444-4444-4444-8444-444444444402"), false, "Tala", "তালা", null },
                    { new Guid("aa000034-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5363), null, new Guid("44444444-4444-4444-8444-444444444403"), false, "Abhaynagar", "অভয়নগর", null },
                    { new Guid("aa000034-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5677), null, new Guid("44444444-4444-4444-8444-444444444403"), false, "Bagharpara", "বাঘারপাড়া", null },
                    { new Guid("aa000034-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5987), null, new Guid("44444444-4444-4444-8444-444444444403"), false, "Chaugachha", "চৌগাছা", null },
                    { new Guid("aa000034-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(6302), null, new Guid("44444444-4444-4444-8444-444444444403"), false, "Keshabpur", "কেশবপুর", null },
                    { new Guid("aa000034-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(6611), null, new Guid("44444444-4444-4444-8444-444444444403"), false, "Manirampur", "মণিরামপুর", null },
                    { new Guid("aa000034-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(6965), null, new Guid("44444444-4444-4444-8444-444444444403"), false, "Sharsha", "শার্শা", null },
                    { new Guid("aa000035-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(7915), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Chitalmari", "চিতলমারী", null },
                    { new Guid("aa000035-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(8229), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Fakirhat", "ফকিরহাট", null },
                    { new Guid("aa000035-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(8534), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Kachua", "কচুয়া", null },
                    { new Guid("aa000035-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(8839), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Mollahat", "মোল্লাহাট", null },
                    { new Guid("aa000035-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(9163), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Morelganj", "মোড়েলগঞ্জ", null },
                    { new Guid("aa000035-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(9475), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Rampal", "রামপাল", null },
                    { new Guid("aa000035-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(9778), null, new Guid("44444444-4444-4444-8444-444444444404"), false, "Sharankhola", "শরণখোলা", null },
                    { new Guid("aa000036-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(702), null, new Guid("44444444-4444-4444-8444-444444444405"), false, "Harinakundu", "হরিণাকুন্ডু", null },
                    { new Guid("aa000036-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1011), null, new Guid("44444444-4444-4444-8444-444444444405"), false, "Kaliganj", "কালীগঞ্জ", null },
                    { new Guid("aa000036-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1316), null, new Guid("44444444-4444-4444-8444-444444444405"), false, "Kotchandpur", "কোটচাঁদপুর", null },
                    { new Guid("aa000036-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1639), null, new Guid("44444444-4444-4444-8444-444444444405"), false, "Maheshpur", "মহেশপুর", null },
                    { new Guid("aa000036-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1947), null, new Guid("44444444-4444-4444-8444-444444444405"), false, "Shailkupa", "শৈলকুপা", null },
                    { new Guid("aa000037-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(2874), null, new Guid("44444444-4444-4444-8444-444444444406"), false, "Mohammadpur", "মহম্মদপুর", null },
                    { new Guid("aa000037-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(3180), null, new Guid("44444444-4444-4444-8444-444444444406"), false, "Sreepur", "শ্রীপুর", null },
                    { new Guid("aa000038-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(4171), null, new Guid("44444444-4444-4444-8444-444444444407"), false, "Kalia", "কালিয়া", null },
                    { new Guid("aa000039-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(5102), null, new Guid("44444444-4444-4444-8444-444444444408"), false, "Bheramara", "ভেড়ামারা", null },
                    { new Guid("aa000039-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(5405), null, new Guid("44444444-4444-4444-8444-444444444408"), false, "Daulatpur", "দৌলতপুর", null },
                    { new Guid("aa000039-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(5710), null, new Guid("44444444-4444-4444-8444-444444444408"), false, "Khoksa", "খোকসা", null },
                    { new Guid("aa000039-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(6015), null, new Guid("44444444-4444-4444-8444-444444444408"), false, "Mirpur", "মিরপুর", null },
                    { new Guid("aa000040-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(7034), null, new Guid("44444444-4444-4444-8444-444444444409"), false, "Mujibnagar", "মুজিবনগর", null },
                    { new Guid("aa000041-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(7969), null, new Guid("44444444-4444-4444-8444-444444444410"), false, "Damurhuda", "দামুড়হুদা", null },
                    { new Guid("aa000041-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(8278), null, new Guid("44444444-4444-4444-8444-444444444410"), false, "Jibannagar", "জীবননগর", null },
                    { new Guid("aa000042-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(9200), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Agailjhara", "আগৈলঝাড়া", null },
                    { new Guid("aa000042-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(9509), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Babuganj", "বাবুগঞ্জ", null },
                    { new Guid("aa000042-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(9833), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Banaripara", "বানারীপাড়া", null },
                    { new Guid("aa000042-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(138), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Gaurnadi", "গৌরনদী", null },
                    { new Guid("aa000042-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(446), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Hijla", "হিজলা", null },
                    { new Guid("aa000042-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(751), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Mehendiganj", "মেহেন্দিগঞ্জ", null },
                    { new Guid("aa000042-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(1060), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Muladi", "মুলাদী", null },
                    { new Guid("aa000042-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(1382), null, new Guid("55555555-5555-4555-8555-555555555501"), false, "Ujirpur", "মিরপুর", null },
                    { new Guid("aa000043-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(2325), null, new Guid("55555555-5555-4555-8555-555555555502"), false, "Bauphal", "বাউফল", null },
                    { new Guid("aa000043-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(2631), null, new Guid("55555555-5555-4555-8555-555555555502"), false, "Dashmina", "দশমিনা", null },
                    { new Guid("aa000043-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(2938), null, new Guid("55555555-5555-4555-8555-555555555502"), false, "Galachipa", "গলাচিপা", null },
                    { new Guid("aa000043-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(3244), null, new Guid("55555555-5555-4555-8555-555555555502"), false, "Kalapara", "কলাপাড়া", null },
                    { new Guid("aa000043-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(3546), null, new Guid("55555555-5555-4555-8555-555555555502"), false, "Mirzaganj", "মির্জাগঞ্জ", null },
                    { new Guid("aa000043-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(3854), null, new Guid("55555555-5555-4555-8555-555555555502"), false, "Rangabali", "রাঙ্গাবালী", null },
                    { new Guid("aa000044-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(4790), null, new Guid("55555555-5555-4555-8555-555555555503"), false, "Charfasson", "চরফ্যাশন", null },
                    { new Guid("aa000044-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(5099), null, new Guid("55555555-5555-4555-8555-555555555503"), false, "Daulatkhan", "দৌলতখান", null },
                    { new Guid("aa000044-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(5404), null, new Guid("55555555-5555-4555-8555-555555555503"), false, "Lalmohan", "লালমোহন", null },
                    { new Guid("aa000044-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(5709), null, new Guid("55555555-5555-4555-8555-555555555503"), false, "Monpura", "মনপুরা", null },
                    { new Guid("aa000044-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(6016), null, new Guid("55555555-5555-4555-8555-555555555503"), false, "Tazumuddin", "তজুমদ্দিন", null },
                    { new Guid("aa000045-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(7189), null, new Guid("55555555-5555-4555-8555-555555555504"), false, "Bhandaria", "ভান্ডারিয়া", null },
                    { new Guid("aa000045-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(7550), null, new Guid("55555555-5555-4555-8555-555555555504"), false, "Indurkani", "ইন্দুরকানী", null },
                    { new Guid("aa000045-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(7878), null, new Guid("55555555-5555-4555-8555-555555555504"), false, "Kawkhali", "কাউখালী", null },
                    { new Guid("aa000045-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(8191), null, new Guid("55555555-5555-4555-8555-555555555504"), false, "Nazirpur", "নাজিরপুর", null },
                    { new Guid("aa000045-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(8546), null, new Guid("55555555-5555-4555-8555-555555555504"), false, "Nesarabad (Swarupkathi)", "নেছারাবাদ (স্বরূপকাঠি)", null },
                    { new Guid("aa000046-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(9488), null, new Guid("55555555-5555-4555-8555-555555555505"), false, "Kanthalia", "কাঠালিয়া", null },
                    { new Guid("aa000046-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(9796), null, new Guid("55555555-5555-4555-8555-555555555505"), false, "Rajapur", "রাজাপুর", null },
                    { new Guid("aa000047-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(742), null, new Guid("55555555-5555-4555-8555-555555555506"), false, "Bamna", "বামনা", null },
                    { new Guid("aa000047-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1051), null, new Guid("55555555-5555-4555-8555-555555555506"), false, "Betagi", "বেতাগী", null },
                    { new Guid("aa000047-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1354), null, new Guid("55555555-5555-4555-8555-555555555506"), false, "Patharghata", "চারঘাট", null },
                    { new Guid("aa000047-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1659), null, new Guid("55555555-5555-4555-8555-555555555506"), false, "Taltali", "তালতলি", null },
                    { new Guid("aa000048-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(2889), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Balaganj", "বালাগঞ্জ", null },
                    { new Guid("aa000048-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(3212), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Bishwanath", "বিশ্বনাথ", null },
                    { new Guid("aa000048-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(3517), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Companiganj", "কোম্পানীগঞ্জ", null },
                    { new Guid("aa000048-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(3896), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Dakkhin Surma", "দক্ষিণ সুরমা", null },
                    { new Guid("aa000048-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(4212), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Fenchuganj", "ফেঞ্চুগঞ্জ", null },
                    { new Guid("aa000048-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(4518), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Golapganj", "গোলাপগঞ্জ", null },
                    { new Guid("aa000048-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(4821), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Gowainghat", "গোয়াইনঘাট", null },
                    { new Guid("aa000048-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(5129), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Jaintapur", "জৈন্তাপুর", null },
                    { new Guid("aa000048-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(5446), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Kanaighat", "কানাইঘাট", null },
                    { new Guid("aa000048-0000-4000-8000-000000000013"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(5771), null, new Guid("66666666-6666-4666-8666-666666666601"), false, "Osmaninagar", "ওসমানী নগর", null },
                    { new Guid("aa000049-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(6698), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Ajmiriganj", "আজমিরীগঞ্জ", null },
                    { new Guid("aa000049-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(7007), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Bahubal", "বাহুবল", null },
                    { new Guid("aa000049-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(7365), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Baniachong", "বানিয়াচং", null },
                    { new Guid("aa000049-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(7765), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Chunarughat", "চুনারুঘাট", null },
                    { new Guid("aa000049-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(8081), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Madhabpur", "মাধবপুর", null },
                    { new Guid("aa000049-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(8402), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Nabiganj", "নবীগঞ্জ", null },
                    { new Guid("aa000049-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(8713), null, new Guid("66666666-6666-4666-8666-666666666602"), false, "Shayestaganj", "শায়েস্তাগঞ্জ", null },
                    { new Guid("aa000050-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(9648), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Baralekha", "বড়লেখা", null },
                    { new Guid("aa000050-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(9978), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Juri", "জুড়ী", null },
                    { new Guid("aa000050-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(288), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Kamalganj", "জামালগঞ্জ", null },
                    { new Guid("aa000050-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(601), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Kulaura", "কুলাউড়া", null },
                    { new Guid("aa000050-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(907), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Rajnagar", "রাজনগর", null },
                    { new Guid("aa000050-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(1228), null, new Guid("66666666-6666-4666-8666-666666666603"), false, "Sreemangal", "শ্রীমঙ্গল", null },
                    { new Guid("aa000051-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(2153), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Bishwambharpur", "বিশ্বম্ভরপুর", null },
                    { new Guid("aa000051-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(2463), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Chhatak", "ছাতক", null },
                    { new Guid("aa000051-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(2776), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Derai", "দিরাই", null },
                    { new Guid("aa000051-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(3082), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Dharmapasha", "ধর্মপাশা", null },
                    { new Guid("aa000051-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(3385), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Dowarabazar", "দোয়ারাবাজার", null },
                    { new Guid("aa000051-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(3702), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Jagannathpur", "জগন্নাথপুর", null },
                    { new Guid("aa000051-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4016), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Jamalganj", "জামালগঞ্জ", null },
                    { new Guid("aa000051-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4323), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Madhyanagar", "মধ্যনগর", null },
                    { new Guid("aa000051-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4628), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Shalla", "শাল্লা", null },
                    { new Guid("aa000051-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4937), null, new Guid("66666666-6666-4666-8666-666666666604"), false, "Shantiganj", "শান্তিগঞ্জ", null },
                    { new Guid("aa000052-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(5865), null, new Guid("77777777-7777-4777-8777-777777777701"), false, "Badarganj", "মাদারগঞ্জ", null },
                    { new Guid("aa000052-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(6173), null, new Guid("77777777-7777-4777-8777-777777777701"), false, "Kaunia", "কাউনিয়া", null },
                    { new Guid("aa000052-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(6498), null, new Guid("77777777-7777-4777-8777-777777777701"), false, "Mithapukur", "মিঠাপুকুর", null },
                    { new Guid("aa000052-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(6807), null, new Guid("77777777-7777-4777-8777-777777777701"), false, "Pirgachha", "পীরগাছা", null },
                    { new Guid("aa000052-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(7118), null, new Guid("77777777-7777-4777-8777-777777777701"), false, "Pirganj", "পীরগঞ্জ", null },
                    { new Guid("aa000052-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(7473), null, new Guid("77777777-7777-4777-8777-777777777701"), false, "Taraganj", "বালাগঞ্জ", null },
                    { new Guid("aa000053-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(8414), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Birampur", "বিরামপুর", null },
                    { new Guid("aa000053-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(8727), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Birganj", "বীরগঞ্জ", null },
                    { new Guid("aa000053-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9053), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Birol", "বিরল", null },
                    { new Guid("aa000053-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9363), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Bochaganj", "বোচাগঞ্জ", null },
                    { new Guid("aa000053-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9681), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Chirirbandar", "চিরিরবন্দর", null },
                    { new Guid("aa000053-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9993), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Fulbari", "ফুলবাড়ী", null },
                    { new Guid("aa000053-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(301), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Ghoraghat", "ঘোড়াঘাট", null },
                    { new Guid("aa000053-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(608), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Hakimpur", "হাকিমপুর", null },
                    { new Guid("aa000053-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(915), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Kaharole", "কাহারোল", null },
                    { new Guid("aa000053-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(1219), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Khansama", "খানসামা", null },
                    { new Guid("aa000053-0000-4000-8000-000000000013"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(1565), null, new Guid("77777777-7777-4777-8777-777777777702"), false, "Nababganj", "নবাবগঞ্জ", null },
                    { new Guid("aa000054-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(2504), null, new Guid("77777777-7777-4777-8777-777777777703"), false, "Baliadangi", "বালিয়াডাঙ্গী", null },
                    { new Guid("aa000054-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(2813), null, new Guid("77777777-7777-4777-8777-777777777703"), false, "Haripur", "হরিপুর", null },
                    { new Guid("aa000054-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(3118), null, new Guid("77777777-7777-4777-8777-777777777703"), false, "Ranishankail", "রাণীশংকৈল", null },
                    { new Guid("aa000055-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(4116), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Bhurungamari", "ভুরুঙ্গামারী", null },
                    { new Guid("aa000055-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(4447), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Chilmari", "চিলমারী", null },
                    { new Guid("aa000055-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(4753), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Phulbari", "ফুলবাড়ী", null },
                    { new Guid("aa000055-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5058), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Rajarhat", "রাজারহাট", null },
                    { new Guid("aa000055-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5364), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Rajibpur", "চর রাজিবপুর", null },
                    { new Guid("aa000055-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5667), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Roumari", "রৌমারী", null },
                    { new Guid("aa000055-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5973), null, new Guid("77777777-7777-4777-8777-777777777704"), false, "Ulipur", "উলিপুর", null },
                    { new Guid("aa000056-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(6914), null, new Guid("77777777-7777-4777-8777-777777777705"), false, "Fulchhari", "ফুলছড়ি", null },
                    { new Guid("aa000056-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(7224), null, new Guid("77777777-7777-4777-8777-777777777705"), false, "Gobindaganj", "গোবিন্দগঞ্জ", null },
                    { new Guid("aa000056-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(7584), null, new Guid("77777777-7777-4777-8777-777777777705"), false, "Palashbari", "পলাশবাড়ী", null },
                    { new Guid("aa000056-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(7907), null, new Guid("77777777-7777-4777-8777-777777777705"), false, "Sadullapur", "সাদুল্লাপুর", null },
                    { new Guid("aa000056-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(8218), null, new Guid("77777777-7777-4777-8777-777777777705"), false, "Saghata", "সাঘাটা", null },
                    { new Guid("aa000057-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(9142), null, new Guid("77777777-7777-4777-8777-777777777706"), false, "Hatibandha", "হাতীবান্ধা", null },
                    { new Guid("aa000057-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(9449), null, new Guid("77777777-7777-4777-8777-777777777706"), false, "Kaliganj", "কালীগঞ্জ", null },
                    { new Guid("aa000057-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(9772), null, new Guid("77777777-7777-4777-8777-777777777706"), false, "Patgram", "পাটগ্রাম", null },
                    { new Guid("aa000058-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(698), null, new Guid("77777777-7777-4777-8777-777777777707"), false, "Dimla", "ডিমলা", null },
                    { new Guid("aa000058-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(1007), null, new Guid("77777777-7777-4777-8777-777777777707"), false, "Domar", "ডোমার", null },
                    { new Guid("aa000058-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(1553), null, new Guid("77777777-7777-4777-8777-777777777707"), false, "Jaldhaka", "জলঢাকা", null },
                    { new Guid("aa000058-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(3561), null, new Guid("77777777-7777-4777-8777-777777777707"), false, "Kishoreganj", "কিশোরগঞ্জ সদর", null },
                    { new Guid("aa000059-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(4998), null, new Guid("77777777-7777-4777-8777-777777777708"), false, "Atowari", "আটোয়ারী", null },
                    { new Guid("aa000059-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(5329), null, new Guid("77777777-7777-4777-8777-777777777708"), false, "Boda", "বোদা", null },
                    { new Guid("aa000059-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(5702), null, new Guid("77777777-7777-4777-8777-777777777708"), false, "Debiganj", "দেবীগঞ্জ", null },
                    { new Guid("aa000060-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(6716), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Bhaluka", "ভালুকা", null },
                    { new Guid("aa000060-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(7038), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Dhobaura", "ধোবাউড়া", null },
                    { new Guid("aa000060-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(7358), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Fulbaria", "ফুলবাড়ীয়া", null },
                    { new Guid("aa000060-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(7701), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Fulpur", "ফুলপুর", null },
                    { new Guid("aa000060-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8020), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Gafargaon", "গফরগাঁও", null },
                    { new Guid("aa000060-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8340), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Gouripur", "গৌরীপুর", null },
                    { new Guid("aa000060-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8663), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Haluaghat", "হালুয়াঘাট", null },
                    { new Guid("aa000060-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8982), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Ishwarganj", "ঈশ্বরগঞ্জ", null },
                    { new Guid("aa000060-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(9298), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Muktagachha", "মুক্তাগাছা", null },
                    { new Guid("aa000060-0000-4000-8000-000000000012"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(9618), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Nandail", "নান্দাইল", null },
                    { new Guid("aa000060-0000-4000-8000-000000000013"), new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(9941), null, new Guid("88888888-8888-4888-8888-888888888801"), false, "Tarakanda", "তারাকান্দা", null },
                    { new Guid("aa000061-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(1141), null, new Guid("88888888-8888-4888-8888-888888888802"), false, "Bakshiganj", "বকশীগঞ্জ", null },
                    { new Guid("aa000061-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(1483), null, new Guid("88888888-8888-4888-8888-888888888802"), false, "Dewanganj", "দেওয়ানগঞ্জ", null },
                    { new Guid("aa000061-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(1825), null, new Guid("88888888-8888-4888-8888-888888888802"), false, "Islampur", "ইসলামপুর", null },
                    { new Guid("aa000061-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(2164), null, new Guid("88888888-8888-4888-8888-888888888802"), false, "Madarganj", "মাদারগঞ্জ", null },
                    { new Guid("aa000061-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(2560), null, new Guid("88888888-8888-4888-8888-888888888802"), false, "Sarishabari", "সরিষাবাড়ী", null },
                    { new Guid("aa000062-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(4243), null, new Guid("88888888-8888-4888-8888-888888888803"), false, "Jhenaigati", "ঝিনাইগাতী", null },
                    { new Guid("aa000062-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(4751), null, new Guid("88888888-8888-4888-8888-888888888803"), false, "Nakla", "নকলা", null },
                    { new Guid("aa000062-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(6554), null, new Guid("88888888-8888-4888-8888-888888888803"), false, "Sreebardi", "শ্রীবরদী", null },
                    { new Guid("aa000063-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(7849), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Atpara", "আটপাড়া", null },
                    { new Guid("aa000063-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(8379), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Barhatta", "বারহাট্টা", null },
                    { new Guid("aa000063-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(8868), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Durgapur", "দুর্গাপুর", null },
                    { new Guid("aa000063-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(9269), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Kendua", "কেন্দুয়া", null },
                    { new Guid("aa000063-0000-4000-8000-000000000007"), new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(9938), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Khaliajuri", "খালিয়াজুরী", null },
                    { new Guid("aa000063-0000-4000-8000-000000000008"), new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(542), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Madan", "মদন", null },
                    { new Guid("aa000063-0000-4000-8000-000000000009"), new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(1285), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Mohanganj", "মোহনগঞ্জ", null },
                    { new Guid("aa000063-0000-4000-8000-000000000010"), new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(1975), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Netrakona Sadar", "নেত্রকোণা সদর", null },
                    { new Guid("aa000063-0000-4000-8000-000000000011"), new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(4547), null, new Guid("88888888-8888-4888-8888-888888888804"), false, "Purbadhala", "পূর্বধলা", null },
                    { new Guid("aa000064-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(1723), null, new Guid("11111111-1111-4111-8111-111111111113"), false, "Bhedarganj", "ভেদরগঞ্জ", null },
                    { new Guid("aa000064-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2033), null, new Guid("11111111-1111-4111-8111-111111111113"), false, "Damudya", "ডামুড্যা", null },
                    { new Guid("aa000064-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2342), null, new Guid("11111111-1111-4111-8111-111111111113"), false, "Gosairhat", "গোসাইরহাট", null },
                    { new Guid("aa000064-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2653), null, new Guid("11111111-1111-4111-8111-111111111113"), false, "Naria", "নড়িয়া", null },
                    { new Guid("aa000064-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2976), null, new Guid("11111111-1111-4111-8111-111111111113"), false, "Shariatpur Sadar", "শরিয়তপুর সদর", null },
                    { new Guid("aa000064-0000-4000-8000-000000000006"), new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(3284), null, new Guid("11111111-1111-4111-8111-111111111113"), false, "Zajira", "জাজিরা", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111113"));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111101"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111102"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111103"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111104"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111105"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111106"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111107"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111108"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111109"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111110"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222201"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222202"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222203"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222204"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222205"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222206"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222207"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222208"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222209"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222210"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333301"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333302"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333303"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4773));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333304"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333305"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333306"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333307"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333308"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444401"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444402"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444403"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444404"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444405"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444406"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444407"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444408"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444409"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444410"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555501"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555502"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555503"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555504"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555505"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555506"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666601"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666602"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666603"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666604"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4834));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777701"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777702"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777703"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777704"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777705"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777706"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777707"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777708"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888801"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888802"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4849));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888803"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888804"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 252, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6421));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 248, DateTimeKind.Utc).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(6481));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(642));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(5269));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(7114));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9674));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 262, DateTimeKind.Utc).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 263, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(2838));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 264, DateTimeKind.Utc).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 265, DateTimeKind.Utc).AddTicks(5743));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(7464));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 266, DateTimeKind.Utc).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(645));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(3327));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 16, 29, 55, 267, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.InsertData(
                table: "Upazilas",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DistrictId", "IsDeleted", "Name", "NameBn", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aa000001-0000-4000-8000-000000000001"), new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(720), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Dhanmondi", "ধানমন্ডি", null },
                    { new Guid("aa000001-0000-4000-8000-000000000002"), new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(2785), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Gulshan", "গুলশান", null },
                    { new Guid("aa000001-0000-4000-8000-000000000003"), new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(3164), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Mirpur", "মিরপুর", null },
                    { new Guid("aa000001-0000-4000-8000-000000000004"), new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(3494), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Uttara", "উত্তরা", null },
                    { new Guid("aa000001-0000-4000-8000-000000000005"), new DateTime(2026, 8, 26, 16, 29, 55, 261, DateTimeKind.Utc).AddTicks(3815), null, new Guid("11111111-1111-4111-8111-111111111101"), false, "Mohammadpur", "মোহাম্মদপুর", null }
                });
        }
    }
}
