using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class seed5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductId", "SkinId" },
                values: new object[,]
                {
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
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
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"),
                column: "Description",
                value: "Công thức với Niacinamide, Piroctone Olamine, hạt tẩy tế bào chết LHA siêu mịn và nước khoáng La Roche-Posay giúp làm sạch sâu lỗ chân lông, giảm sưng viêm và ngừa sự phát triển của vi khuẩn gây mụn, đồng thời giúp làm dịu và kích thích tái tạo tế bào bề mặt da, ngăn ngừa sự hình thành của các vết thâm sau mụn.");

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 38, 1, 354, DateTimeKind.Local).AddTicks(9168));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "ProductId", "SkinId" },
                keyValues: new object[] { new Guid("e447a290-469c-47ab-b918-c9534556d112"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"),
                column: "Description",
                value: "Công thức với Niacinamide, Piroctone Olamine, hạt tẩy tế bào chết LHA siêu mịn và nước khoáng La Roche-Posay giúp làm sạch sâu lỗ chân lông, giảm sưng viêm và ngừa sự phát triển của vi khuẩn gây mụn, đồng thời giúp làm dịu và kích thích tái tạo tế bào bề mặt da, ngăn ngừa sự hình thành của các vết thâm sau mụn.\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9576));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9570));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 14, 1, 15, 1, 437, DateTimeKind.Local).AddTicks(9557));
        }
    }
}
