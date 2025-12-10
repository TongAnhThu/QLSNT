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
                .OrderBy(t => t.MaTinhMoi)  // Sắp xếp theo MaTinhMoi, kiểu int
                .ToListAsync();
        }

        public async Task<TinhMoi?> GetByIdAsync(int id)  // Đổi kiểu id thành int
        {
            return await _db.TinhMois
                .FirstOrDefaultAsync(t => t.MaTinhMoi == id);  // So sánh với int
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

        public async Task DeleteAsync(int id)  // Đổi kiểu id thành int
        {
            var entity = await _db.TinhMois.FirstOrDefaultAsync(t => t.MaTinhMoi == id);  // So sánh với int
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
                    (t.MaTinhMoi.ToString() != null && EF.Functions.Like(t.MaTinhMoi.ToString(), $"%{keyword}%")) ||  // Chuyển int thành string để so sánh
                    (t.LoaiTinh != null && EF.Functions.Like(t.LoaiTinh, $"%{keyword}%"))
                )
                .OrderBy(t => t.TenTinhMoi)
                .ToListAsync();
        }
    }
}
