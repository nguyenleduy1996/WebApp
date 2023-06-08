using System.Threading.Tasks;
using ViewModels.System.Users;

namespace Web_admin.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
