namespace QLSNT.Models
{
    public class TamTru
    {
        // Composite key: MaXaMoi + MaCCCD
        public string MaXaMoi { get; set; } = default!;
        public string MaCCCD { get; set; } = default!;

        public string? DiaChi { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public DateTime? ThoiHan { get; set; }

        public XaMoi XaMoi { get; set; } = default!;
        public NguoiDan NguoiDan { get; set; } = default!;
    }
}

