using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class LssnTinhController : Controller
    {
        private readonly ILssnTinhRepository _lssnTinhRepo;
        private readonly ILichSuSapNhapRepository _lssnRepo;
        private readonly ITinhCuRepository _tinhCuRepo;
        private readonly ITinhMoiRepository _tinhMoiRepo;

        public LssnTinhController(
            ILssnTinhRepository lssnTinhRepo,
            ILichSuSapNhapRepository lssnRepo,
            ITinhCuRepository tinhCuRepo,
            ITinhMoiRepository tinhMoiRepo)
        {
            _lssnTinhRepo = lssnTinhRepo;
            _lssnRepo = lssnRepo;
            _tinhCuRepo = tinhCuRepo;
            _tinhMoiRepo = tinhMoiRepo;
        }

        // ================== INDEX ==================
        // GET: /LssnTinh
        public async Task<IActionResult> Index()
        {
            var list = await _lssnTinhRepo.GetAllAsync();
            return View(list);
        }

        // ================== DETAILS ==================
        // GET: /LssnTinh/Details/LS001
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var item = await _lssnTinhRepo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // ================== CREATE ==================
        // GET: /LssnTinh/Create
        // (nếu muốn tạo theo từng LSSN, bạn có thể dùng Create?maLssn=LS001 rồi gán sẵn)
        public async Task<IActionResult> Create(string? maLssn)
        {
            await LoadTinhDropDownsAsync();

            var model = new LssnTinh();

            if (!string.IsNullOrWhiteSpace(maLssn))
            {
                model.MaLSSN = maLssn.Trim();
                // optional: kiểm tra tồn tại LichSuSapNhap
                var lssn = await _lssnRepo.GetByIdAsync(model.MaLSSN);
                ViewBag.LichSuSapNhap = lssn;
            }

            return View(model);
        }

        // POST: /LssnTinh/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LssnTinh model)
        {
            if (!ModelState.IsValid)
            {
                await LoadTinhDropDownsAsync(model.MaTinhCu, model.MaTinhMoi);
                // nếu có LichSuSapNhap thì nạp lại để hiển thị
                var lssn = await _lssnRepo.GetByIdAsync(model.MaLSSN);
                ViewBag.LichSuSapNhap = lssn;
                return View(model);
            }

            await _lssnTinhRepo.AddAsync(model);

            // Nếu bạn muốn quay về chi tiết lịch sử sáp nhập:
            // return RedirectToAction("Details", "LichSuSapNhap", new { id = model.MaLSSN });

            // Còn nếu chỉ quay về danh sách LssnTinh:
            return RedirectToAction(nameof(Index));
        }

        // ================== EDIT ==================
        // GET: /LssnTinh/Edit/LS001
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var item = await _lssnTinhRepo.GetByIdAsync(id);
            if (item == null) return NotFound();

            await LoadTinhDropDownsAsync(item.MaTinhCu, item.MaTinhMoi);

            var lssn = await _lssnRepo.GetByIdAsync(item.MaLSSN);
            ViewBag.LichSuSapNhap = lssn;

            return View(item);
        }

        // POST: /LssnTinh/Edit/LS001
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, LssnTinh model)
        {
            if (string.IsNullOrWhiteSpace(id) || id != model.MaLSSN)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                await LoadTinhDropDownsAsync(model.MaTinhCu, model.MaTinhMoi);
                var lssn = await _lssnRepo.GetByIdAsync(model.MaLSSN);
                ViewBag.LichSuSapNhap = lssn;
                return View(model);
            }

            await _lssnTinhRepo.UpdateAsync(model);

            // Tuỳ bạn muốn về đâu:
            // return RedirectToAction("Details", "LichSuSapNhap", new { id = model.MaLSSN });
            return RedirectToAction(nameof(Index));
        }

        // ================== DELETE ==================
        // GET: /LssnTinh/Delete/LS001
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var item = await _lssnTinhRepo.GetByIdAsync(id);
            if (item == null) return NotFound();

            var lssn = await _lssnRepo.GetByIdAsync(item.MaLSSN);
            ViewBag.LichSuSapNhap = lssn;

            return View(item);
        }

        // POST: /LssnTinh/Delete/LS001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var item = await _lssnTinhRepo.GetByIdAsync(id);
            if (item == null) return NotFound();

            var maLssn = item.MaLSSN;

            await _lssnTinhRepo.DeleteAsync(id);

            // Tuỳ ý quay lại LichSuSapNhap hay Index
            // return RedirectToAction("Details", "LichSuSapNhap", new { id = maLssn });
            return RedirectToAction(nameof(Index));
        }

        // ================== HELPER: LOAD DROPDOWN TỈNH ==================
        private async Task LoadTinhDropDownsAsync(string? selectedTinhCu = null, string? selectedTinhMoi = null)
        {
            var tinhCuList = await _tinhCuRepo.GetAllAsync();
            var tinhMoiList = await _tinhMoiRepo.GetAllAsync();

            ViewBag.TinhCuList = new SelectList(tinhCuList, "MaTinhCu", "TenTinhCu", selectedTinhCu);
            ViewBag.TinhMoiList = new SelectList(tinhMoiList, "MaTinh", "TenTinh", selectedTinhMoi);
        }
    }
}
