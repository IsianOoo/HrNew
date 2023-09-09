using Microsoft.AspNetCore.Mvc;

namespace HrNew.API.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
