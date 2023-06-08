using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModels.System.Users;

namespace WebAdmin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            return View();
        }
    }
}
