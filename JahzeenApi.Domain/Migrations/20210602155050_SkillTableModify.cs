using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class SkillTableModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "RemainingSubscription",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "RemainingSubscriptionModifiedDate",
                table: "ApplicationUser");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Skill",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    SkillId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    SkillId1 = table.Column<int>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkill_ApplicationUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkill_ApplicationUser_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkill_Skill_SkillId1",
                        column: x => x.SkillId1,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSkill_ApplicationUser_UserId1",
                        column: x => x.UserId1,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_CreatedById",
                table: "UserSkill",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_ModifiedById",
                table: "UserSkill",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId1",
                table: "UserSkill",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId1",
                table: "UserSkill",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkill");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Skill");

            migrationBuilder.AddColumn<long>(
                name: "ApplicationUserId",
                table: "Skill",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                table: "Skill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "Skill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RemainingSubscription",
                table: "ApplicationUser",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemainingSubscriptionModifiedDate",
                table: "ApplicationUser",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "7140d5ed-ca00-4651-8bfa-f8712c83dbfa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "2de11886-0af7-4b18-bc50-f9255c60f62a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "79c3c8b3-9a79-4efb-a3f8-bf645615aaaa");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "0fc778af-e1af-4dbb-bafe-c865c431d2dd");
        }
    }
}
