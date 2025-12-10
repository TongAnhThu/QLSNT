using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSNT.Models
{
    [PrimaryKey(nameof(MaXaMoi), nameof(MaCCCD))]
    public class ThuongTru
    {
        // Composite key: MaXaMoi + MaCCCD
        public int MaXaMoi { get; set; } = default!;
        public string MaCCCD { get; set; } = default!;

        public string? DiaChi { get; set; }
        public DateTime? NgayDangKy { get; set; }
        [ForeignKey(nameof(MaXaMoi))]
        public XaMoi XaMoi { get; set; } = default!;
        [ForeignKey(nameof(MaCCCD))]
        public NguoiDan NguoiDan { get; set; } = default!;


        [NotMapped]   // EF sẽ bỏ qua, không tạo cột trong DB
        public int MaXaCu { get; set; }
    }
}
