using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITonGiaoRepository
    {
        // Lấy tất cả tôn giáo
        Task<IEnumerable<TonGiao>> GetAllAsync();

        // Lấy theo mã
        Task<TonGiao?> GetByIdAsync(string maTonGiao);

        // Tìm theo tên
        Task<IEnumerable<TonGiao>> SearchByNameAsync(string keyword);

        // Thêm mới
        Task AddAsync(TonGiao entity);

        // Cập nhật
        Task UpdateAsync(TonGiao entity);

        // Xóa
        Task DeleteAsync(string maTonGiao);

        // Lưu DB
        Task<int> SaveChangesAsync();
    }
}
