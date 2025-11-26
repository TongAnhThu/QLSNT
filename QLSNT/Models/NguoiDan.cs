namespace QLSNT.Models
{
    public class NguoiDan
    {
        public string MaCCCD { get; set; } = default!;   // PK
        public string HoTen { get; set; } = default!;
        public string? HoTenKhongDau { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? NoiSinh { get; set; }
        public string? NgheNghiep { get; set; }
        public string? NoiLamViec { get; set; }
        public string? TinhTrangHonNhan { get; set; }
        public string? TrangThaiCongDan { get; set; }

        public string? MaQHCH { get; set; }
        public string? MaTonGiao { get; set; }
        public string? MaDanToc { get; set; }
        public string? MaTDVH { get; set; }

        public QuanHeChuHo? QuanHeChuHo { get; set; }
        public TonGiao? TonGiao { get; set; }
        public DanToc? DanToc { get; set; }
        public TrinhDoVanHoa? TrinhDoVanHoa { get; set; }

        public ICollection<ThuongTru> ThuongTrus { get; set; } = new List<ThuongTru>();
        public ICollection<TamTru> TamTrus { get; set; } = new List<TamTru>();
        public ICollection<LichSuDiaChi> LichSuDiaChis { get; set; } = new List<LichSuDiaChi>();
    }
}
