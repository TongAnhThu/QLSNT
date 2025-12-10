using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFTinhMoiRepository : ITinhMoiRepository
    {
        private readonly ApplicationDbContext _db;

        public EFTinhMoiRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TinhMoi>> GetAllAsync()
        {
            return await _db.TinhMois
                .OrderBy(t => t.MaTinhMoi)
                .ToListAsync();
        }

        public async Task<TinhMoi?> GetByIdAsync(string id)
        {
            return await _db.TinhMois
                .FirstOrDefaultAsync(t => t.MaTinhMoi == id);
        }

        public async Task AddAsync(TinhMoi entity)
        {
            _db.TinhMois.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TinhMoi entity)
        {
            _db.TinhMois.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _db.TinhMois.FirstOrDefaultAsync(t => t.MaTinhMoi == id);
            if (entity != null)
            {
                _db.TinhMois.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TinhMoi>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            // Tìm theo tên tỉnh (có thể mở rộng thêm mã / loại nếu muốn)
            return await _db.TinhMois
                .Where(t =>
                    (t.TenTinhMoi != null && EF.Functions.Like(t.TenTinhMoi, $"%{keyword}%")) ||
                    (t.MaTinhMoi != null && EF.Functions.Like(t.MaTinhMoi, $"%{keyword}%")) ||
                    (t.LoaiTinh != null && EF.Functions.Like(t.LoaiTinh, $"%{keyword}%"))
                )
                .OrderBy(t => t.TenTinhMoi)
                .ToListAsync();
        }
    }
}
