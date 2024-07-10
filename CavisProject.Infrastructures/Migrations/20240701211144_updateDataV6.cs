using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class updateDataV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkincareRoutines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Morning = table.Column<bool>(type: "bit", nullable: false),
                    Night = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_SkincareRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkincareRoutines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MethodDetails",
                columns: new[] { "MethodId", "SkinId" },
                values: new object[] { new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Description", "URLImage" },
                values: new object[] { new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2937), "<h4><strong><span style=\"font-size:18pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:18pt;\">Tẩy trang:</span></strong><span style=\"font-size:12pt;\">Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:22pt;\">Rửa mặt:</span></strong><span style=\"font-size:22pt;\">Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><strong><span style=\"font-size:22pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:22pt;\">Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:22pt;\">\r\n        <p><strong><span style=\"font-size:22pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:22pt;\">\r\n        <p><strong><span style=\"font-size:22pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:22pt;\">\r\n        <p><strong><span style=\"font-size:22pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>\r\n<div id=\"gtx-trans\" style=\"position: absolute; left: -58px; top: 43.5312px;\">\r\n    <div class=\"gtx-trans-icon\"><br></div>\r\n</div>\r\n", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "IsDeleted", "ModificationBy", "ModificationDate", "ProductCategoryName" },
                values: new object[,]
                {
                    { new Guid("786b79fb-576a-4999-bf57-ce5ff3792ef6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Cushion" },
                    { new Guid("9dba7949-edd0-469a-9ee2-225a864ede5b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Kem lót" },
                    { new Guid("d7114e75-445e-411f-85cc-c2ad4b0ca65c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Kem nền" },
                    { new Guid("f301d7ab-8c96-4f4b-8b34-5bd8bd2f3798"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "Phấn má" }
                });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.CreateIndex(
                name: "IX_SkincareRoutines_UserId",
                table: "SkincareRoutines",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkincareRoutines");

            migrationBuilder.DeleteData(
                table: "MethodDetails",
                keyColumns: new[] { "MethodId", "SkinId" },
                keyValues: new object[] { new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), new Guid("550ee872-ea09-42a0-b9ac-809890debafb") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("786b79fb-576a-4999-bf57-ce5ff3792ef6"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("9dba7949-edd0-469a-9ee2-225a864ede5b"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("d7114e75-445e-411f-85cc-c2ad4b0ca65c"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("f301d7ab-8c96-4f4b-8b34-5bd8bd2f3798"));

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Description", "URLImage" },
                values: new object[] { new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(4049), "<h4><strong><span style=\"font-size:11pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:11pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Tẩy trang:</span></strong><span style=\"font-size:11pt;\">Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Rửa mặt:</span></strong><span style=\"font-size:11pt;\">Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:11pt;\">Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>\r\n<div id=\"gtx-trans\" style=\"position: absolute; left: -58px; top: 43.5312px;\">\r\n    <div class=\"gtx-trans-icon\"><br></div>\r\n</div>\r\n", null });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3248));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3316));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3312));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3301));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3334));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 28, 2, 52, 15, 865, DateTimeKind.Local).AddTicks(3329));
        }
    }
}
