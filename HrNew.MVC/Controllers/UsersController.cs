using Microsoft.AspNetCore.Mvc;

namespace HrNew.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
