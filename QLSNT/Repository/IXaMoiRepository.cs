using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IXaMoiRepository
    {
        Task<IEnumerable<XaMoi>> GetAllAsync();
        Task<XaMoi?> GetByIdAsync(int id);
        Task AddAsync(XaMoi entity);
        Task UpdateAsync(XaMoi entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<XaMoi>> SearchByNameAsync(string keyword);
    }
}
