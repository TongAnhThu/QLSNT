using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFTinhCuRepository : ITinhCuRepository
    {
        private readonly ApplicationDbContext _context;

        public EFTinhCuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TinhCu>> GetAllAsync()
        {
            return await _context.TinhCus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TinhCu?> GetByIdAsync(string maTinhCu)
        {
            return await _context.TinhCus
                .FirstOrDefaultAsync(t => t.MaTinhCu == maTinhCu);
        }

        public async Task AddAsync(TinhCu entity)
        {
            await _context.TinhCus.AddAsync(entity);
        }

        public async Task UpdateAsync(TinhCu entity)
        {
            // Cách an toàn: attach rồi set state
            _context.TinhCus.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maTinhCu)
        {
            var entity = await GetByIdAsync(maTinhCu);
            if (entity != null)
            {
                _context.TinhCus.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
