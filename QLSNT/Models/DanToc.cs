using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QLSNT.Models
{
   
    public class DanToc
    {
        [Key]
        [Required]
        [StringLength(10)]

        public int MaDanToc { get; set; } = default! ;   
        public string TenDanToc { get; set; } = default!;
        public string? TenKhac { get; set; }
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }

        public ICollection<NguoiDan> NguoiDans { get; set; } = new List<NguoiDan>();
    }
}
