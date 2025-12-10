using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IHuyenCuRepository
    {
        Task<IEnumerable<HuyenCu>> GetAllAsync();
        Task<HuyenCu?> GetByIdAsync(int id);
        Task AddAsync(HuyenCu entity);
        Task UpdateAsync(HuyenCu entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<HuyenCu>> SearchByNameAsync(string keyword);
    }
}
