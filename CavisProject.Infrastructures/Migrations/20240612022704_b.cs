using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("0bf98cb3-0b12-4b0d-8adb-fc33334ea897"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("11cd4fde-5271-4236-9901-abe45403fa91"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("30a3267b-e5d8-4ebe-afa8-7a739428d08e"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4c314611-54ed-4c37-bbc0-fcaa173dfef6"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4c4669ac-b3fa-4e34-8356-80f0ea44d6a2"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("7f462a0d-f19b-4b23-aeca-b9866a343a2d"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("910f3a9d-de2e-433b-a75c-03dd34e094f2"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("95009608-400b-4a05-9bfc-6ab1644dae2e"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("ae9334b7-ba5c-4fec-b7aa-f5415f2c79ec"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("b0ccc886-7863-437f-a301-603adcd4b4a3"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bb395cb3-f2a5-4f4c-95b7-b3fca430aa52"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bc52cd75-9e6f-4e08-b6dd-3f921fd43678"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("d4488a6f-875f-44b7-b2f8-5d41f4d551c8"));

            migrationBuilder.DeleteData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("de312d75-449e-4f77-8992-eb039edc846b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AppointmentId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "AppointmentId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "SkinsName" },
                values: new object[,]
                {
                    { new Guid("0bf98cb3-0b12-4b0d-8adb-fc33334ea897"), true, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3906), null, null, "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", false, null, null, "Da thường" },
                    { new Guid("11cd4fde-5271-4236-9901-abe45403fa91"), true, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3932), null, null, "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", false, null, null, "Da nhạy cảm" },
                    { new Guid("30a3267b-e5d8-4ebe-afa8-7a739428d08e"), true, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3934), null, null, "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", false, null, null, "Da khô" },
                    { new Guid("4c314611-54ed-4c37-bbc0-fcaa173dfef6"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3953), null, null, "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.", false, null, null, "Nám da" },
                    { new Guid("4c4669ac-b3fa-4e34-8356-80f0ea44d6a2"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3945), null, null, "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", false, null, null, "Mụn viêm đỏ" },
                    { new Guid("7f462a0d-f19b-4b23-aeca-b9866a343a2d"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3939), null, null, "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.", false, null, null, "Mụn đầu trắng" },
                    { new Guid("910f3a9d-de2e-433b-a75c-03dd34e094f2"), true, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3935), null, null, "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.", false, null, null, "Da nhờn" },
                    { new Guid("95009608-400b-4a05-9bfc-6ab1644dae2e"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3937), null, null, "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.", false, null, null, "Mụn đầu đen" },
                    { new Guid("ae9334b7-ba5c-4fec-b7aa-f5415f2c79ec"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3941), null, null, "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.", false, null, null, "Mụn bọc" },
                    { new Guid("b0ccc886-7863-437f-a301-603adcd4b4a3"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3949), null, null, "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.", false, null, null, "Mụn đầu đinh" },
                    { new Guid("bb395cb3-f2a5-4f4c-95b7-b3fca430aa52"), true, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3919), null, null, "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", false, null, null, "Da hỗn hợp" },
                    { new Guid("bc52cd75-9e6f-4e08-b6dd-3f921fd43678"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3951), null, null, "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.", false, null, null, "Mụn thâm" },
                    { new Guid("d4488a6f-875f-44b7-b2f8-5d41f4d551c8"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3954), null, null, "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.", false, null, null, "Nếp nhăn" },
                    { new Guid("de312d75-449e-4f77-8992-eb039edc846b"), false, null, new DateTime(2024, 6, 12, 9, 1, 21, 882, DateTimeKind.Local).AddTicks(3943), null, null, "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.", false, null, null, "Mụn mủ" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Appointments_AppointmentId",
                table: "Transactions",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
