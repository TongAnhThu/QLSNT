using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
{
    public class EFLichSuSapNhapRepository : ILichSuSapNhapRepository
    {
        private readonly ApplicationDbContext _db;

        public EFLichSuSapNhapRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // =================== GET ALL ===================
        public async Task<List<LichSuSapNhap>> GetAllAsync()
        {
            return await _db.LichSuSapNhaps
                .OrderBy(l => l.MaLSSN)
                .ToListAsync();
        }

        // =================== GET BY ID (Mộc) ===================
        public async Task<LichSuSapNhap?> GetByIdAsync(string maLssn)
        {
            if (string.IsNullOrWhiteSpace(maLssn))
                return null;

            maLssn = maLssn.Trim();

            return await _db.LichSuSapNhaps
                .FirstOrDefaultAsync(l => l.MaLSSN == maLssn);
        }

        // =================== GET DETAILS (Include quan hệ) ===================
        public async Task<LichSuSapNhap?> GetDetailsAsync(string maLssn)
        {
            if (string.IsNullOrWhiteSpace(maLssn))
                return null;

            maLssn = maLssn.Trim();

            return await _db.LichSuSapNhaps
                .Include(l => l.LssnTinhs)
                .Include(l => l.LssnXas)
                // Nếu sau này bạn có navigation tới SuKienHanhChinh/Tỉnh/Xã thì có thể .ThenInclude thêm ở đây
                .FirstOrDefaultAsync(l => l.MaLSSN == maLssn);
        }

        // =================== GET BY SỐ NGHỊ ĐỊNH ===================
        public async Task<List<LichSuSapNhap>> GetBySoNghiDinhAsync(string soNghiDinh)
        {
            if (string.IsNullOrWhiteSpace(soNghiDinh))
                return new List<LichSuSapNhap>();

            soNghiDinh = soNghiDinh.Trim();

            return await _db.LichSuSapNhaps
                .Where(l => l.SoNghiDinh == soNghiDinh)
                .OrderBy(l => l.MaLSSN)
                .ToListAsync();
        }

        // =================== SEARCH ===================
        public async Task<List<LichSuSapNhap>> SearchAsync(string? keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Không có keyword thì trả toàn bộ
                return await GetAllAsync();
            }

            keyword = keyword.Trim();

            return await _db.LichSuSapNhaps
                .Where(l =>
                    EF.Functions.Like(l.MaLSSN, $"%{keyword}%") ||
                    EF.Functions.Like(l.SoNghiDinh, $"%{keyword}%") ||
                    (l.GhiChu != null && EF.Functions.Like(l.GhiChu, $"%{keyword}%"))
                )
                .OrderByDescending(l => l.NgayTao)
                .ToListAsync();
        }

        // =================== ADD ===================
        public async Task AddAsync(LichSuSapNhap entity)
        {
            // Có thể chuẩn hóa MaLssn ở đây nếu cần (Trim, Upper, ...)
            _db.LichSuSapNhaps.Add(entity);
            await _db.SaveChangesAsync();
        }

        // =================== UPDATE ===================
        public async Task UpdateAsync(LichSuSapNhap entity)
        {
            _db.LichSuSapNhaps.Update(entity);
            await _db.SaveChangesAsync();
        }

        // =================== DELETE ===================
        public async Task DeleteAsync(string maLssn)
        {
            if (string.IsNullOrWhiteSpace(maLssn))
                return;

            maLssn = maLssn.Trim();

            var entity = await _db.LichSuSapNhaps
                .FirstOrDefaultAsync(l => l.MaLSSN == maLssn);

            if (entity != null)
            {
                _db.LichSuSapNhaps.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}
