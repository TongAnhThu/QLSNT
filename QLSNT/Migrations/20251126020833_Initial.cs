using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSNT.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanTocs",
                columns: table => new
                {
                    MaDanToc = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKhac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanTocs", x => x.MaDanToc);
                });

            migrationBuilder.CreateTable(
                name: "QuanHeChuHos",
                columns: table => new
                {
                    MaQHCH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenQHCH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHeChuHos", x => x.MaQHCH);
                });

            migrationBuilder.CreateTable(
                name: "SuKienHanhChinhs",
                columns: table => new
                {
                    SoNghiDinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenSK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanCuPhapLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoQuanBanHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBanHanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuKienHanhChinhs", x => x.SoNghiDinh);
                });

            migrationBuilder.CreateTable(
                name: "TinhCus",
                columns: table => new
                {
                    MaTinhCu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienTich = table.Column<double>(type: "float", nullable: true),
                    DanSo = table.Column<long>(type: "bigint", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLHuyen = table.Column<int>(type: "int", nullable: true),
                    SLXa = table.Column<int>(type: "int", nullable: true),
                    VungDiaLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhCus", x => x.MaTinhCu);
                });

            migrationBuilder.CreateTable(
                name: "TinhMois",
                columns: table => new
                {
                    MaTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienTich = table.Column<double>(type: "float", nullable: true),
                    DanSo = table.Column<long>(type: "bigint", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLXa = table.Column<int>(type: "int", nullable: true),
                    VungDiaLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLHuyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhMois", x => x.MaTinh);
                });

            migrationBuilder.CreateTable(
                name: "TonGiaos",
                columns: table => new
                {
                    MaTonGiao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTonGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKhac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonGiaos", x => x.MaTonGiao);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDoVanHoas",
                columns: table => new
                {
                    MaTDVH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTDVH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinhDoVanHoas", x => x.MaTDVH);
                });

            migrationBuilder.CreateTable(
                name: "LichSuSapNhaps",
                columns: table => new
                {
                    MaLSSN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoNghiDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuKienHanhChinhSoNghiDinh = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuSapNhaps", x => x.MaLSSN);
                    table.ForeignKey(
                        name: "FK_LichSuSapNhaps_SuKienHanhChinhs_SuKienHanhChinhSoNghiDinh",
                        column: x => x.SuKienHanhChinhSoNghiDinh,
                        principalTable: "SuKienHanhChinhs",
                        principalColumn: "SoNghiDinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HuyenCus",
                columns: table => new
                {
                    MaHuyenCu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenHuyenCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanSo = table.Column<long>(type: "bigint", nullable: true),
                    DienTich = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLXa = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTinhCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhCuMaTinhCu = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuyenCus", x => x.MaHuyenCu);
                    table.ForeignKey(
                        name: "FK_HuyenCus_TinhCus_TinhCuMaTinhCu",
                        column: x => x.TinhCuMaTinhCu,
                        principalTable: "TinhCus",
                        principalColumn: "MaTinhCu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaMois",
                columns: table => new
                {
                    MaXaMoi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenXaMoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiXa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLAp = table.Column<int>(type: "int", nullable: true),
                    DanSo = table.Column<long>(type: "bigint", nullable: true),
                    DienTich = table.Column<double>(type: "float", nullable: true),
                    MaTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhMoiMaTinh = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaMois", x => x.MaXaMoi);
                    table.ForeignKey(
                        name: "FK_XaMois_TinhMois_TinhMoiMaTinh",
                        column: x => x.TinhMoiMaTinh,
                        principalTable: "TinhMois",
                        principalColumn: "MaTinh");
                });

            migrationBuilder.CreateTable(
                name: "NguoiDans",
                columns: table => new
                {
                    MaCCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoTenKhongDau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangHonNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiCongDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaQHCH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTonGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDanToc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTDVH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuanHeChuHoMaQHCH = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TonGiaoMaTonGiao = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    DanTocMaDanToc = table.Column<int>(type: "int", nullable: true),
                    TrinhDoVanHoaMaTDVH = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDans", x => x.MaCCCD);
                    table.ForeignKey(
                        name: "FK_NguoiDans_DanTocs_DanTocMaDanToc",
                        column: x => x.DanTocMaDanToc,
                        principalTable: "DanTocs",
                        principalColumn: "MaDanToc");
                    table.ForeignKey(
                        name: "FK_NguoiDans_QuanHeChuHos_QuanHeChuHoMaQHCH",
                        column: x => x.QuanHeChuHoMaQHCH,
                        principalTable: "QuanHeChuHos",
                        principalColumn: "MaQHCH");
                    table.ForeignKey(
                        name: "FK_NguoiDans_TonGiaos_TonGiaoMaTonGiao",
                        column: x => x.TonGiaoMaTonGiao,
                        principalTable: "TonGiaos",
                        principalColumn: "MaTonGiao");
                    table.ForeignKey(
                        name: "FK_NguoiDans_TrinhDoVanHoas_TrinhDoVanHoaMaTDVH",
                        column: x => x.TrinhDoVanHoaMaTDVH,
                        principalTable: "TrinhDoVanHoas",
                        principalColumn: "MaTDVH");
                });

            migrationBuilder.CreateTable(
                name: "LssnTinhs",
                columns: table => new
                {
                    MaLSSN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaTinhCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LichSuSapNhapMaLSSN = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TinhCuMaTinhCu = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TinhMoiMaTinh = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LssnTinhs", x => x.MaLSSN);
                    table.ForeignKey(
                        name: "FK_LssnTinhs_LichSuSapNhaps_LichSuSapNhapMaLSSN",
                        column: x => x.LichSuSapNhapMaLSSN,
                        principalTable: "LichSuSapNhaps",
                        principalColumn: "MaLSSN");
                    table.ForeignKey(
                        name: "FK_LssnTinhs_TinhCus_TinhCuMaTinhCu",
                        column: x => x.TinhCuMaTinhCu,
                        principalTable: "TinhCus",
                        principalColumn: "MaTinhCu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinh",
                        column: x => x.TinhMoiMaTinh,
                        principalTable: "TinhMois",
                        principalColumn: "MaTinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaCus",
                columns: table => new
                {
                    MaXaCu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenXaCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiXa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SLAp = table.Column<int>(type: "int", nullable: true),
                    DanSo = table.Column<long>(type: "bigint", nullable: true),
                    DienTich = table.Column<double>(type: "float", nullable: true),
                    MaHuyenCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuyenCuMaHuyenCu = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaCus", x => x.MaXaCu);
                    table.ForeignKey(
                        name: "FK_XaCus_HuyenCus_HuyenCuMaHuyenCu",
                        column: x => x.HuyenCuMaHuyenCu,
                        principalTable: "HuyenCus",
                        principalColumn: "MaHuyenCu");
                });

            migrationBuilder.CreateTable(
                name: "TamTrus",
                columns: table => new
                {
                    MaXaMoi = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MaCCCD = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiHan = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamTrus", x => new { x.MaXaMoi, x.MaCCCD });
                    table.ForeignKey(
                        name: "FK_TamTrus_NguoiDans_MaCCCD",
                        column: x => x.MaCCCD,
                        principalTable: "NguoiDans",
                        principalColumn: "MaCCCD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TamTrus_XaMois_MaXaMoi",
                        column: x => x.MaXaMoi,
                        principalTable: "XaMois",
                        principalColumn: "MaXaMoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThuongTrus",
                columns: table => new
                {
                    MaXaMoi = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MaCCCD = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongTrus", x => new { x.MaXaMoi, x.MaCCCD });
                    table.ForeignKey(
                        name: "FK_ThuongTrus_NguoiDans_MaCCCD",
                        column: x => x.MaCCCD,
                        principalTable: "NguoiDans",
                        principalColumn: "MaCCCD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThuongTrus_XaMois_MaXaMoi",
                        column: x => x.MaXaMoi,
                        principalTable: "XaMois",
                        principalColumn: "MaXaMoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuDiaChis",
                columns: table => new
                {
                    MaLichSuCuTru = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LoaiThayDoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LyDoThayDoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChiCu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiMoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaXaCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiDanMaCCCD = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    XaCuMaXaCu = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuDiaChis", x => x.MaLichSuCuTru);
                    table.ForeignKey(
                        name: "FK_LichSuDiaChis_NguoiDans_NguoiDanMaCCCD",
                        column: x => x.NguoiDanMaCCCD,
                        principalTable: "NguoiDans",
                        principalColumn: "MaCCCD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuDiaChis_XaCus_XaCuMaXaCu",
                        column: x => x.XaCuMaXaCu,
                        principalTable: "XaCus",
                        principalColumn: "MaXaCu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LssnXas",
                columns: table => new
                {
                    MaLSSN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXaMoi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaXaCu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LichSuSapNhapMaLSSN = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    XaMoiMaXaMoi = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    XaCuMaXaCu = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LssnXas", x => x.MaLSSN);
                    table.ForeignKey(
                        name: "FK_LssnXas_LichSuSapNhaps_LichSuSapNhapMaLSSN",
                        column: x => x.LichSuSapNhapMaLSSN,
                        principalTable: "LichSuSapNhaps",
                        principalColumn: "MaLSSN");
                    table.ForeignKey(
                        name: "FK_LssnXas_XaCus_XaCuMaXaCu",
                        column: x => x.XaCuMaXaCu,
                        principalTable: "XaCus",
                        principalColumn: "MaXaCu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LssnXas_XaMois_XaMoiMaXaMoi",
                        column: x => x.XaMoiMaXaMoi,
                        principalTable: "XaMois",
                        principalColumn: "MaXaMoi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HuyenCus_TinhCuMaTinhCu",
                table: "HuyenCus",
                column: "TinhCuMaTinhCu");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiaChis_NguoiDanMaCCCD",
                table: "LichSuDiaChis",
                column: "NguoiDanMaCCCD");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiaChis_XaCuMaXaCu",
                table: "LichSuDiaChis",
                column: "XaCuMaXaCu");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuSapNhaps_SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps",
                column: "SuKienHanhChinhSoNghiDinh");

            migrationBuilder.CreateIndex(
                name: "IX_LssnTinhs_LichSuSapNhapMaLSSN",
                table: "LssnTinhs",
                column: "LichSuSapNhapMaLSSN");

            migrationBuilder.CreateIndex(
                name: "IX_LssnTinhs_TinhCuMaTinhCu",
                table: "LssnTinhs",
                column: "TinhCuMaTinhCu");

            migrationBuilder.CreateIndex(
                name: "IX_LssnTinhs_TinhMoiMaTinh",
                table: "LssnTinhs",
                column: "TinhMoiMaTinh");

            migrationBuilder.CreateIndex(
                name: "IX_LssnXas_LichSuSapNhapMaLSSN",
                table: "LssnXas",
                column: "LichSuSapNhapMaLSSN");

            migrationBuilder.CreateIndex(
                name: "IX_LssnXas_XaCuMaXaCu",
                table: "LssnXas",
                column: "XaCuMaXaCu");

            migrationBuilder.CreateIndex(
                name: "IX_LssnXas_XaMoiMaXaMoi",
                table: "LssnXas",
                column: "XaMoiMaXaMoi");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_DanTocMaDanToc",
                table: "NguoiDans",
                column: "DanTocMaDanToc");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_QuanHeChuHoMaQHCH",
                table: "NguoiDans",
                column: "QuanHeChuHoMaQHCH");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_TonGiaoMaTonGiao",
                table: "NguoiDans",
                column: "TonGiaoMaTonGiao");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_TrinhDoVanHoaMaTDVH",
                table: "NguoiDans",
                column: "TrinhDoVanHoaMaTDVH");

            migrationBuilder.CreateIndex(
                name: "IX_TamTrus_MaCCCD",
                table: "TamTrus",
                column: "MaCCCD");

            migrationBuilder.CreateIndex(
                name: "IX_ThuongTrus_MaCCCD",
                table: "ThuongTrus",
                column: "MaCCCD");

            migrationBuilder.CreateIndex(
                name: "IX_XaCus_HuyenCuMaHuyenCu",
                table: "XaCus",
                column: "HuyenCuMaHuyenCu");

            migrationBuilder.CreateIndex(
                name: "IX_XaMois_TinhMoiMaTinh",
                table: "XaMois",
                column: "TinhMoiMaTinh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LichSuDiaChis");

            migrationBuilder.DropTable(
                name: "LssnTinhs");

            migrationBuilder.DropTable(
                name: "LssnXas");

            migrationBuilder.DropTable(
                name: "TamTrus");

            migrationBuilder.DropTable(
                name: "ThuongTrus");

            migrationBuilder.DropTable(
                name: "LichSuSapNhaps");

            migrationBuilder.DropTable(
                name: "XaCus");

            migrationBuilder.DropTable(
                name: "NguoiDans");

            migrationBuilder.DropTable(
                name: "XaMois");

            migrationBuilder.DropTable(
                name: "SuKienHanhChinhs");

            migrationBuilder.DropTable(
                name: "HuyenCus");

            migrationBuilder.DropTable(
                name: "DanTocs");

            migrationBuilder.DropTable(
                name: "QuanHeChuHos");

            migrationBuilder.DropTable(
                name: "TonGiaos");

            migrationBuilder.DropTable(
                name: "TrinhDoVanHoas");

            migrationBuilder.DropTable(
                name: "TinhMois");

            migrationBuilder.DropTable(
                name: "TinhCus");
        }
    }
}
