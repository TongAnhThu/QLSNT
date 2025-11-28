using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITinhCuRepository
    {
        Task<IEnumerable<TinhCu>> GetAllAsync();
        Task<TinhCu?> GetByIdAsync(string id);
        Task AddAsync(TinhCu entity);
        Task UpdateAsync(TinhCu entity);
        Task DeleteAsync(string id);

        // Thêm dòng này:
        Task<IEnumerable<TinhCu>> SearchByNameAsync(string keyword);
    }
}
