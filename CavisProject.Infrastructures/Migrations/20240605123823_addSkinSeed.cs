using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class addSkinSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "SkinsName" },
                values: new object[,]
                {
                    { new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), true, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4697), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4730), null, null, "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", false, null, null, "Mụn viêm đỏ" },
                    { new Guid("4678f8d2-5648-4521-9608-8e981dee9103"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4737), null, null, "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.", false, null, null, "Nếp nhăn" },
                    { new Guid("550ee872-ea09-42a0-b9ac-809890debafb"), true, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4659), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4726), null, null, "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.", false, null, null, "Mụn bọc" },
                    { new Guid("73766ff0-d528-4262-a1e8-656b33f58603"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4724), null, null, "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.", false, null, null, "Mụn đầu trắng" },
                    { new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4735), null, null, "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.", false, null, null, "Nám da" },
                    { new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), true, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4700), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("a9035561-1399-464f-9f09-38c164a40a63"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4734), null, null, "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.", false, null, null, "Mụn thâm" },
                    { new Guid("a960d28f-2807-4d58-8248-91eec518d415"), true, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4693), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4728), null, null, "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.", false, null, null, "Mụn mủ" },
                    { new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), true, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4690), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" },
                    { new Guid("e8685143-0f2e-42fa-8025-da53e1707461"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4702), null, null, "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.", false, null, null, "Mụn đầu đen" },
                    { new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"), false, null, new DateTime(2024, 6, 5, 19, 38, 23, 481, DateTimeKind.Local).AddTicks(4732), null, null, "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.", false, null, null, "Mụn đầu đinh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"));

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
    }
}
