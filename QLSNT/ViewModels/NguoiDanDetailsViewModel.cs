namespace QLSNT.ViewModels
{
    public class NguoiDanDetailsViewModel
    {
        public string MaCCCD { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }   // nullable
        public string GioiTinh { get; set; }
        public int? MaDanToc { get; set; }        // nullable
        public string? MaTonGiao { get; set; }       // nullable
        public string? MaTDVH { get; set; }          // nullable
        public string TinhTrangHonNhan { get; set; }
        public string TrangThaiCongDan { get; set; }

        public int? MaXaMoi { get; set; }         // nullable
        public string DiaChiThuongTru { get; set; }
    }

}