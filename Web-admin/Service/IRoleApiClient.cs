using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.CommonDTO;
using ViewModels.System.Roles;

namespace Web_admin.Service
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}
