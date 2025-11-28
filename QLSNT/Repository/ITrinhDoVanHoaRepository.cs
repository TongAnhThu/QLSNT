using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITrinhDoVanHoaRepository
    {
        // Lấy tất cả TDVH
        Task<IEnumerable<TrinhDoVanHoa>> GetAllAsync();

        // Lấy theo mã
        Task<TrinhDoVanHoa?> GetByIdAsync(string maTdvh);

        // Tìm theo tên (search)
        Task<IEnumerable<TrinhDoVanHoa>> SearchByNameAsync(string keyword);

        // Thêm mới
        Task AddAsync(TrinhDoVanHoa entity);

        // Cập nhật
        Task UpdateAsync(TrinhDoVanHoa entity);

        // Xóa
        Task DeleteAsync(string maTdvh);

        // Lưu DB
        Task<int> SaveChangesAsync();
    }
}
