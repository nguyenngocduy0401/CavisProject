using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class addSkinTypeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "SkinsName" },
                values: new object[,]
                {
                    { new Guid("007f3ace-6e08-41f2-b2cb-26a0761bd2fe"), true, null, new DateTime(2024, 6, 5, 18, 49, 49, 324, DateTimeKind.Local).AddTicks(7018), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("87f45aea-3403-4269-8d66-1fd97defa8e4"), true, null, new DateTime(2024, 6, 5, 18, 49, 49, 324, DateTimeKind.Local).AddTicks(7013), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("9d50bae0-42d9-4e68-8d2d-843cbd3d500e"), true, null, new DateTime(2024, 6, 5, 18, 49, 49, 324, DateTimeKind.Local).AddTicks(6993), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("d6d833c6-038b-473e-ae3d-f6839e7745cc"), true, null, new DateTime(2024, 6, 5, 18, 49, 49, 324, DateTimeKind.Local).AddTicks(7015), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("f76114c0-4ec6-432c-82ea-d17fcfad1b76"), true, null, new DateTime(2024, 6, 5, 18, 49, 49, 324, DateTimeKind.Local).AddTicks(7011), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("007f3ace-6e08-41f2-b2cb-26a0761bd2fe"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("87f45aea-3403-4269-8d66-1fd97defa8e4"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("9d50bae0-42d9-4e68-8d2d-843cbd3d500e"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("d6d833c6-038b-473e-ae3d-f6839e7745cc"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f76114c0-4ec6-432c-82ea-d17fcfad1b76"));
        }
    }
}
