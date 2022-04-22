using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class NoPreviousExperienceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "17d62344-fc01-4f94-adf4-da4cab0fce63");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "4131d058-c7f9-4992-9b7c-c989a25b4212");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "abc0429d-777a-459f-806c-4af47dd6ec86");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "65b772d1-ccd8-462d-b756-a5d4506bc19b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "4b962f5b-6032-4716-aaee-6472ed3d5702");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "62504160-3d31-4419-ab93-a1c0b86c286f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "8625c392-3532-4d2f-9d55-940d2ce2fb7a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "36f3b51d-2aa2-4bbd-8485-9cfdfe30d4fa");
        }
    }
}
