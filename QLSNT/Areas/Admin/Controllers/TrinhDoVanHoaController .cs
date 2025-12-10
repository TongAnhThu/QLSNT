using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class TrinhDoVanHoaController : Controller
    {
        private readonly ITrinhDoVanHoaRepository _repo;

        public TrinhDoVanHoaController(ITrinhDoVanHoaRepository repo)
        {
            _repo = repo;
        }

        // GET: /TrinhDoVanHoa?search=12/12
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<TrinhDoVanHoa> list;

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

        // GET: /TrinhDoVanHoa/Details/01
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: /TrinhDoVanHoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TrinhDoVanHoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrinhDoVanHoa model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /TrinhDoVanHoa/Edit/01
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /TrinhDoVanHoa/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrinhDoVanHoa model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /TrinhDoVanHoa/Delete/01
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /TrinhDoVanHoa/Delete/01
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
