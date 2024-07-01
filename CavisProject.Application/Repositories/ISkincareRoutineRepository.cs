using CavisProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Application.Repositories
{
    public interface ISkincareRoutineRepository : IGenericRepository<SkincareRoutine>
    { 
       Task<bool> CheckExistSkincareRoutine(string userId);
    }
}
