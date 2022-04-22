using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class ActionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    ActionType = table.Column<int>(nullable: false),
                    ActionByName = table.Column<string>(nullable: true),
                    ApprovalId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Approvals_ApprovalId",
                        column: x => x.ApprovalId,
                        principalTable: "Approvals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actions_ApplicationUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_ApplicationUser_ModifiedById",
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
                value: "737821cd-19de-42c8-81f6-f7922e762696");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "57fb17de-fcb1-4f70-ad42-18933aba3e16");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "afd0b084-a8af-45d1-88df-2c4ea00de6b1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "36687ec5-ca93-4138-bd8f-774b549695a2");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ApprovalId",
                table: "Actions",
                column: "ApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CreatedById",
                table: "Actions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ModifiedById",
                table: "Actions",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

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
        }
    }
}
