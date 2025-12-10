using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSNT.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HuyenCus_TinhCus_TinhCuMaTinhCu",
                table: "HuyenCus");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiaChis_NguoiDans_NguoiDanMaCCCD",
                table: "LichSuDiaChis");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiaChis_XaCus_XaCuMaXaCu",
                table: "LichSuDiaChis");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuSapNhaps_SuKienHanhChinhs_SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_LichSuSapNhaps_LichSuSapNhapMaLSSN",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_TinhCus_TinhCuMaTinhCu",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinhMoi",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnXas_LichSuSapNhaps_LichSuSapNhapMaLSSN",
                table: "LssnXas");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnXas_XaCus_XaCuMaXaCu",
                table: "LssnXas");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnXas_XaMois_XaMoiMaXaMoi",
                table: "LssnXas");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_DanTocs_DanTocMaDanToc",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_QuanHeChuHos_QuanHeChuHoMaQHCH",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_TonGiaos_TonGiaoMaTonGiao",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_TrinhDoVanHoas_TrinhDoVanHoaMaTDVH",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_XaCus_HuyenCus_HuyenCuMaHuyenCu",
                table: "XaCus");

            migrationBuilder.DropIndex(
                name: "IX_XaCus_HuyenCuMaHuyenCu",
                table: "XaCus");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_DanTocMaDanToc",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_QuanHeChuHoMaQHCH",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_TonGiaoMaTonGiao",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_TrinhDoVanHoaMaTDVH",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_LssnXas_LichSuSapNhapMaLSSN",
                table: "LssnXas");

            migrationBuilder.DropIndex(
                name: "IX_LssnXas_XaCuMaXaCu",
                table: "LssnXas");

            migrationBuilder.DropIndex(
                name: "IX_LssnXas_XaMoiMaXaMoi",
                table: "LssnXas");

            migrationBuilder.DropIndex(
                name: "IX_LssnTinhs_LichSuSapNhapMaLSSN",
                table: "LssnTinhs");

            migrationBuilder.DropIndex(
                name: "IX_LssnTinhs_TinhCuMaTinhCu",
                table: "LssnTinhs");

            migrationBuilder.DropIndex(
                name: "IX_LichSuSapNhaps_SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiaChis_NguoiDanMaCCCD",
                table: "LichSuDiaChis");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiaChis_XaCuMaXaCu",
                table: "LichSuDiaChis");

            migrationBuilder.DropIndex(
                name: "IX_HuyenCus_TinhCuMaTinhCu",
                table: "HuyenCus");

            migrationBuilder.DropColumn(
                name: "HuyenCuMaHuyenCu",
                table: "XaCus");

            migrationBuilder.DropColumn(
                name: "DanTocMaDanToc",
                table: "NguoiDans");

            migrationBuilder.DropColumn(
                name: "QuanHeChuHoMaQHCH",
                table: "NguoiDans");

            migrationBuilder.DropColumn(
                name: "TonGiaoMaTonGiao",
                table: "NguoiDans");

            migrationBuilder.DropColumn(
                name: "TrinhDoVanHoaMaTDVH",
                table: "NguoiDans");

            migrationBuilder.DropColumn(
                name: "LichSuSapNhapMaLSSN",
                table: "LssnXas");

            migrationBuilder.DropColumn(
                name: "XaCuMaXaCu",
                table: "LssnXas");

            migrationBuilder.DropColumn(
                name: "XaMoiMaXaMoi",
                table: "LssnXas");

            migrationBuilder.DropColumn(
                name: "LichSuSapNhapMaLSSN",
                table: "LssnTinhs");

            migrationBuilder.DropColumn(
                name: "MaTinh",
                table: "LssnTinhs");

            migrationBuilder.DropColumn(
                name: "TinhCuMaTinhCu",
                table: "LssnTinhs");

            migrationBuilder.DropColumn(
                name: "SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps");

            migrationBuilder.DropColumn(
                name: "NguoiDanMaCCCD",
                table: "LichSuDiaChis");

            migrationBuilder.DropColumn(
                name: "XaCuMaXaCu",
                table: "LichSuDiaChis");

            migrationBuilder.DropColumn(
                name: "TinhCuMaTinhCu",
                table: "HuyenCus");

            migrationBuilder.RenameColumn(
                name: "TinhMoiMaTinhMoi",
                table: "LssnTinhs",
                newName: "MaTinhMoi");

            migrationBuilder.RenameIndex(
                name: "IX_LssnTinhs_TinhMoiMaTinhMoi",
                table: "LssnTinhs",
                newName: "IX_LssnTinhs_MaTinhMoi");

            migrationBuilder.AlterColumn<string>(
                name: "MaHuyenCu",
                table: "XaCus",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaTonGiao",
                table: "NguoiDans",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaTDVH",
                table: "NguoiDans",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaQHCH",
                table: "NguoiDans",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaDanToc",
                table: "NguoiDans",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaXaMoi",
                table: "LssnXas",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaXaCu",
                table: "LssnXas",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaTinhCu",
                table: "LssnTinhs",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SoNghiDinh",
                table: "LichSuSapNhaps",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaXaCu",
                table: "LichSuDiaChis",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaCCCD",
                table: "LichSuDiaChis",
                type: "nvarchar(12)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaTinhCu",
                table: "HuyenCus",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_XaCus_MaHuyenCu",
                table: "XaCus",
                column: "MaHuyenCu");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_MaDanToc",
                table: "NguoiDans",
                column: "MaDanToc");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_MaQHCH",
                table: "NguoiDans",
                column: "MaQHCH");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_MaTDVH",
                table: "NguoiDans",
                column: "MaTDVH");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDans_MaTonGiao",
                table: "NguoiDans",
                column: "MaTonGiao");

            migrationBuilder.CreateIndex(
                name: "IX_LssnXas_MaXaCu",
                table: "LssnXas",
                column: "MaXaCu");

            migrationBuilder.CreateIndex(
                name: "IX_LssnXas_MaXaMoi",
                table: "LssnXas",
                column: "MaXaMoi");

            migrationBuilder.CreateIndex(
                name: "IX_LssnTinhs_MaTinhCu",
                table: "LssnTinhs",
                column: "MaTinhCu");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuSapNhaps_SoNghiDinh",
                table: "LichSuSapNhaps",
                column: "SoNghiDinh");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiaChis_MaCCCD",
                table: "LichSuDiaChis",
                column: "MaCCCD");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiaChis_MaXaCu",
                table: "LichSuDiaChis",
                column: "MaXaCu");

            migrationBuilder.CreateIndex(
                name: "IX_HuyenCus_MaTinhCu",
                table: "HuyenCus",
                column: "MaTinhCu");

            migrationBuilder.AddForeignKey(
                name: "FK_HuyenCus_TinhCus_MaTinhCu",
                table: "HuyenCus",
                column: "MaTinhCu",
                principalTable: "TinhCus",
                principalColumn: "MaTinhCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiaChis_NguoiDans_MaCCCD",
                table: "LichSuDiaChis",
                column: "MaCCCD",
                principalTable: "NguoiDans",
                principalColumn: "MaCCCD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiaChis_XaCus_MaXaCu",
                table: "LichSuDiaChis",
                column: "MaXaCu",
                principalTable: "XaCus",
                principalColumn: "MaXaCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuSapNhaps_SuKienHanhChinhs_SoNghiDinh",
                table: "LichSuSapNhaps",
                column: "SoNghiDinh",
                principalTable: "SuKienHanhChinhs",
                principalColumn: "SoNghiDinh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_LichSuSapNhaps_MaLSSN",
                table: "LssnTinhs",
                column: "MaLSSN",
                principalTable: "LichSuSapNhaps",
                principalColumn: "MaLSSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_TinhCus_MaTinhCu",
                table: "LssnTinhs",
                column: "MaTinhCu",
                principalTable: "TinhCus",
                principalColumn: "MaTinhCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_TinhMois_MaTinhMoi",
                table: "LssnTinhs",
                column: "MaTinhMoi",
                principalTable: "TinhMois",
                principalColumn: "MaTinhMoi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnXas_LichSuSapNhaps_MaLSSN",
                table: "LssnXas",
                column: "MaLSSN",
                principalTable: "LichSuSapNhaps",
                principalColumn: "MaLSSN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnXas_XaCus_MaXaCu",
                table: "LssnXas",
                column: "MaXaCu",
                principalTable: "XaCus",
                principalColumn: "MaXaCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnXas_XaMois_MaXaMoi",
                table: "LssnXas",
                column: "MaXaMoi",
                principalTable: "XaMois",
                principalColumn: "MaXaMoi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_DanTocs_MaDanToc",
                table: "NguoiDans",
                column: "MaDanToc",
                principalTable: "DanTocs",
                principalColumn: "MaDanToc");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_QuanHeChuHos_MaQHCH",
                table: "NguoiDans",
                column: "MaQHCH",
                principalTable: "QuanHeChuHos",
                principalColumn: "MaQHCH");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_TonGiaos_MaTonGiao",
                table: "NguoiDans",
                column: "MaTonGiao",
                principalTable: "TonGiaos",
                principalColumn: "MaTonGiao");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_TrinhDoVanHoas_MaTDVH",
                table: "NguoiDans",
                column: "MaTDVH",
                principalTable: "TrinhDoVanHoas",
                principalColumn: "MaTDVH");

            migrationBuilder.AddForeignKey(
                name: "FK_XaCus_HuyenCus_MaHuyenCu",
                table: "XaCus",
                column: "MaHuyenCu",
                principalTable: "HuyenCus",
                principalColumn: "MaHuyenCu",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HuyenCus_TinhCus_MaTinhCu",
                table: "HuyenCus");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiaChis_NguoiDans_MaCCCD",
                table: "LichSuDiaChis");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuDiaChis_XaCus_MaXaCu",
                table: "LichSuDiaChis");

            migrationBuilder.DropForeignKey(
                name: "FK_LichSuSapNhaps_SuKienHanhChinhs_SoNghiDinh",
                table: "LichSuSapNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_LichSuSapNhaps_MaLSSN",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_TinhCus_MaTinhCu",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_TinhMois_MaTinhMoi",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnXas_LichSuSapNhaps_MaLSSN",
                table: "LssnXas");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnXas_XaCus_MaXaCu",
                table: "LssnXas");

            migrationBuilder.DropForeignKey(
                name: "FK_LssnXas_XaMois_MaXaMoi",
                table: "LssnXas");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_DanTocs_MaDanToc",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_QuanHeChuHos_MaQHCH",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_TonGiaos_MaTonGiao",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_NguoiDans_TrinhDoVanHoas_MaTDVH",
                table: "NguoiDans");

            migrationBuilder.DropForeignKey(
                name: "FK_XaCus_HuyenCus_MaHuyenCu",
                table: "XaCus");

            migrationBuilder.DropIndex(
                name: "IX_XaCus_MaHuyenCu",
                table: "XaCus");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_MaDanToc",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_MaQHCH",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_MaTDVH",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_NguoiDans_MaTonGiao",
                table: "NguoiDans");

            migrationBuilder.DropIndex(
                name: "IX_LssnXas_MaXaCu",
                table: "LssnXas");

            migrationBuilder.DropIndex(
                name: "IX_LssnXas_MaXaMoi",
                table: "LssnXas");

            migrationBuilder.DropIndex(
                name: "IX_LssnTinhs_MaTinhCu",
                table: "LssnTinhs");

            migrationBuilder.DropIndex(
                name: "IX_LichSuSapNhaps_SoNghiDinh",
                table: "LichSuSapNhaps");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiaChis_MaCCCD",
                table: "LichSuDiaChis");

            migrationBuilder.DropIndex(
                name: "IX_LichSuDiaChis_MaXaCu",
                table: "LichSuDiaChis");

            migrationBuilder.DropIndex(
                name: "IX_HuyenCus_MaTinhCu",
                table: "HuyenCus");

            migrationBuilder.RenameColumn(
                name: "MaTinhMoi",
                table: "LssnTinhs",
                newName: "TinhMoiMaTinhMoi");

            migrationBuilder.RenameIndex(
                name: "IX_LssnTinhs_MaTinhMoi",
                table: "LssnTinhs",
                newName: "IX_LssnTinhs_TinhMoiMaTinhMoi");

            migrationBuilder.AlterColumn<string>(
                name: "MaHuyenCu",
                table: "XaCus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "HuyenCuMaHuyenCu",
                table: "XaCus",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaTonGiao",
                table: "NguoiDans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaTDVH",
                table: "NguoiDans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaQHCH",
                table: "NguoiDans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDanToc",
                table: "NguoiDans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DanTocMaDanToc",
                table: "NguoiDans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuanHeChuHoMaQHCH",
                table: "NguoiDans",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TonGiaoMaTonGiao",
                table: "NguoiDans",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrinhDoVanHoaMaTDVH",
                table: "NguoiDans",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaXaMoi",
                table: "LssnXas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "MaXaCu",
                table: "LssnXas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "LichSuSapNhapMaLSSN",
                table: "LssnXas",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XaCuMaXaCu",
                table: "LssnXas",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "XaMoiMaXaMoi",
                table: "LssnXas",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MaTinhCu",
                table: "LssnTinhs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "LichSuSapNhapMaLSSN",
                table: "LssnTinhs",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaTinh",
                table: "LssnTinhs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TinhCuMaTinhCu",
                table: "LssnTinhs",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SoNghiDinh",
                table: "LichSuSapNhaps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MaXaCu",
                table: "LichSuDiaChis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "MaCCCD",
                table: "LichSuDiaChis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)");

            migrationBuilder.AddColumn<string>(
                name: "NguoiDanMaCCCD",
                table: "LichSuDiaChis",
                type: "nvarchar(12)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "XaCuMaXaCu",
                table: "LichSuDiaChis",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MaTinhCu",
                table: "HuyenCus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "TinhCuMaTinhCu",
                table: "HuyenCus",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_XaCus_HuyenCuMaHuyenCu",
                table: "XaCus",
                column: "HuyenCuMaHuyenCu");

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
                name: "IX_LssnTinhs_LichSuSapNhapMaLSSN",
                table: "LssnTinhs",
                column: "LichSuSapNhapMaLSSN");

            migrationBuilder.CreateIndex(
                name: "IX_LssnTinhs_TinhCuMaTinhCu",
                table: "LssnTinhs",
                column: "TinhCuMaTinhCu");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuSapNhaps_SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps",
                column: "SuKienHanhChinhSoNghiDinh");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiaChis_NguoiDanMaCCCD",
                table: "LichSuDiaChis",
                column: "NguoiDanMaCCCD");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuDiaChis_XaCuMaXaCu",
                table: "LichSuDiaChis",
                column: "XaCuMaXaCu");

            migrationBuilder.CreateIndex(
                name: "IX_HuyenCus_TinhCuMaTinhCu",
                table: "HuyenCus",
                column: "TinhCuMaTinhCu");

            migrationBuilder.AddForeignKey(
                name: "FK_HuyenCus_TinhCus_TinhCuMaTinhCu",
                table: "HuyenCus",
                column: "TinhCuMaTinhCu",
                principalTable: "TinhCus",
                principalColumn: "MaTinhCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiaChis_NguoiDans_NguoiDanMaCCCD",
                table: "LichSuDiaChis",
                column: "NguoiDanMaCCCD",
                principalTable: "NguoiDans",
                principalColumn: "MaCCCD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuDiaChis_XaCus_XaCuMaXaCu",
                table: "LichSuDiaChis",
                column: "XaCuMaXaCu",
                principalTable: "XaCus",
                principalColumn: "MaXaCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichSuSapNhaps_SuKienHanhChinhs_SuKienHanhChinhSoNghiDinh",
                table: "LichSuSapNhaps",
                column: "SuKienHanhChinhSoNghiDinh",
                principalTable: "SuKienHanhChinhs",
                principalColumn: "SoNghiDinh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_LichSuSapNhaps_LichSuSapNhapMaLSSN",
                table: "LssnTinhs",
                column: "LichSuSapNhapMaLSSN",
                principalTable: "LichSuSapNhaps",
                principalColumn: "MaLSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_TinhCus_TinhCuMaTinhCu",
                table: "LssnTinhs",
                column: "TinhCuMaTinhCu",
                principalTable: "TinhCus",
                principalColumn: "MaTinhCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinhMoi",
                table: "LssnTinhs",
                column: "TinhMoiMaTinhMoi",
                principalTable: "TinhMois",
                principalColumn: "MaTinhMoi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnXas_LichSuSapNhaps_LichSuSapNhapMaLSSN",
                table: "LssnXas",
                column: "LichSuSapNhapMaLSSN",
                principalTable: "LichSuSapNhaps",
                principalColumn: "MaLSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_LssnXas_XaCus_XaCuMaXaCu",
                table: "LssnXas",
                column: "XaCuMaXaCu",
                principalTable: "XaCus",
                principalColumn: "MaXaCu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnXas_XaMois_XaMoiMaXaMoi",
                table: "LssnXas",
                column: "XaMoiMaXaMoi",
                principalTable: "XaMois",
                principalColumn: "MaXaMoi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_DanTocs_DanTocMaDanToc",
                table: "NguoiDans",
                column: "DanTocMaDanToc",
                principalTable: "DanTocs",
                principalColumn: "MaDanToc");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_QuanHeChuHos_QuanHeChuHoMaQHCH",
                table: "NguoiDans",
                column: "QuanHeChuHoMaQHCH",
                principalTable: "QuanHeChuHos",
                principalColumn: "MaQHCH");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_TonGiaos_TonGiaoMaTonGiao",
                table: "NguoiDans",
                column: "TonGiaoMaTonGiao",
                principalTable: "TonGiaos",
                principalColumn: "MaTonGiao");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiDans_TrinhDoVanHoas_TrinhDoVanHoaMaTDVH",
                table: "NguoiDans",
                column: "TrinhDoVanHoaMaTDVH",
                principalTable: "TrinhDoVanHoas",
                principalColumn: "MaTDVH");

            migrationBuilder.AddForeignKey(
                name: "FK_XaCus_HuyenCus_HuyenCuMaHuyenCu",
                table: "XaCus",
                column: "HuyenCuMaHuyenCu",
                principalTable: "HuyenCus",
                principalColumn: "MaHuyenCu");
        }
    }
}
