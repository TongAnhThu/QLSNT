using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    public class LichSuSapNhap
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string MaLSSN { get; set; } = default!;
        public string? NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? GhiChu { get; set; }

        public string SoNghiDinh { get; set; } = default!;
        [ForeignKey(nameof(SoNghiDinh))]
        public SuKienHanhChinh SuKienHanhChinh { get; set; } = default!;

        // Thêm lại property này
        public ICollection<LssnTinh> LssnTinhs { get; set; } = new List<LssnTinh>();
        public ICollection<LssnXa> LssnXas { get; set; } = new List<LssnXa>();
    }


}
