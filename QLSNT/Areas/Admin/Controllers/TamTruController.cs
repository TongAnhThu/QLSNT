using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class TamTruController : Controller
    {
        private readonly ITamTruRepository _repo;

        public TamTruController(ITamTruRepository repo)
        {
            _repo = repo;
        }

        // GET: /TamTru
        public async Task<IActionResult> Index(string? keyword)
        {
            List<TamTru> list;

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

        // GET: /TamTru/Details
        public async Task<IActionResult> Details(string maXaMoi, string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /TamTru/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TamTru/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TamTru model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /TamTru/Edit
        public async Task<IActionResult> Edit(string maXaMoi, string maCCCD)
        {
            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /TamTru/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TamTru model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /TamTru/Delete
        public async Task<IActionResult> Delete(string maXaMoi, string maCCCD)
        {
            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /TamTru/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string maXaMoi, string maCCCD)
        {
            await _repo.DeleteAsync(maXaMoi, maCCCD);
            return RedirectToAction(nameof(Index));
        }
    }
}
