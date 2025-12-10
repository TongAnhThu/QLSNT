using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize] // If you are not using role-based authorization, this can be removed
    public class LichSuDiaChiController : Controller
    {
        private readonly ILichSuDiaChiRepository _lsctRepo;
        private readonly INguoiDanRepository _nguoiDanRepo;
        private readonly IXaCuRepository _xaCuRepo;
        private readonly IXaMoiRepository _xaMoiRepo; // Added for new district

        public LichSuDiaChiController(
            ILichSuDiaChiRepository lsctRepo,
            INguoiDanRepository nguoiDanRepo,
            IXaCuRepository xaCuRepo,
            IXaMoiRepository xaMoiRepo)
        {
            _lsctRepo = lsctRepo;
            _nguoiDanRepo = nguoiDanRepo;
            _xaCuRepo = xaCuRepo;
            _xaMoiRepo = xaMoiRepo; // Inject the new repository for XaMoi
        }

        // GET: Admin/LichSuDiaChi
        public async Task<IActionResult> Index(string? searchCccd)
        {
            var list = await _lsctRepo.GetAllAsync(searchCccd);
            ViewBag.SearchCccd = searchCccd;
            return View(list);
        }

        // GET: Admin/LichSuDiaChi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var item = await _lsctRepo.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Admin/LichSuDiaChi/Create
        public async Task<IActionResult> Create(string? maCccd)
        {
            // Load both old and new districts dropdowns
            await LoadDropdowns(maCccd: maCccd);

            var model = new LichSuDiaChi
            {
                MaCCCD = maCccd,           // Create from "NguoiDan" details if needed
                NgayHieuLuc = DateTime.Today
            };

            return View(model);
        }

        // POST: Admin/LichSuDiaChi/Create        
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(LichSuDiaChi model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model.MaCCCD, model.MaXaCu, model.MaXaMoi);
                return View(model);
            }

            // Sinh mã tự động khi thêm bằng tay
            model.MaLichSuCuTru = Guid.NewGuid().ToString();

            model.NguoiTao = User.Identity?.Name;
            model.NgayTao = DateTime.Now;

            await _lsctRepo.AddAsync(model);

            TempData["SuccessMessage"] = "Thêm lịch sử cư trú thành công.";
            return RedirectToAction(nameof(Index), new { searchCccd = model.MaCCCD });
        }


        // GET: Admin/LichSuDiaChi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // Load both old and new districts dropdowns for editing
            await LoadDropdowns(entity.MaCCCD, entity.MaXaCu, entity.MaXaMoi);
            return View(entity);
        }

        // POST: Admin/LichSuDiaChi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, LichSuDiaChi model)
        {
            if (id != model.MaLichSuCuTru)
                return NotFound();

            if (!ModelState.IsValid)
            {
                // Load dropdowns for both old and new districts if model is not valid
                await LoadDropdowns(model.MaCCCD, model.MaXaCu, model.MaXaMoi);
                return View(model);
            }

            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // Update editable fields
            entity.LoaiThayDoi = model.LoaiThayDoi;
            entity.SoQuyetDinh = model.SoQuyetDinh;
            entity.LyDoThayDoi = model.LyDoThayDoi;
            entity.NgayHieuLuc = model.NgayHieuLuc;
            entity.NgayKetThuc = model.NgayKetThuc;
            entity.DiaChiCu = model.DiaChiCu;
            entity.DiaChiMoi = model.DiaChiMoi;
            entity.GhiChu = model.GhiChu;
            entity.MaCCCD = model.MaCCCD;
            entity.MaXaCu = model.MaXaCu;
            entity.MaXaMoi = model.MaXaMoi; // Added for new district code

            // Record update info
            entity.NguoiCapNhat = User.Identity?.Name;
            entity.NgayCapNhat = DateTime.Now;

            await _lsctRepo.UpdateAsync(entity);

            TempData["SuccessMessage"] = "Cập nhật lịch sử cư trú thành công.";
            return RedirectToAction(nameof(Index), new { searchCccd = model.MaCCCD });
        }

        // GET: Admin/LichSuDiaChi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        // POST: Admin/LichSuDiaChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            await _lsctRepo.DeleteAsync(id);

            TempData["SuccessMessage"] = "Xoá lịch sử cư trú thành công.";
            return RedirectToAction(nameof(Index), new { searchCccd = entity.MaCCCD });
        }

        /// <summary>
        /// Load dropdown for NguoiDan and XaCu + XaMoi (new district)
        /// </summary>
        private async Task LoadDropdowns(string? maCccd = null, int? maXaCu = null, int? maXaMoi = null)
        {
            var nguoiDans = await _nguoiDanRepo.GetAllAsync();
            var xasCu = await _xaCuRepo.GetAllAsync();
            var xasMoi = await _xaMoiRepo.GetAllAsync(); // Added for new district dropdown

            ViewBag.NguoiDanList = new SelectList(nguoiDans, "MaCCCD", "HoTen", maCccd);
            ViewBag.XaCuList = new SelectList(xasCu, "MaXaCu", "TenXaCu", maXaCu);
            ViewBag.XaMoiList = new SelectList(xasMoi, "MaXaMoi", "TenXaMoi", maXaMoi); // Added for new district dropdown
        }
    }
}
