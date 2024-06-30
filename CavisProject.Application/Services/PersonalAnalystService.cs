using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModels;
using CavisProject.Application.ViewModels.UserViewModels;
using CavisProject.Domain.Entity;
using CavisProject.Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class PersonalAnalystService : IPersonalAnalystService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public PersonalAnalystService(IUnitOfWork unitOfWork, IMapper mapper,
            IClaimsService claimsService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _claimsService = claimsService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<ApiResponse<Pagination<PersonalAnalystViewModel>>> FilterPersonalAnalystAsync(FilterPersonalAnalystModel filterPersonalAnalystModel)
        {
            var response = new ApiResponse<Pagination<PersonalAnalystViewModel>>();
            try
            {
                var userId = _claimsService.GetCurrentUserId.ToString();
                var search = (Expression<Func<PersonalAnalyst, bool>>)(e =>
                (!filterPersonalAnalystModel.StartDate.HasValue || e.StartDate <= filterPersonalAnalystModel.StartDate) &&
                (!filterPersonalAnalystModel.EndDate.HasValue || e.StartDate >= filterPersonalAnalystModel.EndDate)
                );
                var personalAnalyst = await _unitOfWork.PersonalAnalystRepository.GetFilterAsync(
                    filter: search,
                    includeProperties: "PersonalAnalystDetails",
                    pageIndex: filterPersonalAnalystModel.PageIndex,
                    pageSize: filterPersonalAnalystModel.PageSize,
                    foreignKey: "UserId",
                    foreignKeyId: userId
                    );
                var personalAnalystModel = _mapper.Map<Pagination<PersonalAnalystViewModel>>(personalAnalyst);
                response.Data = personalAnalystModel;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> CreatePersonalAnalystByLoginAsync(ListSkinPersonalModel listSkinPersonalModel)
        {
            var response = new ApiResponse<bool>();
            try
            {
                if (listSkinPersonalModel.SkinIdList == null)
                {
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "Vui lòng chọn loại da của bạn!";
                    return response;
                }
                var userId = _claimsService.GetCurrentUserId.ToString();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new Exception("Not found user!");

                var personAnalystId = await _unitOfWork.PersonalAnalystRepository.CreatePersonalAnalystAsync(
                    new PersonalAnalyst { UserId = userId });
                var personalAnalystDetail = new List<PersonalAnalystDetail>();
                foreach (var skinId in listSkinPersonalModel.SkinIdList)
                {
                    personalAnalystDetail.Add(new PersonalAnalystDetail
                    {
                        PersonalAnalystId = personAnalystId,
                        SkinId = Guid.Parse(skinId),
                    });
                }
                await _unitOfWork.PersonalAnalystDetailRepository.AddRangeAsync(personalAnalystDetail);
                await _unitOfWork.SaveChangeAsync();
                response.Data = true;
                response.isSuccess = true;
                response.Message = "Successful!";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProductAsync(FilterSuggestProductModel filterSuggestProductModel)
        {
            var response = new ApiResponse<Pagination<ProductViewModel>>();
            try
            {
                var personalAnalyst = await _unitOfWork.PersonalAnalystRepository.GetLastPersonalAnalystAsync();
                if (personalAnalyst == null) throw new Exception("Fail in GetLastPersonalAnalyst!");
                var filter = (Expression<Func<Product, bool>>)(e =>
                (!filterSuggestProductModel.MinPrice.HasValue || e.Price <= filterSuggestProductModel.MinPrice) &&
                (!filterSuggestProductModel.MaxPrice.HasValue || e.Price >= filterSuggestProductModel.MaxPrice)
                );
                var products = await _unitOfWork.PersonalAnalystRepository.SuggestProductAsync(
                    personalAnalyst.Id,
                    foreignKey: "ProductCategory",
                    foreignKeyId: filterSuggestProductModel.CategoryId,
                    filter: filter,
                    compatibleProductsEnum:filterSuggestProductModel.CompatibleProducts,
                    pageIndex: filterSuggestProductModel.PageIndex,
                    pageSize: filterSuggestProductModel.PageSize);

                if (products.Items == null)
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không có sản phẩm phù hợp cho bạn!";
                }

                var productViewModel = _mapper.Map<Pagination<ProductViewModel>>(products);
                response.Data = productViewModel;
                response.isSuccess = true;
                response.Message = "Successfully!";

            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<Pagination<MethodViewModel>>> SuggestMethodMakeUpAsync(FilterSuggestMethodModel filterSuggestMethodModel)
        {
            var response = new ApiResponse<Pagination<MethodViewModel>>();
            try
            {
                var personalAnalyst = await _unitOfWork.PersonalAnalystRepository.GetLastPersonalAnalystAsync();
                if (personalAnalyst == null) throw new Exception("Fail in GetLastPersonalAnalyst!");
                var methods = await _unitOfWork.PersonalAnalystRepository.SuggestMethodAsync(personalAnalyst.Id, pageIndex: 1, pageSize: 10);


                List<MethodViewModel> filteredMethods = new List<MethodViewModel>();
                if (filterSuggestMethodModel.Category == MethodCategoryEnum.Skincare)
                {
                    filteredMethods = methods.Items
                        .Where(m => m.Category == 0) 
                        .Select(m => _mapper.Map<MethodViewModel>(m)) 
                        .ToList();
                }
                else if (filterSuggestMethodModel.Category == MethodCategoryEnum.Makeup)
                {
                    filteredMethods = methods.Items
                        .Where(m => m.Category == 1) 
                        .Select(m => _mapper.Map<MethodViewModel>(m)) 
                        .ToList();
                }


              
                if (filteredMethods == null || filteredMethods.Count == 0)
                {
                    response.Data = null;
                    response.isSuccess = true;
                    response.Message = "Không tìm thấy phương pháp cho bạn!";
                    return response;
                }

                var pagination = new Pagination<MethodViewModel>()
                {
                    PageIndex = filterSuggestMethodModel.PageIndex,
                    PageSize = filterSuggestMethodModel.PageSize,
                    TotalItemsCount = methods.TotalItemsCount,
                    Items = filteredMethods
                };

                response.Data = pagination;
                response.isSuccess = true;
                response.Message = "Successfully!";
            }
            catch (DbException ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<SkinListViewModel>> SkinListByLoginAsync() 
        {
            var response = new ApiResponse<SkinListViewModel>();
            try
            {
                var personalAnalyst = await _unitOfWork.PersonalAnalystRepository.GetLastPersonalAnalystDetailAsync();
                var personlAnalystDetails =  personalAnalyst.PersonalAnalystDetails.ToList();
                var skinListViewModel = new SkinListViewModel();
                foreach (var personlAnalystDetail in personlAnalystDetails)
                {
                    if (personlAnalystDetail.Skins.Category == false) 
                    {
                        if (skinListViewModel.SkinConditions != null) skinListViewModel.SkinConditions.Add(personlAnalystDetail.Skins.SkinsName); 
                    }  
                    else skinListViewModel.SkinType = personlAnalystDetail.Skins.SkinsName;
                }
                response.Data = skinListViewModel;
                response.isSuccess = true;
                response.Message = "Successfull!";
            }
            catch (Exception ex) 
            {
                response.Data = null;
                response.isSuccess = true;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
