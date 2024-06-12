using CavisProject.Application.Commons;
using CavisProject.Application.ViewModels.RegistPreniumViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<RegistPremiumViewModel>> RegistPremium(RegistPremiumViewModel registPremiumViewModel);
        Task<ApiResponse<UpgradeToPremiumViewModel>> UpgradeToPremium(UpgradeToPremiumViewModel upgradeToPremiumViewModel);
    }
}
