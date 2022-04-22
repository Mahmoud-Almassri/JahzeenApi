using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class RemoveNoPrevExperienceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoPrevExperience",
                table: "Experience");

            migrationBuilder.AddColumn<bool>(
                name: "NoPrevExperience",
                table: "ApplicationUser",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoPrevExperience",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<bool>(
                name: "NoPrevExperience",
                table: "Experience",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "5692dd98-f74f-4184-a9ad-ee3db76caa12");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "c0c9b78d-e20e-44ef-b057-92ac53e5dee2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "a6e223e0-1b1f-4fae-9f18-d4a22307d018");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "0cfcd7ad-a943-4de7-a248-0e4b8ceed36d");
        }
    }
}
