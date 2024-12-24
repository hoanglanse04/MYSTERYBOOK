using Microsoft.AspNetCore.Mvc;

namespace MisteryBook.Controllers
{
    public class SingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
