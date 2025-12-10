using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITinhMoiRepository
    {
        Task<IEnumerable<TinhMoi>> GetAllAsync();
        Task<TinhMoi?> GetByIdAsync(int id);
        Task AddAsync(TinhMoi entity);
        Task UpdateAsync(TinhMoi entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TinhMoi>> SearchByNameAsync(string keyword);
    }
}
