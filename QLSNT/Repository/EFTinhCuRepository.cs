using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFTinhCuRepository : ITinhCuRepository
    {
        private readonly ApplicationDbContext _db;

        public EFTinhCuRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TinhCu>> GetAllAsync()
        {
            return await _db.TinhCus
                .OrderBy(t => t.MaTinhCu)
                .ToListAsync();
        }

        public async Task<TinhCu?> GetByIdAsync(string id)
        {
            return await _db.TinhCus
                .FirstOrDefaultAsync(t => t.MaTinhCu == id);
        }

        public async Task AddAsync(TinhCu entity)
        {
            _db.TinhCus.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TinhCu entity)
        {
            _db.TinhCus.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _db.TinhCus.FirstOrDefaultAsync(t => t.MaTinhCu == id);
            if (entity != null)
            {
                _db.TinhCus.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        // ⭐ Chính là hàm bạn muốn xài:
        public async Task<IEnumerable<TinhCu>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            // Tìm không phân biệt hoa/thường
            return await _db.TinhCus
                .Where(t => t.TenTinhCu != null &&
                            EF.Functions.Like(t.TenTinhCu, $"%{keyword}%"))
                .OrderBy(t => t.TenTinhCu)
                .ToListAsync();
        }
    }
}
