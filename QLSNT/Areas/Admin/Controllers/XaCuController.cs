using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class XaCuController : Controller
    {
        private readonly IXaCuRepository _repo;

        public XaCuController(IXaCuRepository repo)
        {
            _repo = repo;
        }

        // GET: /Admin/XaCu?search=Thảo Điền
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<XaCu> list;

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

        // GET: /Admin/XaCu/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _repo.GetByIdAsync(id.Value);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /Admin/XaCu/Create
        [HttpGet]
        public IActionResult Create()
        {
            // Sau này có thể load dropdown Huyện cũ ở đây (ViewBag.HuyenCuList)
            return View();
        }

        // POST: /Admin/XaCu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(XaCu model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/XaCu/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _repo.GetByIdAsync(id.Value);
            if (item == null)
                return NotFound();

            // ViewBag.HuyenCuList = ... nếu cần dropdown chọn Huyện
            return View(item);
        }

        // POST: /Admin/XaCu/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, XaCu model)
        {
            if (id != model.MaXaCu)   // đảm bảo id route khớp với model
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/XaCu/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _repo.GetByIdAsync(id.Value);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /Admin/XaCu/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
