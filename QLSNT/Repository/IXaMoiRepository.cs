using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface IXaMoiRepository
    {
        Task<IEnumerable<XaMoi>> GetAllAsync();
        Task<XaMoi?> GetByIdAsync(string id);
        Task AddAsync(XaMoi entity);
        Task UpdateAsync(XaMoi entity);
        Task DeleteAsync(string id);
        Task<IEnumerable<XaMoi>> SearchByNameAsync(string keyword);
    }
}
