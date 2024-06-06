using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class fixSkinEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodDetails_SkinTypes_SkinTypeId",
                table: "MethodDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalAnalystDetails_SkinTypes_SkinTypeId",
                table: "PersonalAnalystDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_SkinTypes_SkinTypeId",
                table: "ProductDetails");

            migrationBuilder.DropTable(
                name: "SkinTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_SkinTypeId",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalAnalystDetails",
                table: "PersonalAnalystDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MethodDetails",
                table: "MethodDetails");

            migrationBuilder.DropIndex(
                name: "IX_MethodDetails_SkinTypeId",
                table: "MethodDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkinTypeId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SkinId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SkinTypeId",
                table: "PersonalAnalystDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SkinId",
                table: "PersonalAnalystDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SkinTypeId",
                table: "MethodDetails",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SkinId",
                table: "MethodDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                columns: new[] { "ProductId", "SkinId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalAnalystDetails",
                table: "PersonalAnalystDetails",
                columns: new[] { "SkinId", "PersonalAnalystId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MethodDetails",
                table: "MethodDetails",
                columns: new[] { "MethodId", "SkinId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_SkinId",
                table: "ProductDetails",
                column: "SkinId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodDetails_SkinId",
                table: "MethodDetails",
                column: "SkinId");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodDetails_Skins_SkinId",
                table: "MethodDetails",
                column: "SkinId",
                principalTable: "Skins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalAnalystDetails_Skins_SkinId",
                table: "PersonalAnalystDetails",
                column: "SkinId",
                principalTable: "Skins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Skins_SkinId",
                table: "ProductDetails",
                column: "SkinId",
                principalTable: "Skins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodDetails_Skins_SkinId",
                table: "MethodDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalAnalystDetails_Skins_SkinId",
                table: "PersonalAnalystDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Skins_SkinId",
                table: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_SkinId",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalAnalystDetails",
                table: "PersonalAnalystDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MethodDetails",
                table: "MethodDetails");

            migrationBuilder.DropIndex(
                name: "IX_MethodDetails_SkinId",
                table: "MethodDetails");

            migrationBuilder.DropColumn(
                name: "SkinId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SkinId",
                table: "PersonalAnalystDetails");

            migrationBuilder.DropColumn(
                name: "SkinId",
                table: "MethodDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkinTypeId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SkinTypeId",
                table: "PersonalAnalystDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SkinTypeId",
                table: "MethodDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                columns: new[] { "ProductId", "SkinTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalAnalystDetails",
                table: "PersonalAnalystDetails",
                columns: new[] { "SkinTypeId", "PersonalAnalystId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MethodDetails",
                table: "MethodDetails",
                columns: new[] { "MethodId", "SkinTypeId" });

            migrationBuilder.CreateTable(
                name: "SkinTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SkinTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_SkinTypeId",
                table: "ProductDetails",
                column: "SkinTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MethodDetails_SkinTypeId",
                table: "MethodDetails",
                column: "SkinTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodDetails_SkinTypes_SkinTypeId",
                table: "MethodDetails",
                column: "SkinTypeId",
                principalTable: "SkinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalAnalystDetails_SkinTypes_SkinTypeId",
                table: "PersonalAnalystDetails",
                column: "SkinTypeId",
                principalTable: "SkinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_SkinTypes_SkinTypeId",
                table: "ProductDetails",
                column: "SkinTypeId",
                principalTable: "SkinTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
