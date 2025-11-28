using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLSNT.Models;
using QLSNT.Repositories;

namespace QLSNT.Controllers
{
    [Area("Admin")]
    public class LichSuSapNhapController : Controller
    {
        private readonly ILichSuSapNhapRepository _repo;
        private readonly ILssnTinhRepository _lssnTinhRepo;
        private readonly ILssnXaRepository _lssnXaRepo;
        private readonly ISuKienHanhChinhRepository _suKienRepo;

        public LichSuSapNhapController(ILichSuSapNhapRepository repo)
        {
            _repo = repo;
        }

        // GET: /LichSuSapNhap
        // Hỗ trợ tìm kiếm đơn giản qua ?keyword=
        public async Task<IActionResult> Index(string? keyword)
        {
            List<LichSuSapNhap> list;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                list = await _repo.SearchAsync(keyword);
                ViewBag.Keyword = keyword;
            }
            else
            {
                list = await _repo.GetAllAsync();
            }

            return View(list);
        }

        // GET: /LichSuSapNhap/Details/LS001
        // Dùng GetDetailsAsync để include LssnTinh, LssnXa
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var item = await _repo.GetDetailsAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /LichSuSapNhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /LichSuSapNhap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LichSuSapNhap model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Gán người tạo + thời gian tạo
            model.NguoiTao = User.Identity?.Name;
            model.NgayTao = DateTime.Now;

            await _repo.AddAsync(model);

            TempData["SuccessMessage"] = "Thêm lịch sử sáp nhập thành công.";
            return RedirectToAction(nameof(Index));
        }


        // GET: /LichSuSapNhap/Edit/LS001
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            await LoadDropdowns(entity.SoNghiDinh);  // nếu có dropdown Sự kiện hành chính

            return View(entity);
        }

        // Hàm load dropdown Sự kiện / Nghị định
        private async Task LoadDropdowns(string? selectedSoNghiDinh = null)
        {
            var suKienList = await _suKienRepo.GetAllAsync(); // repo sự kiện hành chính
            ViewBag.SuKienList = new SelectList(
                suKienList,
                "SoNghiDinh",   // value
                "TenSuKien",    // text hiển thị
                selectedSoNghiDinh
            );
        }


        // POST: /LichSuSapNhap/Edit/LS001
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, LichSuSapNhap model)
        {
            // 1. Đảm bảo id trên URL trùng với id trong form
            if (id != model.MaLSSN)
                return NotFound();

            // 2. Nếu dữ liệu form không hợp lệ -> trả lại view cho user sửa
            if (!ModelState.IsValid)
            {
                await LoadDropdowns(model.SoNghiDinh);
                return View(model);
            }

            // 3. Lấy bản ghi gốc từ database
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // 4. Cập nhật các trường cho phép sửa
            entity.SoNghiDinh = model.SoNghiDinh;
            entity.GhiChu = model.GhiChu;

            // 5. Ghi log người cập nhật + thời gian cập nhật
            entity.NguoiCapNhat = User.Identity?.Name;
            entity.NgayCapNhat = DateTime.Now;

            // KHÔNG đụng tới:
            //  - entity.MaLSSN  (khóa chính)
            //  - entity.NguoiTao / entity.NgayTao (lịch sử tạo ban đầu)

            // 6. Lưu xuống DB
            await _repo.UpdateAsync(entity);

            TempData["SuccessMessage"] = "Cập nhật lịch sử sáp nhập thành công.";
            return RedirectToAction(nameof(Index));
        }



        // GET: /LichSuSapNhap/Delete/LS001
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /LichSuSapNhap/Delete/LS001
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                await _repo.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        // Tuỳ chọn: lọc theo Số nghị định cụ thể
        // GET: /LichSuSapNhap/BySoNghiDinh?so=123/2020/NĐ-CP
        public async Task<IActionResult> BySoNghiDinh(string so)
        {
            if (string.IsNullOrWhiteSpace(so))
                return RedirectToAction(nameof(Index));

            var list = await _repo.GetBySoNghiDinhAsync(so.Trim());
            ViewBag.SoNghiDinh = so;

            // Tái dùng view Index cho nhanh
            return View("Index", list);
        }
    }
}
