using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IQuanHeChuHoRepository
    {
        // Lấy tất cả quan hệ chủ hộ
        Task<IEnumerable<QuanHeChuHo>> GetAllAsync();

        // Lấy theo mã
        Task<QuanHeChuHo?> GetByIdAsync(string maQhch);

        // Tìm theo tên (ví dụ: "Chủ hộ", "Vợ", "Con", "Ông", "Bà"...)
        Task<IEnumerable<QuanHeChuHo>> SearchByNameAsync(string keyword);

        // Thêm
        Task AddAsync(QuanHeChuHo entity);

        // Cập nhật
        Task UpdateAsync(QuanHeChuHo entity);

        // Xóa
        Task DeleteAsync(string maQhch);

        // Lưu DB
        Task<int> SaveChangesAsync();
    }
}
