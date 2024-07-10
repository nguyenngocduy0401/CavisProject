using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
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
        public DbSet<CalendarDetail> CalendarDetails { get; set; }
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
        public DbSet<SkincareRoutine> SkincareRoutines { get; set; }
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
            #region User
            modelBuilder.Entity<User>().HasData
                (
                new User
                {
                    Id = "da8a7be0-e888-4201-8500-3c5b2dba7776",
                    UserName = "Cavis",
                    PhoneNumber = "0987654321",
                    Email = "cavis@gmail.com",
                    FullName = "Cavis",
                    URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/cavis-logo.png?alt=media&token=ec5a2f56-7adc-4abb-b5a8-b478b9d9cb78",
                    DateOfBirth = DateTime.Now,
                    Status = true,
                    Wallet = 0,
                }
                );
            #endregion
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
                 },

                 new ProductCategory
                 {
                     Id = Guid.Parse("9dba7949-edd0-469a-9ee2-225a864ede5b"),
                     ProductCategoryName = "Kem lót",
                 }, 
                 new ProductCategory
                 {
                     Id = Guid.Parse("786b79fb-576a-4999-bf57-ce5ff3792ef6"),
                     ProductCategoryName = "Cushion",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("d7114e75-445e-411f-85cc-c2ad4b0ca65c"),
                     ProductCategoryName = "Kem nền",
                 },
                 new ProductCategory
                 {
                     Id = Guid.Parse("f301d7ab-8c96-4f4b-8b34-5bd8bd2f3798"),
                     ProductCategoryName = "Phấn má",
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
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("5E500A0F-E114-4F88-95D1-F1B12FBA0654"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E"),
                     Status = (ProductStatusEnum)1
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
                     ProductCategoryId = Guid.Parse("30E2E877-861B-4AE5-8A6B-B2E93A79175E"),
                     Status = (ProductStatusEnum)1
                 },
                 //3
                 new Product
                 {
                     Id = Guid.Parse("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"),  
                     ProductName = "Kem Dưỡng Olay Luminous Sáng Da Mờ Thâm Nám Ban Đêm 50g",
                     ClickMoney = 200,
                     Price = 270000, 
                     Description = "Da xỉn màu hiệu quả, cho làn da toả sáng rạng rỡ chỉ trong 28 ngày.", 
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Olay.jpg?alt=media&token=8c757a0c-383d-4499-b3b8-7f3e2b48b719",
                     URL = "https://hasaki.vn/san-pham/kem-duong-am-ban-dem-olay-lam-sang-da-mo-tham-nam-50g-87859.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndHWwtwmT9MaaMeaKHq6Ymco3tN1Wa0ytsHuzvR-rgK4l3PeomwccgaAiaREALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"), 
                     ProductCategoryId = Guid.Parse("DB5D4968-16F9-48C6-AB2B-FEEF85208D5A"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("7201eaec-e23f-4c3a-a575-7aad1cbab460"),
                     ProductName = "Kem Dưỡng Ẩm Laneige Cấp Nước Cho Da Khô 50ml",
                     ClickMoney = 200,
                     Price = 850000,
                     Description = "với công thức cũ, mang lại hiệu quả dưỡng ẩm sâu suốt 72 giờ, cho làn da căng bóng, sáng mịn và đàn hồi.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Laneige.jpg?alt=media&token=bd50a06e-3645-4acf-b488-fb8cc8349dea",
                     URL = "https://hasaki.vn/san-pham/kem-duong-am-laneige-cho-da-kho-50ml-1026.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("DB5D4968-16F9-48C6-AB2B-FEEF85208D5A"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"),
                     ProductName = "Kem Giảm Mụn La Roche-Posay Dành Cho Mụn Sưng Đỏ 15ml",
                     ClickMoney = 200,
                     Price = 610000,
                     Description = "Công thức với Niacinamide, Piroctone Olamine, hạt tẩy tế bào chết LHA siêu mịn và nước khoáng La Roche-Posay giúp làm sạch sâu lỗ chân lông, giảm sưng viêm và ngừa sự phát triển của vi khuẩn gây mụn, đồng thời giúp làm dịu và kích thích tái tạo tế bào bề mặt da, ngăn ngừa sự hình thành của các vết thâm sau mụn.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/La%20Roche-Posay%20Effacla.jpg?alt=media&token=b7a3c1b8-2882-4389-8b73-fd2090b43a35",
                     URL = "https://hasaki.vn/san-pham/kem-duong-la-roche-posay-lam-giam-mun-chuyen-biet-15ml-1092.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndVhOh7KFY12qi3dIFnBPywwEf96mC1lZgd4WZqlyHGD6C95HwLIgAaArFpEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("DB5D4968-16F9-48C6-AB2B-FEEF85208D5A"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("4b01742a-26fa-4799-92cb-8cf936fda356"),
                     ProductName = "Kem Dưỡng Ẩm Neutrogena Cấp Nước Cho Da Dầu 50g",
                     ClickMoney = 200,
                     Price = 389000,
                     Description = "với công thức cũ, mang lại hiệu quả dưỡng ẩm sâu suốt 72 giờ, cho làn da căng bóng, sáng mịn và đàn hồi.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Neutrogena%20Hydro%20Boost%20Water%20Gel.jpg?alt=media&token=6bdfef98-734c-4454-b201-f8bd93bea6e1",
                     URL = "https://hasaki.vn/san-pham/kem-duong-am-neutrogena-cung-cap-nuoc-cho-da-50g-90339.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndONELGoevx8Sn66b5Fl2QsToH_IahOd8gyeYIIKK-E271RuWnktCAaAvogEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("DB5D4968-16F9-48C6-AB2B-FEEF85208D5A"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"),
                     ProductName = "Kem Dưỡng Ẩm Eucerin Dịu Nhẹ Cho Da Thường, Hỗn Hợp 50ml",
                     ClickMoney = 200,
                     Price = 590000,
                     Description = "giúp thúc đẩy hệ thống duy trì độ ẩm ngay từ bên trong, để da luôn ẩm mịn, căng mượt và tràn đầy sức sống.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Eucerin%20Lipo-Balance%20Intensive%20Nourishing%20Cream.jpg?alt=media&token=423592d5-ccc1-44cc-8d8d-27a3944d8952",
                     URL = "https://hasaki.vn/san-pham/kem-duong-am-eucerin-cho-da-thuong-den-da-hon-hop-50ml-68136.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqneRasEsTiW395OeWuFa_ZebB5tH1gDMjSIQjEO7EnM4IB3DUtnZINoaAggoEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("DB5D4968-16F9-48C6-AB2B-FEEF85208D5A"),
                     Status = (ProductStatusEnum)1
                 },
                 //4
                 new Product
                 {
                     Id = Guid.Parse("4df06bb4-f45a-42d5-becd-98b2e834c765"),
                     ProductName = "Kem Chống Nắng MartiDerm Phổ Rộng Bảo Vệ Toàn Diện",
                     ClickMoney = 200,
                     Price = 1350000,
                     Description = "màng lọc chống nắng phổ rộng chống lại các tia UVA, UVB, IR (hồng ngoại), HEV (ánh sáng xanh). Sự kết hợp của Proteoglycans, phức hợp Spectrum Complex, phức hợp Hyaluronic Acid & Silicon Complex giúp giữ cho làn da trẻ trung, tươi tắn và đều màu. Kết cấu dạng cream-to-powder độc đáo mang lại cảm giác mượt mà, mỏng nhẹ tựa vô hình trên da.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/MartiDerm%20The%20Originals%20Proteos%20Screen%20SPF50%2B%20Fluid%20Cream.jpg?alt=media&token=e92f624b-918d-4428-9cc8-3a0f18a27c96",
                     URL = "https://hasaki.vn/san-pham/kem-chong-nang-martiderm-pho-rong-toan-dien-spf50-40ml-90401.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnf0BPilz_8AKunYGCdgJi4LTr0XOYFCe5IumOshtzd6qwrtvxNm4P0aAtjXEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("39201E62-9CE1-45CC-9625-EE52BABC780D"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("6d759056-6bc2-49df-997b-bfb173c2dc19"),
                     ProductName = "Essence Chống Nắng Bioré Màng Nước Dưỡng Ẩm Da 50g",
                     ClickMoney = 200,
                     Price = 195000,
                     Description = "Màng chắn vi điểm mang đến hiệu quả chống nắng hoàn hảo mà không gây bết dính, ngăn tia UV tối ưu đồng thời tạo cảm giác siêu thoáng nhẹ trên da. Đặc biệt với kết cấu dạng essence màng nước trong suốt dễ dàng tán đều, thẩm thấu nhanh chóng, giúp tạo cảm giác tươi mát cùng làn da ẩm mịn mượt mà như lụa.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Biore%20UV%20Aqua%20Rich%20Watery%20Essence.jpg?alt=media&token=9f37b704-dda7-4941-b0bb-78a14b6f90d1",
                     URL = "https://hasaki.vn/san-pham/essence-chong-nang-mang-nuoc-duong-am-biore-spf50-pa-50g-6408.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("39201E62-9CE1-45CC-9625-EE52BABC780D"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("73ca3caf-e6bf-44c4-9441-7d90c77de17a"),
                     ProductName = "Sữa Chống Nắng Anessa Dưỡng Da Kiềm Dầu 60ml",
                     ClickMoney = 200,
                     Price = 715000,
                     Description = "Sữa Chống Nắng Anessa Perfect UV Sunscreen Skincare Milk N SPF50+ PA++++ Dưỡng Da Kiềm Dầu (Mới) là dòng sản phẩm chống nắng da mặt đến từ thương hiệu Anessa - Nhật Bản. Sản phẩm với công nghệ Auto Veil mới giúp cho lớp màng chống UV trở nên bền vững hơn khi gặp nhiệt độ cao, nước và ma sát.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Anessa%20Perfect%20UV%20Sunscreen%20Skincare%20Milk%20N.jpg?alt=media&token=c4371658-3aaf-45f4-9584-a8a24ca456bf",
                     URL = "https://hasaki.vn/san-pham/sua-chong-nang-anessa-duong-da-kiem-dau-60ml-moi-119084.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqncntdErbsKUwqZ1ntRjnIi2tuJK8v-PTr8LUKmSCyVI-y_8aMZ80VsaAkPxEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("39201E62-9CE1-45CC-9625-EE52BABC780D"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("49ff65f1-31c9-485d-89f7-7a2dea6ce649"),
                     ProductName = "Kem Chống Nắng Vichy Chống Bụi Mịn Cho Da Dầu Mụn 50ml",
                     ClickMoney = 200,
                     Price = 585000,
                     Description = "Kem Chống Nắng Chống Ô Nhiễm & Bụi Mịn Hằng Ngày Vichy Capital Soleil Mattifying 3in1 SPF50+ 50ml là sản phẩm chống nắng da mặt 3 trong 1 mới từ thương hiệu dược mỹ phẩm Vichy, được thiết kế dành cho da dầu mụn. ",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Vichy%20Capital%20Soleil%20Mattifying.jpg?alt=media&token=64266959-9a96-4d6d-bb0e-9fe026cb969d",
                     URL = "https://hasaki.vn/san-pham/kem-chong-nang-vichy-kiem-dau-spf50-50ml-88835.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnfcttLtt9diCT48iS-WDplNHtsBwy_Umy_EgQqc-rN_ia_0uYNCvT4aAlP1EALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("39201E62-9CE1-45CC-9625-EE52BABC780D"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"),
                     ProductName = "Kem Chống Nắng Hằng Ngày Kiehl's SPF50/PA ++++ 30ml",
                     ClickMoney = 200,
                     Price = 950000,
                     Description = "Kem Chống Nắng Hằng Ngày Kiehl's Ultra Light Daily UV Defense SPF50/PA++++ Anti-Pollution đóng vai trò vô cùng quan trọng trong việc bảo vệ và chăm sóc làn da trước tác hại của ánh nắng mặt trời cũng như tia UV gây hại cho da",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Kiehl's%20Ultra%20Light%20Daily%20UV%20Defense%20SPF.jpg?alt=media&token=bf69bece-dafc-4706-aa39-6172f0fa267a",
                     URL = "https://hasaki.vn/san-pham/kem-chong-nang-hang-ngay-kiehl-s-spf50-pa-30ml-73170.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("39201E62-9CE1-45CC-9625-EE52BABC780D"),
                     Status = (ProductStatusEnum)1
                 },
                 //5
                 new Product
                 {
                     Id = Guid.Parse("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"),
                     ProductName = "Nước Tẩy Trang Byphasse Cho Mọi Loại Da 500ml",
                     ClickMoney = 200,
                     Price = 180000,
                     Description = "Sử dụng công nghệ Micellar giúp loại bỏ hiệu quả lớp trang điểm cùng bụi bẩn, bã nhờn sâu trong lỗ chân lông, mang lại làn da sạch thoáng mà không gây nhờn dính.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Byphasse%20Solution%20Micellaire.jpg?alt=media&token=6037becc-f411-44cd-85e4-be7fd34f4ed5",
                     URL = "https://hasaki.vn/san-pham/nuoc-tay-trang-byphasse-cho-moi-loai-da-500ml-3183.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("839DC6D7-4B15-479B-9E01-17B8D3303144"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("a4457bba-0aa8-4443-9619-d3dab29aa196"),
                     ProductName = "Nước Tẩy Trang L'Oreal Làm Sạch Sâu Trang Điểm 400ml",
                     ClickMoney = 200,
                     Price = 269000,
                     Description = "Có hai lớp chất lỏng giúp hòa tan chất bẩn và loại bỏ toàn bộ lớp trang điểm hiệu quả, kể cả lớp trang điểm lâu trôi và không thấm nước chỉ trong một bước.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/L'Or%C3%A9al%20Paris%20Micellar%20Water%203-in-1%20Moisturizing%20Even%20For%20Sensitive%20Skin.jpg?alt=media&token=a4dd0fe3-9c4f-4ae1-a88c-79deca96ce68",
                     URL = "https://hasaki.vn/san-pham/nuoc-tay-trang-l-oreal-3-in-1-lam-sach-sau-400ml-34119.html",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("839DC6D7-4B15-479B-9E01-17B8D3303144"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("dad66471-6992-4588-a77d-ab3802ee59f7"),
                     ProductName = "Dầu Tẩy Trang Klairs Làm Sạch Sâu Cho Mọi Loại Da 150ml",
                     ClickMoney = 200,
                     Price = 425000,
                     Description = "kiểm soát sản xuất bã nhờn và cung cấp dinh dưỡng cho làn da, ngăn chặn tình trạng mất nước và lão hóa trên da.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Klairs%20Gentle%20Black%20Deep%20Cleansing%20Oil.jpg?alt=media&token=605ebe34-80fa-4feb-8aa5-fa4468361e8a",
                     URL = "https://hasaki.vn/san-pham/dau-tay-trang-klairs-lam-sach-sau-cho-moi-loai-da-150ml-66046.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqneXiK5EtEZTGc8AreQnfD9DH2BaoDtu8cyOxWfBT2lWqrgD2Mqq4JoaAonLEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("839DC6D7-4B15-479B-9E01-17B8D3303144"),
                     Status = (ProductStatusEnum)1
                 },
                 new Product
                 {
                     Id = Guid.Parse("bee3860c-9eaa-4e7b-878b-90a15b9defa2"),
                     ProductName = "Nước Tẩy Trang Caryophy Cho Da Dầu Mụn, Nhạy Cảm 500ml",
                     ClickMoney = 200,
                     Price = 460000,
                     Description = "Công thức sản phẩm an toàn & lành tính, dịu nhẹ cho làn da nhạy cảm, với các chiết xuất thiên nhiên như Rau Sam, Rau Má và thành phần độc đáo Citric Acid giúp làm sạch da tối ưu và hỗ trợ kháng khuẩn, kháng viêm, ngăn ngừa mụn và làm dịu da, giải tỏa căng thẳng trên da.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Caryophy%20Smart%20Cleansing%20Water.jpg?alt=media&token=64c2e8fc-e893-45aa-bd86-0b592f309392",
                     URL = "https://hasaki.vn/san-pham/nuoc-tay-trang-caryophy-cho-da-dau-mun-nhay-cam-500ml-91531.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqnc5cVVKaND4RQ-VF7ZpLe2tG3uH1mkEN-QQ8en7HkAakUuKQ3quz9saAogdEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("839DC6D7-4B15-479B-9E01-17B8D3303144"),
                     Status = (ProductStatusEnum)1,
                 },
                 new Product
                 {
                     Id = Guid.Parse("e447a290-469c-47ab-b918-c9534556d112"),
                     ProductName = "Nước Tẩy Trang Simple Làm Sạch Trang Điểm Vượt Trội 400ml",
                     ClickMoney = 200,
                     Price = 189000,
                     Description = "Micelles thông minh giúp loại bỏ lớp trang điểm và bụi bẩn hiệu quả, làm thông thoáng lỗ chân lông, mang lại cảm giác tươi mát cho da sau khi sử dụng, đồng thời cấp ẩm lên đến 4 giờ mà không để lại dư lượng thừa trên da.",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/Simple%20Micellar%20Cleansing%20Water.jpg?alt=media&token=3747c611-6b2f-4464-91e5-6de00f90fefb",
                     URL = "https://hasaki.vn/san-pham/nuoc-tay-trang-simple-lam-sach-trang-diem-va-cap-am-400ml-104259.html?gad_source=1&gclid=Cj0KCQjwsaqzBhDdARIsAK2gqndbwfo5t-8uGNIEDk-WrXO8F2GSsjCT3GqN-MmQOs2iLV92I4XqnqoaAiTaEALw_wcB",
                     SupplierId = Guid.Parse("8F78562C-4DA1-4CF4-9100-22215C0B6530"),
                     ProductCategoryId = Guid.Parse("839DC6D7-4B15-479B-9E01-17B8D3303144"),
                     Status= (ProductStatusEnum)1
                 }
                );
                 
            #endregion
            #region SeedProductDetail
            modelBuilder.Entity<ProductDetail>().HasData
                (
                //set1
                //179F7F08-41A7-48C4-A389-0584AAA49ED9
                new ProductDetail
                {
                    ProductId = Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                    SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),//Da thường
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),//Nám da
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                    SkinId = Guid.Parse("4678f8d2-5648-4521-9608-8e981dee9103"),//Nếp nhăn
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("179F7F08-41A7-48C4-A389-0584AAA49ED9"),
                    SkinId = Guid.Parse("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),//Mụn viêm đỏ
                },
                #region 8383AFF4AC-C495-4582-8877-1D2FC83EB9CB
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),//Nám da
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("4678f8d2-5648-4521-9608-8e981dee9103"),//Nếp nhăn
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("5AB57D24-20AD-4B15-8427-C951419DA3BA"),//Mụn bọc
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),//Mụn viêm đỏ
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("BD287628-2EB7-458A-B202-D89D63FAAEBF"),//Mụn mũ
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("E8685143-0F2E-42FA-8025-DA53E1707461"),//Mụn đầu đen
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("F49B6287-8F31-4FD5-9899-ED1EB6D0564A"),//Mụn đầu đinh
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("A9035561-1399-464F-9F09-38C164A40A63"),//Mụn thâm
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("83AFF4AC-C495-4582-8877-1D2FC83EB9CB"),
                    SkinId = Guid.Parse("73766FF0-D528-4262-A1E8-656B33F58603"),//Mụn đầu trắng
                },
            #endregion
#region 21653406-6211-4F18-B661-A360B581B397
                new ProductDetail
                {
                    ProductId = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                    SkinId = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                    SkinId = Guid.Parse("12774b27-0e13-4f82-87d0-bfd6bd23e6e5"),//Mụn viêm đỏ
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                    SkinId = Guid.Parse("5AB57D24-20AD-4B15-8427-C951419DA3BA"),//Mụn bọc
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("21653406-6211-4F18-B661-A360B581B397"),
                    SkinId = Guid.Parse("BD287628-2EB7-458A-B202-D89D63FAAEBF"),//Mụn mủ
                },
            #endregion
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
                //set2
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
                },
                //set3
                //2818b73c-0d4f-4772-b528-fd08cd0ffd9c
                new ProductDetail
                {
                    ProductId = Guid.Parse("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"),
                    SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("2818b73c-0d4f-4772-b528-fd08cd0ffd9c"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //7201eaec-e23f-4c3a-a575-7aad1cbab460
                new ProductDetail
                {
                    ProductId = Guid.Parse("7201eaec-e23f-4c3a-a575-7aad1cbab460"),
                    SkinId = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("7201eaec-e23f-4c3a-a575-7aad1cbab460"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //6f1fdabb-ef74-4bdd-a106-1a06ee2bc254
                new ProductDetail
                {
                    ProductId = Guid.Parse("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"),
                    SkinId = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("6f1fdabb-ef74-4bdd-a106-1a06ee2bc254"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //4b01742a-26fa-4799-92cb-8cf936fda356
                new ProductDetail
                {
                    ProductId = Guid.Parse("4b01742a-26fa-4799-92cb-8cf936fda356"),
                    SkinId = Guid.Parse("BE37023D-6A58-4B4B-92E5-39DCECE45473"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("4b01742a-26fa-4799-92cb-8cf936fda356"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //03a271ba-2b54-455e-8a87-7c4ac5b45a7c
                new ProductDetail
                {
                    ProductId = Guid.Parse("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"),
                    SkinId = Guid.Parse("A960D28F-2807-4D58-8248-91EEC518D415"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("03a271ba-2b54-455e-8a87-7c4ac5b45a7c"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //set4
                //4df06bb4-f45a-42d5-becd-98b2e834c765
                new ProductDetail
                {
                    ProductId = Guid.Parse("4df06bb4-f45a-42d5-becd-98b2e834c765"),
                    SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("4df06bb4-f45a-42d5-becd-98b2e834c765"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //6d759056-6bc2-49df-997b-bfb173c2dc19
                new ProductDetail
                {
                    ProductId = Guid.Parse("6d759056-6bc2-49df-997b-bfb173c2dc19"),
                    SkinId = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("6d759056-6bc2-49df-997b-bfb173c2dc19"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //73ca3caf-e6bf-44c4-9441-7d90c77de17a
                new ProductDetail
                {
                    ProductId = Guid.Parse("73ca3caf-e6bf-44c4-9441-7d90c77de17a"),
                    SkinId = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("73ca3caf-e6bf-44c4-9441-7d90c77de17a"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //49ff65f1-31c9-485d-89f7-7a2dea6ce649
                new ProductDetail
                {
                    ProductId = Guid.Parse("49ff65f1-31c9-485d-89f7-7a2dea6ce649"),
                    SkinId = Guid.Parse("BE37023D-6A58-4B4B-92E5-39DCECE45473"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("49ff65f1-31c9-485d-89f7-7a2dea6ce649"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //7b7c9d03-67a4-4ed8-a1fc-34611b8de62e
                new ProductDetail
                {
                    ProductId = Guid.Parse("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"),
                    SkinId = Guid.Parse("A960D28F-2807-4D58-8248-91EEC518D415"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("7b7c9d03-67a4-4ed8-a1fc-34611b8de62e"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //set5
                //8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9
                new ProductDetail
                {
                    ProductId = Guid.Parse("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"),
                    SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("8c5f0b9a-3b55-4635-bd1d-a53e4c2a70a9"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //a4457bba-0aa8-4443-9619-d3dab29aa196
                new ProductDetail
                {
                    ProductId = Guid.Parse("a4457bba-0aa8-4443-9619-d3dab29aa196"),
                    SkinId = Guid.Parse("05AB75D8-622B-4BAB-9543-AD10E441D7D6"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("a4457bba-0aa8-4443-9619-d3dab29aa196"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //dad66471-6992-4588-a77d-ab3802ee59f7
                new ProductDetail
                {
                    ProductId = Guid.Parse("dad66471-6992-4588-a77d-ab3802ee59f7"),
                    SkinId = Guid.Parse("90A11B66-E89F-45AB-BFC4-B31101D0DD81"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("dad66471-6992-4588-a77d-ab3802ee59f7"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //bee3860c-9eaa-4e7b-878b-90a15b9defa2
                new ProductDetail
                {
                    ProductId = Guid.Parse("bee3860c-9eaa-4e7b-878b-90a15b9defa2"),
                    SkinId = Guid.Parse("BE37023D-6A58-4B4B-92E5-39DCECE45473"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("bee3860c-9eaa-4e7b-878b-90a15b9defa2"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                },
                //e447a290-469c-47ab-b918-c9534556d112
                new ProductDetail
                {
                    ProductId = Guid.Parse("e447a290-469c-47ab-b918-c9534556d112"),
                    SkinId = Guid.Parse("A960D28F-2807-4D58-8248-91EEC518D415"),
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("e447a290-469c-47ab-b918-c9534556d112"),
                    SkinId = Guid.Parse("8D9526B4-4532-4AFF-8F69-379DBAC8A55F"),
                }
                );
            #endregion
            #region Package
            modelBuilder.Entity<PackagePremium>().HasData(
                
                new PackagePremium
            {
                Id = Guid.Parse("623A23FF-4EE9-409A-BF30-2E764E8BD754"),
                PackagePremiumName = "Premium Package 5 days",
                Price = 5000,
                Duration = 5, // Duration in days, months, etc., depending on your application logic
                Description = "This is a premium package offering special features."
            },
                  new PackagePremium
                  {
                      Id = Guid.Parse("56866515-9D42-4209-A3F9-62E166CB322A"),
                      PackagePremiumName = "Premium Package year",
                      Price = 200000,
                      Duration = 365, // Duration in days, months, etc., depending on your application logic
                      Description = "This is a premium package offering special features."
                  }
);
            #endregion
            #region seedMethod
            /*  modelBuilder.Entity<Method>().HasData(
                   new Method
                   {
                       Id = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                       MethodName = "Chăm sóc da thường",
                       Category = 0,
                       Description = "<h4><strong><span style=\"font-size:11pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:11pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:11pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Tẩy trang:</span></strong><span style=\"font-size:11pt;\">Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Rửa mặt:</span></strong><span style=\"font-size:11pt;\">Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><strong><span style=\"font-size:11pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:11pt;\">Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:11pt;\">\r\n        <p><strong><span style=\"font-size:11pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:11pt;\">\r\n                <p><span style=\"font-size:11pt;\">Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>\r\n<div id=\"gtx-trans\" style=\"position: absolute; left: -58px; top: 43.5312px;\">\r\n    <div class=\"gtx-trans-icon\"><br></div>\r\n</div>\r\n",
                       Status = 0,
                       UserId = "da8a7be0-e888-4201-8500-3c5b2dba7776",
                       CreationDate = DateTime.Now
                   }
                   );*/
            #endregion
            #region Calendar
            modelBuilder.Entity<Calendar>().HasData(
                   new Calendar
                   {
                       Id = Guid.Parse("FCE513A4-01D5-47A8-9FD2-887381FF6A7D"),
                       StartTime = new TimeSpan(8, 0, 0),
                       EndTime = new TimeSpan(10, 0, 0),
                       Duration = 2.0
                   }, new Calendar
                   {
                       Id = Guid.Parse("5BD3814D-2306-4B91-9412-73512136FE04"),
                       StartTime = new TimeSpan(11, 0, 0),
                       EndTime = new TimeSpan(13, 0, 0),
                       Duration = 2.0
                   }, new Calendar
                   {
                       Id = Guid.Parse("E5795B99-A5EA-4FFE-A799-A097475872A4"),
                       StartTime = new TimeSpan(14 , 0, 0),
                       EndTime = new TimeSpan(16, 0, 0),
                       Duration = 2.0
                   }, new Calendar
                   {
                       Id = Guid.Parse("FFC9FC78-FAA7-4E37-B618-DB6AFF2EFB5F"),
                       StartTime = new TimeSpan(16, 0, 0),
                       EndTime = new TimeSpan(18, 0, 0),
                       Duration = 2.0
                   }, new Calendar
                   {
                       Id = Guid.Parse("74816131-CAC6-4BC3-B1E5-5ED31BDA575E"),
                       StartTime = new TimeSpan(19, 0, 0),
                       EndTime = new TimeSpan(21, 0, 0),
                       Duration = 2.0
                   }

                   );
            modelBuilder.Entity<Method>().HasData(
                 new Method
                 {
                     Id = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                     MethodName = "Chăm sóc da thường",
                     URLImage = "https://firebasestorage.googleapis.com/v0/b/cavisproject.appspot.com/o/da-thuong-3.jpg?alt=media&token=96cece83-4aaa-426d-ae5f-6d37c061a8f2",
                     Category = 0,
                     Description = "<h4><strong><span style=\"font-size:18pt;\">1. Chăm sóc da thường</span></strong></h4>\r\n<p><span style=\"font-size:12pt;\">Da thường là loại da lý tưởng mà nhiều người mong muốn có được. Đây là loại da không nhờn, không khô, ít mụn và thường có độ ẩm cân bằng. Tuy nhiên, để duy trì làn da khỏe đẹp này, bạn vẫn cần có một quy trình chăm sóc da đúng cách.</span></p>\r\n<p><strong><span style=\"font-size:18pt;\">Phương pháp chăm sóc:</span></strong></p>\r\n<ol>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Làm sạch da:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Tẩy trang:</span></strong><span style=\"font-size:12pt;\"> Sử dụng sản phẩm tẩy trang không chứa cồn để loại bỏ mỹ phẩm và bụi bẩn.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Rửa mặt:</span></strong><span style=\"font-size:12pt;\"> Rửa mặt buổi sáng và tối bằng sữa rửa mặt có độ pH từ 4.5-5.5 để duy trì độ cân bằng tự nhiên của da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><strong><span style=\"font-size:12pt;\">Tẩy tế bào chết:</span></strong><span style=\"font-size:12pt;\"> Tẩy tế bào chết 2 lần/tuần để loại bỏ da chết, giúp da mịn màng hơn.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Toner:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng toner không chứa cồn để cân bằng độ pH và cấp ẩm cho da sau khi rửa mặt.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Dưỡng ẩm:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Sử dụng kem dưỡng ẩm ban ngày và ban đêm để duy trì độ ẩm cho da.</span></p>\r\n            </li>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Đắp mặt nạ 2 lần/tuần, ưu tiên các nguyên liệu tự nhiên như yến mạch, bơ để cung cấp thêm dưỡng chất cho da.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n    <li style=\"list-style-type:decimal;font-size:12pt;\">\r\n        <p><strong><span style=\"font-size:12pt;\">Chống nắng:</span></strong></p>\r\n        <ul>\r\n            <li style=\"list-style-type:circle;font-size:12pt;\">\r\n                <p><span style=\"font-size:12pt;\"> Thoa kem chống nắng hàng ngày để bảo vệ da khỏi tác hại của tia UV.</span></p>\r\n            </li>\r\n        </ul>\r\n    </li>\r\n</ol>",
                     Status = 0,
                     UserId = "da8a7be0-e888-4201-8500-3c5b2dba7776",
                     CreationDate = DateTime.Now
                 }
                 );
            #endregion
            #region SeedMethodDetail
            modelBuilder.Entity<MethodDetail>().HasData(
                 new MethodDetail
                 {
                     MethodId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),
                     SkinId = Guid.Parse("550EE872-EA09-42A0-B9AC-809890DEBAFB"),// Da thuong
                 }
                 );
            #endregion
        }
    }
}
