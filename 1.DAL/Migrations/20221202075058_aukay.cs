using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1.DAL.Migrations
{
    public partial class aukay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhacHang_IdKhachHang",
                table: "HoaDon");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhachHang",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhacHang_IdKhachHang",
                table: "HoaDon",
                column: "IdKhachHang",
                principalTable: "KhacHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhacHang_IdKhachHang",
                table: "HoaDon");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdKhachHang",
                table: "HoaDon",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhacHang_IdKhachHang",
                table: "HoaDon",
                column: "IdKhachHang",
                principalTable: "KhacHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
