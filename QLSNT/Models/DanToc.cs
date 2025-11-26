namespace QLSNT.Models
{
    public class DanToc
    {
        public string MaDanToc { get; set; } = default!;   // PK
        public string TenDanToc { get; set; } = default!;
        public string? TenKhac { get; set; }
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }

        public ICollection<NguoiDan> NguoiDans { get; set; } = new List<NguoiDan>();
    }
}
