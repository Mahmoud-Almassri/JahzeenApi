using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class ApprovalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    AccountId = table.Column<int>(nullable: false),
                    ApprovalUserName = table.Column<string>(nullable: true),
                    ActionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approvals_ApplicationUser_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Approvals_ApplicationUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_ApplicationUser_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "635d8c85-af23-45ae-896b-f623fafe00d3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "b3c2c75a-3d96-4a43-9cbd-96f161536c78");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "16f461ce-30dd-4720-8a1c-c8ef53a590af");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "e39bbf2c-bb57-4193-820e-579e2a9c2ae6");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_AccountId",
                table: "Approvals",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_CreatedById",
                table: "Approvals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ModifiedById",
                table: "Approvals",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

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
    }
}
