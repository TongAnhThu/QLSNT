namespace QLSNT.Models
{
    public class LssnTinh
    {
        public string MaLSSN { get; set; } = default!;    // PK + FK → LichSuSapNhap
        public string MaTinhCu { get; set; } = default!;  // FK → TinhCu
        public string MaTinh { get; set; } = default!;    // FK → TinhMoi

        public LichSuSapNhap LichSuSapNhap { get; set; } = default!;
        public TinhCu TinhCu { get; set; } = default!;
        public TinhMoi TinhMoi { get; set; } = default!;
    }
}
