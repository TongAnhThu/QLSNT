using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLSNT.Areas.Admin.ViewModel;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class LichSuSapNhapController : Controller
    {
        private readonly ILichSuSapNhapRepository _repo;
        private readonly ITinhCuRepository _tinhCuRepo;
        private readonly ITinhMoiRepository _tinhMoiRepo;
        private readonly IXaCuRepository _xaCuRepo;
        private readonly IXaMoiRepository _xaMoiRepo;

        public LichSuSapNhapController(
            ILichSuSapNhapRepository repo,
            ITinhCuRepository tinhCuRepo,
            ITinhMoiRepository tinhMoiRepo,
            IXaCuRepository xaCuRepo,
            IXaMoiRepository xaMoiRepo)
        {
            _repo = repo;
            _tinhCuRepo = tinhCuRepo;
            _tinhMoiRepo = tinhMoiRepo;
            _xaCuRepo = xaCuRepo;
            _xaMoiRepo = xaMoiRepo;
        }

        // Index
        public async Task<IActionResult> Index(string? search)
        {
            var list = string.IsNullOrWhiteSpace(search)
                ? await _repo.GetAllAsync()
                : await _repo.SearchAsync(search);

            ViewBag.Search = search;
            return View(list);
        }

        // Details
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction(nameof(Index));

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return RedirectToAction(nameof(Index));

            return View(item);
        }

        // Hàm nạp dropdown riêng cho tỉnh cũ/mới và xã cũ/mới
        private async Task LoadDropdowns()
        {
            var tinhCus = await _tinhCuRepo.GetAllAsync();
            ViewBag.TinhCuList = new SelectList(tinhCus ?? new List<TinhCu>(), "MaTinh", "TenTinh");

            var tinhMois = await _tinhMoiRepo.GetAllAsync();
            ViewBag.TinhMoiList = new SelectList(tinhMois ?? new List<TinhMoi>(), "MaTinh", "TenTinh");

            var xaCus = await _xaCuRepo.GetAllAsync();
            ViewBag.XaCuList = new SelectList(xaCus ?? new List<XaCu>(), "MaXa", "TenXa");

            var xaMois = await _xaMoiRepo.GetAllAsync();
            ViewBag.XaMoiList = new SelectList(xaMois ?? new List<XaMoi>(), "MaXa", "TenXa");
        }


        // GET: Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLSSN model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns();
                return View(model);
            }

            // Sinh mã LSSN nhỏ gọn
            var count = await _repo.CountAsync();
            var newCode = "LSSN" + (count + 1).ToString("D3");

            var entity = new LichSuSapNhap
            {
                MaLSSN = newCode,
                SoNghiDinh = model.SoNghiDinh,
                NguoiTao = User.Identity?.Name,
                NgayTao = DateTime.Now,
                GhiChu = null,
                LssnTinhs = new List<LssnTinh>(),
                LssnXas = new List<LssnXa>()
            };

            // Nếu loại là Tỉnh
            if (model.Loai == "Tinh" && model.MaTinhCu != null && model.MaTinhMoi != null)
            {
                entity.LssnTinhs.Add(new LssnTinh
                {
                    MaLSSN = entity.MaLSSN,
                    MaTinhCu = model.MaTinhCu.Value,
                    MaTinhMoi = model.MaTinhMoi.Value
                });
            }

            // Nếu loại là Xã
            if (model.Loai == "Xa" && model.MaXaCu != null && model.MaXaMoi != null)
            {
                entity.LssnXas.Add(new LssnXa
                {
                    MaLSSN = entity.MaLSSN,
                    MaXaCu = model.MaXaCu.Value,
                    MaXaMoi = model.MaXaMoi.Value
                });
            }

            await _repo.AddAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        // Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction(nameof(Index));

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return RedirectToAction(nameof(Index));

            await LoadDropdowns();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LichSuSapNhap model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns();
                return View(model);
            }

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return RedirectToAction(nameof(Index));

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return RedirectToAction(nameof(Index));

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
