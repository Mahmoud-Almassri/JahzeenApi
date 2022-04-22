using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class Jahzzeen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppleStore",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleStore",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "4c1c06b0-5777-4570-9acd-c56a218d932a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "0fbe2830-f0f1-4c6e-89b6-d8029d06c8ae");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "4c9f522c-329d-471a-b887-6cf31d7ebe74");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "c0cd2504-1a99-436b-97c8-59449158f309");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppleStore",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "GoogleStore",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "AppSettings");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "de711549-916d-477e-b96b-ad1ca079484d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "c619a02d-d0ea-4cd3-b6df-5db3a76c643c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "5454e0c7-72f4-4b71-be9e-df69884e6fb0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "8b787481-5b13-4de0-adc1-4f678c70f84c");
        }
    }
}
