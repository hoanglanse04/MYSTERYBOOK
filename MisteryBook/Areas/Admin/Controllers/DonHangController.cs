using Microsoft.AspNetCore.Mvc;

namespace MisteryBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
      
        public IActionResult TaoDonHang()
        {
            return View();
        }



    public IActionResult TraCuuDonHang()
        {
            return View();
        }


          public IActionResult BaoCaoThongKe()
        {
            return View();
        }




        






    }
}
