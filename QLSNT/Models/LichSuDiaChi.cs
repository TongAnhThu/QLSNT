using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    public class LichSuDiaChi
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string MaLichSuCuTru { get; set; } = default!; // PK
        public string? LoaiThayDoi { get; set; }
        public string? SoQuyetDinh { get; set; }
        public string? LyDoThayDoi { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string? DiaChiCu { get; set; }
        public string? DiaChiMoi { get; set; }
        public string? NguoiCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? GhiChu { get; set; }

        public string MaCCCD { get; set; } = default!;  // FK → NguoiDan
        public string MaXaCu { get; set; } = default!;  // FK → XaCu
        [ForeignKey(nameof(MaCCCD))]
        public NguoiDan NguoiDan { get; set; } = default!;
        [ForeignKey(nameof(MaXaCu))]
        public XaCu XaCu { get; set; } = default!;

        public string MaXaMoi { get; set; } = default!;  // FK → XaCu
        [ForeignKey(nameof(MaXaMoi))]
        public XaMoi xaMoi { get; set; } = default!;

    }
}
