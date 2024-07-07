using AutoMapper;
using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.Repositories;
using CavisProject.Application.ViewModels.SkincareRoutineViewModels;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class SkincareRoutineService : ISkincareRoutineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public SkincareRoutineService(IUnitOfWork unitOfWork, IClaimsService claimsService,
            UserManager<User> userManager, IMapper mapper)
        {
            _claimsService = claimsService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<SkincareRoutineViewModel>> GetSkincareRoutineByLogin()
        {
            var response = new ApiResponse<SkincareRoutineViewModel>();
            try
            {
                var userId = _claimsService.GetCurrentUserId.ToString();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new Exception("Login first!");
                if(!(await _unitOfWork.SkincareRoutineRepository.CheckExistSkincareRoutine(user.Id)))
                {
                    var skincare = new SkincareRoutine();
                    skincare.UserId = userId;
                    skincare.Morning = false;
                    skincare.Night = false;
                    await _unitOfWork.SkincareRoutineRepository.AddAsync(skincare);
                    var isSucccess= await _unitOfWork.SaveChangeAsync() > 0;
                    if (!isSucccess) throw new Exception("Can not create new!");
                }
                var filter = (Expression<Func<SkincareRoutine, bool>>)(e => e.UserId == userId);
                Func<IQueryable<SkincareRoutine>, IOrderedQueryable<SkincareRoutine>>? orderBy = q => q.OrderByDescending(e => e.CreationDate);
                var skincareRoutine =  await _unitOfWork.SkincareRoutineRepository.GetFilterAsync(filter : filter, orderBy : orderBy, pageSize:1, pageIndex:1);
                if (skincareRoutine.Items == null) throw new Exception("Not found!");
                var skincareRoutineViewModel = _mapper.Map<SkincareRoutineViewModel>(skincareRoutine.Items.FirstOrDefault());
                response.Data = skincareRoutineViewModel;
                response.isSuccess = true;
                response.Message ="Successfull!";
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiResponse<bool>> UpdateSkincareRoutineByIdAsync(UpdateSkincareRoutineModel updateSkincareRoutineModel, Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var skincareRoutine = await _unitOfWork.SkincareRoutineRepository.GetByIdAsync(id);
                if (skincareRoutine == null) throw new Exception("Not found!");
                if (skincareRoutine.Morning == true && skincareRoutine.Night == true) 
                {
                    response.Data = false;
                    response.isSuccess = true;
                    response.Message = "Quá trình đã hoàn thành không thể cập nhật lại!";
                    return response;
                }
                if (updateSkincareRoutineModel.Morning != null) skincareRoutine.Morning = (bool)updateSkincareRoutineModel.Morning;
                if (updateSkincareRoutineModel.Night != null) skincareRoutine.Night = (bool)updateSkincareRoutineModel.Night;
                
                _unitOfWork.SkincareRoutineRepository.Update(skincareRoutine);
                var isSucccess = await _unitOfWork.SaveChangeAsync() > 0;
                if (!isSucccess) throw new Exception("Can not update!");
                response.Data = true;
                response.isSuccess = true;
                response.Message = "Successfull!";
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.isSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
