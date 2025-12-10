using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class TinhCuController : Controller
    {
        private readonly ITinhCuRepository _repo;

        public TinhCuController(ITinhCuRepository repo)
        {
            _repo = repo;
        }

        // GET: /TinhCu?search=Hà Nội
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<TinhCu> list;

            if (!string.IsNullOrWhiteSpace(search))
            {
                list = await _repo.SearchByNameAsync(search);
                ViewBag.Search = search;
            }
            else
            {
                list = await _repo.GetAllAsync();
            }

            return View(list);
        }

        // GET: /TinhCu/Details/01
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: /TinhCu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TinhCu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TinhCu model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /TinhCu/Edit/01
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /TinhCu/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TinhCu model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /TinhCu/Delete/01
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /TinhCu/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
