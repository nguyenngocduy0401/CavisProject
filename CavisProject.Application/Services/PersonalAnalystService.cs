using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModel;
using CavisProject.Domain.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class PersonalAnalystService : IPersonalAnalystService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
  
        public  PersonalAnalystService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _claimsService = claimsService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
   
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
