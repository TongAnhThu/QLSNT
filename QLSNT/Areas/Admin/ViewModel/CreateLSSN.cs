using QLSNT.Models;
using System.ComponentModel.DataAnnotations;

namespace QLSNT.Areas.Admin.ViewModel
{
    public class CreateLSSN
    {
        public string? MaLSSN { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số nghị định")]
       

        
        public string Loai { get; set; } = string.Empty;

        public int? MaTinhCu { get; set; }
        public int? MaTinhMoi { get; set; }
        public int? MaXaCu { get; set; }
        public int? MaXaMoi { get; set; }

        // Thêm danh sách để bind dropdown
        public IEnumerable<TinhCu>? TinhCuList { get; set; }
        public IEnumerable<TinhMoi>? TinhMoiList { get; set; }
        public IEnumerable<XaCu>? XaCuList { get; set; }
        public IEnumerable<XaMoi>? XaMoiList { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại sáp nhập")]
        public string SoNghiDinh { get; set; } = string.Empty;
        public List<SuKienHanhChinh>? SuKienHanhChinhList { get; set; }
    }


}
