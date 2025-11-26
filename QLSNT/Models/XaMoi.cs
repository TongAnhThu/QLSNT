namespace QLSNT.Models
{
    public class XaMoi
    {
        public string MaXaMoi { get; set; } = default!;  // PK
        public string TenXaMoi { get; set; } = default!;
        public string? LoaiXa { get; set; }
        public int? SLAp { get; set; }
        public long? DanSo { get; set; }
        public double? DienTich { get; set; }

        public string MaTinh { get; set; } = default!;   // FK → TinhMoi
        public TinhMoi TinhMoi { get; set; } = default!;

        public ICollection<LssnXa> LssnXas { get; set; } = new List<LssnXa>();
        public ICollection<ThuongTru> ThuongTrus { get; set; } = new List<ThuongTru>();
        public ICollection<TamTru> TamTrus { get; set; } = new List<TamTru>();
    }
}
