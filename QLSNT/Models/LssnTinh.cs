using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    
    public class LssnTinh
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string MaLSSN { get; set; } = default!;    // PK + FK → LichSuSapNhap
        public string MaTinhCu { get; set; } = default!;  // FK → TinhCu
        public string MaTinhMoi { get; set; } = default!;    // FK → TinhMoi
        [ForeignKey(nameof(MaLSSN))]
        public LichSuSapNhap LichSuSapNhap { get; set; } = default!;
        [ForeignKey(nameof(MaTinhCu))]
        public TinhCu TinhCu { get; set; } = default!;
        [ForeignKey(nameof(MaTinhMoi))]
        public TinhMoi TinhMoi { get; set; } = default!;
    }
}
