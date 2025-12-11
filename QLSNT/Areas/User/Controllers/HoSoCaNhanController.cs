using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLSNT.Areas.User.ViewModel;
using QLSNT.Models;
using QLSNT.Repositories;
using QLSNT.ViewModels;

namespace QLSNT.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "NguoiDan")] // 👈 chỉ người dân mới vào được area này
    public class HoSoCaNhanController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly INguoiDanRepository _nguoiDanRepo;
        private readonly IThuongTruRepository _thuongTruRepo;
        private readonly ITamTruRepository _tamTruRepo;

        public HoSoCaNhanController(
            UserManager<IdentityUser> userManager,
            INguoiDanRepository nguoiDanRepo,
            IThuongTruRepository thuongTruRepo,
            ITamTruRepository tamTruRepo)
        {
            _userManager = userManager;
            _nguoiDanRepo = nguoiDanRepo;
            _thuongTruRepo = thuongTruRepo;
            _tamTruRepo = tamTruRepo;
        }

        // GET: /User/HoSoCaNhan
        public async Task<IActionResult> Index()
        {
            // 1. Lấy user Identity đang đăng nhập
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge(); // ép quay về login
            }

            // 2. Tìm bản ghi NguoiDan tương ứng
            // Giả sử NguoiDan có cột IdentityUserId map với AspNetUsers.Id
            var nguoiDan = await _nguoiDanRepo.GetByIdentityUserIdAsync(user.Id);
            if (nguoiDan == null)
            {
                return NotFound("Không tìm thấy thông tin người dân tương ứng với tài khoản này.");
            }

            // 3. Lấy địa chỉ thường trú hiện tại
            var thuongTruHienTai =
                await _thuongTruRepo.GetThuongTruHienTaiByNguoiDanIdAsync(nguoiDan.MaCCCD);

            // 4. Lấy danh sách tạm trú còn hiệu lực
            var danhSachTamTru =
                await _tamTruRepo.GetTamTruHieuLucByNguoiDanIdAsync(nguoiDan.MaCCCD);

            // 5. Đưa vào ViewModel
            var vm = new HoSoCaNhanViewModel
            {
                NguoiDan = nguoiDan,
                ThuongTruHienTai = thuongTruHienTai,
                DanhSachTamTru = danhSachTamTru
            };

            return View(vm); // => Areas/User/Views/HoSoCaNhan/Index.cshtml
        }
    }
}
