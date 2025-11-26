using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFXaCuRepository : IXaCuRepository
    {
        private readonly ApplicationDbContext _context;

        public EFXaCuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<XaCu>> GetAllAsync()
        {
            return await _context.XaCus
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<XaCu?> GetByIdAsync(string maXaCu)
        {
            return await _context.XaCus
                .FirstOrDefaultAsync(x => x.MaXaCu == maXaCu);
        }

        public async Task<IEnumerable<XaCu>> GetByHuyenCuAsync(string maHuyenCu)
        {
            return await _context.XaCus
                .Where(x => x.MaHuyenCu == maHuyenCu)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(XaCu entity)
        {
            await _context.XaCus.AddAsync(entity);
        }

        public async Task UpdateAsync(XaCu entity)
        {
            _context.XaCus.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maXaCu)
        {
            var entity = await GetByIdAsync(maXaCu);
            if (entity != null)
            {
                _context.XaCus.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
