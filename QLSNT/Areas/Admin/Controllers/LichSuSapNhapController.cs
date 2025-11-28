using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class LichSuSapNhapController : Controller
    {
        private readonly ILichSuSapNhapRepository _repo;

        public LichSuSapNhapController(ILichSuSapNhapRepository repo)
        {
            _repo = repo;
        }

        // GET: /LichSuSapNhap
        // Hỗ trợ tìm kiếm đơn giản qua ?keyword=
        public async Task<IActionResult> Index(string? keyword)
        {
            List<LichSuSapNhap> list;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                list = await _repo.SearchAsync(keyword);
                ViewBag.Keyword = keyword;
            }
            else
            {
                list = await _repo.GetAllAsync();
            }

            return View(list);
        }

        // GET: /LichSuSapNhap/Details/LS001
        // Dùng GetDetailsAsync để include LssnTinh, LssnXa
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var item = await _repo.GetDetailsAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /LichSuSapNhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /LichSuSapNhap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LichSuSapNhap model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /LichSuSapNhap/Edit/LS001
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            // Edit chỉ cần bản ghi nhẹ, không cần include
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /LichSuSapNhap/Edit/LS001
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

        // GET: /LichSuSapNhap/Delete/LS001
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /LichSuSapNhap/Delete/LS001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                await _repo.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        // Tuỳ chọn: lọc theo Số nghị định cụ thể
        // GET: /LichSuSapNhap/BySoNghiDinh?so=123/2020/NĐ-CP
        public async Task<IActionResult> BySoNghiDinh(string so)
        {
            if (string.IsNullOrWhiteSpace(so))
                return RedirectToAction(nameof(Index));

            var list = await _repo.GetBySoNghiDinhAsync(so.Trim());
            ViewBag.SoNghiDinh = so;

            // Tái dùng view Index cho nhanh
            return View("Index", list);
        }
    }
}
