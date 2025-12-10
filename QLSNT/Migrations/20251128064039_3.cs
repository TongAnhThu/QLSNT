using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSNT.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinh",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_XaMois_TinhMois_TinhMoiMaTinh",
                table: "XaMois");

            migrationBuilder.RenameColumn(
                name: "TinhMoiMaTinh",
                table: "XaMois",
                newName: "TinhMoiMaTinhMoi");

            migrationBuilder.RenameIndex(
                name: "IX_XaMois_TinhMoiMaTinh",
                table: "XaMois",
                newName: "IX_XaMois_TinhMoiMaTinhMoi");

            migrationBuilder.RenameColumn(
                name: "TenTinh",
                table: "TinhMois",
                newName: "TenTinhMoi");

            migrationBuilder.RenameColumn(
                name: "MaTinh",
                table: "TinhMois",
                newName: "MaTinhMoi");

            migrationBuilder.RenameColumn(
                name: "TinhMoiMaTinh",
                table: "LssnTinhs",
                newName: "TinhMoiMaTinhMoi");

            migrationBuilder.RenameIndex(
                name: "IX_LssnTinhs_TinhMoiMaTinh",
                table: "LssnTinhs",
                newName: "IX_LssnTinhs_TinhMoiMaTinhMoi");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "XaMois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "XaMois",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "XaCus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "XaCus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungDeNghi",
                table: "TamTrus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinhMoi",
                table: "LssnTinhs",
                column: "TinhMoiMaTinhMoi",
                principalTable: "TinhMois",
                principalColumn: "MaTinhMoi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_XaMois_TinhMois_TinhMoiMaTinhMoi",
                table: "XaMois",
                column: "TinhMoiMaTinhMoi",
                principalTable: "TinhMois",
                principalColumn: "MaTinhMoi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinhMoi",
                table: "LssnTinhs");

            migrationBuilder.DropForeignKey(
                name: "FK_XaMois_TinhMois_TinhMoiMaTinhMoi",
                table: "XaMois");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "XaMois");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "XaMois");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "XaCus");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "XaCus");

            migrationBuilder.DropColumn(
                name: "NoiDungDeNghi",
                table: "TamTrus");

            migrationBuilder.RenameColumn(
                name: "TinhMoiMaTinhMoi",
                table: "XaMois",
                newName: "TinhMoiMaTinh");

            migrationBuilder.RenameIndex(
                name: "IX_XaMois_TinhMoiMaTinhMoi",
                table: "XaMois",
                newName: "IX_XaMois_TinhMoiMaTinh");

            migrationBuilder.RenameColumn(
                name: "TenTinhMoi",
                table: "TinhMois",
                newName: "TenTinh");

            migrationBuilder.RenameColumn(
                name: "MaTinhMoi",
                table: "TinhMois",
                newName: "MaTinh");

            migrationBuilder.RenameColumn(
                name: "TinhMoiMaTinhMoi",
                table: "LssnTinhs",
                newName: "TinhMoiMaTinh");

            migrationBuilder.RenameIndex(
                name: "IX_LssnTinhs_TinhMoiMaTinhMoi",
                table: "LssnTinhs",
                newName: "IX_LssnTinhs_TinhMoiMaTinh");

            migrationBuilder.AddForeignKey(
                name: "FK_LssnTinhs_TinhMois_TinhMoiMaTinh",
                table: "LssnTinhs",
                column: "TinhMoiMaTinh",
                principalTable: "TinhMois",
                principalColumn: "MaTinh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_XaMois_TinhMois_TinhMoiMaTinh",
                table: "XaMois",
                column: "TinhMoiMaTinh",
                principalTable: "TinhMois",
                principalColumn: "MaTinh");
        }
    }
}
