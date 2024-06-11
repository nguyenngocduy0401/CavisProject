using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
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
        public  PersonalAnalystService(IUnitOfWork unitOfWork, IMapper mapper,
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
                var personalAnalyst=await _unitOfWork.PersonalAnalystRepository.GetFilterAsync(
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
                    { PersonalAnalystId = personAnalystId,
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

        public async Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProduct(string personalAnalystId)
        {
            var response = new ApiResponse<Pagination<ProductViewModel>>();
            try
            {
                var personalId = Guid.Parse(personalAnalystId);
                var personal = _unitOfWork.PersonalAnalystRepository.Find(s => s.Id == personalId);
                if (personal == null)
                {
                    throw new Exception("not exist");
                }
                else
                {
                    var personalAnalyst = await _unitOfWork.PersonalAnalystRepository.GetByIdAsync(personalId);
                    if (personalAnalyst == null)
                    {
                        throw new Exception("Personal analyst not found.");

                    }
                    var productList = new List<Product>();
                    var skinIds = await _unitOfWork.PersonalAnalystRepository.GetSkinIdsByPersonalAnalystIdAsync(personalAnalystId);
                    foreach (var skinId in skinIds)
                    {
                        if (skinId.HasValue)
                        {
                            var productsBySkin = await _unitOfWork.ProductRepository.GetProductsBySkinIdAsync(skinId.Value);
                            productList.AddRange(productsBySkin);
                        }
                    }

                    var productViewModels = _mapper.Map<List<ProductViewModel>>(productList);
                    var pagination = new Pagination<ProductViewModel>
                    {
                        PageIndex = 1,
                        PageSize = productViewModels.Count,
                        TotalItemsCount = productViewModels.Count,
                        Items = productViewModels
                    };

                    response.Data = pagination;
                    response.isSuccess = true;
                    response.Message = "Suggested products fetched successfully.";
                }
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
    }
}
