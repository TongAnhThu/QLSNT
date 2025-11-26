namespace QLSNT.Models
{
    public class TrinhDoVanHoa
    {
        public string MaTDVH { get; set; } = default!;     // PK
        public string TenTDVH { get; set; } = default!;
        public string? MoTa { get; set; }
        public string? GhiChu { get; set; }

        public ICollection<NguoiDan> NguoiDans { get; set; } = new List<NguoiDan>();
    }
}
