namespace QLSNT.Models
{
    public class QuanHeChuHo
    {
        public string MaQHCH { get; set; } = default!;     // PK
        public string TenQHCH { get; set; } = default!;
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }

        public ICollection<NguoiDan> NguoiDans { get; set; } = new List<NguoiDan>();
    }
}
