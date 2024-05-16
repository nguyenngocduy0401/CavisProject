using CavisProject.Application;
using CavisProject.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAppointmentDetailRepository _appointmentDetailRepository;
        private readonly ICalendarRepository _calendarRepository;
        private readonly IMethodRepository _methodRepository;
        private readonly IMethodDetailRepository _methodDetailRepository;
        private readonly IPackageDetailRepository _packageDetailRepository;
        private readonly IPackagePreniumRepository _packagePreniumRepository;
        private readonly IPersonalAnalystRepository _personalAnalystRepository;
        private readonly IPersonalAnalystDetailRepository _personalAnalystDetailRepository;
        private readonly IPersonalImageRepository _personalImageRepository;
        private readonly IPersonalMethodDetailRepository _personalMethodDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ISkinTypeRepository _skinTypeRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWishListRepository _wishListRepository;
        private readonly IRoleRepository _roleRepository;

        public UnitOfWork(AppDbContext appDbContext, IAppointmentRepository appointmentRepository, IUserRepository userRepository, IAppointmentDetailRepository appointmentDetailRepository, ICalendarRepository calendarRepository, IMethodRepository methodRepository, IMethodDetailRepository methodDetailRepository, IPackageDetailRepository packageDetailRepository, IPackagePreniumRepository packagePreniumRepository, IPersonalAnalystRepository personalAnalystRepository, IPersonalAnalystDetailRepository personalAnalystDetailRepository, IPersonalImageRepository personalImageRepository, IPersonalMethodDetailRepository personalMethodDetailRepository, IProductRepository productRepository, IProductDetailRepository productDetailRepository, IProductCategoryRepository productCategoryRepository, ISkinTypeRepository skinTypeRepository, ISupplierRepository supplierRepository, ITransactionRepository transactionRepository, IWishListRepository wishListRepository, IRoleRepository roleRepository)
        {
            _dbContext = appDbContext;
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _appointmentDetailRepository = appointmentDetailRepository;
            _calendarRepository = calendarRepository;
            _methodRepository = methodRepository;
            _methodDetailRepository = methodDetailRepository;
            _packageDetailRepository = packageDetailRepository;
            _packagePreniumRepository = packagePreniumRepository;
            _personalAnalystRepository = personalAnalystRepository;
            _personalAnalystDetailRepository = personalAnalystDetailRepository;
            _personalImageRepository = personalImageRepository;
            _personalMethodDetailRepository = personalMethodDetailRepository;
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
            _productCategoryRepository = productCategoryRepository;
            _skinTypeRepository = skinTypeRepository;
            _supplierRepository = supplierRepository;
            _transactionRepository = transactionRepository;
            _wishListRepository = wishListRepository;
            _roleRepository = roleRepository;
        }

        public IAppointmentRepository AppointmentRepository => _appointmentRepository;

        public IAppointmentDetailRepository AppointmentDetailRepository => _appointmentDetailRepository;

        public ICalendarRepository CalendarRepository => _calendarRepository;

        public IMethodDetailRepository MethodDetailRepository => _methodDetailRepository;

        public IMethodRepository MethodRepository => _methodRepository;

        public IPackageDetailRepository PackageDetailRepository => _packageDetailRepository;

        public IPackagePreniumRepository PackagePreniumRepository => _packagePreniumRepository;

        public IPersonalAnalystRepository PersonalAnalystRepository => _personalAnalystRepository;

        public IPersonalAnalystDetailRepository PersonalAnalystDetailRepository => _personalAnalystDetailRepository;
        public IPersonalImageRepository PersonalImageRepository => _personalImageRepository;

        public IPersonalMethodDetailRepository PersonalMethodDetailRepository => _personalMethodDetailRepository;

        public IProductRepository ProductRepository => _productRepository;

        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository;

        public IProductDetailRepository ProductDetailRepository => _productDetailRepository;

        public ISkinTypeRepository SkinTypeRepository => _skinTypeRepository;

        public IUserRepository UserRepository => _userRepository;

        public ISupplierRepository SupplierRepository => _supplierRepository;

        public ITransactionRepository TransactionRepository => _transactionRepository;

        public IWishListRepository WishListRepository => _wishListRepository;

        public IRoleRepository RoleRepository => _roleRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
