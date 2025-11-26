namespace QLSNT.Models
{
    public class LichSuSapNhap
    {
        public string MaLSSN { get; set; } = default!;   // PK
        public string? NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? GhiChu { get; set; }

        public string SoNghiDinh { get; set; } = default!;   // FK → SuKienHanhChinh
        public SuKienHanhChinh SuKienHanhChinh { get; set; } = default!;

        public ICollection<LssnTinh> LssnTinhs { get; set; } = new List<LssnTinh>();
        public ICollection<LssnXa> LssnXas { get; set; } = new List<LssnXa>();
    }
}
