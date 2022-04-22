using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class UserSkillTableModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearOfBirth",
                table: "ApplicationUser",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "ApplicationUser",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImgUrl",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "1c7b813b-da4a-4187-b73c-4e35b12b6922");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "9f2fe4f6-146c-40fe-bde0-adecc5bffd4d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "f71a7ed5-a84a-484d-a561-0de71231a89b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "593a2899-bb26-4549-b363-78f22043356f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImgUrl",
                table: "ApplicationUser");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfBirth",
                table: "ApplicationUser",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "ApplicationUser",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "04e59b00-afee-4992-93ea-026aaf332ee8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "60ef14e0-f4df-4e38-85d1-51b4674b9fbc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "b99381b9-de35-47f4-82ad-cf3a60e48a98");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "c26ca186-22a8-47ad-96f9-19d93f749a70");
        }
    }
}
