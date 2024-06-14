using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class newDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SkinTypeId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "SkinTypeId",
                table: "PersonalAnalystDetails");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                    { new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Kem dưỡng mặt" }
                });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 2, 23, 39, 224, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Email", "IsDeleted", "ModificationBy", "ModificationDate", "PhoneNumber", "Status", "SupplierName" },
                values: new object[] { new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), "71 Hoàng Hoa Thám, P.13, Q.Tân Bình, TP.HCM", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "hotro@hasaki.vn", false, null, null, "1800 6324", 1, "Hasaki" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("005eb795-d06e-4a1a-b828-87fb00b9e919"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("c45b4c4a-eefe-4295-8110-e9bed75273d9"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "SkinTypeId",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SkinTypeId",
                table: "PersonalAnalystDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4737));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4732));
        }
    }
}
