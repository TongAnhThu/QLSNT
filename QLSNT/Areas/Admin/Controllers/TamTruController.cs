using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        public async Task<IActionResult> Details(int maXaMoi, string maCCCD)
        {
            // Check for invalid or missing IDs
            if (maXaMoi == 0 || string.IsNullOrWhiteSpace(maCCCD))
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
        public async Task<IActionResult> Edit(int maXaMoi, string maCCCD)
        {
            // Check for invalid or missing IDs
            if (maXaMoi == 0 || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

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
        public async Task<IActionResult> Delete(int maXaMoi, string maCCCD)
        {
            // Check for invalid or missing IDs
            if (maXaMoi == 0 || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

            var item = await _repo.GetByIdAsync(maXaMoi, maCCCD);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /TamTru/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maXaMoi, string maCCCD)
        {
            await _repo.DeleteAsync(maXaMoi, maCCCD);
            return RedirectToAction(nameof(Index));
        }
    }
}
