using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class BaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Skill",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Notification",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Notification",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Notification",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Notification",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Notification",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Experience",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "EmployeeAttachments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EmployeeAttachments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "EmployeeAttachments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EmployeeAttachments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EmployeeAttachments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "CompanyBranches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "CompanyBranches",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CompanyBranches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "CompanyBranches",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CompanyBranches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CompanyBranches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastEducationLevel",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOfBirth",
                table: "ApplicationUser",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CreatedById",
                table: "Skill",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ModifiedById",
                table: "Skill",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CreatedById",
                table: "Notification",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ModifiedById",
                table: "Notification",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_CreatedById",
                table: "Experience",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ModifiedById",
                table: "Experience",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttachments_CreatedById",
                table: "EmployeeAttachments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttachments_ModifiedById",
                table: "EmployeeAttachments",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranches_CompanyId1",
                table: "CompanyBranches",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranches_CreatedById",
                table: "CompanyBranches",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBranches_ModifiedById",
                table: "CompanyBranches",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreatedById",
                table: "Company",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ModifiedById",
                table: "Company",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ApplicationUser_CreatedById",
                table: "Company",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_ApplicationUser_ModifiedById",
                table: "Company",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_Company_CompanyId1",
                table: "CompanyBranches",
                column: "CompanyId1",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_ApplicationUser_CreatedById",
                table: "CompanyBranches",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_ApplicationUser_ModifiedById",
                table: "CompanyBranches",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttachments_ApplicationUser_CreatedById",
                table: "EmployeeAttachments",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAttachments_ApplicationUser_ModifiedById",
                table: "EmployeeAttachments",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_ApplicationUser_CreatedById",
                table: "Experience",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experience_ApplicationUser_ModifiedById",
                table: "Experience",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_ApplicationUser_CreatedById",
                table: "Notification",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_ApplicationUser_ModifiedById",
                table: "Notification",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_ApplicationUser_CreatedById",
                table: "Skill",
                column: "CreatedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_ApplicationUser_ModifiedById",
                table: "Skill",
                column: "ModifiedById",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_ApplicationUser_CreatedById",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_ApplicationUser_ModifiedById",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_Company_CompanyId1",
                table: "CompanyBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_ApplicationUser_CreatedById",
                table: "CompanyBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_ApplicationUser_ModifiedById",
                table: "CompanyBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttachments_ApplicationUser_CreatedById",
                table: "EmployeeAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAttachments_ApplicationUser_ModifiedById",
                table: "EmployeeAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_ApplicationUser_CreatedById",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Experience_ApplicationUser_ModifiedById",
                table: "Experience");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_ApplicationUser_CreatedById",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_ApplicationUser_ModifiedById",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_ApplicationUser_CreatedById",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_ApplicationUser_ModifiedById",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_CreatedById",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_ModifiedById",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Notification_CreatedById",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ModifiedById",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Experience_CreatedById",
                table: "Experience");

            migrationBuilder.DropIndex(
                name: "IX_Experience_ModifiedById",
                table: "Experience");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAttachments_CreatedById",
                table: "EmployeeAttachments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAttachments_ModifiedById",
                table: "EmployeeAttachments");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranches_CompanyId1",
                table: "CompanyBranches");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranches_CreatedById",
                table: "CompanyBranches");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranches_ModifiedById",
                table: "CompanyBranches");

            migrationBuilder.DropIndex(
                name: "IX_Company_CreatedById",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ModifiedById",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "EmployeeAttachments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EmployeeAttachments");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "EmployeeAttachments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EmployeeAttachments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmployeeAttachments");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "LastEducationLevel",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "YearOfBirth",
                table: "ApplicationUser");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "7ace6a77-c2c8-4443-8da5-ab829f4eb793");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "128fcb89-3330-4fe1-bdc4-2597b557a43b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "f07ebca6-4c65-4a4c-bedf-ae5857073a01");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "264cbe47-2521-4987-bb3b-aa1f2f3f85ca");
        }
    }
}
