using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class XaMoiController : Controller
    {
        private readonly IXaMoiRepository _repo;

        public XaMoiController(IXaMoiRepository repo)
        {
            _repo = repo;
        }

        // GET: /XaMoi?search=Phường 1
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<XaMoi> list;

            if (!string.IsNullOrWhiteSpace(search))
            {
                list = await _repo.SearchByNameAsync(search);
                ViewBag.Search = search;  // Passing the search term to ViewBag
            }
            else
            {
                list = await _repo.GetAllAsync();
            }

            return View(list);
        }

        // GET: /XaMoi/Details/1
        public async Task<IActionResult> Details(int maXa)
        {
            if (maXa == 0)
                return NotFound();

            var item = await _repo.GetByIdAsync(maXa);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /XaMoi/Create
        public IActionResult Create()
        {
            // Later you can add dropdown for HuyenMoi if necessary
            return View();
        }

        // POST: /XaMoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(XaMoi model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index)); // Redirecting to the Index after creating
        }

        // GET: /XaMoi/Edit/1
        public async Task<IActionResult> Edit(int maXa)
        {
            if (maXa == 0)
                return NotFound();

            var item = await _repo.GetByIdAsync(maXa);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /XaMoi/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(XaMoi model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index)); // Redirecting to the Index after editing
        }

        // GET: /XaMoi/Delete/1
        public async Task<IActionResult> Delete(int maXa)
        {
            if (maXa == 0)
                return NotFound();

            var item = await _repo.GetByIdAsync(maXa);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /XaMoi/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maXa)
        {
            if (maXa == 0)
                return NotFound();

            await _repo.DeleteAsync(maXa);
            return RedirectToAction(nameof(Index)); // Redirecting to the Index after deletion
        }
    }
}
