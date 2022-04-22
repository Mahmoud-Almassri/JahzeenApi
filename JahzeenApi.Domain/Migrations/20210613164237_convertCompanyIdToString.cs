using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class convertCompanyIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_Company_CompanyId1",
                table: "CompanyBranches");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranches_CompanyId1",
                table: "CompanyBranches");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "CompanyBranches");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyBranches",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "IX_CompanyBranches_CompanyId",
                table: "CompanyBranches",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_Company_CompanyId",
                table: "CompanyBranches",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBranches_Company_CompanyId",
                table: "CompanyBranches");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBranches_CompanyId",
                table: "CompanyBranches");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "CompanyBranches",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "CompanyBranches",
                type: "int",
                nullable: true);

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
                name: "IX_CompanyBranches_CompanyId1",
                table: "CompanyBranches",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBranches_Company_CompanyId1",
                table: "CompanyBranches",
                column: "CompanyId1",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
