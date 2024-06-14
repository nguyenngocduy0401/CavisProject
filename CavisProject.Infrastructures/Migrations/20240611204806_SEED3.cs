using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class SEED3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductId", "SkinId" },
                values: new object[,]
                {
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") }
                });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2616));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("21653406-6211-4f18-b661-a360b581b397"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 20, 35, 740, DateTimeKind.Local).AddTicks(3921));
        }
    }
}
