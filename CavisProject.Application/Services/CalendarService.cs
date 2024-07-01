using AutoMapper;
using CavisProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        public CalendarService(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;
        }

    }
}
