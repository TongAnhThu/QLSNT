using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFTrinhDoVanHoaRepository : ITrinhDoVanHoaRepository
    {
        private readonly ApplicationDbContext _context;

        public EFTrinhDoVanHoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrinhDoVanHoa>> GetAllAsync()
        {
            return await _context.TrinhDoVanHoas
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TrinhDoVanHoa?> GetByIdAsync(string maTdvh)
        {
            return await _context.TrinhDoVanHoas
                .FirstOrDefaultAsync(t => t.MaTDVH == maTdvh);
        }

        public async Task<IEnumerable<TrinhDoVanHoa>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            keyword = keyword.Trim();

            return await _context.TrinhDoVanHoas
                .Where(t => t.TenTDVH.Contains(keyword))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(TrinhDoVanHoa entity)
        {
            await _context.TrinhDoVanHoas.AddAsync(entity);
        }

        public async Task UpdateAsync(TrinhDoVanHoa entity)
        {
            _context.TrinhDoVanHoas.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maTdvh)
        {
            var entity = await GetByIdAsync(maTdvh);
            if (entity != null)
            {
                _context.TrinhDoVanHoas.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
