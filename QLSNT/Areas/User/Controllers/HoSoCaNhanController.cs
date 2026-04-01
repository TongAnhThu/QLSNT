using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLSNT.Areas.User.ViewModel;
using QLSNT.Repositories;
using System.Threading.Tasks;

namespace QLSNT.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")] // chỉ cho phép người dân đã đăng nhập với role User
    public class ThongTinCaNhanController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly INguoiDanRepository _nguoiDanRepo;
        private readonly IThuongTruRepository _thuongTruRepo;
        private readonly ITamTruRepository _tamTruRepo;

        public ThongTinCaNhanController(UserManager<IdentityUser> userManager,
                                        INguoiDanRepository nguoiDanRepo,
                                        IThuongTruRepository thuongTruRepo,
                                        ITamTruRepository tamTruRepo)
        {
            _userManager = userManager;
            _nguoiDanRepo = nguoiDanRepo;
            _thuongTruRepo = thuongTruRepo;
            _tamTruRepo = tamTruRepo;
        }

        // Người dân xem hồ sơ cá nhân (cả thường trú và tạm trú)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge(); // chưa đăng nhập

            // Vì UserName = CCCD, ta dùng UserName để tìm NguoiDan
            var nguoiDan = await _nguoiDanRepo.GetByIdentityUserIdAsync(user.UserName);
            if (nguoiDan == null)
            {
                ViewBag.Message = "Chưa có hồ sơ cá nhân trong hệ thống.";
                return View();
            }

            // Lấy địa chỉ thường trú hiện tại
            var thuongTru = await _thuongTruRepo.GetThuongTruHienTaiByNguoiDanIdAsync(nguoiDan.MaCCCD);

            // Lấy danh sách tạm trú còn hiệu lực
            var tamTruList = await _tamTruRepo.GetTamTruHieuLucByNguoiDanIdAsync(nguoiDan.MaCCCD);

            // Gom vào ViewModel
            var vm = new HoSoCaNhanViewModel
            {
                NguoiDan = nguoiDan,
                ThuongTruHienTai = thuongTru,
                DanhSachTamTru = tamTruList
            };

            return View(vm); // => Areas/User/Views/ThongTinCaNhan/Index.cshtml
        }
    }
}
