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
                new Skin { SkinsName = "Da thường", 
                    Description = "Da cân bằng với vẻ ngoài khỏe mạnh, không quá nhờn cũng không quá khô, và ít khuyết điểm.", 
                    Category = true, CreationDate = DateTime.Now },
                new Skin { SkinsName = "Da hỗn hợp", 
                    Description = "Sự kết hợp của các loại da; thường thì vùng chữ T (trán, mũi, và cằm) là da nhờn trong khi má là da khô hoặc bình thường.", 
                    Category = true, CreationDate = DateTime.Now },
                new Skin { SkinsName = "Da nhạy cảm", 
                    Description = "Da dễ phản ứng với các sản phẩm và yếu tố môi trường, thường dẫn đến đỏ, ngứa, hoặc kích ứng.", 
                    Category = true, CreationDate = DateTime.Now },
                new Skin { SkinsName = "Da khô", 
                    Description = "Da thiếu độ ẩm, thường cảm thấy căng, thô ráp, hoặc bong tróc, và có thể trông xỉn màu.", 
                    Category = true, CreationDate = DateTime.Now },
                new Skin { SkinsName = "Da nhờn", 
                    Description = "Da sản xuất quá nhiều bã nhờn, dẫn đến vẻ ngoài bóng và có khả năng cao bị mụn và lỗ chân lông to.",
                    Category = true, CreationDate = DateTime.Now }
                );
        }
    }
}
