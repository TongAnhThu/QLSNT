using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFXaMoiRepository : IXaMoiRepository
    {
        private readonly ApplicationDbContext _db;

        public EFXaMoiRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<XaMoi>> GetAllAsync()
        {
            return await _db.XaMois
                .OrderBy(x => x.MaXaMoi)
                .ToListAsync();
        }

        public async Task<XaMoi?> GetByIdAsync(int id)
        {
            return await _db.XaMois
                .FirstOrDefaultAsync(x => x.MaXaMoi == id);
        }

        public async Task AddAsync(XaMoi entity)
        {
            _db.XaMois.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(XaMoi entity)
        {
            _db.XaMois.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.XaMois.FirstOrDefaultAsync(x => x.MaXaMoi == id);
            if (entity != null)
            {
                _db.XaMois.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<XaMoi>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            return await _db.XaMois
                .Where(x =>
                    (x.TenXaMoi != null && EF.Functions.Like(x.TenXaMoi, $"%{keyword}%")) ||
                    (x.MaXaMoi.ToString() != null && EF.Functions.Like(x.MaXaMoi.ToString(), $"%{keyword}%")) ||
                    (x.LoaiXa != null && EF.Functions.Like(x.LoaiXa, $"%{keyword}%"))
                )
                .OrderBy(x => x.TenXaMoi)
                .ToListAsync();
        }
    }
}
