using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFHuyenCuRepository : IHuyenCuRepository
    {
        private readonly ApplicationDbContext _context;

        public EFHuyenCuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HuyenCu>> GetAllAsync()
        {
            return await _context.HuyenCus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<HuyenCu?> GetByIdAsync(string maHuyenCu)
        {
            return await _context.HuyenCus
                .FirstOrDefaultAsync(h => h.MaHuyenCu == maHuyenCu);
        }

        public async Task<IEnumerable<HuyenCu>> GetByTinhCuAsync(string maTinhCu)
        {
            return await _context.HuyenCus
                .Where(h => h.MaTinhCu == maTinhCu)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(HuyenCu entity)
        {
            await _context.HuyenCus.AddAsync(entity);
        }

        public async Task UpdateAsync(HuyenCu entity)
        {
            _context.HuyenCus.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maHuyenCu)
        {
            var entity = await GetByIdAsync(maHuyenCu);
            if (entity != null)
            {
                _context.HuyenCus.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
