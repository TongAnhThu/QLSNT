using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IThuongTruRepository
    {
        // Lấy tất cả
        Task<IEnumerable<ThuongTru>> GetAllAsync();
        Task<ThuongTru?> GetByCCCDAsync(string maCCCD);

        // Tìm kiếm theo CCCD, mã xã, địa chỉ...
        Task<IEnumerable<ThuongTru>> SearchAsync(string? keyword);

        // Lấy 1 bản ghi theo composite key
        Task<ThuongTru?> GetByIdAsync(int maXaMoi, string maCccd);

        // Lấy tất cả thường trú trong 1 xã
        Task<IEnumerable<ThuongTru>> GetByXaMoiAsync(int maXaMoi);

        // Lấy tất cả nơi thường trú của 1 người dân
        Task<IEnumerable<ThuongTru>> GetByNguoiDanAsync(string maCccd);

        // Thêm mới (tự SaveChanges bên trong)
        Task AddAsync(ThuongTru entity);

        // Cập nhật (tự SaveChanges bên trong)
        Task UpdateAsync(ThuongTru entity);

        // Xóa (tự SaveChanges bên trong)
        Task DeleteAsync(int maXaMoi, string maCccd);
        Task<ThuongTru?> GetThuongTruHienTaiByNguoiDanIdAsync(string maNguoiDan);
    }
}
