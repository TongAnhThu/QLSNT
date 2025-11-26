using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IHuyenCuRepository
    {
        // Lấy tất cả Huyện cũ
        Task<IEnumerable<HuyenCu>> GetAllAsync();

        // Lấy 1 Huyện cũ theo mã
        Task<HuyenCu?> GetByIdAsync(string maHuyenCu);

        // Lấy danh sách Huyện theo Tỉnh cũ
        Task<IEnumerable<HuyenCu>> GetByTinhCuAsync(string maTinhCu);

        // Thêm mới
        Task AddAsync(HuyenCu entity);

        // Cập nhật
        Task UpdateAsync(HuyenCu entity);

        // Xóa theo mã
        Task DeleteAsync(string maHuyenCu);

        // Lưu thay đổi
        Task<int> SaveChangesAsync();
    }
}
