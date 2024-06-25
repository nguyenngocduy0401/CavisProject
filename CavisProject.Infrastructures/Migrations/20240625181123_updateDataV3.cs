using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class updateDataV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Methods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Url" },
                values: new object[] { new DateTime(2024, 6, 26, 1, 11, 23, 507, DateTimeKind.Local).AddTicks(8461), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21653406-6211-4f18-b661-a360b581b397"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e447a290-469c-47ab-b918-c9534556d112"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"),
                column: "Status",
                value: 1);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Methods");

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4536));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 24, 19, 53, 38, 111, DateTimeKind.Local).AddTicks(4564));
        }
    }
}
