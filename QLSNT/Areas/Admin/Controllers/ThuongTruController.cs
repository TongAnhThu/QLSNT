using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class ThuongTruController : Controller
    {
        private readonly IThuongTruRepository _repo;

        public ThuongTruController(IThuongTruRepository repo)
        {
            _repo = repo;
        }

        // GET: /ThuongTru
        // Hỗ trợ tìm kiếm theo keyword (CCCD, xã, địa chỉ...)
        public async Task<IActionResult> Index(string? keyword)
        {
            IEnumerable<ThuongTru> list;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                list = await _repo.SearchAsync(keyword);
            }
            else
            {
                list = await _repo.GetAllAsync();
            }

            return View(list);
        }



        // GET: /ThuongTru/Details?maXaMoi=...&maCCCD=...
        public async Task<IActionResult> Details(string maXaMoi, string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /ThuongTru/Create
        public IActionResult Create()
        {
            // Nếu sau này bạn muốn dropdown:
            // - ViewBag.DanhSachXaMoi
            // - ViewBag.DanhSachNguoiDan
            return View();
        }

        // POST: /ThuongTru/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThuongTru model)
        {
            if (!ModelState.IsValid)
            {
                // load lại dropdown nếu có
                return View(model);
            }

            // Ở đây MaXaMoi + MaCCCD là PK, không identity nên bắt buộc model phải có đủ 2 cái
            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /ThuongTru/Edit?maXaMoi=...&maCCCD=...
        public async Task<IActionResult> Edit(string maXaMoi, string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            // load dropdown nếu cần
            return View(item);
        }

        // POST: /ThuongTru/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ThuongTru model)
        {
            // Lưu ý: để Update đúng, View phải giữ nguyên MaXaMoi + MaCCCD (readonly/hidden),
            // không cho sửa PK trên form.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /ThuongTru/Delete?maXaMoi=...&maCCCD=...
        public async Task<IActionResult> Delete(string maXaMoi, string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /ThuongTru/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string maXaMoi, string maCCCD)
        {
            if (!string.IsNullOrWhiteSpace(maXaMoi) && !string.IsNullOrWhiteSpace(maCCCD))
            {
                await _repo.DeleteAsync(maXaMoi, maCCCD);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
