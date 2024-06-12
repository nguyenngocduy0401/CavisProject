using CavisProject.Domain.Entity;
using CavisProject.Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region Dbset
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Method> Methods { get; set; }
        public DbSet<MethodDetail> MethodDetails { get; set; }
        public DbSet<PackageDetail> PackageDetails { get; set; }
        public DbSet<PackagePremium> PackagePremiums { get; set; }
        public DbSet<PersonalAnalyst> PersonalAnalysts { get; set; }
        public DbSet<PersonalAnalystDetail> PersonalAnalystDetails { get; set; }
        public DbSet<PersonalImage> PersonalImages { get; set; }
        public DbSet<PersonalMethodDetail> PersonalMethodDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MethodDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PackageDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalAnalystDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalMethodDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDetailConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WishListConfiguration).Assembly);
            #region SeedSkin
            modelBuilder.Entity<Skin>().HasData(
                new Skin
                {
                    Id = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                    SkinsName = "Da thường",
                    Description = "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.Parse("BE37023D-6A58-4B4B-92E5-39DCECE45473"),
                    SkinsName = "Da hỗn hợp",
                    Description = "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.Parse("A960D28F-2807-4D58-8248-91EEC518D415"),
                    SkinsName = "Da nhạy cảm",
                    Description = "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                    SkinsName = "Da khô",
                    Description = "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                    SkinsName = "Da nhờn",
                    Description = "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.Parse("E8685143-0F2E-42FA-8025-DA53E1707461"),
                    SkinsName = "Mụn đầu đen", 
                    Description = "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.Parse("73766FF0-D528-4262-A1E8-656B33F58603"),
                    SkinsName = "Mụn đầu trắng", 
                    Description = "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.Parse("5AB57D24-20AD-4B15-8427-C951419DA3BA"),
                    SkinsName = "Mụn bọc",
                    Description = "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.Parse("BD287628-2EB7-458A-B202-D89D63FAAEBF"), 
                    SkinsName = "Mụn mủ", 
                    Description = "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin {Id = Guid.Parse("12774B27-0E13-4F82-87D0-BFD6BD23E6E5"),
                    SkinsName = "Mụn viêm đỏ",
                    Description = "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", 
                    Category = false,
                    CreationDate = DateTime.Now },
                new Skin { Id = Guid.Parse("F49B6287-8F31-4FD5-9899-ED1EB6D0564A"), 
                    SkinsName = "Mụn đầu đinh",
                    Description = "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.Parse("A9035561-1399-464F-9F09-38C164A40A63"), 
                    SkinsName = "Mụn thâm",
                    Description = "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                    SkinsName = "Nám da",
                    Description = "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.Parse("4678F8D2-5648-4521-9608-8E981DEE9103"),
                    SkinsName = "Nếp nhăn",
                    Description = "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.",
                    Category = false,
                    CreationDate = DateTime.Now
                }
            );
            #endregion 
            #region SeedProductCategory
            modelBuilder.Entity<ProductCategory>().HasData(
                 new ProductCategory
                 {
                    Id = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654"),
                    ProductCategoryName = "Sữa rửa mặt",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E"),
                     ProductCategoryName = "Toner",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("DB5D4968-16F9-48C6-AB2B-FEEF85208D5A"),
                     ProductCategoryName = "Kem dưỡng ngày",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("39201E62-9CE1-45CC-9625-EE52BABC780D"),
                     ProductCategoryName = "Kem chống nắng",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("839DC6D7-4B15-479B-9E01-17B8D3303144"),
                     ProductCategoryName = "Nước tẩy trang",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("C45B4C4A-EEFE-4295-8110-E9BED75273D9"),
                     ProductCategoryName = "Serum",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("005EB795-D06E-4A1A-B828-87FB00B9E919"),
                     ProductCategoryName = "Kem dưỡng đêm",
                 }
                );
            #endregion
            #region SeedSupplier
            modelBuilder.Entity<Supplier>().HasData(
                 new Supplier
                 {
                     Id = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     SupplierName = "Hasaki",
                     PhoneNumber = "1800 6324",
                     Email = "hotro@hasaki.vn",
                     Status = 1,
                     Address = "71 Hoàng Hoa Thám, P.13, Q.Tân Bình, TP.HCM"
                 }
                );
            #endregion
            #region SeedProduct
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id= Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                     ProductName = "Sữa Rửa Mặt Paula’s Choice Cân Bằng Độ Ẩm Da 190ml",
                     ClickMoney = 200,
                     Price = 638000,
                     Description = "Sản phẩm là sự kết hợp hoàn hảo của ceramide và hyaluronic acid, giúp nhẹ nhàng loại bỏ hết dầu thừa, bụi bẩn và các lớp trang điểm mà không làm khô da, cho da mềm mại, mịn màng hơn. Thành phần ceramide có tác dụng cải thiện rõ nét sắc diện và độ sáng trong của làn da. Nó ngay lập tức mang đến làn da mịn màng, mềm mại, tăng cường lượng collagen tự nhiên trong da, cho làn da săn chắc. Ngoài ra, ceramide còn giúp làm giảm các nếp nhăn sâu, xóa các nếp nhăn mờ nông, cho bề mặt da láng mượt, săn chắc.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/paula.jpg?alt=media&token=25b6781b-fb55-4cc6-999d-1944d6533418",
                     URL = "https://hasaki.vn/san-pham/sua-rua-mat-paula-s-choice-can-bang-da-190ml-2329.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654")
                 },
                 new Product
                 {
                     Id = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                     ProductName = "Kem Rửa Mặt Hada Labo Sạch Sâu Dưỡng Ẩm 80g",
                     ClickMoney = 200,
                     Price = 83000,
                     Description = "Chứa thành phần làm sạch gốc tự nhiên giúp sạch sâu bụi bẩn, bã nhờn và dưỡng da ẩm mịn.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/hadalabo.png?alt=media&token=3804cc5d-10c7-4ff4-8a71-4ef665bc413c",
                     URL = "https://hasaki.vn/san-pham/kem-rua-mat-hada-labo-duong-am-toi-uu-80g-4359.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMId5JCuqnjMla9hkVGIMUrzwnpV_bVDm3yfaLjmKMnJj6yLlQ6Wq1RoCu10QAvD_BwE",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654")
                 },
                 new Product
                 {
                     Id = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                     ProductName = "Sữa Rửa Mặt Vichy Dạng Gel Làm Sạch Sâu Da Dầu Mụn 50ml",
                     ClickMoney = 200,
                     Price = 140000,
                     Description = "Giúp làm sạch sâu, se khít lỗ chân lông và kiềm dầu hiệu quả mà không làm khô da. Sản phẩm là sự lựa chọn tối ưu dành cho làn da dầu mụn và nhạy cảm, giúp mang lại làn da sạch thoáng, thanh khiết, không còn nỗi lo về mụn và lỗ chân lông được thu nhỏ.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/vichy.png?alt=media&token=4fbad0f6-a839-43dd-b704-4864cc3e9ba6",
                     URL = "https://hasaki.vn/san-pham/sua-rua-mat-dang-gel-vichy-lam-sach-sau-cho-da-nhon-mun-50ml-80971.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("EF3342B3-E716-4028-B508-F29A1EC87865"),
                     ProductName = "Gel Rửa Mặt Eucerin Làm Sạch Dịu Nhẹ Da Nhạy Cảm 200ml",
                     ClickMoney = 200,
                     Price = 408000,
                     Description = "Mang lại làn da sạch bóng và mịn màng sau khi rửa mặt, đồng thời hỗ trợ da hô hấp dễ dàng hơn, chuẩn bị tốt hơn cho giai đoạn tái tạo.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/eucerin3.jpg?alt=media&token=3a6317da-f045-42d8-917b-825ea52c5fd8",
                     URL = "https://hasaki.vn/san-pham/gel-rua-mat-eucerin-tuoi-mat-cho-da-thuong-nhay-cam-200ml-89925.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("44231B57-5715-46E3-BF7B-8FB891B73CCB"),
                     ProductName = "Sữa Rửa Mặt Skin1004 Làm Sạch Sâu Cho Da Nhạy Cảm 125ml",
                     ClickMoney = 200,
                     Price = 375000,
                     Description = "Sữa Rửa Mặt Skin1004 Làm Sạch Sâu Cho Da Nhạy Cảm 125ml từ thương hiệu mỹ phẩm Skin1004 của Hàn Quốc là dạng sữa rửa mặt tạo bọt chứa chiết xuất rau má giúp làm sạch da ngăn ngừa mụn và hỗ trợ điều trị mụn. Chứa thành phần tự nhiên dịu nhẹ cho da nên sữa rửa mặt không làm khô da mà còn giữ ẩm cho da. ",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/centella3.png?alt=media&token=49d34368-8e90-4165-baca-a774cc354262",
                     URL = "https://hasaki.vn/san-pham/sua-rua-mat-chiet-xuat-rau-ma-skin1004-diu-nhe-lam-sach-sau-da-125ml-86169.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("0E5CCE09-CD4B-4681-A56F-56B4C2BAEC7C"),
                     ProductName = "Nước Hoa Hồng Thayers Không Cồn Hương Hoa Hồng 355ml",
                     ClickMoney = 200,
                     Price = 264000,
                     Description = "Nước Hoa Hồng Thayers với thành phần không chứa cồn (alcohol-free) và công thức độc quyền kết hợp giữa chiết xuất Lô Hội (Aloe Vera) & chiết xuất cây Phỉ (Witch Hazel) không chưng cất sẽ giúp nhẹ nhàng làm sạch da, cân bằng độ pH và dưỡng ẩm, mang lại vẻ sáng mịn tự nhiên và khỏe mạnh cho làn da của bạn.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2thayers.png?alt=media&token=6d12bf7b-6a41-4cdc-bddf-1ccb677f4d93",
                     URL = "https://hasaki.vn/san-pham/nuoc-hoa-hong-khong-con-thayers-huong-hoa-hong-355ml-3227.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("87092517-B5CA-4794-8A9F-33CB8AB2CBFE"),
                     ProductName = "Nước Hoa Hồng Evoluderm Dành Cho Da Khô Và Nhạy Cảm 500ml",
                     ClickMoney = 200,
                     Price = 325000,
                     Description = "Giúp da mềm mại, tránh cho da không bị mất nước, mang đến cảm giác thoải mái và cho làn da được thông thoáng, thư giãn.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2tonique.jpg?alt=media&token=b9c6411d-cfec-44a5-bbfd-341f3697d725",
                     URL = "https://hasaki.vn/san-pham/nuoc-hoa-hong-evoluderm-danh-cho-da-kho-va-nhay-cam-500ml-14949.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("AAA3964A-2EB1-4E95-9FE2-CE972A357BD7"),
                     ProductName = "Nước Hoa Hồng Caryophy Ngừa Mụn Kiềm Dầu Giảm Thâm 300ml",
                     ClickMoney = 200,
                     Price = 400000,
                     Description = "Ngây, Nhân Sâm... giúp mang lại công dụng làm giảm mụn thâm, dưỡng ẩm, tẩy da chết, cân bằng độ pH cho da và là bước đệm hoàn hảo để các dưỡng chất thấm sâu vào da tốt nhất",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2caryophy.png?alt=media&token=1f38576d-d99e-44a8-a625-94b23ecdada3",
                     URL = "https://hasaki.vn/san-pham/nuoc-hoa-hong-cho-da-mun-caryophy-300ml-78140.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMFIk6UKxeIL3HRR1hvVcUaAjCJiMbyuE5tweE_JTxteiOnVqbvEaIRoCgGkQAvD_BwE",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("85AF885A-ABB5-454F-8AD8-D15147BBA22E"),
                     ProductName = "Nước Hoa Hồng Klairs Không Mùi Cho Da Nhạy Cảm 180ml",
                     ClickMoney = 200,
                     Price = 409000,
                     Description = "Nước hoa hồng Dear, Klairs Supple Preparation Facial Toner sản phẩm tối ưu trong việc làm sạch, cân bằng độ PH và dưỡng ẩm, có kết cấu dạng lỏng nhẹ, trong suốt và không màu, thẩm thấu nhanh chóng vào da. Kết hợp cùng mùi hương thảo mộc vô cùng dễ chịu, hoàn toàn không gây kích ứng hay cảm giác nhờn dính",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2klairs-2.jpg?alt=media&token=d74a0e41-5ab2-40dc-b17c-610118bb4f24",
                     URL = "https://hasaki.vn/san-pham/nuoc-hoa-hong-khong-mui-klairs-danh-cho-da-nhay-cam-180ml-65994.html?gad_source=1&gclid=CjwKCAjw65-zBhBkEiwAjrqRMEJSpgovsMtCFQ3MpacrWVHnPjqQ3_KqAoJ_LWQS2Tnz8BNEfLazNxoCj4MQAvD_BwE",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E")
                 }, 
                 new Product
                 {
                     Id = Guid.Parse("897AB50D-EBE3-4869-A1B4-D2D7F288FC45"),
                     ProductName = "Toner Mamonde Dưỡng Ẩm, Dịu Nhẹ Da Nhạy Cảm 250ml",
                     ClickMoney = 200,
                     Price = 360000,
                     Description = "Nước Hoa Hồng Mamonde Rose Water Toner là dòng toner đến từ thương hiệu mỹ phẩm Mamonde của Hàn Quốc, với thành phần chứa 90,97% nước hoa hồng Damask thay vì nước thông thường giúp dưỡng ẩm sâu, cấp nước nhanh chóng, phục hồi làn da khô ráp, thiếu sức sống.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/2mamonde2.jpg?alt=media&token=d6b5de2a-9ba2-4ed8-88f2-93d459bba634",
                     URL = "https://hasaki.vn/san-pham/nuoc-can-bang-mamonde-duong-am-diu-nhe-cho-da-nhay-cam-250ml-95787.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E")
                 }
                );
            #endregion
            #region #region SeedProductDetail
            modelBuilder.Entity<ProductDetail>().HasData
                (
                //179F7F08-41A7-48C4-A389-0584AAA49ED9
                new ProductDetail 
                {
                     ProductId = Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                     SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //83AFF4AC-C495-4582-8877-1D2FC83EB9CB
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //21653406-6211-4F18-B661-A360B581B397
                new ProductDetail
                {
                    ProductId = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                    SkinId = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //EF3342B3-E716-4028-B508-F29A1EC87865
                new ProductDetail
                {
                    ProductId = Guid.Parse("EF3342B3-E716-4028-B508-F29A1EC87865"),
                    SkinId = Guid.Parse("BE37023D-6A58-4B4B-92E5-39DCECE45473"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("EF3342B3-E716-4028-B508-F29A1EC87865"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //44231B57-5715-46E3-BF7B-8FB891B73CCB
                new ProductDetail
                {
                    ProductId = Guid.Parse("44231B57-5715-46E3-BF7B-8FB891B73CCB"),
                    SkinId = Guid.Parse("A960D28F-2807-4D58-8248-91EEC518D415"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("44231B57-5715-46E3-BF7B-8FB891B73CCB"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //0E5CCE09-CD4B-4681-A56F-56B4C2BAEC7C
                new ProductDetail
                {
                    ProductId = Guid.Parse("0E5CCE09-CD4B-4681-A56F-56B4C2BAEC7C"),
                    SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("0E5CCE09-CD4B-4681-A56F-56B4C2BAEC7C"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //87092517-B5CA-4794-8A9F-33CB8AB2CBFE
                new ProductDetail
                {
                    ProductId = Guid.Parse("87092517-B5CA-4794-8A9F-33CB8AB2CBFE"),
                    SkinId = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("87092517-B5CA-4794-8A9F-33CB8AB2CBFE"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //AAA3964A-2EB1-4E95-9FE2-CE972A357BD7
                new ProductDetail
                {
                    ProductId = Guid.Parse("AAA3964A-2EB1-4E95-9FE2-CE972A357BD7"),
                    SkinId = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("AAA3964A-2EB1-4E95-9FE2-CE972A357BD7"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //85AF885A-ABB5-454F-8AD8-D15147BBA22E
                new ProductDetail
                {
                    ProductId = Guid.Parse("85AF885A-ABB5-454F-8AD8-D15147BBA22E"),
                    SkinId = Guid.Parse("BE37023D-6A58-4B4B-92E5-39DCECE45473"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("85AF885A-ABB5-454F-8AD8-D15147BBA22E"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //897AB50D-EBE3-4869-A1B4-D2D7F288FC45
                new ProductDetail
                {
                    ProductId = Guid.Parse("897AB50D-EBE3-4869-A1B4-D2D7F288FC45"),
                    SkinId = Guid.Parse("A960D28F-2807-4D58-8248-91EEC518D415"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("897AB50D-EBE3-4869-A1B4-D2D7F288FC45"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                }

                );
            #endregion
        }
    }
}
