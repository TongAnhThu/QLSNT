using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    public class HuyenCu
    {
        [Key]
        [Required]
        [StringLength(10)]
        // Khóa chính
        public string MaHuyenCu { get; set; } = default!;

        // Thuộc tính
        public string TenHuyenCu { get; set; } = default!;
        public string? LoaiHuyen { get; set; }
        public long? DanSo { get; set; }
        public double? DienTich { get; set; }
        public string? TrangThai { get; set; }
        public int? SLXa { get; set; }
        public string? GhiChu { get; set; }

        // Khóa ngoại tới TinhCu
        public string MaTinhCu { get; set; } = default!;
        [ForeignKey(nameof(MaTinhCu))]
        public TinhCu? TinhCu { get; set; } = default!;

        // Quan hệ 1 Huyện cũ – nhiều Xã cũ
        public ICollection<XaCu> XaCus { get; set; } = new List<XaCu>();
    }
}
