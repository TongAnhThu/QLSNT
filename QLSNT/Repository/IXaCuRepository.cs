using QLSNT.Models;

public interface IXaCuRepository
{
    Task<IEnumerable<XaCu>> GetAllAsync();
    Task<XaCu?> GetByIdAsync(int id);
    Task AddAsync(XaCu entity);
    Task UpdateAsync(XaCu entity);
    Task DeleteAsync(int id);

    Task<IEnumerable<XaCu>> SearchByNameAsync(string keyword);
}
