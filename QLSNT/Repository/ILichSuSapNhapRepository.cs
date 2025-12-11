using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ILichSuSapNhapRepository
    {
        // Lấy tất cả bản ghi (dùng cho danh sách, dropdown, ...)
        Task<List<LichSuSapNhap>> GetAllAsync(bool includeTinhs = false, bool includeXas = false);
        Task<List<LichSuSapNhap>> SearchAsync(string search, bool includeTinhs = false, bool includeXas = false);

        // Lấy 1 bản ghi theo MaLssn (không include nặng)
        Task<LichSuSapNhap?> GetByIdAsync(string id, bool includeTinhs = false, bool includeXas = false);
        

            // Lấy chi tiết 1 bản ghi + các quan hệ (Tỉnh/Xã)
            Task<LichSuSapNhap?> GetDetailsAsync(string maLssn);

        // Lấy tất cả lịch sử theo Số nghị định (FK sang SuKienHanhChinh)
        Task<List<LichSuSapNhap>> GetBySoNghiDinhAsync(string soNghiDinh);

        // Tìm kiếm chung theo từ khóa (MaLssn, SoNghiDinh, GhiChu)
        

        // Thêm mới
        Task AddAsync(LichSuSapNhap entity);

        // Cập nhật
        Task UpdateAsync(LichSuSapNhap entity);

        // Xoá theo MaLssn
        Task DeleteAsync(string maLssn);
        Task<int> CountAsync();
    }
}
