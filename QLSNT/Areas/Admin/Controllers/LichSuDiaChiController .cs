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
    [Authorize] // nếu chưa dùng phân quyền thì có thể bỏ
    public class LichSuDiaChiController : Controller
    {
        private readonly ILichSuDiaChiRepository _lsctRepo;
        private readonly INguoiDanRepository _nguoiDanRepo;
        private readonly IXaCuRepository _xaCuRepo;

        public LichSuDiaChiController(
            ILichSuDiaChiRepository lsctRepo,
            INguoiDanRepository nguoiDanRepo,
            IXaCuRepository xaCuRepo)
        {
            _lsctRepo = lsctRepo;
            _nguoiDanRepo = nguoiDanRepo;
            _xaCuRepo = xaCuRepo;
        }

        // GET: Admin/LichSuCuTru
        public async Task<IActionResult> Index(string? searchCccd)
        {
            var list = await _lsctRepo.GetAllAsync(searchCccd);
            ViewBag.SearchCccd = searchCccd;
            return View(list);
        }

        // GET: Admin/LichSuCuTru/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var item = await _lsctRepo.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Admin/LichSuCuTru/Create
        public async Task<IActionResult> Create(string? maCccd)
        {
            await LoadDropdowns(maCccd: maCccd);

            var model = new LichSuDiaChi
            {
                MaCCCD = maCccd,           // nếu tạo từ màn chi tiết Người dân
                NgayHieuLuc = DateTime.Today
            };

            return View(model);
        }

        // POST: Admin/LichSuCuTru/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LichSuDiaChi model)
        {
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model.MaCCCD, model.MaXaCu);
                return View(model);
            }

            // Lấy tên user đăng nhập
            model.NguoiTao = User.Identity?.Name;
            model.NgayTao = DateTime.Now;

            await _lsctRepo.AddAsync(model);

            TempData["SuccessMessage"] = "Thêm lịch sử cư trú thành công.";
            return RedirectToAction(nameof(Index), new { searchCccd = model.MaCCCD });
        }

        // GET: Admin/LichSuCuTru/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            await LoadDropdowns(entity.MaCCCD, entity.MaXaCu);
            return View(entity);
        }

        // POST: Admin/LichSuCuTru/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, LichSuDiaChi model)
        {
            if (id != model.MaLichSuCuTru)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model.MaCCCD, model.MaXaCu);
                return View(model);
            }

            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // Cập nhật các trường cho phép sửa
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

            // Thông tin cập nhật
            entity.NguoiCapNhat = User.Identity?.Name;
            entity.NgayCapNhat = DateTime.Now;

            await _lsctRepo.UpdateAsync(entity);

            TempData["SuccessMessage"] = "Cập nhật lịch sử cư trú thành công.";
            return RedirectToAction(nameof(Index), new { searchCccd = model.MaCCCD });
        }

        // GET: Admin/LichSuCuTru/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        // POST: Admin/LichSuCuTru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var entity = await _lsctRepo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            await _lsctRepo.DeleteAsync(id);

            TempData["SuccessMessage"] = "Xoá lịch sử cư trú thành công.";
            return RedirectToAction(nameof(Index), new { searchCccd = entity.MaCCCD });
        }

        /// <summary>
        /// Load dropdown Người dân + Xã cũ
        /// </summary>
        private async Task LoadDropdowns(string? maCccd = null, string? maXaCu = null)
        {
            var nguoiDans = await _nguoiDanRepo.GetAllAsync();
            var xas = await _xaCuRepo.GetAllAsync();

            ViewBag.NguoiDanList = new SelectList(nguoiDans, "MaCCCD", "HoTen", maCccd);
            ViewBag.XaCuList = new SelectList(xas, "MaXaCu", "TenXaCu", maXaCu);
        }
    }
}
