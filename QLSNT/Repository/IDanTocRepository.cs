using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IDanTocRepository
    {
        // Lấy tất cả dân tộc
        Task<IEnumerable<DanToc>> GetAllAsync();

        // Lấy theo mã
        Task<DanToc?> GetByIdAsync(int maDanToc);

        // Tìm theo tên (search)
        Task<IEnumerable<DanToc>> SearchByNameAsync(string keyword);

        // Thêm mới
        Task AddAsync(DanToc entity);

        // Cập nhật
        Task UpdateAsync(DanToc entity);

        // Xóa
        Task DeleteAsync(int maDanToc);

        // Lưu DB
        Task<int> SaveChangesAsync();
    }
}
