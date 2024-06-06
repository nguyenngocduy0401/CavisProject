using CavisProject.Domain.Entity;
using CavisProject.Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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
            modelBuilder.Entity<Skin>().HasData(
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Da thường",
                    Description = "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Da hỗn hợp",
                    Description = "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Da nhạy cảm",
                    Description = "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Da khô",
                    Description = "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Da nhờn",
                    Description = "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.",
                    Category = true,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.NewGuid(),
                    SkinsName = "Mụn đầu đen", 
                    Description = "Mụn đầu đen là loại mụn mà lỗ chân lông bị tắc bởi bã nhờn và tế bào da chết. Chúng thường màu đen hoặc vàng nâu.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.NewGuid(),
                    SkinsName = "Mụn đầu trắng", 
                    Description = "Mụn đầu trắng cũng là lỗ chân lông bị tắc, nhưng bề mặt của chúng bị phủ bởi một lớp da sạch. Chúng thường xuất hiện màu trắng hoặc da, thường nhỏ hơn mụn đầu đen.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.NewGuid(),
                    SkinsName = "Mụn bọc",
                    Description = "Mụn bọc là các nốt sưng và đỏ trên da mà không có đầu trắng hoặc đen ở phần trên. Chúng có thể gây đau và khó chịu.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.NewGuid(), 
                    SkinsName = "Mụn mủ", 
                    Description = "Mụn mủ là các nốt sưng và đỏ có chứa mủ ở phần trên. Chúng thường là dấu hiệu của một nhiễm trùng nặng hơn trong lỗ chân lông.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin {Id = Guid.NewGuid(),
                    SkinsName = "Mụn viêm đỏ",
                    Description = "Mụn viêm đỏ là các nốt sưng lớn và đau nhức dưới da. Chúng thường không có mủ ở phần trên như mụn mủ.", 
                    Category = false,
                    CreationDate = DateTime.Now },
                new Skin { Id = Guid.NewGuid(), 
                    SkinsName = "Mụn đầu đinh",
                    Description = "Mụn đầu đinh là các nốt sưng lớn và đau nhức có mủ ở phần trên. Chúng có thể gây ra tổn thương và vết sẹo nếu không được điều trị đúng cách.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin { Id = Guid.NewGuid(), 
                    SkinsName = "Mụn thâm",
                    Description = "Mụn thâm là các vết sẹo hoặc vết đỏ hoặc nâu trên da sau khi mụn đã lành. Chúng có thể gây ra tự ti và không tự tin về da mặt.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Nám da",
                    Description = "Nám da là sự xuất hiện của các vùng sạm màu trên da, thường là do tác động của tia UV từ ánh nắng mặt trời.",
                    Category = false,
                    CreationDate = DateTime.Now
                },
                new Skin
                {
                    Id = Guid.NewGuid(),
                    SkinsName = "Nếp nhăn",
                    Description = "Sự xuất hiện của nếp nhăn trên da thường là kết quả của quá trình lão hóa tự nhiên, nhưng cũng có thể được tăng cường bởi tác động từ môi trường, chế độ ăn uống và lối sống.",
                    Category = false,
                    CreationDate = DateTime.Now
                }
            );
        }
    }
}
