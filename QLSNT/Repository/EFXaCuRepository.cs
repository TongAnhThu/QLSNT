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
                .OrderBy(x => x.MaXaCu)      // MaXaCu là int
                .ToListAsync();
        }

        public async Task<XaCu?> GetByIdAsync(int id)
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

        public async Task DeleteAsync(int id)
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

            // Tìm theo tên xã, loại xã, hoặc gõ số để match MaXaCu / MaHuyenCu
            return await _db.XaCus
                .Where(x =>
                    (x.TenXaCu != null && EF.Functions.Like(x.TenXaCu, $"%{keyword}%")) ||
                    (x.LoaiXa != null && EF.Functions.Like(x.LoaiXa, $"%{keyword}%")) ||
                    EF.Functions.Like(x.MaXaCu.ToString(), $"%{keyword}%") ||
                    EF.Functions.Like(x.MaHuyenCu.ToString(), $"%{keyword}%")
                )
                .OrderBy(x => x.TenXaCu)
                .ToListAsync();
        }
    }
}
