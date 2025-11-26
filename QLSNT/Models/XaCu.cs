namespace QLSNT.Models
{
    public class XaCu
    {
        // Khóa chính
        public string MaXaCu { get; set; } = default!;

        // Thuộc tính
        public string TenXaCu { get; set; } = default!;
        public string? LoaiXa { get; set; }
        public int? SLAp { get; set; }
        public long? DanSo { get; set; }
        public double? DienTich { get; set; }

        // Khóa ngoại tới HuyenCu
        public string MaHuyenCu { get; set; } = default!;
        public HuyenCu HuyenCu { get; set; } = default!;
    }
}
