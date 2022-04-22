using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class AppSettingsTableModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUsDescription",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsDescriptionAR",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsMision",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsMisionAR",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsTitleAR",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsVision",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsVisionAR",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsEmail",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsLatitude",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsLongitude",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsMobileNo",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsTitleAR",
                table: "AppSettings");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsPoint1",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsPoint2",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsPoint3",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsPoint4",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsDescription",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feature1",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feature2",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feature3",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feature4",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feature5",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feature6",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeaturesDescription",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeaturesTitle",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterNote",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeDescription",
                table: "AppSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTitle",
                table: "AppSettings",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUsPoint1",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsPoint2",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsPoint3",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AboutUsPoint4",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ContactUsDescription",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Feature1",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Feature2",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Feature3",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Feature4",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Feature5",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "Feature6",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeaturesDescription",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FeaturesTitle",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "FooterNote",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "HomeDescription",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "HomeTitle",
                table: "AppSettings");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsDescription",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsDescriptionAR",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsMision",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsMisionAR",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsTitleAR",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsVision",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsVisionAR",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsEmail",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsLatitude",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsLongitude",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsMobileNo",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsTitleAR",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
