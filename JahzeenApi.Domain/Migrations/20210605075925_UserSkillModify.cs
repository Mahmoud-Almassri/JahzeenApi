using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class UserSkillModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "ProfileImgUrl",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<int>(
                name: "TitleLevel",
                table: "UserSkill",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "bfb97327-7b5c-40d2-89de-555c6122dd27");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "7a50d840-bd9e-482e-9468-2108693d5cc0");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "d265b99c-59a3-4b2b-8efa-7f6fe2c4b4d3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "b42742bd-e9b6-4a8a-b1f9-161bc328bb3b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleLevel",
                table: "UserSkill");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImgUrl",
                table: "ApplicationUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "a2a621b9-55ca-4548-9577-b30b43f594ca");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "ca2e165f-7243-4329-89b1-ec0b17b1bbaf");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "ba3ae0c7-c124-4dd0-845c-e0b8211fc44f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "6a840abb-06eb-448f-a5ca-240c1fcfb426");
        }
    }
}
