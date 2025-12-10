using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFThuongTruRepository : IThuongTruRepository
    {
        private readonly ApplicationDbContext _context;

        public EFThuongTruRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ThuongTru>> GetAllAsync()
        {
            return await _context.ThuongTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .AsNoTracking()
                .OrderBy(t => t.MaXaMoi)
                .ThenBy(t => t.MaCCCD)
                .ToListAsync();
        }

        public async Task<IEnumerable<ThuongTru>> SearchAsync(string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            var query = _context.ThuongTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .AsQueryable();

            return await query
                .Where(t =>
                    EF.Functions.Like(t.MaXaMoi, $"%{keyword}%") ||
                    EF.Functions.Like(t.MaCCCD, $"%{keyword}%") ||
                    (t.DiaChi != null && EF.Functions.Like(t.DiaChi, $"%{keyword}%"))
                // nếu NguoiDan có HoTen, có thể thêm:
                // || (t.NguoiDan.HoTen != null && EF.Functions.Like(t.NguoiDan.HoTen, $"%{keyword}%"))
                )
                .AsNoTracking()
                .OrderBy(t => t.MaXaMoi)
                .ThenBy(t => t.MaCCCD)
                .ToListAsync();
        }

        public async Task<ThuongTru?> GetByIdAsync(string maXaMoi, string maCccd)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCccd))
                return null;

            maXaMoi = maXaMoi.Trim();
            maCccd = maCccd.Trim();

            return await _context.ThuongTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .FirstOrDefaultAsync(t => t.MaXaMoi == maXaMoi && t.MaCCCD == maCccd);
        }

        public async Task<IEnumerable<ThuongTru>> GetByXaMoiAsync(string maXaMoi)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi))
                return Enumerable.Empty<ThuongTru>();

            maXaMoi = maXaMoi.Trim();

            return await _context.ThuongTrus
                .Where(t => t.MaXaMoi == maXaMoi)
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .AsNoTracking()
                .OrderBy(t => t.MaCCCD)
                .ToListAsync();
        }

        public async Task<IEnumerable<ThuongTru>> GetByNguoiDanAsync(string maCccd)
        {
            if (string.IsNullOrWhiteSpace(maCccd))
                return Enumerable.Empty<ThuongTru>();

            maCccd = maCccd.Trim();

            return await _context.ThuongTrus
                .Where(t => t.MaCCCD == maCccd)
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .AsNoTracking()
                .OrderBy(t => t.MaXaMoi)
                .ToListAsync();
        }

        public async Task AddAsync(ThuongTru entity)
        {
            await _context.ThuongTrus.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ThuongTru entity)
        {
            _context.ThuongTrus.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string maXaMoi, string maCccd)
        {
            var existing = await GetByIdAsync(maXaMoi, maCccd);
            if (existing != null)
            {
                _context.ThuongTrus.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
