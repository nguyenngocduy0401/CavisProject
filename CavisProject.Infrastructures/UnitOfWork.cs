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
        private readonly IMethodSkinCareRepository _methodSkinCareRepository;
        private readonly IMethodDetailRepository _methodDetailRepository;
        private readonly IPackageDetailRepository _packageDetailRepository;
        private readonly IPackagePremiumRepository _packagePremiumRepository;
        private readonly IPersonalAnalystRepository _personalAnalystRepository;
        private readonly IPersonalAnalystDetailRepository _personalAnalystDetailRepository;
        private readonly IPersonalImageRepository _personalImageRepository;
        private readonly IPersonalMethodDetailRepository _personalMethodDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ISkinTypeRepository _skinTypeRepository;
        private readonly ISkinConditionRepository _skinConditionRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWishListRepository _wishListRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMethodMakeUpRepository _methodMakeUpRepository;
        private readonly ISkincareRoutineRepository _skincareRoutineRepository;

        public UnitOfWork(AppDbContext appDbContext, IAppointmentRepository appointmentRepository, 
            IUserRepository userRepository, IAppointmentDetailRepository appointmentDetailRepository, 
            ICalendarRepository calendarRepository, IMethodSkinCareRepository methodSkinCareRepository, 
            IMethodDetailRepository methodDetailRepository, IPackageDetailRepository packageDetailRepository, 
            IPackagePremiumRepository packagePremiumRepository, IPersonalAnalystRepository personalAnalystRepository,
            IPersonalAnalystDetailRepository personalAnalystDetailRepository, IPersonalImageRepository personalImageRepository,
            IPersonalMethodDetailRepository personalMethodDetailRepository, IProductRepository productRepository, 
            IProductDetailRepository productDetailRepository, IProductCategoryRepository productCategoryRepository,
            ISkinTypeRepository skinTypeRepository, ISupplierRepository supplierRepository,
            ITransactionRepository transactionRepository, IWishListRepository wishListRepository,
            IRoleRepository roleRepository, IRefreshTokenRepository refreshTokenRepository,
            ISkinConditionRepository skinConditionRepository,IMethodMakeUpRepository methodMakeUpRepository,
            ISkincareRoutineRepository skincareRoutineRepository)
        {
            _dbContext = appDbContext;
            
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
            _appointmentDetailRepository = appointmentDetailRepository;
            _calendarRepository = calendarRepository;
            _methodSkinCareRepository = methodSkinCareRepository;
            _methodDetailRepository = methodDetailRepository;
            _packageDetailRepository = packageDetailRepository;
            _packagePremiumRepository = packagePremiumRepository;
            _personalAnalystRepository = personalAnalystRepository;
            _personalAnalystDetailRepository = personalAnalystDetailRepository;
            _personalImageRepository = personalImageRepository;
            _personalMethodDetailRepository = personalMethodDetailRepository;
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
            _productCategoryRepository = productCategoryRepository;
            _skinTypeRepository = skinTypeRepository;
            _skinConditionRepository = skinConditionRepository;
            _supplierRepository = supplierRepository;
            _transactionRepository = transactionRepository;
            _wishListRepository = wishListRepository;
            _roleRepository = roleRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _methodMakeUpRepository = methodMakeUpRepository;
            _skincareRoutineRepository = skincareRoutineRepository;
        }

        public IAppointmentRepository AppointmentRepository => _appointmentRepository;

        public IAppointmentDetailRepository AppointmentDetailRepository => _appointmentDetailRepository;
        public ICalendarRepository CalendarRepository => _calendarRepository;
        public IMethodDetailRepository MethodDetailRepository => _methodDetailRepository;
        public IMethodSkinCareRepository MethodSkinCareRepository => _methodSkinCareRepository;
        public IPackageDetailRepository PackageDetailRepository => _packageDetailRepository;
        public IPackagePremiumRepository PackagePremiumRepository => _packagePremiumRepository;
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
        public IRefreshTokenRepository RefreshTokenRepository => _refreshTokenRepository;
        public ISkinConditionRepository SkinConditionRepository =>_skinConditionRepository;
        public IMethodMakeUpRepository MethodMakeUpRepository=>_methodMakeUpRepository;
        public ISkincareRoutineRepository SkincareRoutineRepository => _skincareRoutineRepository;
        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
