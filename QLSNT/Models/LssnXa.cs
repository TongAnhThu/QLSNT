namespace QLSNT.Models
{
    public class LssnXa
    {
        public string MaLSSN { get; set; } = default!;   // PK + FK → LichSuSapNhap
        public string MaXaMoi { get; set; } = default!;  // FK → XaMoi
        public string MaXaCu { get; set; } = default!;   // FK → XaCu

        public LichSuSapNhap LichSuSapNhap { get; set; } = default!;
        public XaMoi XaMoi { get; set; } = default!;
        public XaCu XaCu { get; set; } = default!;
    }
}
