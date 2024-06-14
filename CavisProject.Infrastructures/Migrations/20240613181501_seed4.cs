using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class seed4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ClickMoney", "ClicksAmount", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "ModificationBy", "ModificationDate", "Price", "ProductCategoryId", "ProductName", "SupplierId", "TotalMoney", "URL", "URLImage" },
                values: new object[,]
                {
                    { new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "giúp thúc đẩy hệ thống duy trì độ ẩm ngay từ bên trong, để da luôn ẩm mịn, căng mượt và tràn đầy sức sống.", false, null, null, 590000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Ẩm Eucerin Dịu Nhẹ Cho Da Thường, Hỗn Hợp 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-eucerin-cho-da-thuong-den-da-hon-hop-50ml-68136.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqneRasEsTiW395OeWuFa_ZebB5tH1gDMjSIQjEO7EnM4IB3DUtnZINoaAggoEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Eucerin%20Lipo-Balance%20Intensive%20Nourishing%20Cream.jpg?alt=media&token=423592d5-ccc1-44cc-8d8d-27a3944d8952" },
                    { new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Da xỉn màu hiệu quả, cho làn da toả sáng rạng rỡ chỉ trong 28 ngày.", false, null, null, 270000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Olay Luminous Sáng Da Mờ Thâm Nám Ban Đêm 50g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-ban-dem-olay-lam-sang-da-mo-tham-nam-50g-87859.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndHWwtwmT9MaaMeaKHq6Ymco3tN1Wa0ytsHuzvR-rgK4l3PeomwccgaAiaREALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Olay.jpg?alt=media&token=8c757a0c-383d-4499-b3b8-7f3e2b48b719" },
                    { new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Kem Chống Nắng Chống Ô Nhiễm & Bụi Mịn Hằng Ngày Vichy Capital Soleil Mattifying 3in1 SPF50+ 50ml là sản phẩm chống nắng da mặt 3 trong 1 mới từ thương hiệu dược mỹ phẩm Vichy, được thiết kế dành cho da dầu mụn. ", false, null, null, 585000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Kem Chống Nắng Vichy Chống Bụi Mịn Cho Da Dầu Mụn 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-chong-nang-vichy-kiem-dau-spf50-50ml-88835.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnfcttLtt9diCT48iS-WDplNHtsBwy_Umy_EgQqc-rN_ia_0uYNCvT4aAlP1EALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Vichy%20Capital%20Soleil%20Mattifying.jpg?alt=media&token=64266959-9a96-4d6d-bb0e-9fe026cb969d" },
                    { new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "với công thức cũ, mang lại hiệu quả dưỡng ẩm sâu suốt 72 giờ, cho làn da căng bóng, sáng mịn và đàn hồi.", false, null, null, 389000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Ẩm Neutrogena Cấp Nước Cho Da Dầu 50g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-neutrogena-cung-cap-nuoc-cho-da-50g-90339.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndONELGoevx8Sn66b5Fl2QsToH_IahOd8gyeYIIKK-E271RuWnktCAaAvogEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Neutrogena%20Hydro%20Boost%20Water%20Gel.jpg?alt=media&token=6bdfef98-734c-4454-b201-f8bd93bea6e1" },
                    { new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "màng lọc chống nắng phổ rộng chống lại các tia UVA, UVB, IR (hồng ngoại), HEV (ánh sáng xanh). Sự kết hợp của Proteoglycans, phức hợp Spectrum Complex, phức hợp Hyaluronic Acid & Silicon Complex giúp giữ cho làn da trẻ trung, tươi tắn và đều màu. Kết cấu dạng cream-to-powder độc đáo mang lại cảm giác mượt mà, mỏng nhẹ tựa vô hình trên da.", false, null, null, 1350000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Kem Chống Nắng MartiDerm Phổ Rộng Bảo Vệ Toàn Diện", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-chong-nang-martiderm-pho-rong-toan-dien-spf50-40ml-90401.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnf0BPilz_8AKunYGCdgJi4LTr0XOYFCe5IumOshtzd6qwrtvxNm4P0aAtjXEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/MartiDerm%20The%20Originals%20Proteos%20Screen%20SPF50%2B%20Fluid%20Cream.jpg?alt=media&token=e92f624b-918d-4428-9cc8-3a0f18a27c96" },
                    { new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Màng chắn vi điểm mang đến hiệu quả chống nắng hoàn hảo mà không gây bết dính, ngăn tia UV tối ưu đồng thời tạo cảm giác siêu thoáng nhẹ trên da. Đặc biệt với kết cấu dạng essence màng nước trong suốt dễ dàng tán đều, thẩm thấu nhanh chóng, giúp tạo cảm giác tươi mát cùng làn da ẩm mịn mượt mà như lụa.", false, null, null, 195000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Essence Chống Nắng Bioré Màng Nước Dưỡng Ẩm Da 50g", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/essence-chong-nang-mang-nuoc-duong-am-biore-spf50-pa-50g-6408.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Biore%20UV%20Aqua%20Rich%20Watery%20Essence.jpg?alt=media&token=9f37b704-dda7-4941-b0bb-78a14b6f90d1" },
                    { new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Công thức với Niacinamide, Piroctone Olamine, hạt tẩy tế bào chết LHA siêu mịn và nước khoáng La Roche-Posay giúp làm sạch sâu lỗ chân lông, giảm sưng viêm và ngừa sự phát triển của vi khuẩn gây mụn, đồng thời giúp làm dịu và kích thích tái tạo tế bào bề mặt da, ngăn ngừa sự hình thành của các vết thâm sau mụn.\r\n\r\n", false, null, null, 610000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Giảm Mụn La Roche-Posay Dành Cho Mụn Sưng Đỏ 15ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-la-roche-posay-lam-giam-mun-chuyen-biet-15ml-1092.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndVhOh7KFY12qi3dIFnBPywwEf96mC1lZgd4WZqlyHGD6C95HwLIgAaArFpEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/La%20Roche-Posay%20Effacla.jpg?alt=media&token=b7a3c1b8-2882-4389-8b73-fd2090b43a35" },
                    { new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "với công thức cũ, mang lại hiệu quả dưỡng ẩm sâu suốt 72 giờ, cho làn da căng bóng, sáng mịn và đàn hồi.", false, null, null, 850000.0, new Guid("db5d4968-16f9-48c6-ab2b-feef85208d5a"), "Kem Dưỡng Ẩm Laneige Cấp Nước Cho Da Khô 50ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-duong-am-laneige-cho-da-kho-50ml-1026.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Laneige.jpg?alt=media&token=bd50a06e-3645-4acf-b488-fb8cc8349dea" },
                    { new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sữa Chống Nắng Anessa Perfect UV Sunscreen Skincare Milk N SPF50+ PA++++ Dưỡng Da Kiềm Dầu (Mới) là dòng sản phẩm chống nắng da mặt đến từ thương hiệu Anessa - Nhật Bản. Sản phẩm với công nghệ Auto Veil mới giúp cho lớp màng chống UV trở nên bền vững hơn khi gặp nhiệt độ cao, nước và ma sát.", false, null, null, 715000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Sữa Chống Nắng Anessa Dưỡng Da Kiềm Dầu 60ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/sua-chong-nang-anessa-duong-da-kiem-dau-60ml-moi-119084.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqncntdErbsKUwqZ1ntRjnIi2tuJK8v-PTr8LUKmSCyVI-y_8aMZ80VsaAkPxEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Anessa%20Perfect%20UV%20Sunscreen%20Skincare%20Milk%20N.jpg?alt=media&token=c4371658-3aaf-45f4-9584-a8a24ca456bf" },
                    { new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Kem Chống Nắng Hằng Ngày Kiehl's Ultra Light Daily UV Defense SPF50/PA++++ Anti-Pollution đóng vai trò vô cùng quan trọng trong việc bảo vệ và chăm sóc làn da trước tác hại của ánh nắng mặt trời cũng như tia UV gây hại cho da", false, null, null, 950000.0, new Guid("39201e62-9ce1-45cc-9625-ee52babc780d"), "Kem Chống Nắng Hằng Ngày Kiehl's SPF50/PA ++++ 30ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/kem-chong-nang-hang-ngay-kiehl-s-spf50-pa-30ml-73170.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Kiehl's%20Ultra%20Light%20Daily%20UV%20Defense%20SPF.jpg?alt=media&token=bf69bece-dafc-4706-aa39-6172f0fa267a" },
                    { new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sử dụng công nghệ Micellar giúp loại bỏ hiệu quả lớp trang điểm cùng bụi bẩn, bã nhờn sâu trong lỗ chân lông, mang lại làn da sạch thoáng mà không gây nhờn dính.", false, null, null, 180000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang Byphasse Cho Mọi Loại Da 500ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-byphasse-cho-moi-loai-da-500ml-3183.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Byphasse%20Solution%20Micellaire.jpg?alt=media&token=6037becc-f411-44cd-85e4-be7fd34f4ed5" },
                    { new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Có hai lớp chất lỏng giúp hòa tan chất bẩn và loại bỏ toàn bộ lớp trang điểm hiệu quả, kể cả lớp trang điểm lâu trôi và không thấm nước chỉ trong một bước.", false, null, null, 269000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang L'Oreal Làm Sạch Sâu Trang Điểm 400ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-l-oreal-3-in-1-lam-sach-sau-400ml-34119.html", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/L'Or%C3%A9al%20Paris%20Micellar%20Water%203-in-1%20Moisturizing%20Even%20For%20Sensitive%20Skin.jpg?alt=media&token=a4dd0fe3-9c4f-4ae1-a88c-79deca96ce68" },
                    { new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Công thức sản phẩm an toàn & lành tính, dịu nhẹ cho làn da nhạy cảm, với các chiết xuất thiên nhiên như Rau Sam, Rau Má và thành phần độc đáo Citric Acid giúp làm sạch da tối ưu và hỗ trợ kháng khuẩn, kháng viêm, ngăn ngừa mụn và làm dịu da, giải tỏa căng thẳng trên da.", false, null, null, 460000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang Caryophy Cho Da Dầu Mụn, Nhạy Cảm 500ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-caryophy-cho-da-dau-mun-nhay-cam-500ml-91531.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnc5cVVKaND4RQ-VF7ZpLe2tG3uH1mkEN-QQ8en7HkAakUuKQ3quz9saAogdEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Caryophy%20Smart%20Cleansing%20Water.jpg?alt=media&token=64c2e8fc-e893-45aa-bd86-0b592f309392" },
                    { new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "kiểm soát sản xuất bã nhờn và cung cấp dinh dưỡng cho làn da, ngăn chặn tình trạng mất nước và lão hóa trên da.", false, null, null, 425000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Dầu Tẩy Trang Klairs Làm Sạch Sâu Cho Mọi Loại Da 150ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/dau-tay-trang-klairs-lam-sach-sau-cho-moi-loai-da-150ml-66046.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqneXiK5EtEZTGc8AreQnfD9DH2BaoDtu8cyOxWfBT2lWqrgD2Mqq4JoaAonLEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Klairs%20Gentle%20Black%20Deep%20Cleansing%20Oil.jpg?alt=media&token=605ebe34-80fa-4feb-8aa5-fa4468361e8a" },
                    { new Guid("e447a290-469c-47ab-b918-c9534556d112"), 200.0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Micelles thông minh giúp loại bỏ lớp trang điểm và bụi bẩn hiệu quả, làm thông thoáng lỗ chân lông, mang lại cảm giác tươi mát cho da sau khi sử dụng, đồng thời cấp ẩm lên đến 4 giờ mà không để lại dư lượng thừa trên da.", false, null, null, 189000.0, new Guid("839dc6d7-4b15-479b-9e01-17b8d3303144"), "Nước Tẩy Trang Simple Làm Sạch Trang Điểm Vượt Trội 400ml", new Guid("8f78562c-4da1-4cf4-9100-22215c0b6530"), 0.0, "https://hasaki.vn/san-pham/nuoc-tay-trang-simple-lam-sach-trang-diem-va-cap-am-400ml-104259.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndbwfo5t-8uGNIEDk-WrXO8F2GSsjCT3GqN-MmQOs2iLV92I4XqnqoaAiTaEALw_wcB", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Simple%20Micellar%20Cleansing%20Water.jpg?alt=media&token=3747c611-6b2f-4464-91e5-6de00f90fefb" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49ff65f1-31c9-485d-89f7-7a2dea6ce649"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b01742a-26fa-4799-92cb-8cf936fda356"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4df06bb4-f45a-42d5-becd-98b2e834c765"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d759056-6bc2-49df-997b-bfb173c2dc19"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7201eaec-e23f-4c3a-a575-7aad1cbab460"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73ca3caf-e6bf-44c4-9441-7d90c77de17a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4457bba-0aa8-4443-9619-d3dab29aa196"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bee3860c-9eaa-4e7b-878b-90a15b9defa2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dad66471-6992-4588-a77d-ab3802ee59f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e447a290-469c-47ab-b918-c9534556d112"));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 12, 3, 48, 6, 279, DateTimeKind.Local).AddTicks(2616));
        }
    }
}
