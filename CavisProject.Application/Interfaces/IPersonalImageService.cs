using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PersonalImageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IPersonalImageService
    {
        Task<ApiResponse<Pagination<PersonalImageViewModel>>> FilterPersonalImageByLoginAsync(FilterPersonalImageViewModel filterPersonalImageViewModel);
        Task<ApiResponse<bool>> CreatePersonalImageByLoginAsync(CreatePersonalImageViewModel createPersonalImageViewModel);
        Task<ApiResponse<PersonalImageViewModel>> GetPersonalImageByIdAsync(Guid id);
    }
}
