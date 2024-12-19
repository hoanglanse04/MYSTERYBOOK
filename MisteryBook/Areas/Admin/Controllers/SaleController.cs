using Microsoft.AspNetCore.Mvc;

namespace SALEAPP.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
