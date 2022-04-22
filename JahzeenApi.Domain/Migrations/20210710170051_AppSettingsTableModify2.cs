using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class AppSettingsTableModify2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeatureTitle1",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTitle2",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTitle3",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTitle4",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTitle5",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTitle6",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "f4f1ab44-6ea1-4852-9d9f-ea6de5f47b0c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "64f50c06-34d3-4bf0-9b52-c3129345f053");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "c79b6550-6678-410c-be78-e35f3a7d9e6c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "2b8ece97-fa94-4b60-b2d3-b887f7f93df8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatureTitle1",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeatureTitle2",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeatureTitle3",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeatureTitle4",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeatureTitle5",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeatureTitle6",
                table: "AppSettings");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "a47c8ed6-a9fc-45d0-a545-f1b75befe5e2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "69393965-1786-493b-8ce0-1088a49c26f7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "69214178-7212-470b-8609-13c0bf96c581");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "1cb09553-5165-4dd2-80f6-6bfba24c48d2");
        }
    }
}
