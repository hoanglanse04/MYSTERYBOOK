using Microsoft.AspNetCore.Mvc;

namespace SALEAPP.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
