using Microsoft.AspNetCore.Mvc;

namespace SALEAPP.Controllers
{
    public class PubLisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
