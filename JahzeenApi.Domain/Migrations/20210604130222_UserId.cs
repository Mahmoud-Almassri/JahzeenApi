using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Company",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                table: "Company",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ApplicationUser_UserId",
                table: "Company",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_ApplicationUser_UserId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_UserId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "431f52ce-a4c5-46c6-bfe3-fef1b871b1d1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "ec7ed45d-3fc7-47de-8fd3-440f3b489974");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "b6741833-a777-431b-9372-c48986901e5d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "6f8102bf-bfc3-473b-b93a-5cb2ae77c439");
        }
    }
}
