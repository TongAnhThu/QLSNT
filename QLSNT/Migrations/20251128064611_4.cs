using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLSNT.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XaMois_TinhMois_TinhMoiMaTinhMoi",
                table: "XaMois");

            migrationBuilder.DropIndex(
                name: "IX_XaMois_TinhMoiMaTinhMoi",
                table: "XaMois");

            migrationBuilder.DropColumn(
                name: "TinhMoiMaTinhMoi",
                table: "XaMois");

            migrationBuilder.AlterColumn<string>(
                name: "MaTinh",
                table: "XaMois",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_XaMois_MaTinh",
                table: "XaMois",
                column: "MaTinh");

            migrationBuilder.AddForeignKey(
                name: "FK_XaMois_TinhMois_MaTinh",
                table: "XaMois",
                column: "MaTinh",
                principalTable: "TinhMois",
                principalColumn: "MaTinhMoi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XaMois_TinhMois_MaTinh",
                table: "XaMois");

            migrationBuilder.DropIndex(
                name: "IX_XaMois_MaTinh",
                table: "XaMois");

            migrationBuilder.AlterColumn<string>(
                name: "MaTinh",
                table: "XaMois",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddColumn<string>(
                name: "TinhMoiMaTinhMoi",
                table: "XaMois",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_XaMois_TinhMoiMaTinhMoi",
                table: "XaMois",
                column: "TinhMoiMaTinhMoi");

            migrationBuilder.AddForeignKey(
                name: "FK_XaMois_TinhMois_TinhMoiMaTinhMoi",
                table: "XaMois",
                column: "TinhMoiMaTinhMoi",
                principalTable: "TinhMois",
                principalColumn: "MaTinhMoi");
        }
    }
}
