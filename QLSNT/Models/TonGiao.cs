namespace QLSNT.Models
{
    public class TonGiao
    {
        public string MaTonGiao { get; set; } = default!;  // PK
        public string TenTonGiao { get; set; } = default!;
        public string? TenKhac { get; set; }
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }

        public ICollection<NguoiDan> NguoiDans { get; set; } = new List<NguoiDan>();
    }
}
