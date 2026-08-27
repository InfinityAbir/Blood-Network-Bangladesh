using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodNetwork.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId1",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111101"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111102"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111103"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111104"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111105"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111106"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111107"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111108"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111109"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111110"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111113"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222201"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222202"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222203"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222204"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222205"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222206"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222207"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222208"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222209"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222210"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333301"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333302"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333303"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333304"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333305"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333306"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333307"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333308"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444401"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444402"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444403"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444404"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444405"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444406"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444407"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444408"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444409"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7106));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444410"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555501"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555502"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555503"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555504"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555505"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-4555-8555-555555555506"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666601"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666602"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666603"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-4666-8666-666666666604"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777701"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777702"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777703"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777704"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777705"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777706"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777707"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-4777-8777-777777777708"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888801"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888802"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888803"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-4888-8888-888888888804"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 293, DateTimeKind.Utc).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-e1f2-4a3b-4c5d-6e7f8a9b0c1d"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-f2a3-4b4c-5d6e-7f8a9b0c1d2e"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e1f-2a3b-4c5d6e7f8a9b"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f2a-3b4c-5d6e7f8a9b0c"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 291, DateTimeKind.Utc).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 332, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 333, DateTimeKind.Utc).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 334, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 335, DateTimeKind.Utc).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 336, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(9863));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(7602));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 338, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 339, DateTimeKind.Utc).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(6187));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 340, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(880));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(2704));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 341, DateTimeKind.Utc).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 342, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 343, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(9303));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 344, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(9294));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 345, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000038-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(7244));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000040-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 346, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 347, DateTimeKind.Utc).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(6317));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 348, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 349, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 350, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 351, DateTimeKind.Utc).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 352, DateTimeKind.Utc).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(3465));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(3819));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 353, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(644));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(2529));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(3839));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 354, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 27, 5, 46, 44, 337, DateTimeKind.Utc).AddTicks(8831));

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequestMatches_BloodRequestId_DonorId",
                table: "BloodRequestMatches",
                columns: new[] { "BloodRequestId", "DonorId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BloodRequestMatches_BloodRequestId_DonorId",
                table: "BloodRequestMatches");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "RefreshTokens",
                type: "uuid",
                nullable: true);

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
                keyValue: new Guid("11111111-1111-4111-8111-111111111113"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 295, DateTimeKind.Utc).AddTicks(6318));

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
                keyValue: new Guid("aa000001-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000001-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(8382));

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
                keyValue: new Guid("aa000002-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 336, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000002-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(323));

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
                keyValue: new Guid("aa000003-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000003-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(1879));

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
                keyValue: new Guid("aa000004-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000004-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(4050));

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
                keyValue: new Guid("aa000005-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000005-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(6136));

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
                keyValue: new Guid("aa000006-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 337, DateTimeKind.Utc).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000006-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(7402));

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
                keyValue: new Guid("aa000007-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 338, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(747));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000007-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(4676));

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
                keyValue: new Guid("aa000008-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000008-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 339, DateTimeKind.Utc).AddTicks(9659));

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
                keyValue: new Guid("aa000009-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000009-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(3965));

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
                keyValue: new Guid("aa000010-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000010-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(7395));

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
                keyValue: new Guid("aa000011-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000011-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 340, DateTimeKind.Utc).AddTicks(9379));

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
                keyValue: new Guid("aa000012-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000012-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(1416));

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
                keyValue: new Guid("aa000013-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000013-0000-4000-8000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(8682));

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
                keyValue: new Guid("aa000014-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(830));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(1138));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000014-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(1441));

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
                keyValue: new Guid("aa000015-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000015-0000-4000-8000-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(7175));

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
                keyValue: new Guid("aa000016-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000016-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 342, DateTimeKind.Utc).AddTicks(9999));

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
                keyValue: new Guid("aa000017-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000017-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(2457));

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
                keyValue: new Guid("aa000018-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000018-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(3990));

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
                keyValue: new Guid("aa000019-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000019-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(6964));

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
                keyValue: new Guid("aa000020-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000020-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(8829));

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
                keyValue: new Guid("aa000021-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 343, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000021-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(1629));

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
                keyValue: new Guid("aa000022-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000022-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(4848));

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
                keyValue: new Guid("aa000023-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000023-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(7078));

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
                keyValue: new Guid("aa000024-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 344, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000024-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(159));

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
                keyValue: new Guid("aa000025-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1377));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000025-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(2464));

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
                keyValue: new Guid("aa000026-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(3429));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000026-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(6189));

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
                keyValue: new Guid("aa000027-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000027-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(8088));

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
                keyValue: new Guid("aa000028-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 345, DateTimeKind.Utc).AddTicks(9906));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(930));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000028-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(1538));

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
                keyValue: new Guid("aa000029-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000029-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(4755));

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
                keyValue: new Guid("aa000030-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000030-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(7618));

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
                keyValue: new Guid("aa000031-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000031-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 346, DateTimeKind.Utc).AddTicks(9176));

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
                keyValue: new Guid("aa000032-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000032-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(2261));

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
                keyValue: new Guid("aa000033-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(3483));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000033-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(4413));

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
                keyValue: new Guid("aa000034-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000034-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(6965));

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
                keyValue: new Guid("aa000035-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000035-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 347, DateTimeKind.Utc).AddTicks(9778));

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
                keyValue: new Guid("aa000036-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000036-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(1947));

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
                keyValue: new Guid("aa000037-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(2874));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000037-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(3180));

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
                keyValue: new Guid("aa000038-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(4171));

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
                keyValue: new Guid("aa000039-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000039-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(6015));

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
                keyValue: new Guid("aa000040-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(7034));

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
                keyValue: new Guid("aa000041-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000041-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(8278));

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
                keyValue: new Guid("aa000042-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 348, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000042-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(1382));

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
                keyValue: new Guid("aa000043-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000043-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(3854));

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
                keyValue: new Guid("aa000044-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000044-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(6016));

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
                keyValue: new Guid("aa000045-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(7189));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000045-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(8546));

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
                keyValue: new Guid("aa000046-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000046-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 349, DateTimeKind.Utc).AddTicks(9796));

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
                keyValue: new Guid("aa000047-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000047-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(1659));

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
                keyValue: new Guid("aa000048-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(4212));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000048-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(5771));

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
                keyValue: new Guid("aa000049-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(6698));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000049-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(8713));

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
                keyValue: new Guid("aa000050-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 350, DateTimeKind.Utc).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000050-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(1228));

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
                keyValue: new Guid("aa000051-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000051-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(4937));

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
                keyValue: new Guid("aa000052-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000052-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(7473));

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
                keyValue: new Guid("aa000053-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9681));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 351, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000053-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(1565));

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
                keyValue: new Guid("aa000054-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000054-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(3118));

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
                keyValue: new Guid("aa000055-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000055-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(5973));

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
                keyValue: new Guid("aa000056-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000056-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(8218));

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
                keyValue: new Guid("aa000057-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000057-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 352, DateTimeKind.Utc).AddTicks(9772));

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
                keyValue: new Guid("aa000058-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000058-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(3561));

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
                keyValue: new Guid("aa000059-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000059-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(5702));

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
                keyValue: new Guid("aa000060-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000060-0000-4000-8000-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 353, DateTimeKind.Utc).AddTicks(9941));

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
                keyValue: new Guid("aa000061-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000061-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(2560));

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
                keyValue: new Guid("aa000062-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(4243));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000062-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(6554));

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

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 354, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000063-0000-4000-8000-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 355, DateTimeKind.Utc).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "Upazilas",
                keyColumn: "Id",
                keyValue: new Guid("aa000064-0000-4000-8000-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 8, 26, 19, 24, 11, 341, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId1",
                table: "RefreshTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId1",
                table: "RefreshTokens",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
