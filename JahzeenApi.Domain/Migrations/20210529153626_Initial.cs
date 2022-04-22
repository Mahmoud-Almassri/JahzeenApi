using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JahzeenApi.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorMessage = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    LoggedInUser = table.Column<string>(maxLength: 50, nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    RemainingSubscription = table.Column<double>(nullable: true),
                    RemainingSubscriptionModifiedDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyLogoPath = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonTitle = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    IndustryOption = table.Column<string>(nullable: true),
                    CompanySize = table.Column<string>(nullable: true),
                    CommercialRegisterPath = table.Column<string>(nullable: true),
                    OtherAttachmentPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalPicturePath = table.Column<string>(nullable: true),
                    LastEducationCertificatePath = table.Column<string>(nullable: true),
                    NoCriminalRecordPath = table.Column<string>(nullable: true),
                    PersonalId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoPrevExperience = table.Column<bool>(nullable: true),
                    ExperienceType = table.Column<int>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Employer = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    ApplicationUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationTitle = table.Column<string>(nullable: true),
                    NotificationBody = table.Column<string>(nullable: true),
                    NotificationType = table.Column<string>(nullable: true),
                    IsOpened = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true),
                    SkillLevel = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    AboutUsTitle = table.Column<string>(nullable: true),
                    AboutUsDescription = table.Column<string>(nullable: true),
                    AboutUsVision = table.Column<string>(nullable: true),
                    AboutUsMision = table.Column<string>(nullable: true),
                    ContactUsEmail = table.Column<string>(nullable: true),
                    ContactUsMobileNo = table.Column<string>(nullable: true),
                    ContactUsLatitude = table.Column<string>(nullable: true),
                    ContactUsLongitude = table.Column<string>(nullable: true),
                    ContactUsTitle = table.Column<string>(nullable: true),
                    ContactUsTitleAR = table.Column<string>(nullable: true),
                    AboutUsTitleAR = table.Column<string>(nullable: true),
                    AboutUsDescriptionAR = table.Column<string>(nullable: true),
                    AboutUsVisionAR = table.Column<string>(nullable: true),
                    AboutUsMisionAR = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSettings_ApplicationUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppSettings_ApplicationUser_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedById = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUs_ApplicationUser_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactUs_ApplicationUser_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { -1, "264cbe47-2521-4987-bb3b-aa1f2f3f85ca", "SuperAdmin", "SUPERADMIN" },
                    { -2, "f07ebca6-4c65-4a4c-bedf-ae5857073a01", "Admin", "ADMIN" },
                    { -3, "128fcb89-3330-4fe1-bdc4-2597b557a43b", "DataEntry", "DATAENTRY" },
                    { -4, "7ace6a77-c2c8-4443-8da5-ab829f4eb793", "Qa", "QA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_CreatedById",
                table: "AppSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_ModifiedById",
                table: "AppSettings",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_CreatedById",
                table: "ContactUs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ModifiedById",
                table: "ContactUs",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationExceptions");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "CompanyBranches");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "EmployeeAttachments");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
