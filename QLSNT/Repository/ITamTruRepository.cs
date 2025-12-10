using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITamTruRepository
    {
        // Lấy tất cả bản ghi tạm trú
        Task<List<TamTru>> GetAllAsync();

        // Tìm kiếm theo CCCD, mã xã, địa chỉ, lý do...
        Task<List<TamTru>> SearchAsync(string? keyword);

        // Lấy 1 bản ghi theo composite key (MaXaMoi + MaCCCD)
        Task<TamTru?> GetByIdAsync(int maXaMoi, string maCCCD);

        // Thêm mới
        Task AddAsync(TamTru entity);

        // Cập nhật
        Task UpdateAsync(TamTru entity);

        // Xóa
        Task DeleteAsync(int maXaMoi, string maCCCD);
    }
}
