using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TinhCuController : Controller
    {
        private readonly ITinhCuRepository _repo;

        public TinhCuController(ITinhCuRepository repo)
        {
            _repo = repo;
        }

        // GET: /Admin/TinhCu?search=Hà Nội
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

        // GET: /Admin/TinhCu/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var item = await _repo.GetByIdAsync(id.Value);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: /Admin/TinhCu/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Admin/TinhCu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TinhCu model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/TinhCu/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var item = await _repo.GetByIdAsync(id.Value);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /Admin/TinhCu/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TinhCu model)
        {
            if (id != model.MaTinhCu) return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/TinhCu/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var item = await _repo.GetByIdAsync(id.Value);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /Admin/TinhCu/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
