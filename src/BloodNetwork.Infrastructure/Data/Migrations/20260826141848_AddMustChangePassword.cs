using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMustChangePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MustChangePassword",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MustChangePassword",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111101"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 621, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111102"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111103"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111104"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111105"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111106"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111107"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111108"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111109"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111110"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222201"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222202"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222203"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222204"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222205"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222206"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222207"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222208"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222209"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222210"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(344));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333301"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333302"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333303"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333304"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333305"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333306"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333307"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333308"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444401"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444402"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(373));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444403"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444404"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444405"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444406"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444407"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444408"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444409"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444410"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555501"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555502"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555503"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555504"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555505"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(394));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555506"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666601"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(397));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666602"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666603"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666604"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777701"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777702"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777703"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777704"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777705"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777706"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777707"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777708"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888801"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888802"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888803"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(427));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888804"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 622, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 618, DateTimeKind.Utc).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 637, DateTimeKind.Utc).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 638, DateTimeKind.Utc).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 639, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 640, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(3721));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(5478));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 641, DateTimeKind.Utc).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 642, DateTimeKind.Utc).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(8617));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 643, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 644, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(3228));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 13, 2, 13, 645, DateTimeKind.Utc).AddTicks(6889));
        }
    }
}
