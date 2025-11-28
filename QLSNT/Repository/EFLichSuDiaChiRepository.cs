using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFLichSuDiaChiRepository : ILichSuDiaChiRepository
    {
        private readonly ApplicationDbContext _context;

        public EFLichSuDiaChiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LichSuDiaChi>> GetAllAsync()
        {
            return await _context.LichSuDiaChis
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<LichSuDiaChi?> GetByIdAsync(string maLsdc)
        {
            return await _context.LichSuDiaChis
                .FirstOrDefaultAsync(x => x.MaLichSuCuTru == maLsdc);
        }

        public async Task<IEnumerable<LichSuDiaChi>> GetByNguoiDanAsync(string maCccd)
        {
            return await _context.LichSuDiaChis
                .Where(x => x.MaCCCD == maCccd)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<LichSuDiaChi>> GetByXaMoiAsync(string maXaMoi)
        {
            return await _context.LichSuDiaChis
                .Where(x => x.MaXaCu == maXaMoi)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddAsync(LichSuDiaChi entity)
        {
            await _context.LichSuDiaChis.AddAsync(entity);
        }

        public async Task UpdateAsync(LichSuDiaChi entity)
        {
            _context.LichSuDiaChis.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string maLsdc)
        {
            var entity = await GetByIdAsync(maLsdc);
            if (entity != null)
            {
                _context.LichSuDiaChis.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
