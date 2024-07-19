using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CavisProject.Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabaseV9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Description", "URLImage" },
                values: new object[] { new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(8338), "<h4><strong><span style=\"font-size:18pt;\">Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FRua%20mat.jpg?alt=media&token=60771aeb-3651-43d6-8b66-efc06c3d0a90\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"1\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Tẩy trang:</span></strong><span style=\"font-size:12pt;\"> Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:12pt;\"> Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FToner.jpg?alt=media&token=b4b54349-af04-426b-9ca6-40de84e469df\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"2\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FDuong%20am.jpg?alt=media&token=ec79e546-1007-4b57-8de1-4bfab2739fa8\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"3\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FKem%20chong%20nang.jpg?alt=media&token=3558b83b-654a-4214-b978-7b464d06486c\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"4\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>", "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "Id", "Category", "CreatedBy", "CreationDate", "DeleteBy", "DeletionDate", "Description", "IsDeleted", "MethodName", "ModificationBy", "ModificationDate", "Status", "URLImage", "UserId" },
                values: new object[,]
                {
                    { new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), 0, null, new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(8342), null, null, "<h4><strong><span style=\"font-size:18pt;\">Chăm sóc da khô</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da khô là loại da dễ bị mất độ ẩm, dẫn đến tình trạng bong tróc và nứt nẻ. Nguyên nhân có thể do thời tiết, tiếp xúc với tia cực tím hoặc chăm sóc da không đúng cách. Việc chăm sóc da khô đòi hỏi sự cẩn thận và sử dụng các sản phẩm dưỡng ẩm phù hợp.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FRua%20mat.jpg?alt=media&token=60771aeb-3651-43d6-8b66-efc06c3d0a90&fbclid=IwZXh0bgNhZW0CMTAAAR0RcORzu8IGNY2-b22J9OfFj1hXsCU_3g9Cv64DjFU1Tmw5oWUZI6V9pT4_aem_lh8U1YiojUM35JK9vk8XUQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"1\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Sữa rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Chọn loại sữa rửa mặt nhẹ dịu, không chứa xà phòng, không bọt, không hương liệu. Sản phẩm nên có độ pH trung tính từ 5.5-6.5.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FToner.jpg?alt=media&token=b4b54349-af04-426b-9ca6-40de84e469df&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"2\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Chọn toner không chứa cồn và đặc biệt là bổ sung dưỡng ẩm cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FDuong%20am.jpg?alt=media&token=ec79e546-1007-4b57-8de1-4bfab2739fa8&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"3\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem dưỡng ẩm dạng kem chứa các thành phần như ceramide, glycerin, hyaluronic acid, dầu squalane để tạo lớp màng bảo vệ độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Nếu da vẫn bị khô bong tróc, dùng thêm các sản phẩm cấp ẩm hỗ trợ như toner, xịt khoáng, serum có chứa HA, panthenol, vitamin E, B3, B5.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FKem%20chong%20nang.jpg?alt=media&token=3558b83b-654a-4214-b978-7b464d06486c&fbclid=IwZXh0bgNhZW0CMTAAAR1IW-8V3PFxNhPaAO8r6uLc3jhH6TwXeg7fxXgf_9YdS7idq0cFPVUOPSE_aem__tVJ4IdpYb9JFazfEAkmqg\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"4\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem chống nắng dạng kem có chứa các thành phần cấp ẩm như hyaluronic acid và ceramides, tránh các sản phẩm chứa cồn hay paraben.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>", false, "Chăm sóc da khô", null, null, 0, "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2", "da8a7be0-e888-4201-8500-3c5b2dba7776" },
                    { new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), 0, null, new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(8344), null, null, "<h4><strong><span style=\"font-size:18pt;\">Chăm sóc da dầu</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da dầu là loại da dễ bị bóng nhờn và có lỗ chân lông to, dễ bị mụn. Chăm sóc da dầu cần chú trọng đến việc kiểm soát dầu thừa mà không làm khô da.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FRua%20mat.jpg?alt=media&token=60771aeb-3651-43d6-8b66-efc06c3d0a90&fbclid=IwZXh0bgNhZW0CMTAAAR0RcORzu8IGNY2-b22J9OfFj1hXsCU_3g9Cv64DjFU1Tmw5oWUZI6V9pT4_aem_lh8U1YiojUM35JK9vk8XUQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"1\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Sữa rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Chọn loại sữa rửa mặt dành cho da dầu, không tạo nhân mụn. Rửa mặt không quá 2 lần mỗi ngày để tránh kích thích tiết dầu.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FToner.jpg?alt=media&token=b4b54349-af04-426b-9ca6-40de84e469df&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"2\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng toner chứa các thành phần như salicylic acid, glycolic acid, lactic acid để kiểm soát dầu nhờn và làm sạch sâu.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FDuong%20am.jpg?alt=media&token=ec79e546-1007-4b57-8de1-4bfab2739fa8&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"3\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Chọn các sản phẩm dưỡng ẩm mỏng nhẹ, kiềm dầu và không tạo nhân mụn, chứa các thành phần như licochalcone A, dimethicone, dẫn xuất polymer, niacinamide.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FKem%20chong%20nang.jpg?alt=media&token=3558b83b-654a-4214-b978-7b464d06486c&fbclid=IwZXh0bgNhZW0CMTAAAR1IW-8V3PFxNhPaAO8r6uLc3jhH6TwXeg7fxXgf_9YdS7idq0cFPVUOPSE_aem__tVJ4IdpYb9JFazfEAkmqg\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"4\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem chống nắng dạng \"dry touch\" giúp kiềm dầu khô thoáng, có SPF từ 30 trở lên, không chứa chất tạo nhân mụn, tránh các dòng chống nắng hóa học đơn thuần.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>", false, "Chăm sóc da dầu", null, null, 0, "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2", "da8a7be0-e888-4201-8500-3c5b2dba7776" },
                    { new Guid("a960d28f-2807-4d58-8248-91eec518d415"), 0, null, new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(8349), null, null, "<h4><strong><span style=\"font-size:18pt;\">Chăm sóc da nhạy cảm</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da nhạy cảm dễ bị kích ứng bởi các yếu tố bên ngoài như mỹ phẩm, ánh nắng mặt trời, thời tiết khắc nghiệt. Chăm sóc da nhạy cảm cần sự nhẹ nhàng và cẩn thận trong việc chọn lựa sản phẩm.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FRua%20mat.jpg?alt=media&token=60771aeb-3651-43d6-8b66-efc06c3d0a90&fbclid=IwZXh0bgNhZW0CMTAAAR0RcORzu8IGNY2-b22J9OfFj1hXsCU_3g9Cv64DjFU1Tmw5oWUZI6V9pT4_aem_lh8U1YiojUM35JK9vk8XUQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"1\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Sữa rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Sử dụng lotion rửa mặt có thành phần lành tính, không chứa xà phòng. Tránh các sản phẩm có nhiều hương liệu và tính sát khuẩn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FToner.jpg?alt=media&token=b4b54349-af04-426b-9ca6-40de84e469df&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"2\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Chọn toner không chứa cồn và kem dưỡng không hương liệu. Nếu cần, có thể bỏ qua bước toner.\r\n</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FDuong%20am.jpg?alt=media&token=ec79e546-1007-4b57-8de1-4bfab2739fa8&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"3\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem dưỡng ẩm chứa ít hơn 10 thành phần, không chứa hương liệu, chất màu và chất bảo quản.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FKem%20chong%20nang.jpg?alt=media&token=3558b83b-654a-4214-b978-7b464d06486c&fbclid=IwZXh0bgNhZW0CMTAAAR1IW-8V3PFxNhPaAO8r6uLc3jhH6TwXeg7fxXgf_9YdS7idq0cFPVUOPSE_aem__tVJ4IdpYb9JFazfEAkmqg\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"4\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n      <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Chọn kem chống nắng vật lý chứa titanium dioxide hoặc zinc oxide để giảm nguy cơ kích ứng.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>\r\n", false, "Chăm sóc da nhạy cảm", null, null, 0, "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2", "da8a7be0-e888-4201-8500-3c5b2dba7776" },
                    { new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), 0, null, new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(8347), null, null, "<h4><strong><span style=\"font-size:18pt;\">Chăm sóc da hỗn hợp</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da hỗn hợp là loại da có vùng khô ở hai bên má và vùng dầu ở vùng chữ T (trán, mũi, cằm). Việc chăm sóc da hỗn hợp đòi hỏi sự cân bằng giữa việc cấp ẩm và kiểm soát dầu.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FRua%20mat.jpg?alt=media&token=60771aeb-3651-43d6-8b66-efc06c3d0a90&fbclid=IwZXh0bgNhZW0CMTAAAR0RcORzu8IGNY2-b22J9OfFj1hXsCU_3g9Cv64DjFU1Tmw5oWUZI6V9pT4_aem_lh8U1YiojUM35JK9vk8XUQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"1\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Sữa rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Đối với da hỗn hợp thiên khô, chọn sản phẩm tẩy rửa nhẹ nhàng, pH trung tính, có thể chứa AHA nhẹ. Đối với da hỗn hợp thiên dầu, chọn sữa rửa mặt dành cho da dầu, không tạo nhân mụn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FToner.jpg?alt=media&token=b4b54349-af04-426b-9ca6-40de84e469df&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"2\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Da hỗn hợp thiên khô: Chọn toner không chứa cồn, chứa các thành phần như HA, glycerin, chiết xuất hoa hồng, lô hội.</span></p>\r\n            </li>\r\n        </ul>\r\n      <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Da hỗn hợp thiên dầu: Chọn toner giúp làm sạch sâu và kiểm soát dầu nhờn với các thành phần như salicylic acid, glycolic acid, lactic acid.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FDuong%20am.jpg?alt=media&token=ec79e546-1007-4b57-8de1-4bfab2739fa8&fbclid=IwZXh0bgNhZW0CMTAAAR1PI55gsRpBN2OW2nI8lRI61HIJinqRHECklvY6cmTuyrw5pKJXoEAfETs_aem_cgyNYDoQABHELt4XJTnrWQ\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"3\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Da hỗn hợp thiên khô: Chọn sản phẩm dưỡng ẩm không chứa chất tạo nhân mụn, không bít tắc lỗ chân lông.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Da hỗn hợp thiên dầu: Chọn sản phẩm dưỡng ẩm dạng gel, không tạo nhân mụn, chứa các thành phần như licochalcone A, dimethicone, dẫn xuất polymer, niacinamide. Dùng thêm dầu dưỡng cho vùng bị khô vào buổi tối.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n  </ol>\r\n<ul style=\"list-style: none; padding-left: 0;\">\r\n    <li style=\"list-style-type: none; text-align: center; width: 100%;\">\r\n        <img src=\"https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da%20thuong%2FKem%20chong%20nang.jpg?alt=media&token=3558b83b-654a-4214-b978-7b464d06486c&fbclid=IwZXh0bgNhZW0CMTAAAR1IW-8V3PFxNhPaAO8r6uLc3jhH6TwXeg7fxXgf_9YdS7idq0cFPVUOPSE_aem__tVJ4IdpYb9JFazfEAkmqg\" width=\"300px\" height=\"200px\">\r\n    </li>\r\n</ul>\r\n<ol start=\"4\">\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Da hỗn hợp thiên khô: Sử dụng kem chống nắng dạng lotion hoặc cream, có SPF từ 30 trở lên, không chứa cồn hay paraben.</span></p>\r\n            </li>\r\n        </ul>\r\n      <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Da hỗn hợp thiên dầu: Sử dụng kem chống nắng dạng \"dry touch\" giúp kiềm dầu, có SPF từ 30 trở lên.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>", false, "Chăm sóc da hỗn hợp", null, null, 0, "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2", "da8a7be0-e888-4201-8500-3c5b2dba7776" }
                });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7762));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 17, 4, 27, 14, 846, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.InsertData(
                table: "MethodDetails",
                columns: new[] { "MethodId", "SkinId" },
                values: new object[,]
                {
                    { new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") },
                    { new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") },
                    { new Guid("a960d28f-2807-4d58-8248-91eec518d415"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") },
                    { new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MethodDetails",
                keyColumns: new[] { "MethodId", "SkinId" },
                keyValues: new object[] { new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"), new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6") });

            migrationBuilder.DeleteData(
                table: "MethodDetails",
                keyColumns: new[] { "MethodId", "SkinId" },
                keyValues: new object[] { new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"), new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81") });

            migrationBuilder.DeleteData(
                table: "MethodDetails",
                keyColumns: new[] { "MethodId", "SkinId" },
                keyValues: new object[] { new Guid("a960d28f-2807-4d58-8248-91eec518d415"), new Guid("a960d28f-2807-4d58-8248-91eec518d415") });

            migrationBuilder.DeleteData(
                table: "MethodDetails",
                keyColumns: new[] { "MethodId", "SkinId" },
                keyValues: new object[] { new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"), new Guid("be37023d-6a58-4b4b-92e5-39dcece45473") });

            migrationBuilder.DeleteData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"));

            migrationBuilder.DeleteData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"));

            migrationBuilder.DeleteData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"));

            migrationBuilder.DeleteData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"));

            migrationBuilder.UpdateData(
                table: "Methods",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                columns: new[] { "CreationDate", "Description", "URLImage" },
                values: new object[] { new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6756), "<h4><strong><span style=\"font-size:11pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:11pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Tẩy trang:</span></strong><span style=\"font-size:11pt;\">Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Rửa mặt:</span></strong><span style=\"font-size:11pt;\">Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:11pt;\">Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>\r\n<div id=\"gtx-trans\" style=\"position: absolute; left: -58px; top: 43.5312px;\">\r\n    <div class=\"gtx-trans-icon\"><br></div>\r\n</div>\r\n", null });

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("05ab75d8-622b-4bab-9543-ad10e441d7d6"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("4678f8d2-5648-4521-9608-8e981dee9103"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("550ee872-ea09-42a0-b9ac-809890debafb"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("5ab57d24-20ad-4b15-8427-c951419da3ba"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("73766ff0-d528-4262-a1e8-656b33f58603"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("8d9526b4-4532-4aff-8f69-379dbac8a55f"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("90a11b66-e89f-45ab-bfc4-b31101d0dd81"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a9035561-1399-464f-9f09-38c164a40a63"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6135));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("a960d28f-2807-4d58-8248-91eec518d415"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("bd287628-2eb7-458a-b202-d89d63faaebf"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("be37023d-6a58-4b4b-92e5-39dcece45473"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("e8685143-0f2e-42fa-8025-da53e1707461"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Skins",
                keyColumn: "Id",
                keyValue: new Guid("f49b6287-8f31-4fd5-9899-ed1eb6d0564a"),
                column: "CreationDate",
                value: new DateTime(2024, 7, 15, 22, 2, 2, 591, DateTimeKind.Local).AddTicks(6131));
        }
    }
}
