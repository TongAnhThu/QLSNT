using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IXaMoiRepository
    {
        // Lấy tất cả Xã mới
        Task<IEnumerable<XaMoi>> GetAllAsync();

        // Lấy 1 Xã mới theo mã
        Task<XaMoi?> GetByIdAsync(string maXaMoi);

        // Lấy danh sách Xã mới theo Tỉnh mới
        Task<IEnumerable<XaMoi>> GetByTinhMoiAsync(string maTinh);

        // Thêm mới
        Task AddAsync(XaMoi entity);

        // Cập nhật
        Task UpdateAsync(XaMoi entity);

        // Xóa theo mã
        Task DeleteAsync(string maXaMoi);

        // Lưu thay đổi
        Task<int> SaveChangesAsync();
    }
}
