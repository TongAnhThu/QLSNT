namespace QLSNT.Models
{
    public class TinhCu
    {
        // Khóa chính
        public string MaTinhCu { get; set; } = default!;

        // Thuộc tính
        public string TenTinh { get; set; } = default!;
        public double? DienTich { get; set; }
        public long? DanSo { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public int? SLHuyen { get; set; }
        public int? SLXa { get; set; }
        public string? VungDiaLy { get; set; }
        public string? LoaiTinh { get; set; }

        // Quan hệ 1 Tỉnh cũ – nhiều Huyện cũ
        public ICollection<HuyenCu> HuyenCus { get; set; } = new List<HuyenCu>();
    }
}
