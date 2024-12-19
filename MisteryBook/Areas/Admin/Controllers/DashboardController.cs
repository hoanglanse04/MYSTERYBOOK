using Microsoft.AspNetCore.Mvc;

namespace MisteryBook.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        [Route("admin/dashboard")]
        public IActionResult Index()
        {
            
            return View("~/Areas/Admin/Views/DashBoard/Index.cshtml");
        }
    }
}
