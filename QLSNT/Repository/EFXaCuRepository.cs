using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFXaCuRepository : IXaCuRepository
    {
        private readonly ApplicationDbContext _db;

        public EFXaCuRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<XaCu>> GetAllAsync()
        {
            return await _db.XaCus
                .OrderBy(x => x.MaXaCu)
                .ToListAsync();
        }

        public async Task<XaCu?> GetByIdAsync(string id)
        {
            return await _db.XaCus
                .FirstOrDefaultAsync(x => x.MaXaCu == id);
        }

        public async Task AddAsync(XaCu entity)
        {
            _db.XaCus.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(XaCu entity)
        {
            _db.XaCus.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _db.XaCus.FirstOrDefaultAsync(x => x.MaXaCu == id);
            if (entity != null)
            {
                _db.XaCus.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<XaCu>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            // Tìm theo tên xã (và có thể cả mã, loại, huyện)
            return await _db.XaCus
                .Where(x =>
                    (x.TenXaCu != null && EF.Functions.Like(x.TenXaCu, $"%{keyword}%")) ||
                    (x.MaXaCu != null && EF.Functions.Like(x.MaXaCu, $"%{keyword}%")) ||
                    (x.LoaiXa != null && EF.Functions.Like(x.LoaiXa, $"%{keyword}%")) ||
                    (x.MaHuyenCu != null && EF.Functions.Like(x.MaHuyenCu, $"%{keyword}%"))
                )
                .OrderBy(x => x.TenXaCu)
                .ToListAsync();
        }
    }
}
