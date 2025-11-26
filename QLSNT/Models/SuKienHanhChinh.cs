namespace QLSNT.Models
{
    public class SuKienHanhChinh
    {
        public string SoNghiDinh { get; set; } = default!;   // PK
        public string TenSK { get; set; } = default!;
        public string? MoTaChiTiet { get; set; }
        public string? CanCuPhapLy { get; set; }
        public string? CoQuanBanHanh { get; set; }
        public DateTime? NgayBanHanh { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? NguoiTao { get; set; }

        public ICollection<LichSuSapNhap> LichSuSapNhaps { get; set; } = new List<LichSuSapNhap>();
    }   
}
