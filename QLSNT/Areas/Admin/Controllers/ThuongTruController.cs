using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class ThuongTruController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThuongTruController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThuongTru
        public async Task<IActionResult> Index()
        {
            var list = await _context.ThuongTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .ToListAsync();
            return View(list);
        }

        // GET: ThuongTru/Details/5
        public async Task<IActionResult> Details(int? maXaMoi, string? maCCCD)
        {
            if (maXaMoi == null || maCCCD == null)
                return NotFound();

            var thuongTru = await _context.ThuongTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .FirstOrDefaultAsync(m => m.MaXaMoi == maXaMoi && m.MaCCCD == maCCCD);

            if (thuongTru == null)
                return NotFound();

            return View(thuongTru);
        }

        // GET: ThuongTru/Create
        // GET: ThuongTru/Create
        public IActionResult Create()
        {
            ViewData["MaXaMoi"] = new SelectList(_context.XaMois, "MaXaMoi", "TenXaMoi");
            ViewData["MaCCCD"] = new SelectList(_context.NguoiDans, "MaCCCD", "HoTen");
            return View();
        }

        // POST: ThuongTru/Create
        // POST: ThuongTru/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaXaMoi,MaCCCD,DiaChi,NgayDangKy")] ThuongTru thuongTru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuongTru);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ⚠️ Gán lại ViewBag khi return View
            ViewData["MaXaMoi"] = new SelectList(_context.XaMois, "MaXaMoi", "TenXaMoi", thuongTru.MaXaMoi);
            ViewData["MaCCCD"] = new SelectList(_context.NguoiDans, "MaCCCD", "HoTen", thuongTru.MaCCCD);

            return View(thuongTru);
        }



        // GET: ThuongTru/Edit/5
        public async Task<IActionResult> Edit(int? maXaMoi, string? maCCCD)
        {
            if (maXaMoi == null || maCCCD == null)
                return NotFound();

            var thuongTru = await _context.ThuongTrus.FindAsync(maXaMoi, maCCCD);
            if (thuongTru == null)
                return NotFound();

            return View(thuongTru);
        }

        // POST: ThuongTru/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int maXaMoi, string maCCCD, [Bind("MaXaMoi,MaCCCD,DiaChi,NgayDangKy")] ThuongTru thuongTru)
        {
            if (maXaMoi != thuongTru.MaXaMoi || maCCCD != thuongTru.MaCCCD)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuongTru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuongTruExists(maXaMoi, maCCCD))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(thuongTru);
        }

        // GET: ThuongTru/Delete/5
        public async Task<IActionResult> Delete(int? maXaMoi, string? maCCCD)
        {
            if (maXaMoi == null || maCCCD == null)
                return NotFound();

            var thuongTru = await _context.ThuongTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .FirstOrDefaultAsync(m => m.MaXaMoi == maXaMoi && m.MaCCCD == maCCCD);

            if (thuongTru == null)
                return NotFound();

            return View(thuongTru);
        }

        // POST: ThuongTru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maXaMoi, string maCCCD)
        {
            var thuongTru = await _context.ThuongTrus.FindAsync(maXaMoi, maCCCD);
            if (thuongTru != null)
            {
                _context.ThuongTrus.Remove(thuongTru);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ThuongTruExists(int maXaMoi, string maCCCD)
        {
            return _context.ThuongTrus.Any(e => e.MaXaMoi == maXaMoi && e.MaCCCD == maCCCD);
        }
    }
}
