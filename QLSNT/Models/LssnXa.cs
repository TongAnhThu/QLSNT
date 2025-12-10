using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    public class LssnXa
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string MaLSSN { get; set; } = default!;   // PK + FK → LichSuSapNhap
        public int MaXaMoi { get; set; } = default!;  // FK → XaMoi
        public int MaXaCu { get; set; } = default!;   // FK → XaCu
        [ForeignKey(nameof(MaLSSN))]
        public LichSuSapNhap LichSuSapNhap { get; set; } = default!;
        [ForeignKey(nameof(MaXaMoi))]
        public XaMoi XaMoi { get; set; } = default!;
        [ForeignKey(nameof(MaXaCu))]
        public XaCu XaCu { get; set; } = default!;
    }
}
