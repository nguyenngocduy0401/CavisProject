using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Enums
{
    public enum UserPremiumStatusEnum
    {
       
        NotActivated = 0, // Chưa được kích hoạt (status = 0)
        Active = 1,      // Đang sử dụng premium (status = 1)
    }
}
