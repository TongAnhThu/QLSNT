using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ILssnTinhRepository
    {
        // Lấy tất cả
        Task<IEnumerable<LssnTinh>> GetAllAsync();

        // Lấy theo MaLSSN
        Task<IEnumerable<LssnTinh>> GetByLssnAsync(string maLssn);

        // Lấy theo Tỉnh cũ
        Task<IEnumerable<LssnTinh>> GetByTinhCuAsync(string maTinhCu);

        // Lấy theo Tỉnh mới
        Task<IEnumerable<LssnTinh>> GetByTinhMoiAsync(string maTinhMoi);

        // Lấy 1 bản ghi (PK)
        Task<LssnTinh?> GetByIdAsync(string maLssn);

        // Thêm
        Task AddAsync(LssnTinh entity);

        // Sửa
        Task UpdateAsync(LssnTinh entity);

        // Xóa
        Task DeleteAsync(string maLssn);

        // Lưu DB
        Task<int> SaveChangesAsync();
    }
}
