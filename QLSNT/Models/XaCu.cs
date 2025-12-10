using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    public class XaCu
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string MaXaCu { get; set; } = default!;

        // Thuộc tính
        public string TenXaCu { get; set; } = default!;
        public string? LoaiXa { get; set; }
        public string? TrangThai { get; set; }
        public int? SLAp { get; set; }
        public string? GhiChu { get; set; }
        public long? DanSo { get; set; }
        public double? DienTich { get; set; }

        // Khóa ngoại tới HuyenCu
        public string MaHuyenCu { get; set; } = default!;
        [ForeignKey(nameof(MaHuyenCu))]
        public HuyenCu HuyenCu { get; set; } = default!;
    }
}
