using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface INguoiDanRepository
    {
        /// <summary>
        /// Lấy toàn bộ danh sách người dân (kèm các quan hệ cơ bản nếu cần).
        /// </summary>
        Task<IEnumerable<NguoiDan>> GetAllAsync();

        /// <summary>
        /// Tìm kiếm theo từ khóa (CCCD, họ tên, địa chỉ... tùy bạn implement).
        /// </summary>
        Task<IEnumerable<NguoiDan>> SearchAsync(string? keyword);

        /// <summary>
        /// Lấy 1 người dân theo mã CCCD.
        /// </summary>
        Task<NguoiDan?> GetByIdAsync(string maCccd);

        /// <summary>
        /// Thêm người dân mới.
        /// </summary>
        Task AddAsync(NguoiDan entity);

        /// <summary>
        /// Cập nhật thông tin người dân.
        /// </summary>
        Task UpdateAsync(NguoiDan entity);

        /// <summary>
        /// Xóa người dân theo CCCD.
        /// </summary>
        Task DeleteAsync(string maCccd);
    }
}
