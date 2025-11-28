using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ITinhMoiRepository
    {
        Task<IEnumerable<TinhMoi>> GetAllAsync();
        Task<TinhMoi?> GetByIdAsync(string id);
        Task AddAsync(TinhMoi entity);
        Task UpdateAsync(TinhMoi entity);
        Task DeleteAsync(string id);
        Task<IEnumerable<TinhMoi>> SearchByNameAsync(string keyword);
    }
}
