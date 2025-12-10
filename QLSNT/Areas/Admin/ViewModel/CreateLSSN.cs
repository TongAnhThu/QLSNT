using System.ComponentModel.DataAnnotations;

namespace QLSNT.Areas.Admin.ViewModel
{
    public class CreateLSSN
    {
        public string? MaLSSN { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số nghị định")]
        public string SoNghiDinh { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn loại sáp nhập")]
        public string Loai { get; set; } = string.Empty;

        public int? MaTinhCu { get; set; }
        public int? MaTinhMoi { get; set; }
        public int? MaXaCu { get; set; }
        public int? MaXaMoi { get; set; }
    }

}
