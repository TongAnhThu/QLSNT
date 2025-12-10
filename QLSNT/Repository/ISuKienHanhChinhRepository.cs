using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ISuKienHanhChinhRepository
    {
        Task<IEnumerable<SuKienHanhChinh>> GetAllAsync();
        Task<SuKienHanhChinh?> GetByIdAsync(string id);
        Task AddAsync(SuKienHanhChinh entity);
        Task UpdateAsync(SuKienHanhChinh entity);
        Task DeleteAsync(string id);
        Task<IEnumerable<SuKienHanhChinh>> SearchAsync(string keyword);
    }
}
