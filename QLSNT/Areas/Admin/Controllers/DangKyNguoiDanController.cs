using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.ViewModels;
using QLSNT.Repositories;
using System;
using System.Threading.Tasks;

namespace QLSNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangKyNguoiDanController : Controller
    {
        private readonly INguoiDanRepository _nguoiDanRepo;
        private readonly IThuongTruRepository _thuongTruRepo;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IDanTocRepository _danTocRepo;
        private readonly ITonGiaoRepository _tonGiaoRepo;
        private readonly ITrinhDoVanHoaRepository _trinhDoRepo;
        private readonly IQuanHeChuHoRepository _quanHeChuHoRepo;
        private readonly ITinhMoiRepository _tinhRepo;
        private readonly IXaMoiRepository _xaMoiRepo;
        private readonly ILichSuDiaChiRepository _lichSuDiaChiRepo;
        public DangKyNguoiDanController(
            INguoiDanRepository nguoiDanRepo,
            IThuongTruRepository thuongTruRepo,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IDanTocRepository danTocRepo,
            ITonGiaoRepository tonGiaoRepo,
            ITrinhDoVanHoaRepository trinhDoRepo,
            IQuanHeChuHoRepository quanHeChuHoRepo,
            ITinhMoiRepository tinhRepo,
            IXaMoiRepository xaMoiRepo,
            ILichSuDiaChiRepository lichSuDiaChiRepo)
        {
            _nguoiDanRepo = nguoiDanRepo;
            _thuongTruRepo = thuongTruRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _danTocRepo = danTocRepo;
            _tonGiaoRepo = tonGiaoRepo;
            _trinhDoRepo = trinhDoRepo;
            _quanHeChuHoRepo = quanHeChuHoRepo;
            _tinhRepo = tinhRepo;
            _xaMoiRepo = xaMoiRepo;
            _lichSuDiaChiRepo = lichSuDiaChiRepo;
        }
        // ============================
        // Load dropdowns cho view
        // ============================
        private async Task LoadDropdownsAsync()
        {
            ViewBag.DanTocList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _danTocRepo.GetAllAsync(), "MaDanToc", "TenDanToc");
            ViewBag.TonGiaoList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _tonGiaoRepo.GetAllAsync(), "MaTonGiao", "TenTonGiao");
            ViewBag.TrinhDoList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _trinhDoRepo.GetAllAsync(), "MaTDVH", "TenTDVH");
            ViewBag.QuanHeChuHoList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _quanHeChuHoRepo.GetAllAsync(), "MaQHCH", "TenQHCH");
            ViewBag.TinhList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _tinhRepo.GetAllAsync(), "MaTinhMoi", "TenTinhMoi");
            ViewBag.XaList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(await _xaMoiRepo.GetAllAsync(), "MaXaMoi", "TenXaMoi");

            ViewBag.TinhTrangHonNhanList = new[]
            {
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Độc thân", "Độc thân"),
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Đã kết hôn", "Đã kết hôn"),
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Ly hôn", "Ly hôn"),
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Góa", "Góa")
            };

            ViewBag.TrangThaiCongDanList = new[]
            {
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Còn sống", "Còn sống"),
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Đã mất", "Đã mất"),
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem("Mất tích", "Mất tích")
            };
        }

        // ============================
        // BƯỚC 1: THÔNG TIN CƠ BẢN
        // ============================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownsAsync();
            return View("CreateBasic", new NguoiDan());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NguoiDan nguoiDan)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View("CreateBasic", nguoiDan);
            }

            // 1) Lưu người dân
            await _nguoiDanRepo.AddAsync(nguoiDan);
            string cccd = nguoiDan.MaCCCD;

            // 2) Tạo Identity User với CCCD làm username
            var user = new IdentityUser
            {
                UserName = cccd,
                Email = $"{cccd}@qlsnt.local",
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, cccd); // mật khẩu mặc định = CCCD
            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", $"{err.Code} - {err.Description}");
                }
                await LoadDropdownsAsync();
                return View("CreateBasic", nguoiDan);
            }

            // 3) Gán role mặc định "User"
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
            await _userManager.AddToRoleAsync(user, "User");

            // 4) Chuyển sang bước 2
            TempData["SuccessMessage"] = "Đăng ký người dân thành công. Vui lòng nhập địa chỉ thường trú!";
            return RedirectToAction("CreateDetails", new { maCCCD = cccd });
        }

        // ============================
        // BƯỚC 2: ĐỊA CHỈ THƯỜNG TRÚ
        // ============================
        [HttpGet]
        public async Task<IActionResult> CreateDetails(string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maCCCD))
                return RedirectToAction("Create");

            await LoadDropdownsAsync();
            var model = new NguoiDanCreateViewModel { MaCCCD = maCCCD };
            return View("CreateDetails", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetails(NguoiDanCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View("CreateDetails", model);
            }

            var thuongTru = new ThuongTru
            {
                MaCCCD = model.MaCCCD,
                MaXaMoi = model.MaXaMoi,
                DiaChi = model.DiaChiThuongTru,
                NgayDangKy = DateTime.Today
            };
            await _thuongTruRepo.AddAsync(thuongTru);

            TempData["SuccessMessage"] = "Đăng ký người dân hoàn tất!";
            return RedirectToAction("Index", "NguoiDan", new { area = "Admin" });
        }


        // ============================
        // EDIT THÔNG TIN CƠ BẢN
        // ============================
        [HttpGet]
        public async Task<IActionResult> Edit(string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maCCCD))
                return RedirectToAction("Index", "NguoiDan");

            var nguoiDan = await _nguoiDanRepo.GetByIdAsync(maCCCD);
            if (nguoiDan == null)
                return NotFound();

            await LoadDropdownsAsync();
            return View("EditBasic", nguoiDan);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NguoiDan nguoiDan)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View("EditBasic", nguoiDan);
            }

            await _nguoiDanRepo.UpdateAsync(nguoiDan);

            TempData["SuccessMessage"] = "Cập nhật thông tin cơ bản thành công!";
            return RedirectToAction("Index", "NguoiDan", new { area = "Admin" });
        }
        // ============================
        // EDIT ĐỊA CHỈ THƯỜNG TRÚ
        // ============================
        [HttpGet]
        public async Task<IActionResult> EditDetails(string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maCCCD))
                return RedirectToAction("Index", "NguoiDan");

            // Nếu repo chưa có GetByCCCDAsync, bạn có thể viết thêm hoặc dùng SearchAsync
            var thuongTru = await _thuongTruRepo.GetByCCCDAsync(maCCCD);
            if (thuongTru == null)
                return NotFound();

            var model = new NguoiDanCreateViewModel
            {
                MaCCCD = thuongTru.MaCCCD,
                MaXaMoi = thuongTru.MaXaMoi,
                DiaChiThuongTru = thuongTru.DiaChi
            };

            await LoadDropdownsAsync();
            return View("EditDetails", model);
        }
        
        [HttpPost]

        public async Task<IActionResult> EditDetails(NguoiDanCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdownsAsync();
                return View("EditDetails", model);
            }

            var thuongTru = await _thuongTruRepo.GetByCCCDAsync(model.MaCCCD);
            if (thuongTru == null)
                return NotFound();

            // Nếu địa chỉ thay đổi thì ghi lịch sử
            if (thuongTru.DiaChi != model.DiaChiThuongTru || thuongTru.MaXaMoi != model.MaXaMoi)
            {
                var lichSu = new LichSuDiaChi
                {
                    MaLichSuCuTru = await GenerateMaLichSuCuTruAsync(),
                    MaCCCD = thuongTru.MaCCCD,
                    DiaChiCu = thuongTru.DiaChi,
                    DiaChiMoi = model.DiaChiThuongTru,
                    NgayHieuLuc = DateTime.UtcNow,
                    NguoiTao = User.Identity?.Name,
                    NgayTao = DateTime.Now,

                    // Chỉ còn mã xã mới
                    MaXaMoi = model.MaXaMoi
                };
                await _lichSuDiaChiRepo.AddAsync(lichSu);
            }

            // Cập nhật thông tin mới
            thuongTru.MaXaMoi = model.MaXaMoi;
            thuongTru.DiaChi = model.DiaChiThuongTru;
            await _thuongTruRepo.UpdateAsync(thuongTru);

            return RedirectToAction("Index", "NguoiDan");
        }


        // ============================
        // XEM CHI TIẾT NGƯỜI DÂN
        // ============================
        [HttpGet]
        public async Task<IActionResult> Details(string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maCCCD))
                return RedirectToAction("Index", "NguoiDan");

            var nguoiDan = await _nguoiDanRepo.GetByIdAsync(maCCCD);
            if (nguoiDan == null)
                return NotFound();

            var thuongTru = await _thuongTruRepo.GetByCCCDAsync(maCCCD); // cần implement nếu chưa có

            var model = new NguoiDanDetailsViewModel
            {
                MaCCCD = nguoiDan.MaCCCD,
                MaXaMoi = thuongTru?.MaXaMoi,
                DiaChiThuongTru = thuongTru?.DiaChi,
                HoTen = nguoiDan.HoTen,
                NgaySinh = nguoiDan.NgaySinh,
                GioiTinh = nguoiDan.GioiTinh,
                MaDanToc = nguoiDan.MaDanToc,
                MaTonGiao = nguoiDan.MaTonGiao,
                MaTDVH = nguoiDan.MaTDVH,
                TinhTrangHonNhan = nguoiDan.TinhTrangHonNhan,
                TrangThaiCongDan = nguoiDan.TrangThaiCongDan
            };


            await LoadDropdownsAsync();
            return View("Details", model);
        }
        [HttpGet]
        public async Task<IActionResult> GetXaByTinh(int maTinhMoi)
        {
            var xaList = await _xaMoiRepo.GetByTinhAsync(maTinhMoi);
            var result = xaList.Select(x => new {
                maXaMoi = x.MaXaMoi,
                tenXaMoi = x.TenXaMoi
            });
            return Json(result);
        }
        private async Task<string> GenerateMaLichSuCuTruAsync()
        {
            var last = await _lichSuDiaChiRepo.GetLastCodeAsync(); // ví dụ lấy mã cuối cùng
            int number = 0;
            if (!string.IsNullOrEmpty(last) && last.Length > 2)
            {
                int.TryParse(last.Substring(2), out number);
            }
            return $"LS{(number + 1):D3}";
        }




    }

}
