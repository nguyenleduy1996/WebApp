using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModels.CommonDTO;

namespace Web_admin.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("_Default", result));
        }
    }
}
