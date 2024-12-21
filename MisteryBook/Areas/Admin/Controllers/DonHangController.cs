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
        private readonly WebsiteBanSachContext   _context;

        // Constructor để inject logger và DbContext vào controller
        public DonHangController(ILogger<DonHangController> logger, WebsiteBanSachContext context)
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
            ViewData["ActiveMenu"] = "DonHang";
            return View();
        }

  public async Task<IActionResult> TraCuuDonHangAsync()
{
    var donHangList = await _context.DonHangs
        .Include(d => d.MaKhNavigation)  // Nạp thông tin khách hàng (User) của MaKh
        .Include(d => d.MaNvNavigation)  // Nạp thông tin nhân viên (User) của MaNv
        .ToListAsync();

    if (donHangList == null || !donHangList.Any())
    {
        return View("NoData");
    }

    ViewData["ActiveMenu"] = "DonHang";
    return View(donHangList);  // Truyền đúng model vào view
}


        public IActionResult BaoCaoThongKe()
        {
          
            return View();
        }
    }
}
