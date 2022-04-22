using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class fixUserSkillId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_Skill_SkillId1",
                table: "UserSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_ApplicationUser_UserId1",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_SkillId1",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_UserId1",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "SkillId1",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserSkill");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserSkill",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "UserSkill",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                table: "UserSkill",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_Skill_SkillId",
                table: "UserSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_ApplicationUser_UserId",
                table: "UserSkill",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_Skill_SkillId",
                table: "UserSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_ApplicationUser_UserId",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_UserId",
                table: "UserSkill");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserSkill",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "SkillId",
                table: "UserSkill",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SkillId1",
                table: "UserSkill",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserSkill",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "30af470c-5d04-45fd-a3d2-6fa9d52f6844");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "73b109b1-42a5-49cd-9244-011ad6b20f0d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "08beec0c-a374-4a17-8ff6-d0ad46715dcf");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "057e2e79-b28c-4a5c-a63a-9f56adb11a98");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SkillId1",
                table: "UserSkill",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId1",
                table: "UserSkill",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_Skill_SkillId1",
                table: "UserSkill",
                column: "SkillId1",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_ApplicationUser_UserId1",
                table: "UserSkill",
                column: "UserId1",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
