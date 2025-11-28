using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ILichSuDiaChiRepository
    {
        // Lấy tất cả lịch sử địa chỉ
        Task<IEnumerable<LichSuDiaChi>> GetAllAsync();

        // Lấy 1 bản ghi theo mã
        Task<LichSuDiaChi?> GetByIdAsync(string maLsdc);

        // Lấy lịch sử địa chỉ của 1 người dân (theo CCCD)
        Task<IEnumerable<LichSuDiaChi>> GetByNguoiDanAsync(string maCccd);

        // Lấy lịch sử địa chỉ theo xã (ai từng ở xã này)
        Task<IEnumerable<LichSuDiaChi>> GetByXaMoiAsync(string maXaMoi);

        // Thêm mới
        Task AddAsync(LichSuDiaChi entity);

        // Cập nhật
        Task UpdateAsync(LichSuDiaChi entity);

        // Xóa
        Task DeleteAsync(string maLsdc);

        // Lưu DB
        Task<int> SaveChangesAsync();
    }
}
