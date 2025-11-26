using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITinhCuRepository
    {
        // Lấy tất cả tỉnh cũ
        Task<IEnumerable<TinhCu>> GetAllAsync();

        // Lấy 1 tỉnh cũ theo mã
        Task<TinhCu?> GetByIdAsync(string maTinhCu);

        // Thêm mới
        Task AddAsync(TinhCu entity);

        // Cập nhật
        Task UpdateAsync(TinhCu entity);

        // Xóa theo mã
        Task DeleteAsync(string maTinhCu);

        // Lưu thay đổi
        Task<int> SaveChangesAsync();
    }
}
