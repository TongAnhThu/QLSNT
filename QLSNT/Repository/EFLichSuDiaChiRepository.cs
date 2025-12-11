using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<LichSuDiaChi>> GetAllAsync(string? keyword = null)
        {
            var query = _context.LichSuDiaChis
                .Include(x => x.NguoiDan)   // navigation sang Người dân
                .Include(x => x.XaMoi)      // chỉ còn XaMoi
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();

                query = query.Where(x =>
                    x.MaCCCD.Contains(keyword) ||
                    (x.NguoiDan != null && x.NguoiDan.HoTen.Contains(keyword)));
            }

            // Mới nhất lên trước
            return await query
                .OrderByDescending(x => x.NgayHieuLuc)
                .ThenByDescending(x => x.MaLichSuCuTru)
                .ToListAsync();
        }

        public async Task<LichSuDiaChi?> GetByIdAsync(string id)
        {
            return await _context.LichSuDiaChis
                .Include(x => x.NguoiDan)
                .Include(x => x.XaMoi)   // chỉ còn XaMoi
                .FirstOrDefaultAsync(x => x.MaLichSuCuTru == id);
        }
        public async Task<string?> GetLastCodeAsync()
        {
            return await _context.LichSuDiaChis
                .OrderByDescending(x => x.MaLichSuCuTru)
                .Select(x => x.MaLichSuCuTru)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(LichSuDiaChi entity)
        {
            _context.LichSuDiaChis.Add(entity);
            await _context.SaveChangesAsync();
        }

        

        public async Task UpdateAsync(LichSuDiaChi entity)
        {
            _context.LichSuDiaChis.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _context.LichSuDiaChis.FindAsync(id);
            if (entity != null)
            {
                _context.LichSuDiaChis.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
