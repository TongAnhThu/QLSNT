using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
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

        [Required(ErrorMessage = "Địa chỉ mới là bắt buộc")]
        public string? DiaChiMoi { get; set; }

        public string? NguoiCapNhat { get; set; }
        public string? NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? GhiChu { get; set; }

        // Người dân bắt buộc
        [Required(ErrorMessage = "CCCD là bắt buộc")]
     
        public string MaCCCD { get; set; } = default!;

        [ForeignKey(nameof(MaCCCD))]
        public NguoiDan? NguoiDan { get; set; } = default!;

        // Xã mới bắt buộc
        [Required(ErrorMessage = "Xã mới là bắt buộc")]
      
        public int MaXaMoi { get; set; }

        [ForeignKey(nameof(MaXaMoi))]
        public XaMoi? XaMoi { get; set; } = default!;
    }
}
