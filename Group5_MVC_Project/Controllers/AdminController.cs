using Microsoft.AspNetCore.Mvc;

namespace Group5_MVC_Project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
