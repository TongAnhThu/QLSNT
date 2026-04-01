using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class XaMoiController : Controller
    {
        private readonly IXaMoiRepository _repo;
        private readonly ITinhMoiRepository _tinhRepo;

        public XaMoiController(IXaMoiRepository repo, ITinhMoiRepository tinhRepo)
        {
            _repo = repo;
            _tinhRepo = tinhRepo;
        }

        // GET: /Admin/XaMoi?search=Phường 1
        public async Task<IActionResult> Index(string? search)
        {
            IEnumerable<XaMoi> list = string.IsNullOrWhiteSpace(search)
                ? await _repo.GetAllAsync()
                : await _repo.SearchByNameAsync(search);

            ViewBag.Search = search;
            return View(list);
        }

        // GET: /Admin/XaMoi/Details/1
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // GET: /Admin/XaMoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Admin/XaMoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(XaMoi model)
        {
            if (!ModelState.IsValid) return View(model);

            await _repo.AddAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/XaMoi/Edit/1
        // GET: /Admin/XaMoi/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            // Nạp dropdown tỉnh
            await PopulateTinhsDropDownAsync(item.MaTinh);

            return View(item);
        }

        // POST: /Admin/XaMoi/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(XaMoi model)
        {
            if (!ModelState.IsValid)
            {
                // Nạp lại dropdown tỉnh khi lỗi
                await PopulateTinhsDropDownAsync(model.MaTinh);
                return View(model);
            }

            await _repo.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // Hàm phụ trợ để nạp dropdown tỉnh
        private async Task PopulateTinhsDropDownAsync(int? selectedMaTinh = null)
        {
            var tinhs = await _tinhRepo.GetAllAsync(); // hoặc _db.TinhMois.ToListAsync()
            ViewBag.TinhList = tinhs.Select(t => new SelectListItem
            {
                Value = t.MaTinhMoi.ToString(),
                Text = t.TenTinhMoi,
                Selected = selectedMaTinh.HasValue && selectedMaTinh.Value == t.MaTinhMoi
            }).ToList();
        }


        // GET: /Admin/XaMoi/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();

            return View(item);
        }

        // POST: /Admin/XaMoi/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0) return NotFound();

            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GetByTinh(int maTinh)
        {
            var xas = await _repo.GetByTinhAsync(maTinh);
            var result = xas.Select(x => new {
                maXaMoi = x.MaXaMoi,
                tenXaMoi = x.TenXaMoi
            });
            return Json(result);
        }
    }
}
