using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    public class XaMoi
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaXaMoi { get; set; } = default!;  // PK
        public string TenXaMoi { get; set; } = default!;
        public string? LoaiXa { get; set; }
        public string? TrangThai { get; set; }              
        public string? GhiChu { get; set; }

        public int? SLAp { get; set; }
        public long? DanSo { get; set; }
        public double? DienTich { get; set; }

        
        public int MaTinh { get; set; } = default!;   // FK → TinhMoi
        [ForeignKey(nameof(MaTinh))]
        public TinhMoi? TinhMoi { get; set; } = default!;

        public ICollection<LssnXa> LssnXas { get; set; } = new List<LssnXa>();
        public ICollection<ThuongTru> ThuongTrus { get; set; } = new List<ThuongTru>();
        public ICollection<TamTru> TamTrus { get; set; } = new List<TamTru>();
    }
}
