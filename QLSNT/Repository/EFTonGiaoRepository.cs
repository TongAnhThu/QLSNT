using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFTonGiaoRepository : ITonGiaoRepository
    {
        private readonly ApplicationDbContext _context;

        public EFTonGiaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TonGiao>> GetAllAsync()
        {
            return await _context.TonGiaos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TonGiao?> GetByIdAsync(string maTonGiao)
        {
            return await _context.TonGiaos
                .FirstOrDefaultAsync(t => t.MaTonGiao == maTonGiao);
        }

        public async Task<IEnumerable<TonGiao>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            keyword = keyword.Trim();

            return await _context.TonGiaos
                .Where(t =>
                    t.TenTonGiao.Contains(keyword) ||
                    (t.TenKhac != null && t.TenKhac.Contains(keyword)))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(TonGiao entity)
        {
            await _context.TonGiaos.AddAsync(entity);
        }

        public async Task UpdateAsync(TonGiao entity)
        {
            _context.TonGiaos.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maTonGiao)
        {
            var entity = await GetByIdAsync(maTonGiao);
            if (entity != null)
            {
                _context.TonGiaos.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
