using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface IAppointmentRepository :IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate, string userId);
       
        Task<List<Appointment>> GetAppointmentsForUserAsync(string userId, DateTime? date, TimeSpan? startTime, TimeSpan? endTime, int pageIndex, int pageSize);
        Task<bool> IsExpertAvailable(string expertId, DateTime? date, TimeSpan? startTime, TimeSpan? endTime);
    }
}
