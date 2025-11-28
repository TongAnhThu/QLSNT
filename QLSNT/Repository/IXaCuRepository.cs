using QLSNT.Models;

public interface IXaCuRepository
{
    Task<IEnumerable<XaCu>> GetAllAsync();
    Task<XaCu?> GetByIdAsync(string id);
    Task AddAsync(XaCu entity);
    Task UpdateAsync(XaCu entity);
    Task DeleteAsync(string id);

    Task<IEnumerable<XaCu>> SearchByNameAsync(string keyword);
}
