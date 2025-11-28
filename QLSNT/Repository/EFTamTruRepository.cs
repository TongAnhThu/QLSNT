using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFTamTruRepository : ITamTruRepository
    {
        private readonly ApplicationDbContext _db;

        public EFTamTruRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<TamTru>> GetAllAsync()
        {
            return await _db.TamTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .OrderBy(t => t.MaXaMoi)
                .ThenBy(t => t.MaCCCD)
                .ToListAsync();
        }

        public async Task<List<TamTru>> SearchAsync(string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            var query = _db.TamTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .AsQueryable();

            // Tùy bạn có thuộc tính gì trong NguoiDan/XaMoi, tớ để basic:
            return await query
                .Where(t =>
                    EF.Functions.Like(t.MaXaMoi, $"%{keyword}%") ||
                    EF.Functions.Like(t.MaCCCD, $"%{keyword}%") ||
                    (t.DiaChi != null && EF.Functions.Like(t.DiaChi, $"%{keyword}%")) ||
                    (t.NoiDungDeNghi != null && EF.Functions.Like(t.NoiDungDeNghi, $"%{keyword}%"))
                )
                .OrderBy(t => t.MaXaMoi)
                .ThenBy(t => t.MaCCCD)
                .ToListAsync();
        }

        public async Task<TamTru?> GetByIdAsync(string maXaMoi, string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCCCD))
                return null;

            maXaMoi = maXaMoi.Trim();
            maCCCD = maCCCD.Trim();

            return await _db.TamTrus
                .Include(t => t.XaMoi)
                .Include(t => t.NguoiDan)
                .FirstOrDefaultAsync(t => t.MaXaMoi == maXaMoi && t.MaCCCD == maCCCD);
        }

        public async Task AddAsync(TamTru entity)
        {
            _db.TamTrus.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TamTru entity)
        {
            _db.TamTrus.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string maXaMoi, string maCCCD)
        {
            if (string.IsNullOrWhiteSpace(maXaMoi) || string.IsNullOrWhiteSpace(maCCCD))
                return;

            maXaMoi = maXaMoi.Trim();
            maCCCD = maCCCD.Trim();

            var entity = await _db.TamTrus
                .FirstOrDefaultAsync(t => t.MaXaMoi == maXaMoi && t.MaCCCD == maCCCD);

            if (entity != null)
            {
                _db.TamTrus.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
