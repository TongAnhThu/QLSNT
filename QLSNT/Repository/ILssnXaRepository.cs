using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ILssnXaRepository
    {
        // Lấy tất cả bản ghi LSSN-Xã
        Task<IEnumerable<LssnXa>> GetAllAsync();

        // Lấy theo MaLSSN (khóa chính / khóa liên kết với LichSuSapNhap)
        Task<LssnXa?> GetByIdAsync(string maLssn);

        // Lấy tất cả xã cũ/xã mới trong một lần sáp nhập
        Task<IEnumerable<LssnXa>> GetByLssnAsync(string maLssn);

        // Lấy các dòng liên quan tới một Xã cũ
        Task<IEnumerable<LssnXa>> GetByXaCuAsync(string maXaCu);

        // Lấy các dòng liên quan tới một Xã mới
        Task<IEnumerable<LssnXa>> GetByXaMoiAsync(string maXaMoi);

        // Thêm mới
        Task AddAsync(LssnXa entity);

        // Cập nhật
        Task UpdateAsync(LssnXa entity);

        // Xóa theo MaLSSN
        Task DeleteAsync(string maLssn);

        // Lưu thay đổi
        Task<int> SaveChangesAsync();

    }
}
