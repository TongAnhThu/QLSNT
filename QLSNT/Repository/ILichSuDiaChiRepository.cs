using System.Collections.Generic;
using System.Threading.Tasks;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public interface ILichSuDiaChiRepository
    {
        Task<IEnumerable<LichSuDiaChi>> GetAllAsync(string? keyword = null);
        Task<LichSuDiaChi?> GetByIdAsync(string id);
        Task AddAsync(LichSuDiaChi entity);
        Task UpdateAsync(LichSuDiaChi entity);
        Task DeleteAsync(string id);
        Task<string?> GetLastCodeAsync();
    }
}
