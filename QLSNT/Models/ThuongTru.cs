namespace QLSNT.Models
{
    public class ThuongTru
    {
        // Composite key: MaXaMoi + MaCCCD
        public string MaXaMoi { get; set; } = default!;
        public string MaCCCD { get; set; } = default!;

        public string? DiaChi { get; set; }
        public DateTime? NgayDangKy { get; set; }

        public XaMoi XaMoi { get; set; } = default!;
        public NguoiDan NguoiDan { get; set; } = default!;
    }
}
