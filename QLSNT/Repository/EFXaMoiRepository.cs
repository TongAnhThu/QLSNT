using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFXaMoiRepository : IXaMoiRepository
    {
        private readonly ApplicationDbContext _db;

        public EFXaMoiRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Lấy danh sách xã theo mã tỉnh
        public async Task<IEnumerable<XaMoi>> GetByTinhAsync(int maTinhMoi)
        {
            return await _db.XaMois
                .Include(x => x.TinhMoi)                // Include để load tên tỉnh
                .Where(x => x.MaTinh == maTinhMoi)
                .OrderBy(x => x.MaXaMoi)
                .ToListAsync();
        }

        // Lấy tất cả xã
        public async Task<IEnumerable<XaMoi>> GetAllAsync()
        {
            return await _db.XaMois
                .Include(x => x.TinhMoi)                // Include để load tên tỉnh
                .OrderBy(x => x.MaXaMoi)
                .ToListAsync();
        }

        // Lấy xã theo ID
        public async Task<XaMoi?> GetByIdAsync(int id)
        {
            return await _db.XaMois
                .Include(x => x.TinhMoi)                // Include để load tên tỉnh
                .FirstOrDefaultAsync(x => x.MaXaMoi == id);
        }

        // Thêm xã mới
        public async Task AddAsync(XaMoi entity)
        {
            await _db.XaMois.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        // Cập nhật xã
        public async Task UpdateAsync(XaMoi entity)
        {
            _db.XaMois.Update(entity);
            await _db.SaveChangesAsync();
        }

        // Xóa xã
        public async Task DeleteAsync(int id)
        {
            var entity = await _db.XaMois.FirstOrDefaultAsync(x => x.MaXaMoi == id);
            if (entity != null)
            {
                _db.XaMois.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        // Tìm kiếm xã theo tên, mã, loại
        public async Task<IEnumerable<XaMoi>> SearchByNameAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            return await _db.XaMois
                .Include(x => x.TinhMoi)                // Include để load tên tỉnh
                .Where(x =>
                    (x.TenXaMoi != null && EF.Functions.Like(x.TenXaMoi, $"%{keyword}%")) ||
                    EF.Functions.Like(x.MaXaMoi.ToString(), $"%{keyword}%") ||
                    (x.LoaiXa != null && EF.Functions.Like(x.LoaiXa, $"%{keyword}%"))
                )
                .OrderBy(x => x.TenXaMoi)
                .ToListAsync();
        }
    }
}
