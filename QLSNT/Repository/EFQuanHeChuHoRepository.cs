using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFQuanHeChuHoRepository : IQuanHeChuHoRepository
    {
        private readonly ApplicationDbContext _context;

        public EFQuanHeChuHoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuanHeChuHo>> GetAllAsync()
        {
            return await _context.QuanHeChuHos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<QuanHeChuHo?> GetByIdAsync(string maQhch)
        {
            return await _context.QuanHeChuHos
                .FirstOrDefaultAsync(q => q.MaQHCH == maQhch);
        }

        public async Task<IEnumerable<QuanHeChuHo>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            keyword = keyword.Trim();

            return await _context.QuanHeChuHos
                .Where(q => q.TenQHCH.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(QuanHeChuHo entity)
        {
            await _context.QuanHeChuHos.AddAsync(entity);
        }

        public async Task UpdateAsync(QuanHeChuHo entity)
        {
            _context.QuanHeChuHos.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maQhch)
        {
            var entity = await GetByIdAsync(maQhch);
            if (entity != null)
            {
                _context.QuanHeChuHos.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
