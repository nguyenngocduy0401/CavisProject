using CavisProject.Application.Commons;
using CavisProject.Application.Interfaces;
using CavisProject.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class PersonalAnalystDetailService : IPersonalAnalystDetailService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IClaimsService _claimsService;
        public readonly UserManager<User> _userManager;
        public PersonalAnalystDetailService(IUnitOfWork unitOfWork, IClaimsService claimsService, UserManager<User> userManager)
        {
            _claimsService = claimsService;
            _userManager = userManager; 
            _unitOfWork = unitOfWork;
        }
        
    }
}
