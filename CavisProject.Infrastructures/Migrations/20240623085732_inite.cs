using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:CavisProject.Infrastructures/Migrations/20240622140350_initDb.cs
    public partial class initDb : Migration
========
    public partial class inite : Migration
>>>>>>>> c7dab5f7314ceb89a864ec72ab499bcbfd63f2cb:CavisProject.Infrastructures/Migrations/20240623085732_inite.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wallet = table.Column<double>(type: "float", nullable: true),
                    URLImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RewardPoint = table.Column<double>(type: "float", nullable: true),
                    OTPEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireOTPEmail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackagePremiums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackagePremiumName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagePremiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkinsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetails",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetails", x => new { x.UserId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Methods_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonalAnalysts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAnalysts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalAnalysts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonalImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetails",
                columns: table => new
                {
                    PackagePremiumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetails", x => new { x.UserId, x.PackagePremiumId });
                    table.ForeignKey(
                        name: "FK_PackageDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageDetails_PackagePremiums_PackagePremiumId",
                        column: x => x.PackagePremiumId,
                        principalTable: "PackagePremiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPaid = table.Column<double>(type: "float", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PackagePremiumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_PackagePremiums_PackagePremiumId",
                        column: x => x.PackagePremiumId,
                        principalTable: "PackagePremiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClicksAmount = table.Column<int>(type: "int", nullable: false),
                    ClickMoney = table.Column<double>(type: "float", nullable: false),
                    TotalMoney = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MethodDetails",
                columns: table => new
                {
                    MethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SkinTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodDetails", x => new { x.MethodId, x.SkinId });
                    table.ForeignKey(
                        name: "FK_MethodDetails_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MethodDetails_Skins_SkinId",
                        column: x => x.SkinId,
                        principalTable: "Skins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAnalystDetails",
                columns: table => new
                {
                    PersonalAnalystId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAnalystDetails", x => new { x.SkinId, x.PersonalAnalystId });
                    table.ForeignKey(
                        name: "FK_PersonalAnalystDetails_PersonalAnalysts_PersonalAnalystId",
                        column: x => x.PersonalAnalystId,
                        principalTable: "PersonalAnalysts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalAnalystDetails_Skins_SkinId",
                        column: x => x.SkinId,
                        principalTable: "Skins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalMethodDetails",
                columns: table => new
                {
                    MethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalAnalystId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMethodDetails", x => new { x.PersonalAnalystId, x.MethodId });
                    table.ForeignKey(
                        name: "FK_PersonalMethodDetails_Methods_MethodId",
                        column: x => x.MethodId,
                        principalTable: "Methods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalMethodDetails_PersonalAnalysts_PersonalAnalystId",
                        column: x => x.PersonalAnalystId,
                        principalTable: "PersonalAnalysts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
<<<<<<<< HEAD:CavisProject.Infrastructures/Migrations/20240622140350_initDb.cs
                    SkinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
========
                    SkinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
>>>>>>>> c7dab5f7314ceb89a864ec72ab499bcbfd63f2cb:CavisProject.Infrastructures/Migrations/20240623085732_inite.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => new { x.ProductId, x.SkinId });
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Skins_SkinId",
                        column: x => x.SkinId,
                        principalTable: "Skins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishLists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PackagePremiums",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "Duration", "IsDeleted", "ModificationBy", "ModificationDate", "PackagePremiumName", "Price" },
                values: new object[,]
                {
                    { new Guid("56866515-9d42-4209-a3f9-62e166cb322a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "This is a premium package offering special features.", 365.0, false, null, null, "Premium Package year", 200000.0 },
                    { new Guid("623a23ff-4ee9-409a-bf30-2e764e8bd754"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "This is a premium package offering special features.", 5.0, false, null, null, "Premium Package 5 days", 5000.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "ProductCategoryName" },
                values: new object[,]
                {
                    { new Guid("005eb795-d06e-4a1a-b828-87fb00b9e919"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Kem dưỡng đêm" },
                    { new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Toner" },
                    { new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Kem chống nắng" },
                    { new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Sữa rửa mặt" },
                    { new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Nước tẩy trang" },
                    { new Guid("c45b4c4a-eefe-4295-8110-e9bed75273d9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Serum" },
                    { new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Kem dưỡng ngày" }
                });

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "SkinsName" },
                values: new object[,]
                {
<<<<<<<< HEAD:CavisProject.Infrastructures/Migrations/20240622140350_initDb.cs
                    { new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), true, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6101), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6135), null, null, "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", false, null, null, "Mụn viêm đỏ" },
                    { new Guid("4678f8d2-5648-4521-9608-8e981dee9103"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6143), null, null, "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.", false, null, null, "Nếp nhăn" },
                    { new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), true, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6080), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6132), null, null, "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.", false, null, null, "Mụn bọc" },
                    { new Guid("73766ff0-d528-4262-a1e8-656b33f58603"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6130), null, null, "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.", false, null, null, "Mụn đầu trắng" },
                    { new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6142), null, null, "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.", false, null, null, "Nám da" },
                    { new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), true, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6103), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("a9035561-1399-464f-9f09-38c164a40a63"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6140), null, null, "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.", false, null, null, "Mụn thâm" },
                    { new Guid("a960d28f-2807-4d58-8248-91eec518d415"), true, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6099), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6133), null, null, "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.", false, null, null, "Mụn mủ" },
                    { new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), true, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6097), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" },
                    { new Guid("e8685143-0f2e-42fa-8025-da53e1707461"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6104), null, null, "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.", false, null, null, "Mụn đầu đen" },
                    { new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"), false, null, new DateTime(2024, 6, 22, 21, 3, 50, 612, DateTimeKind.Local).AddTicks(6137), null, null, "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.", false, null, null, "Mụn đầu đinh" }
========
                    { new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), true, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2264), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2278), null, null, "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", false, null, null, "Mụn viêm đỏ" },
                    { new Guid("4678f8d2-5648-4521-9608-8e981dee9103"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2287), null, null, "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.", false, null, null, "Nếp nhăn" },
                    { new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), true, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2237), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2273), null, null, "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.", false, null, null, "Mụn bọc" },
                    { new Guid("73766ff0-d528-4262-a1e8-656b33f58603"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2271), null, null, "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.", false, null, null, "Mụn đầu trắng" },
                    { new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2285), null, null, "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.", false, null, null, "Nám da" },
                    { new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), true, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2266), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("a9035561-1399-464f-9f09-38c164a40a63"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2283), null, null, "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.", false, null, null, "Mụn thâm" },
                    { new Guid("a960d28f-2807-4d58-8248-91eec518d415"), true, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2262), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2276), null, null, "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.", false, null, null, "Mụn mủ" },
                    { new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), true, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2259), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" },
                    { new Guid("e8685143-0f2e-42fa-8025-da53e1707461"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2269), null, null, "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.", false, null, null, "Mụn đầu đen" },
                    { new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"), false, null, new DateTime(2024, 6, 23, 15, 57, 31, 779, DateTimeKind.Local).AddTicks(2281), null, null, "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.", false, null, null, "Mụn đầu đinh" }
>>>>>>>> c7dab5f7314ceb89a864ec72ab499bcbfd63f2cb:CavisProject.Infrastructures/Migrations/20240623085732_inite.cs
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Email", "IsDeleted", "ModificationBy", "ModificationDate", "PhoneNumber", "Status", "SupplierName" },
                values: new object[] { new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), "71 Hoàng Hoa Thám, P.13, Q.Tân Bình, TP.HCM", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "hotro@hasaki.vn", false, null, null, "1800 6324", 1, "Hasaki" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ClickMoney", "ClicksAmount", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "Price", "ProductCategoryId", "ProductName", "SupplierId", "TotalMoney", "URL", "URLImage" },
                values: new object[,]
                {
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "giúp thúc đẩy hệ thống duy trì độ ẩm ngay từ bên trong, để da luôn ẩm mịn, căng mượt và tràn đầy sức sống.", false, null, null, 590000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Ẩm Eucerin Dịu Nhẹ Cho Da Thường, Hỗn Hợp 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-eucerin-cho-da-thuong-den-da-hon-hop-50ml-68136.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqneRasEsTiW395OeWuFa_ZebB5tH1gDMjSIQjEO7EnM4IB3DUtnZINoaAggoEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Eucerin%20Lipo-Balance%20Intensive%20Nourishing%20Cream.jpg?alt=media&token=423592d5-ccc1-44cc-8d8d-27a3944d8952" },
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nước Hoa Hồng Thayers với thành phần không chứa cồn (alcohol-free) và công thức độc quyền kết hợp giữa chiết xuất Lô Hội (Aloe Vera) & chiết xuất cây Phỉ (Witch Hazel) không chưng cất sẽ giúp nhẹ nhàng làm sạch da, cân bằng độ pH và dưỡng ẩm, mang lại vẻ sáng mịn tự nhiên và khỏe mạnh cho làn da của bạn.", false, null, null, 264000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Thayers Không Cồn Hương Hoa Hồng 355ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-khong-con-thayers-huong-hoa-hong-355ml-3227.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2thayers.png?alt=media&token=6d12bf7b-6a41-4cdc-bddf-1ccb677f4d93" },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sản phẩm là sự kết hợp hoàn hảo của ceramide và hyaluronic acid, giúp nhẹ nhàng loại bỏ hết dầu thừa, bụi bẩn và các lớp trang điểm mà không làm khô da, cho da mềm mại, mịn màng hơn. Thành phần ceramide có tác dụng cải thiện rõ nét sắc diện và độ sáng trong của làn da. Nó ngay lập tức mang đến làn da mịn màng, mềm mại, tăng cường lượng collagen tự nhiên trong da, cho làn da săn chắc. Ngoài ra, ceramide còn giúp làm giảm các nếp nhăn sâu, xóa các nếp nhăn mờ nông, cho bề mặt da láng mượt, săn chắc.", false, null, null, 638000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Sữa Rửa Mặt Paula’s Choice Cân Bằng Độ Ẩm Da 190ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-rua-mat-paula-s-choice-can-bang-da-190ml-2329.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/paula.jpg?alt=media&token=25b6781b-fb55-4cc6-999d-1944d6533418" },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Giúp làm sạch sâu, se khít lỗ chân lông và kiềm dầu hiệu quả mà không làm khô da. Sản phẩm là sự lựa chọn tối ưu dành cho làn da dầu mụn và nhạy cảm, giúp mang lại làn da sạch thoáng, thanh khiết, không còn nỗi lo về mụn và lỗ chân lông được thu nhỏ.", false, null, null, 140000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Sữa Rửa Mặt Vichy Dạng Gel Làm Sạch Sâu Da Dầu Mụn 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-rua-mat-dang-gel-vichy-lam-sach-sau-cho-da-nhon-mun-50ml-80971.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/vichy.png?alt=media&token=4fbad0f6-a839-43dd-b704-4864cc3e9ba6" },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Da xỉn màu hiệu quả, cho làn da toả sáng rạng rỡ chỉ trong 28 ngày.", false, null, null, 270000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Olay Luminous Sáng Da Mờ Thâm Nám Ban Đêm 50g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-ban-dem-olay-lam-sang-da-mo-tham-nam-50g-87859.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndHWwtwmT9MaaMeaKHq6Ymco3tN1Wa0ytsHuzvR-rgK4l3PeomwccgaAiaREALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Olay.jpg?alt=media&token=8c757a0c-383d-4499-b3b8-7f3e2b48b719" },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sữa Rửa Mặt Skin1004 Làm Sạch Sâu Cho Da Nhạy Cảm 125ml từ thương hiệu mỹ phẩm Skin1004 của Hàn Quốc là dạng sữa rửa mặt tạo bọt chứa chiết xuất rau má giúp làm sạch da ngăn ngừa mụn và hỗ trợ điều trị mụn. Chứa thành phần tự nhiên dịu nhẹ cho da nên sữa rửa mặt không làm khô da mà còn giữ ẩm cho da. ", false, null, null, 375000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Sữa Rửa Mặt Skin1004 Làm Sạch Sâu Cho Da Nhạy Cảm 125ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-rua-mat-chiet-xuat-rau-ma-skin1004-diu-nhe-lam-sach-sau-da-125ml-86169.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/centella3.png?alt=media&token=49d34368-8e90-4165-baca-a774cc354262" },
                    { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Kem Chống Nắng Chống Ô Nhiễm & Bụi Mịn Hằng Ngày Vichy Capital Soleil Mattifying 3in1 SPF50+ 50ml là sản phẩm chống nắng da mặt 3 trong 1 mới từ thương hiệu dược mỹ phẩm Vichy, được thiết kế dành cho da dầu mụn. ", false, null, null, 585000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Kem Chống Nắng Vichy Chống Bụi Mịn Cho Da Dầu Mụn 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-chong-nang-vichy-kiem-dau-spf50-50ml-88835.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnfcttLtt9diCT48iS-WDplNHtsBwy_Umy_EgQqc-rN_ia_0uYNCvT4aAlP1EALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Vichy%20Capital%20Soleil%20Mattifying.jpg?alt=media&token=64266959-9a96-4d6d-bb0e-9fe026cb969d" },
                    { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "với công thức cũ, mang lại hiệu quả dưỡng ẩm sâu suốt 72 giờ, cho làn da căng bóng, sáng mịn và đàn hồi.", false, null, null, 389000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Ẩm Neutrogena Cấp Nước Cho Da Dầu 50g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-neutrogena-cung-cap-nuoc-cho-da-50g-90339.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndONELGoevx8Sn66b5Fl2QsToH_IahOd8gyeYIIKK-E271RuWnktCAaAvogEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Neutrogena%20Hydro%20Boost%20Water%20Gel.jpg?alt=media&token=6bdfef98-734c-4454-b201-f8bd93bea6e1" },
                    { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "màng lọc chống nắng phổ rộng chống lại các tia UVA, UVB, IR (hồng ngoại), HEV (ánh sáng xanh). Sự kết hợp của Proteoglycans, phức hợp Spectrum Complex, phức hợp Hyaluronic Acid & Silicon Complex giúp giữ cho làn da trẻ trung, tươi tắn và đều màu. Kết cấu dạng cream-to-powder độc đáo mang lại cảm giác mượt mà, mỏng nhẹ tựa vô hình trên da.", false, null, null, 1350000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Kem Chống Nắng MartiDerm Phổ Rộng Bảo Vệ Toàn Diện", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-chong-nang-martiderm-pho-rong-toan-dien-spf50-40ml-90401.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnf0BPilz_8AKunYGCdgJi4LTr0XOYFCe5IumOshtzd6qwrtvxNm4P0aAtjXEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/MartiDerm%20The%20Originals%20Proteos%20Screen%20SPF50%2B%20Fluid%20Cream.jpg?alt=media&token=e92f624b-918d-4428-9cc8-3a0f18a27c96" },
                    { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Màng chắn vi điểm mang đến hiệu quả chống nắng hoàn hảo mà không gây bết dính, ngăn tia UV tối ưu đồng thời tạo cảm giác siêu thoáng nhẹ trên da. Đặc biệt với kết cấu dạng essence màng nước trong suốt dễ dàng tán đều, thẩm thấu nhanh chóng, giúp tạo cảm giác tươi mát cùng làn da ẩm mịn mượt mà như lụa.", false, null, null, 195000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Essence Chống Nắng Bioré Màng Nước Dưỡng Ẩm Da 50g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/essence-chong-nang-mang-nuoc-duong-am-biore-spf50-pa-50g-6408.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Biore%20UV%20Aqua%20Rich%20Watery%20Essence.jpg?alt=media&token=9f37b704-dda7-4941-b0bb-78a14b6f90d1" },
                    { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Công thức với Niacinamide, Piroctone Olamine, hạt tẩy tế bào chết LHA siêu mịn và nước khoáng La Roche-Posay giúp làm sạch sâu lỗ chân lông, giảm sưng viêm và ngừa sự phát triển của vi khuẩn gây mụn, đồng thời giúp làm dịu và kích thích tái tạo tế bào bề mặt da, ngăn ngừa sự hình thành của các vết thâm sau mụn.", false, null, null, 610000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Giảm Mụn La Roche-Posay Dành Cho Mụn Sưng Đỏ 15ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-la-roche-posay-lam-giam-mun-chuyen-biet-15ml-1092.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndVhOh7KFY12qi3dIFnBPywwEf96mC1lZgd4WZqlyHGD6C95HwLIgAaArFpEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/La%20Roche-Posay%20Effacla.jpg?alt=media&token=b7a3c1b8-2882-4389-8b73-fd2090b43a35" },
                    { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "với công thức cũ, mang lại hiệu quả dưỡng ẩm sâu suốt 72 giờ, cho làn da căng bóng, sáng mịn và đàn hồi.", false, null, null, 850000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Ẩm Laneige Cấp Nước Cho Da Khô 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-laneige-cho-da-kho-50ml-1026.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Laneige.jpg?alt=media&token=bd50a06e-3645-4acf-b488-fb8cc8349dea" },
                    { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sữa Chống Nắng Anessa Perfect UV Sunscreen Skincare Milk N SPF50+ PA++++ Dưỡng Da Kiềm Dầu (Mới) là dòng sản phẩm chống nắng da mặt đến từ thương hiệu Anessa - Nhật Bản. Sản phẩm với công nghệ Auto Veil mới giúp cho lớp màng chống UV trở nên bền vững hơn khi gặp nhiệt độ cao, nước và ma sát.", false, null, null, 715000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Sữa Chống Nắng Anessa Dưỡng Da Kiềm Dầu 60ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-chong-nang-anessa-duong-da-kiem-dau-60ml-moi-119084.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqncntdErbsKUwqZ1ntRjnIi2tuJK8v-PTr8LUKmSCyVI-y_8aMZ80VsaAkPxEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Anessa%20Perfect%20UV%20Sunscreen%20Skincare%20Milk%20N.jpg?alt=media&token=c4371658-3aaf-45f4-9584-a8a24ca456bf" },
                    { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Kem Chống Nắng Hằng Ngày Kiehl's Ultra Light Daily UV Defense SPF50/PA++++ Anti-Pollution đóng vai trò vô cùng quan trọng trong việc bảo vệ và chăm sóc làn da trước tác hại của ánh nắng mặt trời cũng như tia UV gây hại cho da", false, null, null, 950000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Kem Chống Nắng Hằng Ngày Kiehl's SPF50/PA ++++ 30ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-chong-nang-hang-ngay-kiehl-s-spf50-pa-30ml-73170.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Kiehl's%20Ultra%20Light%20Daily%20UV%20Defense%20SPF.jpg?alt=media&token=bf69bece-dafc-4706-aa39-6172f0fa267a" },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chứa thành phần làm sạch gốc tự nhiên giúp sạch sâu bụi bẩn, bã nhờn và dưỡng da ẩm mịn.", false, null, null, 83000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Kem Rửa Mặt Hada Labo Sạch Sâu Dưỡng Ẩm 80g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-rua-mat-hada-labo-duong-am-toi-uu-80g-4359.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMId5JCuqnjMla9hkVGIMUrzwnpV_bVDm3yfaLjmKMnJj6yLlQ6Wq1RoCu10QAvD_BwE", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/hadalabo.png?alt=media&token=3804cc5d-10c7-4ff4-8a71-4ef665bc413c" },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nước hoa hồng Dear, Klairs Supple Preparation Facial Toner sản phẩm tối ưu trong việc làm sạch, cân bằng độ PH và dưỡng ẩm, có kết cấu dạng lỏng nhẹ, trong suốt và không màu, thẩm thấu nhanh chóng vào da. Kết hợp cùng mùi hương thảo mộc vô cùng dễ chịu, hoàn toàn không gây kích ứng hay cảm giác nhờn dính", false, null, null, 409000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Klairs Không Mùi Cho Da Nhạy Cảm 180ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-khong-mui-klairs-danh-cho-da-nhay-cam-180ml-65994.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMEJSpgovsMtCFQ3MpacrWVHnPjqQ3_KqAoJ_LWQS2Tnz8BNEfLazNxoCj4MQAvD_BwE", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2klairs-2.jpg?alt=media&token=d74a0e41-5ab2-40dc-b17c-610118bb4f24" },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Giúp da mềm mại, tránh cho da không bị mất nước, mang đến cảm giác thoải mái và cho làn da được thông thoáng, thư giãn.", false, null, null, 325000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Evoluderm Dành Cho Da Khô Và Nhạy Cảm 500ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-evoluderm-danh-cho-da-kho-va-nhay-cam-500ml-14949.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2tonique.jpg?alt=media&token=b9c6411d-cfec-44a5-bbfd-341f3697d725" },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nước Hoa Hồng Mamonde Rose Water Toner là dòng toner đến từ thương hiệu mỹ phẩm Mamonde của Hàn Quốc, với thành phần chứa 90,97% nước hoa hồng Damask thay vì nước thông thường giúp dưỡng ẩm sâu, cấp nước nhanh chóng, phục hồi làn da khô ráp, thiếu sức sống.", false, null, null, 360000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Toner Mamonde Dưỡng Ẩm, Dịu Nhẹ Da Nhạy Cảm 250ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-can-bang-mamonde-duong-am-diu-nhe-cho-da-nhay-cam-250ml-95787.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2mamonde2.jpg?alt=media&token=d6b5de2a-9ba2-4ed8-88f2-93d459bba634" },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sử dụng công nghệ Micellar giúp loại bỏ hiệu quả lớp trang điểm cùng bụi bẩn, bã nhờn sâu trong lỗ chân lông, mang lại làn da sạch thoáng mà không gây nhờn dính.", false, null, null, 180000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang Byphasse Cho Mọi Loại Da 500ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-byphasse-cho-moi-loai-da-500ml-3183.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Byphasse%20Solution%20Micellaire.jpg?alt=media&token=6037becc-f411-44cd-85e4-be7fd34f4ed5" },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Có hai lớp chất lỏng giúp hòa tan chất bẩn và loại bỏ toàn bộ lớp trang điểm hiệu quả, kể cả lớp trang điểm lâu trôi và không thấm nước chỉ trong một bước.", false, null, null, 269000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang L'Oreal Làm Sạch Sâu Trang Điểm 400ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-l-oreal-3-in-1-lam-sach-sau-400ml-34119.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/L'Or%C3%A9al%20Paris%20Micellar%20Water%203-in-1%20Moisturizing%20Even%20For%20Sensitive%20Skin.jpg?alt=media&token=a4dd0fe3-9c4f-4ae1-a88c-79deca96ce68" },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ngây, Nhân Sâm... giúp mang lại công dụng làm giảm mụn thâm, dưỡng ẩm, tẩy da chết, cân bằng độ pH cho da và là bước đệm hoàn hảo để các dưỡng chất thấm sâu vào da tốt nhất", false, null, null, 400000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Caryophy Ngừa Mụn Kiềm Dầu Giảm Thâm 300ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-cho-da-mun-caryophy-300ml-78140.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMFIk6UKxeIL3HRR1hvVcUaAjCJiMbyuE5tweE_JTxteiOnVqbvEaIRoCgGkQAvD_BwE", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2caryophy.png?alt=media&token=1f38576d-d99e-44a8-a625-94b23ecdada3" },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Công thức sản phẩm an toàn & lành tính, dịu nhẹ cho làn da nhạy cảm, với các chiết xuất thiên nhiên như Rau Sam, Rau Má và thành phần độc đáo Citric Acid giúp làm sạch da tối ưu và hỗ trợ kháng khuẩn, kháng viêm, ngăn ngừa mụn và làm dịu da, giải tỏa căng thẳng trên da.", false, null, null, 460000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang Caryophy Cho Da Dầu Mụn, Nhạy Cảm 500ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-caryophy-cho-da-dau-mun-nhay-cam-500ml-91531.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnc5cVVKaND4RQ-VF7ZpLe2tG3uH1mkEN-QQ8en7HkAakUuKQ3quz9saAogdEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Caryophy%20Smart%20Cleansing%20Water.jpg?alt=media&token=64c2e8fc-e893-45aa-bd86-0b592f309392" },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "kiểm soát sản xuất bã nhờn và cung cấp dinh dưỡng cho làn da, ngăn chặn tình trạng mất nước và lão hóa trên da.", false, null, null, 425000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Dầu Tẩy Trang Klairs Làm Sạch Sâu Cho Mọi Loại Da 150ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/dau-tay-trang-klairs-lam-sach-sau-cho-moi-loai-da-150ml-66046.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqneXiK5EtEZTGc8AreQnfD9DH2BaoDtu8cyOxWfBT2lWqrgD2Mqq4JoaAonLEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Klairs%20Gentle%20Black%20Deep%20Cleansing%20Oil.jpg?alt=media&token=605ebe34-80fa-4feb-8aa5-fa4468361e8a" },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Micelles thông minh giúp loại bỏ lớp trang điểm và bụi bẩn hiệu quả, làm thông thoáng lỗ chân lông, mang lại cảm giác tươi mát cho da sau khi sử dụng, đồng thời cấp ẩm lên đến 4 giờ mà không để lại dư lượng thừa trên da.", false, null, null, 189000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang Simple Làm Sạch Trang Điểm Vượt Trội 400ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-simple-lam-sach-trang-diem-va-cap-am-400ml-104259.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndbwfo5t-8uGNIEDk-WrXO8F2GSsjCT3GqN-MmQOs2iLV92I4XqnqoaAiTaEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Simple%20Micellar%20Cleansing%20Water.jpg?alt=media&token=3747c611-6b2f-4464-91e5-6de00f90fefb" },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Mang lại làn da sạch bóng và mịn màng sau khi rửa mặt, đồng thời hỗ trợ da hô hấp dễ dàng hơn, chuẩn bị tốt hơn cho giai đoạn tái tạo.", false, null, null, 408000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Gel Rửa Mặt Eucerin Làm Sạch Dịu Nhẹ Da Nhạy Cảm 200ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/gel-rua-mat-eucerin-tuoi-mat-cho-da-thuong-nhay-cam-200ml-89925.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/eucerin3.jpg?alt=media&token=3a6317da-f045-42d8-917b-825ea52c5fd8" }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
<<<<<<<< HEAD:CavisProject.Infrastructures/Migrations/20240622140350_initDb.cs
                columns: new[] { "ProductId", "SkinId" },
                values: new object[,]
                {
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") },
                    { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") },
                    { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") }
========
                columns: new[] { "ProductId", "SkinId", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("a960d28f-2807-4d58-8248-91eec518d415"), false },
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), false },
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), false },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), false },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), false },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("a960d28f-2807-4d58-8248-91eec518d415"), false },
                    { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), false },
                    { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), false },
                    { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), false },
                    { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), false },
                    { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), false },
                    { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), false },
                    { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), false },
                    { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), new Guid("a960d28f-2807-4d58-8248-91eec518d415"), false },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), false },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), false },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), false },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("a960d28f-2807-4d58-8248-91eec518d415"), false },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), false },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), false },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), false },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), false },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), false },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("a960d28f-2807-4d58-8248-91eec518d415"), false },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), false }
>>>>>>>> c7dab5f7314ceb89a864ec72ab499bcbfd63f2cb:CavisProject.Infrastructures/Migrations/20240623085732_inite.cs
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodDetails_SkinId",
                table: "MethodDetails",
                column: "SkinId");

            migrationBuilder.CreateIndex(
                name: "IX_Methods_UserId",
                table: "Methods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetails_PackagePremiumId",
                table: "PackageDetails",
                column: "PackagePremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAnalystDetails_PersonalAnalystId",
                table: "PersonalAnalystDetails",
                column: "PersonalAnalystId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAnalysts_UserId",
                table: "PersonalAnalysts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImages_UserId",
                table: "PersonalImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMethodDetails_MethodId",
                table: "PersonalMethodDetails",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_SkinId",
                table: "ProductDetails",
                column: "SkinId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppointmentId",
                table: "Transactions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PackagePremiumId",
                table: "Transactions",
                column: "PackagePremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "MethodDetails");

            migrationBuilder.DropTable(
                name: "PackageDetails");

            migrationBuilder.DropTable(
                name: "PersonalAnalystDetails");

            migrationBuilder.DropTable(
                name: "PersonalImages");

            migrationBuilder.DropTable(
                name: "PersonalMethodDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "PersonalAnalysts");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "PackagePremiums");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
