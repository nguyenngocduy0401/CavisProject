using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class newDataSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URLImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"),
                column: "ProductCategoryName",
                value: "Kem dưỡng ngày");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ClickMoney", "ClicksAmount", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "Price", "ProductCategoryId", "ProductName", "SupplierId", "TotalMoney", "URL", "URLImage" },
                values: new object[,]
                {
                    { new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nước Hoa Hồng Thayers với thành phần không chứa cồn (alcohol-free) và công thức độc quyền kết hợp giữa chiết xuất Lô Hội (Aloe Vera) & chiết xuất cây Phỉ (Witch Hazel) không chưng cất sẽ giúp nhẹ nhàng làm sạch da, cân bằng độ pH và dưỡng ẩm, mang lại vẻ sáng mịn tự nhiên và khỏe mạnh cho làn da của bạn.", false, null, null, 264000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Thayers Không Cồn Hương Hoa Hồng 355ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-khong-con-thayers-huong-hoa-hong-355ml-3227.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2thayers.png?alt=media&token=6d12bf7b-6a41-4cdc-bddf-1ccb677f4d93" },
                    { new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sản phẩm là sự kết hợp hoàn hảo của ceramide và hyaluronic acid, giúp nhẹ nhàng loại bỏ hết dầu thừa, bụi bẩn và các lớp trang điểm mà không làm khô da, cho da mềm mại, mịn màng hơn. Thành phần ceramide có tác dụng cải thiện rõ nét sắc diện và độ sáng trong của làn da. Nó ngay lập tức mang đến làn da mịn màng, mềm mại, tăng cường lượng collagen tự nhiên trong da, cho làn da săn chắc. Ngoài ra, ceramide còn giúp làm giảm các nếp nhăn sâu, xóa các nếp nhăn mờ nông, cho bề mặt da láng mượt, săn chắc.", false, null, null, 638000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Sữa Rửa Mặt Paula’s Choice Cân Bằng Độ Ẩm Da 190ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-rua-mat-paula-s-choice-can-bang-da-190ml-2329.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/paula.jpg?alt=media&token=25b6781b-fb55-4cc6-999d-1944d6533418" },
                    { new Guid("21653406-6211-4f18-b661-a360b581b397"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Giúp làm sạch sâu, se khít lỗ chân lông và kiềm dầu hiệu quả mà không làm khô da. Sản phẩm là sự lựa chọn tối ưu dành cho làn da dầu mụn và nhạy cảm, giúp mang lại làn da sạch thoáng, thanh khiết, không còn nỗi lo về mụn và lỗ chân lông được thu nhỏ.", false, null, null, 140000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Sữa Rửa Mặt Vichy Dạng Gel Làm Sạch Sâu Da Dầu Mụn 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-rua-mat-dang-gel-vichy-lam-sach-sau-cho-da-nhon-mun-50ml-80971.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/vichy.png?alt=media&token=4fbad0f6-a839-43dd-b704-4864cc3e9ba6" },
                    { new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sữa Rửa Mặt Skin1004 Làm Sạch Sâu Cho Da Nhạy Cảm 125ml từ thương hiệu mỹ phẩm Skin1004 của Hàn Quốc là dạng sữa rửa mặt tạo bọt chứa chiết xuất rau má giúp làm sạch da ngăn ngừa mụn và hỗ trợ điều trị mụn. Chứa thành phần tự nhiên dịu nhẹ cho da nên sữa rửa mặt không làm khô da mà còn giữ ẩm cho da. ", false, null, null, 375000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Sữa Rửa Mặt Skin1004 Làm Sạch Sâu Cho Da Nhạy Cảm 125ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-rua-mat-chiet-xuat-rau-ma-skin1004-diu-nhe-lam-sach-sau-da-125ml-86169.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/centella3.png?alt=media&token=49d34368-8e90-4165-baca-a774cc354262" },
                    { new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Chứa thành phần làm sạch gốc tự nhiên giúp sạch sâu bụi bẩn, bã nhờn và dưỡng da ẩm mịn.", false, null, null, 83000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Kem Rửa Mặt Hada Labo Sạch Sâu Dưỡng Ẩm 80g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-rua-mat-hada-labo-duong-am-toi-uu-80g-4359.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMId5JCuqnjMla9hkVGIMUrzwnpV_bVDm3yfaLjmKMnJj6yLlQ6Wq1RoCu10QAvD_BwE", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/hadalabo.png?alt=media&token=3804cc5d-10c7-4ff4-8a71-4ef665bc413c" },
                    { new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nước hoa hồng Dear, Klairs Supple Preparation Facial Toner sản phẩm tối ưu trong việc làm sạch, cân bằng độ PH và dưỡng ẩm, có kết cấu dạng lỏng nhẹ, trong suốt và không màu, thẩm thấu nhanh chóng vào da. Kết hợp cùng mùi hương thảo mộc vô cùng dễ chịu, hoàn toàn không gây kích ứng hay cảm giác nhờn dính", false, null, null, 409000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Klairs Không Mùi Cho Da Nhạy Cảm 180ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-khong-mui-klairs-danh-cho-da-nhay-cam-180ml-65994.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMEJSpgovsMtCFQ3MpacrWVHnPjqQ3_KqAoJ_LWQS2Tnz8BNEfLazNxoCj4MQAvD_BwE", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2klairs-2.jpg?alt=media&token=d74a0e41-5ab2-40dc-b17c-610118bb4f24" },
                    { new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Giúp da mềm mại, tránh cho da không bị mất nước, mang đến cảm giác thoải mái và cho làn da được thông thoáng, thư giãn.", false, null, null, 325000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Evoluderm Dành Cho Da Khô Và Nhạy Cảm 500ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-evoluderm-danh-cho-da-kho-va-nhay-cam-500ml-14949.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2tonique.jpg?alt=media&token=b9c6411d-cfec-44a5-bbfd-341f3697d725" },
                    { new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Nước Hoa Hồng Mamonde Rose Water Toner là dòng toner đến từ thương hiệu mỹ phẩm Mamonde của Hàn Quốc, với thành phần chứa 90,97% nước hoa hồng Damask thay vì nước thông thường giúp dưỡng ẩm sâu, cấp nước nhanh chóng, phục hồi làn da khô ráp, thiếu sức sống.", false, null, null, 360000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Toner Mamonde Dưỡng Ẩm, Dịu Nhẹ Da Nhạy Cảm 250ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-can-bang-mamonde-duong-am-diu-nhe-cho-da-nhay-cam-250ml-95787.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2mamonde2.jpg?alt=media&token=d6b5de2a-9ba2-4ed8-88f2-93d459bba634" },
                    { new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Ngây, Nhân Sâm... giúp mang lại công dụng làm giảm mụn thâm, dưỡng ẩm, tẩy da chết, cân bằng độ pH cho da và là bước đệm hoàn hảo để các dưỡng chất thấm sâu vào da tốt nhất", false, null, null, 400000.0, new Guid("30e2e877-861b-4ae5-8a6b-b2e93a79175e"), "Nước Hoa Hồng Caryophy Ngừa Mụn Kiềm Dầu Giảm Thâm 300ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-hoa-hong-cho-da-mun-caryophy-300ml-78140.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMFIk6UKxeIL3HRR1hvVcUaAjCJiMbyuE5tweE_JTxteiOnVqbvEaIRoCgGkQAvD_BwE", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2caryophy.png?alt=media&token=1f38576d-d99e-44a8-a625-94b23ecdada3" },
                    { new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Mang lại làn da sạch bóng và mịn màng sau khi rửa mặt, đồng thời hỗ trợ da hô hấp dễ dàng hơn, chuẩn bị tốt hơn cho giai đoạn tái tạo.", false, null, null, 408000.0, new Guid("5e500a0f-e114-4f88-95d1-f1b12fba0654"), "Gel Rửa Mặt Eucerin Làm Sạch Dịu Nhẹ Da Nhạy Cảm 200ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/gel-rua-mat-eucerin-tuoi-mat-cho-da-thuong-nhay-cam-200ml-89925.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/eucerin3.jpg?alt=media&token=3a6317da-f045-42d8-917b-825ea52c5fd8" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e5cce09-cd4b-4681-a56f-56b4c2baec7c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("179f7f08-41a7-48c4-a389-0584aaa49ed9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21653406-6211-4f18-b661-a360b581b397"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44231b57-5715-46e3-bf7b-8fb891b73ccb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83aff4ac-c495-4582-8877-1d2fc83eb9cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("85af885a-abb5-454f-8ad8-d15147bba22e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("87092517-b5ca-4794-8a9f-33cb8ab2cbfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("897ab50d-ebe3-4869-a1b4-d2d7f288fc45"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aaa3964a-2eb1-4e95-9fe2-ce972a357bd7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef3342b3-e716-4028-b508-f29a1ec87865"));

            migrationBuilder.DropColumn(
                name: "URLImage",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"),
                column: "ProductCategoryName",
                value: "Kem dưỡng mặt");

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
        }
    }
}
