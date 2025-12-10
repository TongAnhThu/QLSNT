using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFDanTocRepository : IDanTocRepository
    {
        private readonly ApplicationDbContext _context;

        public EFDanTocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DanToc>> GetAllAsync()
        {
            return await _context.DanTocs
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<DanToc?> GetByIdAsync(int maDanToc)
        {
            return await _context.DanTocs
                .FirstOrDefaultAsync(d => d.MaDanToc == maDanToc);
        }

        public async Task<IEnumerable<DanToc>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            keyword = keyword.Trim();

            return await _context.DanTocs
                .Where(d =>
                    d.TenDanToc.Contains(keyword) ||
                    (d.TenKhac != null && d.TenKhac.Contains(keyword)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(DanToc entity)
        {
            await _context.DanTocs.AddAsync(entity);
        }

        public async Task UpdateAsync(DanToc entity)
        {
            _context.DanTocs.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int maDanToc)
        {
            var entity = await GetByIdAsync(maDanToc);
            if (entity != null)
            {
                _context.DanTocs.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
