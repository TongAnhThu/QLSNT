using Microsoft.AspNetCore.Mvc;
using QLSNT.Models;
using QLSNT.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLSNT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TamTruController : Controller
    {
        private readonly ITamTruRepository _tamTruRepo;
        private readonly INguoiDanRepository _nguoiDanRepo;
        private readonly IXaMoiRepository _xaMoiRepo;

        public TamTruController(ITamTruRepository tamTruRepo,
                                INguoiDanRepository nguoiDanRepo,
                                IXaMoiRepository xaMoiRepo)
        {
            _tamTruRepo = tamTruRepo;
            _nguoiDanRepo = nguoiDanRepo;
            _xaMoiRepo = xaMoiRepo;
        }

        // GET: Admin/TamTru/Index
        public async Task<IActionResult> Index(string? maCccd)
        {
            List<TamTru> list;
            if (!string.IsNullOrWhiteSpace(maCccd))
            {
                list = await _tamTruRepo.GetByNguoiDanAsync(maCccd);
                ViewBag.MaCCCD = maCccd;
            }
            else
            {
                list = await _tamTruRepo.GetAllAsync();
            }
            return View(list);
        }
        public async Task<IActionResult> Details(int maXaMoi, string maCCCD)
        {
            // Kiểm tra tham số
            if (maXaMoi == 0 || string.IsNullOrWhiteSpace(maCCCD))
                return NotFound();

            // Lấy dữ liệu từ repository
            var entity = await _tamTruRepo.GetByIdAsync(maXaMoi, maCCCD);
            if (entity == null)
                return NotFound();

            // Trả về view chi tiết
            return View(entity);
        }

        // GET: Admin/TamTru/Create
        public async Task<IActionResult> Create(string? maCccd)
        {
            ViewBag.NguoiDanList = new SelectList(await _nguoiDanRepo.GetAllAsync(), "MaCCCD", "HoTen", maCccd);
            ViewBag.XaMoiList = new SelectList(await _xaMoiRepo.GetAllAsync(), "MaXaMoi", "TenXaMoi");

            var model = new TamTru
            {
                MaCCCD = maCccd,
                NgayDangKy = DateTime.Today
            };
            return View(model);
        }

        // POST: Admin/TamTru/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TamTru model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.NguoiDanList = new SelectList(await _nguoiDanRepo.GetAllAsync(), "MaCCCD", "HoTen", model.MaCCCD);
                ViewBag.XaMoiList = new SelectList(await _xaMoiRepo.GetAllAsync(), "MaXaMoi", "TenXaMoi", model.MaXaMoi);
                return View(model);
            }

            await _tamTruRepo.AddAsync(model);
            TempData["SuccessMessage"] = "Thêm địa chỉ tạm trú thành công.";
            return RedirectToAction(nameof(Index), new { maCccd = model.MaCCCD });
        }

        // GET: Admin/TamTru/Edit
        public async Task<IActionResult> Edit(int maXaMoi, string maCccd)
        {
            var entity = await _tamTruRepo.GetByIdAsync(maXaMoi, maCccd);
            if (entity == null) return NotFound();

            ViewBag.NguoiDanList = new SelectList(await _nguoiDanRepo.GetAllAsync(), "MaCCCD", "HoTen", entity.MaCCCD);
            ViewBag.XaMoiList = new SelectList(await _xaMoiRepo.GetAllAsync(), "MaXaMoi", "TenXaMoi", entity.MaXaMoi);

            return View(entity);
        }

        // POST: Admin/TamTru/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TamTru model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.NguoiDanList = new SelectList(await _nguoiDanRepo.GetAllAsync(), "MaCCCD", "HoTen", model.MaCCCD);
                ViewBag.XaMoiList = new SelectList(await _xaMoiRepo.GetAllAsync(), "MaXaMoi", "TenXaMoi", model.MaXaMoi);
                return View(model);
            }

            await _tamTruRepo.UpdateAsync(model);
            TempData["SuccessMessage"] = "Cập nhật địa chỉ tạm trú thành công.";
            return RedirectToAction(nameof(Index), new { maCccd = model.MaCCCD });
        }

        // GET: Admin/TamTru/Delete
        public async Task<IActionResult> Delete(int maXaMoi, string maCccd)
        {
            var entity = await _tamTruRepo.GetByIdAsync(maXaMoi, maCccd);
            if (entity == null) return NotFound();

            return View(entity);
        }

        // POST: Admin/TamTru/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maXaMoi, string maCccd)
        {
            await _tamTruRepo.DeleteAsync(maXaMoi, maCccd);
            TempData["SuccessMessage"] = "Xoá địa chỉ tạm trú thành công.";
            return RedirectToAction(nameof(Index), new { maCccd });
        }
    }
}
