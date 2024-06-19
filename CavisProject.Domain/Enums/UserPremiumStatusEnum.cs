using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavisProject.Domain.Enums
{
    public enum UserPremiumStatusEnum
    {
        All = 0,        // Tất cả các trạng thái
        NotActivated = 1, // Chưa được kích hoạt (status = 0)
        Active = 2,      // Đang sử dụng premium (status = 1)
        Expired = 3      // Hết hạn (status = 2)
    }
}
