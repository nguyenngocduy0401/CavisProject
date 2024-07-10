using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class updateDataV7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_Appointments_AppointmentId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_AspNetUsers_UserId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_AspNetUsers_UserId",
                table: "Calendars");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PackagePremiums_PackagePremiumId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentDetails",
                table: "AppointmentDetails");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDetails_AppointmentId",
                table: "AppointmentDetails");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Calendars");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppointmentDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "PackagePremiumId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Calendars",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Calendars",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentDetails",
                table: "AppointmentDetails",
                columns: new[] { "AppointmentId", "UserId" });

            migrationBuilder.CreateTable(
                name: "CalendarDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailabilityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarDetails_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Duration", "EndTime", "IsDeleted", "ModificationBy", "ModificationDate", "StartTime" },
                values: new object[,]
                {
                    { new Guid("5bd3814d-2306-4b91-9412-73512136fe04"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2.0, new TimeSpan(0, 13, 0, 0, 0), false, null, null, new TimeSpan(0, 11, 0, 0, 0) },
                    { new Guid("74816131-cac6-4bc3-b1e5-5ed31bda575e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2.0, new TimeSpan(0, 21, 0, 0, 0), false, null, null, new TimeSpan(0, 19, 0, 0, 0) },
                    { new Guid("e5795b99-a5ea-4ffe-a799-a097475872a4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2.0, new TimeSpan(0, 16, 0, 0, 0), false, null, null, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("fce513a4-01d5-47a8-9fd2-887381ff6a7d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2.0, new TimeSpan(0, 10, 0, 0, 0), false, null, null, new TimeSpan(0, 8, 0, 0, 0) },
                    { new Guid("ffc9fc78-faa7-4e37-b618-db6aff2efb5f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2.0, new TimeSpan(0, 18, 0, 0, 0), false, null, null, new TimeSpan(0, 16, 0, 0, 0) }
                });

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(4071), "<h4><strong><span style=\"font-size:18pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:12pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Tẩy trang:</span></strong><span style=\"font-size:12pt;\"> Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:12pt;\"> Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>" });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3254));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 11, 1, 36, 14, 536, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_UserId",
                table: "AppointmentDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDetails_CalendarId",
                table: "CalendarDetails",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarDetails_UserId",
                table: "CalendarDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_Appointments_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_AspNetUsers_UserId",
                table: "AppointmentDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PackagePremiums_PackagePremiumId",
                table: "Transactions",
                column: "PackagePremiumId",
                principalTable: "PackagePremiums",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_Appointments_AppointmentId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetails_AspNetUsers_UserId",
                table: "AppointmentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PackagePremiums_PackagePremiumId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "CalendarDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentDetails",
                table: "AppointmentDetails");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDetails_UserId",
                table: "AppointmentDetails");

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("5bd3814d-2306-4b91-9412-73512136fe04"));

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("74816131-cac6-4bc3-b1e5-5ed31bda575e"));

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("e5795b99-a5ea-4ffe-a799-a097475872a4"));

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("fce513a4-01d5-47a8-9fd2-887381ff6a7d"));

            migrationBuilder.DeleteData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: new Guid("ffc9fc78-faa7-4e37-b618-db6aff2efb5f"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Appointments");

            migrationBuilder.AlterColumn<Guid>(
                name: "PackagePremiumId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Calendars",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Calendars",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId",
                table: "Calendars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Calendars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppointmentDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentDetails",
                table: "AppointmentDetails",
                columns: new[] { "UserId", "AppointmentId" });

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2024, 7, 2, 4, 11, 43, 346, DateTimeKind.Local).AddTicks(2937), "<h4><strong><span style=\"font-size:18pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:18pt;\">Tẩy trang:</span></strong><span style=\"font-size:12pt;\">Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:22pt;\">Rửa mặt:</span></strong><span style=\"font-size:22pt;\">Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><strong><span style=\"font-size:22pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:22pt;\">Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:22pt;\">\r\n        <p><strong><span style=\"font-size:22pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:22pt;\">\r\n        <p><strong><span style=\"font-size:22pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:22pt;\">\r\n        <p><strong><span style=\"font-size:22pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:22pt;\">\r\n                <p><span style=\"font-size:22pt;\">Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>\r\n<div id=\"gtx-trans\" style=\"position: absolute; left: -58px; top: 43.5312px;\">\r\n    <div class=\"gtx-trans-icon\"><br></div>\r\n</div>\r\n" });

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
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_Appointments_AppointmentId",
                table: "AppointmentDetails",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetails_AspNetUsers_UserId",
                table: "AppointmentDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_AspNetUsers_UserId",
                table: "Calendars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PackagePremiums_PackagePremiumId",
                table: "Transactions",
                column: "PackagePremiumId",
                principalTable: "PackagePremiums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
