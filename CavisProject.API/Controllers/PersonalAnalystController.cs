using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Application.ViewModels.MethodViewModels;
using CavisProject.Application.ViewModels.PersonalAnalystViewModels;
using CavisProject.Application.ViewModels.ProductViewModel;
using CavisProject.Application.ViewModels.SkinTypeViewModels;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CavisProject.API.Controllers
{
    [Route("api/v1/personal-analysts")]
    public class PersonalAnalystController :ControllerBase
    {
        
        private readonly IPersonalAnalystService _personalAnalystService;
        public PersonalAnalystController(IPersonalAnalystService personalAnalystService)
        {
            _personalAnalystService = personalAnalystService;
        }
        
    }
}
