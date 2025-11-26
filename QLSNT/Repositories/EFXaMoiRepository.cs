using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFXaMoiRepository : IXaMoiRepository
    {
        private readonly ApplicationDbContext _context;

        public EFXaMoiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<XaMoi>> GetAllAsync()
        {
            return await _context.XaMois
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<XaMoi?> GetByIdAsync(string maXaMoi)
        {
            return await _context.XaMois
                .FirstOrDefaultAsync(x => x.MaXaMoi == maXaMoi);
        }

        public async Task<IEnumerable<XaMoi>> GetByTinhMoiAsync(string maTinh)
        {
            return await _context.XaMois
                .Where(x => x.MaTinh == maTinh)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(XaMoi entity)
        {
            await _context.XaMois.AddAsync(entity);
        }

        public async Task UpdateAsync(XaMoi entity)
        {
            _context.XaMois.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maXaMoi)
        {
            var entity = await GetByIdAsync(maXaMoi);
            if (entity != null)
            {
                _context.XaMois.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
