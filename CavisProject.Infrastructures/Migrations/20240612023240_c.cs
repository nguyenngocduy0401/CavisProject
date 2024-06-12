using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("0e65155b-7e30-4e5a-9ed7-462efa6e8709"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("14b8c3ba-fe79-4d38-b1b5-49b239393e79"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("537dcd5e-2fdf-42ba-bf7b-06d16ca13fd6"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("622c9d0f-b33c-4c62-b1ca-9b2d6820593f"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("69a871e5-533f-434b-8935-f5e6de0a0834"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("71e52141-bbf3-4278-b58e-8bc1f691397a"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("9855359c-5ae2-461b-8a0a-282c425c76b1"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a2fc474e-ab12-4ae9-adeb-3338d534f729"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("aa18a93b-c56a-4a7c-9e15-a2c332960899"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("ab30f0ad-efa9-4ecb-909b-a897f63d0318"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("b73287c9-d87f-4122-9003-0e2cb2f87656"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("c9eb7dae-05e1-4f39-99b9-b450e6491c95"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("ccc2421e-b9c5-4f63-ba87-dfe769090712"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("ec8728de-5411-45dc-b809-1d2fa817bd1c"));

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "SkinsName" },
                values: new object[,]
                {
                    { new Guid("09fb2796-31a7-4aa6-967a-c4aaadb2f2dd"), true, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3358), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("17c51d1e-da05-4e02-87d0-28e6c1ef8817"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3406), null, null, "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.", false, null, null, "Nếp nhăn" },
                    { new Guid("1d7f3d89-3fe1-4843-8f87-085d1c3ff4b3"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3400), null, null, "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.", false, null, null, "Mụn đầu đinh" },
                    { new Guid("1e928220-d1a5-43ab-b82e-ec38bcf6054e"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3394), null, null, "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.", false, null, null, "Mụn bọc" },
                    { new Guid("2d1fda4a-b1ad-4bd1-b749-2ffdd184497e"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3396), null, null, "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.", false, null, null, "Mụn mủ" },
                    { new Guid("36c2d7ad-b5b1-4e32-9315-4c28350757df"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3380), null, null, "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.", false, null, null, "Mụn đầu đen" },
                    { new Guid("4ca22d7d-75bf-4f4c-be66-704812ea9fa4"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3392), null, null, "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.", false, null, null, "Mụn đầu trắng" },
                    { new Guid("537bba9b-051b-4e77-9bd0-efd3598aba01"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3402), null, null, "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.", false, null, null, "Mụn thâm" },
                    { new Guid("5719d99f-bdc3-4d14-b8a0-06f998d3db37"), true, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3378), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("9eadb583-cd57-40a7-8488-1ab42a194bb3"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3404), null, null, "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.", false, null, null, "Nám da" },
                    { new Guid("ae9a44ee-8b16-4fa8-9038-f69cd0196b67"), false, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3398), null, null, "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", false, null, null, "Mụn viêm đỏ" },
                    { new Guid("cc78ec32-5566-4edb-af00-446b3393ef87"), true, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3376), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("d4b32cb8-626f-45fe-99cc-54244794b2c9"), true, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3374), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("dcbf3d90-a7e4-4bf2-b47e-3c07df00c4f3"), true, null, new DateTime(2024, 6, 12, 9, 32, 39, 952, DateTimeKind.Local).AddTicks(3371), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("09fb2796-31a7-4aa6-967a-c4aaadb2f2dd"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("17c51d1e-da05-4e02-87d0-28e6c1ef8817"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("1d7f3d89-3fe1-4843-8f87-085d1c3ff4b3"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("1e928220-d1a5-43ab-b82e-ec38bcf6054e"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("2d1fda4a-b1ad-4bd1-b749-2ffdd184497e"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("36c2d7ad-b5b1-4e32-9315-4c28350757df"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4ca22d7d-75bf-4f4c-be66-704812ea9fa4"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("537bba9b-051b-4e77-9bd0-efd3598aba01"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5719d99f-bdc3-4d14-b8a0-06f998d3db37"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("9eadb583-cd57-40a7-8488-1ab42a194bb3"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("ae9a44ee-8b16-4fa8-9038-f69cd0196b67"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("cc78ec32-5566-4edb-af00-446b3393ef87"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("d4b32cb8-626f-45fe-99cc-54244794b2c9"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("dcbf3d90-a7e4-4bf2-b47e-3c07df00c4f3"));

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "SkinsName" },
                values: new object[,]
                {
                    { new Guid("0e65155b-7e30-4e5a-9ed7-462efa6e8709"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5982), null, null, "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.", false, null, null, "Nếp nhăn" },
                    { new Guid("14b8c3ba-fe79-4d38-b1b5-49b239393e79"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5930), null, null, "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", false, null, null, "Mụn viêm đỏ" },
                    { new Guid("537dcd5e-2fdf-42ba-bf7b-06d16ca13fd6"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5922), null, null, "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.", false, null, null, "Mụn đầu đen" },
                    { new Guid("622c9d0f-b33c-4c62-b1ca-9b2d6820593f"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5977), null, null, "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.", false, null, null, "Nám da" },
                    { new Guid("69a871e5-533f-434b-8935-f5e6de0a0834"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5928), null, null, "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.", false, null, null, "Mụn mủ" },
                    { new Guid("71e52141-bbf3-4278-b58e-8bc1f691397a"), true, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5904), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("9855359c-5ae2-461b-8a0a-282c425c76b1"), true, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5902), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" },
                    { new Guid("a2fc474e-ab12-4ae9-adeb-3338d534f729"), true, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5890), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("aa18a93b-c56a-4a7c-9e15-a2c332960899"), true, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5906), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("ab30f0ad-efa9-4ecb-909b-a897f63d0318"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5926), null, null, "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.", false, null, null, "Mụn bọc" },
                    { new Guid("b73287c9-d87f-4122-9003-0e2cb2f87656"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5932), null, null, "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.", false, null, null, "Mụn đầu đinh" },
                    { new Guid("c9eb7dae-05e1-4f39-99b9-b450e6491c95"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5924), null, null, "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.", false, null, null, "Mụn đầu trắng" },
                    { new Guid("ccc2421e-b9c5-4f63-ba87-dfe769090712"), true, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5908), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("ec8728de-5411-45dc-b809-1d2fa817bd1c"), false, null, new DateTime(2024, 6, 12, 9, 27, 3, 702, DateTimeKind.Local).AddTicks(5975), null, null, "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.", false, null, null, "Mụn thâm" }
                });
        }
    }
}
