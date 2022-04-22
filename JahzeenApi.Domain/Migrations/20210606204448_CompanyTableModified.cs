using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class CompanyTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovalId",
                table: "Company",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "be460906-5ad3-4c78-98a1-51671ed4091c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "32770f36-7f30-4080-92d6-55eea5e10f68");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "4bb1a8e1-e459-47ad-a5fb-0cd67912c898");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "386a3cad-df5e-406a-977c-bb51ea823617");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ApprovalId",
                table: "Company",
                column: "ApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Approvals_ApprovalId",
                table: "Company",
                column: "ApprovalId",
                principalTable: "Approvals",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Approvals_ApprovalId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ApprovalId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -4,
                column: "ConcurrencyStamp",
                value: "1e047898-5288-4234-bf49-40ce4bde6307");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -3,
                column: "ConcurrencyStamp",
                value: "96a2505d-e4e2-4e73-b91e-184d9fb9a7e2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -2,
                column: "ConcurrencyStamp",
                value: "8fd08a43-4575-4343-b129-9ec576cd6116");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: -1,
                column: "ConcurrencyStamp",
                value: "34e4534e-87ba-4790-9963-ba0768fb268d");
        }
    }
}
