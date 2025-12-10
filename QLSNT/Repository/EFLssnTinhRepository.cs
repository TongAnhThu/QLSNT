using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFLssnTinhRepository : ILssnTinhRepository
    {
        private readonly ApplicationDbContext _context;

        public EFLssnTinhRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LssnTinh>> GetAllAsync()
        {
            return await _context.LssnTinhs
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LssnTinh>> GetByLssnAsync(string maLssn)
        {
            return await _context.LssnTinhs
                .Where(x => x.MaLSSN == maLssn)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LssnTinh>> GetByTinhCuAsync(string maTinhCu)
        {
            return await _context.LssnTinhs
                .Where(x => x.MaTinhCu == maTinhCu)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LssnTinh>> GetByTinhMoiAsync(string maTinhMoi)
        {
            return await _context.LssnTinhs
                .Where(x => x.MaTinhMoi == maTinhMoi)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<LssnTinh?> GetByIdAsync(string maLssn)
        {
            return await _context.LssnTinhs
                .FirstOrDefaultAsync(x => x.MaLSSN == maLssn);
        }

        public async Task AddAsync(LssnTinh entity)
        {
            await _context.LssnTinhs.AddAsync(entity);
        }

        public async Task UpdateAsync(LssnTinh entity)
        {
            _context.LssnTinhs.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maLssn)
        {
            var entity = await GetByIdAsync(maLssn);
            if (entity != null)
            {
                _context.LssnTinhs.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
