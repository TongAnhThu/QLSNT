using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ILichSuSapNhapRepository
    {
        // Lấy tất cả bản ghi (dùng cho danh sách, dropdown, ...)
        Task<List<LichSuSapNhap>> GetAllAsync();

        // Lấy 1 bản ghi theo MaLssn (không include nặng)
        Task<LichSuSapNhap?> GetByIdAsync(string maLssn);

        // Lấy chi tiết 1 bản ghi + các quan hệ (Tỉnh/Xã)
        Task<LichSuSapNhap?> GetDetailsAsync(string maLssn);

        // Lấy tất cả lịch sử theo Số nghị định (FK sang SuKienHanhChinh)
        Task<List<LichSuSapNhap>> GetBySoNghiDinhAsync(string soNghiDinh);

        // Tìm kiếm chung theo từ khóa (MaLssn, SoNghiDinh, GhiChu)
        Task<List<LichSuSapNhap>> SearchAsync(string? keyword);

        // Thêm mới
        Task AddAsync(LichSuSapNhap entity);

        // Cập nhật
        Task UpdateAsync(LichSuSapNhap entity);

        // Xoá theo MaLssn
        Task DeleteAsync(string maLssn);
    }
}
