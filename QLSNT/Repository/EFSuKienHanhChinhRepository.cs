using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFSuKienHanhChinhRepository : ISuKienHanhChinhRepository
    {
        private readonly ApplicationDbContext _db;

        public EFSuKienHanhChinhRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SuKienHanhChinh>> GetAllAsync()
        {
            return await _db.SuKienHanhChinhs
                .OrderBy(s => s.SoNghiDinh)
                .ToListAsync();
        }

        public async Task<SuKienHanhChinh?> GetByIdAsync(string id)
        {
            return await _db.SuKienHanhChinhs
                .FirstOrDefaultAsync(s => s.SoNghiDinh == id);
        }

        public async Task AddAsync(SuKienHanhChinh entity)
        {
            _db.SuKienHanhChinhs.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(SuKienHanhChinh entity)
        {
            _db.SuKienHanhChinhs.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _db.SuKienHanhChinhs.FirstOrDefaultAsync(s => s.SoNghiDinh == id);
            if (entity != null)
            {
                _db.SuKienHanhChinhs.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SuKienHanhChinh>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllAsync();

            keyword = keyword.Trim();

            return await _db.SuKienHanhChinhs
                .Where(s =>
                    EF.Functions.Like(s.TenSK, $"%{keyword}%") ||
                    (s.CoQuanBanHanh != null && EF.Functions.Like(s.CoQuanBanHanh, $"%{keyword}%"))
                )
                .OrderBy(s => s.TenSK)
                .ToListAsync();
        }
    }
}
