using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation_With_AJAX.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
