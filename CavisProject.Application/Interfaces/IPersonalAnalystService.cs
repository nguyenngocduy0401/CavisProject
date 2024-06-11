using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IPersonalAnalystService
    {
        Task<ApiResponse<Pagination<ProductViewModel>>> SuggestProduct(string personalAnalystId);
        Task<ApiResponse<bool>> CreatePersonalAnalystByLoginAsync(ListSkinPersonalModel listSkinPersonalModel);
        Task<ApiResponse<Pagination<PersonalAnalystViewModel>>> FilterPersonalAnalystAsync(
            FilterPersonalAnalystModel filterPersonalAnalystModel);
    }
}
