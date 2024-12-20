using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MisteryBook.Models;

namespace MisteryBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private readonly ILogger<DonHangController> _logger;
        private readonly QuanLyCuaHangSachContext _context;

        // Constructor để inject logger và DbContext vào controller
        public DonHangController(ILogger<DonHangController> logger, QuanLyCuaHangSachContext context)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaoDonHang()
        {
            return View();
        }

   public async Task<IActionResult> TraCuuDonHangAsync()
{
    var donHangList = await _context.HoaDonMuas.ToListAsync();
    
    if (donHangList == null || !donHangList.Any())
    {
        return View("NoData");
    }

    return View(donHangList);  // Truyền đúng model vào view
}

        public IActionResult BaoCaoThongKe()
        {
            return View();
        }
    }
}
