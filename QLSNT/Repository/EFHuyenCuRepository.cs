using Microsoft.EntityFrameworkCore;
using QLSNT.Data;
using QLSNT.Models;

namespace QLSNT.Repositories
    {
        public class EFHuyenCuRepository : IHuyenCuRepository
        {
            private readonly ApplicationDbContext _db;

            public EFHuyenCuRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<IEnumerable<HuyenCu>> GetAllAsync()
            {
                return await _db.HuyenCus
                    .OrderBy(h => h.MaHuyenCu)
                    .ToListAsync();
            }

            public async Task<HuyenCu?> GetByIdAsync(string id)
            {
                return await _db.HuyenCus
                    .FirstOrDefaultAsync(h => h.MaHuyenCu == id);
            }

            public async Task AddAsync(HuyenCu entity)
            {
                _db.HuyenCus.Add(entity);
                await _db.SaveChangesAsync();
            }

            public async Task UpdateAsync(HuyenCu entity)
            {
                _db.HuyenCus.Update(entity);
                await _db.SaveChangesAsync();
            }

            public async Task DeleteAsync(string id)
            {
                var entity = await _db.HuyenCus.FirstOrDefaultAsync(h => h.MaHuyenCu == id);
                if (entity != null)
                {
                    _db.HuyenCus.Remove(entity);
                    await _db.SaveChangesAsync();
                }
            }

            // ⭐ Hàm SearchByNameAsync mà controller đang gọi
            public async Task<IEnumerable<HuyenCu>> SearchByNameAsync(string keyword)
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return await GetAllAsync();
                }

                keyword = keyword.Trim();

                return await _db.HuyenCus
                    .Where(h =>
                        h.TenHuyenCu != null &&
                        EF.Functions.Like(h.TenHuyenCu, $"%{keyword}%"))
                    .OrderBy(h => h.TenHuyenCu)
                    .ToListAsync();
            }
        }
    }


