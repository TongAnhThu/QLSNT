using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITamTruRepository
{
    Task<List<TamTru>> GetAllAsync();
    Task<TamTru?> GetByIdAsync(int maXaMoi, string maCCCD);
    Task AddAsync(TamTru entity);
    Task UpdateAsync(TamTru entity);
    Task DeleteAsync(int maXaMoi, string maCCCD);

    // Thêm mới
    Task<List<TamTru>> GetByNguoiDanAsync(string maCCCD);
    Task<IEnumerable<TamTru>> GetTamTruHieuLucByNguoiDanIdAsync(string maNguoiDan);
    }

}
