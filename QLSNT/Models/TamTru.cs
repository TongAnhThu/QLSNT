using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    [PrimaryKey(nameof(MaXaMoi), nameof(MaCCCD))]
    public class TamTru
    {
        // Composite key: MaXaMoi + MaCCCD
        public string MaXaMoi { get; set; } = default!;
        public string MaCCCD { get; set; } = default!;

        public string? DiaChi { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? ThoiHan { get; set; }
        public string? NoiDungDeNghi { get; set; }
        [ForeignKey(nameof(MaXaMoi))]
        public XaMoi XaMoi { get; set; } = default!;
        [ForeignKey(nameof(MaCCCD))]

        public NguoiDan NguoiDan { get; set; } = default!;
    }
}

