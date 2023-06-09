using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CommonDTO;
using ViewModels.System.Users;

namespace Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest requset);
        Task<bool> Register(RegisterRequest request);
        Task<PagedResult<UserVm>> GetUsersPaging(GetUserPagingRequest request);
     }
}
