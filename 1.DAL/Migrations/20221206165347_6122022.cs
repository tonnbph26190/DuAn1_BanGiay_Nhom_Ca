using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class _6122022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_IdNhanVien",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HoaDon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNhanVien",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_IdNhanVien",
                table: "HoaDon",
                column: "IdNhanVien",
                principalTable: "NhanVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_IdNhanVien",
                table: "HoaDon");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "HoaDon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdNhanVien",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_IdNhanVien",
                table: "HoaDon",
                column: "IdNhanVien",
                principalTable: "NhanVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
