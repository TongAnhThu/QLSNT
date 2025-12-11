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
        private readonly ISuKienHanhChinhRepository _suKienRepo;
        public LichSuSapNhapController(
            ILichSuSapNhapRepository repo,
            ITinhCuRepository tinhCuRepo,
            ITinhMoiRepository tinhMoiRepo,
            IXaCuRepository xaCuRepo,
            IXaMoiRepository xaMoiRepo,
            ISuKienHanhChinhRepository suKienRepo)
        {
            _repo = repo;
            _tinhCuRepo = tinhCuRepo;
            _tinhMoiRepo = tinhMoiRepo;
            _xaCuRepo = xaCuRepo;
            _xaMoiRepo = xaMoiRepo;
            _suKienRepo = suKienRepo;
        }

        // Index
        public async Task<IActionResult> Index(string? search)
        {
            List<LichSuSapNhap> list;

            if (string.IsNullOrWhiteSpace(search))
            {
                // lấy tất cả, include đầy đủ navigation
                list = await _repo.GetAllAsync(includeTinhs: true, includeXas: true);
            }
            else
            {
                // tìm kiếm, vẫn include navigation để view hiển thị đúng
                list = await _repo.SearchAsync(search, includeTinhs: true, includeXas: true);
            }

            ViewBag.Search = search;
            return View(list);
        }



        // Details
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return RedirectToAction(nameof(Index));

            // lấy bản ghi kèm navigation
            var item = await _repo.GetByIdAsync(id, includeTinhs: true, includeXas: true);

            if (item == null)
                return RedirectToAction(nameof(Index));

            return View(item);
        }


        // Hàm nạp dropdown riêng cho tỉnh cũ/mới và xã cũ/mới
        private async Task LoadDropdowns()
        {
            var tinhCus = await _tinhCuRepo.GetAllAsync();
            ViewBag.TinhCuList = new SelectList(tinhCus ?? new List<TinhCu>(), "MaTinhCu", "TenTinhCu");

            var tinhMois = await _tinhMoiRepo.GetAllAsync();
            ViewBag.TinhMoiList = new SelectList(tinhMois ?? new List<TinhMoi>(), "MaTinhMoi", "TenTinhMoi");

            var xaCus = await _xaCuRepo.GetAllAsync();
            ViewBag.XaCuList = new SelectList(xaCus ?? new List<XaCu>(), "MaXaCu", "TenXaCu");

            var xaMois = await _xaMoiRepo.GetAllAsync();
            ViewBag.XaMoiList = new SelectList(xaMois ?? new List<XaMoi>(), "MaXaMoi", "TenXaMoi");

            // thêm sự kiện hành chính
            var suKiens = await _suKienRepo.GetAllAsync();
            ViewBag.SuKienHanhChinhList = new SelectList(
                suKiens ?? new List<SuKienHanhChinh>(),
                "SoNghiDinh", 
                "TenSK"       
            );

        }


        // GET: Create
        public async Task<IActionResult> Create()
        {
            var model = new CreateLSSN
            {
                TinhCuList = await _tinhCuRepo.GetAllAsync(),
                TinhMoiList = await _tinhMoiRepo.GetAllAsync(),
                XaCuList = await _xaCuRepo.GetAllAsync(),
                XaMoiList = await _xaMoiRepo.GetAllAsync(),
                SuKienHanhChinhList = (await _suKienRepo.GetAllAsync()).ToList()
            };
            return View(model);
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLSSN model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(); // nạp lại dropdown
                return View(model);
            }

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

            if (model.Loai == "Tinh" && model.MaTinhCu != null && model.MaTinhMoi != null)
            {
                entity.LssnTinhs.Add(new LssnTinh
                {
                    MaLSSN = entity.MaLSSN,
                    MaTinhCu = model.MaTinhCu.Value,
                    MaTinhMoi = model.MaTinhMoi.Value
                });
            }

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
        // GET: Edit
        public async Task<IActionResult> Edit(string id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            var suKiens = await _suKienRepo.GetAllAsync();
            // truyền thêm selectedValue = entity.SoNghiDinh
            ViewBag.SuKienHanhChinhList = new SelectList(
                suKiens,
                "SoNghiDinh", // value
                "TenSK",      // text hiển thị
                entity.SoNghiDinh // giá trị đang chọn
            );

            return View(entity);
        }


        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LichSuSapNhap model)
        {
            if (!ModelState.IsValid)
            {
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
