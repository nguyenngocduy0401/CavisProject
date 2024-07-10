using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.SkincareRoutineViewModels;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface ISkincareRoutineService
    {
        Task<ApiResponse<SkincareRoutineViewModel>> GetSkincareRoutineByLogin();
        Task<ApiResponse<bool>> UpdateSkincareRoutineByIdAsync(UpdateSkincareRoutineModel updateSkincareRoutineModel, Guid id);
    }
}
