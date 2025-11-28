using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFLssnXaRepository : ILssnXaRepository
    {
        private readonly ApplicationDbContext _context;

        public EFLssnXaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LssnXa>> GetAllAsync()
        {
            return await _context.LssnXas
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<LssnXa?> GetByIdAsync(string maLssn)
        {
            return await _context.LssnXas
                .FirstOrDefaultAsync(x => x.MaLSSN == maLssn);
        }

        public async Task<IEnumerable<LssnXa>> GetByLssnAsync(string maLssn)
        {
            return await _context.LssnXas
                .Where(x => x.MaLSSN == maLssn)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LssnXa>> GetByXaCuAsync(string maXaCu)
        {
            return await _context.LssnXas
                .Where(x => x.MaXaCu == maXaCu)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LssnXa>> GetByXaMoiAsync(string maXaMoi)
        {
            return await _context.LssnXas
                .Where(x => x.MaXaMoi == maXaMoi)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(LssnXa entity)
        {
            await _context.LssnXas.AddAsync(entity);
        }

        public async Task UpdateAsync(LssnXa entity)
        {
            _context.LssnXas.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maLssn)
        {
            var entity = await GetByIdAsync(maLssn);
            if (entity != null)
            {
                _context.LssnXas.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
