using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class updateDataV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DropColumn(
                name: "SkinTypeId",
                table: "MethodDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Methods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductId", "SkinId" },
                values: new object[,]
                {
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5") },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("4678f8d2-5648-4521-9608-8e981dee9103") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("bd287628-2eb7-458a-b202-d89d63faaebf") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("4678f8d2-5648-4521-9608-8e981dee9103") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("73766ff0-d528-4262-a1e8-656b33f58603") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("a9035561-1399-464f-9f09-38c164a40a63") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("bd287628-2eb7-458a-b202-d89d63faaebf") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("e8685143-0f2e-42fa-8025-da53e1707461") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a") }
                });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 22, 36, 44, 32, DateTimeKind.Local).AddTicks(4392));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("4678f8d2-5648-4521-9608-8e981dee9103") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("bd287628-2eb7-458a-b202-d89d63faaebf") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("4678f8d2-5648-4521-9608-8e981dee9103") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("73766ff0-d528-4262-a1e8-656b33f58603") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("a9035561-1399-464f-9f09-38c164a40a63") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("bd287628-2eb7-458a-b202-d89d63faaebf") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("e8685143-0f2e-42fa-8025-da53e1707461") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a") });

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Methods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SkinTypeId",
                table: "MethodDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductId", "SkinId" },
                values: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(7886));
        }
    }
}
