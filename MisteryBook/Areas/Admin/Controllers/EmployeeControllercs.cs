using Microsoft.AspNetCore.Mvc;

namespace SALEAPP.Controllers
{
    public class EmployeeControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
