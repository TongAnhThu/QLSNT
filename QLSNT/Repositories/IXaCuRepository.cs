using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IXaCuRepository
    {
        // Lấy tất cả Xã cũ
        Task<IEnumerable<XaCu>> GetAllAsync();

        // Lấy 1 Xã cũ theo mã
        Task<XaCu?> GetByIdAsync(string maXaCu);

        // Lấy danh sách Xã theo Huyện cũ
        Task<IEnumerable<XaCu>> GetByHuyenCuAsync(string maHuyenCu);

        // Thêm mới
        Task AddAsync(XaCu entity);

        // Cập nhật
        Task UpdateAsync(XaCu entity);

        // Xóa theo mã
        Task DeleteAsync(string maXaCu);

        // Lưu thay đổi
        Task<int> SaveChangesAsync();
    }
}
