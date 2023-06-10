using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ViewModels.CommonDTO;
using ViewModels.System.Users;

namespace Web_admin.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request);

        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}
