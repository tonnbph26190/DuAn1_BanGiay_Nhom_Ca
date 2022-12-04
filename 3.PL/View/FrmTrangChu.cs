using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using _3.PL.View;

namespace _3.PL
{
    public partial class FrmTrangChu : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRecRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        public FrmTrangChu(string user)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRecRgn(0, 0, Width, Height, 25, 25));
            User.Text = user;

        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
     
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {

            lb_TrangChu.Text = "Thanh Toán";
            this.pnlFromLoad.Controls.Clear();
            FrmThanhToan frmThanhToan = new FrmThanhToan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmThanhToan);
            frmThanhToan.Show();
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Sản Phẩm";
            this.pnlFromLoad.Controls.Clear();
            Frm_ChiTietSanPham frmSanPham = new Frm_ChiTietSanPham(){Dock = DockStyle.Fill,TopLevel = false,TopMost = true};
            this.pnlFromLoad.Controls.Add(frmSanPham);
            frmSanPham.Show();

        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Doanh Thu";
            this.pnlFromLoad.Controls.Clear();
            Fm_ThongKe frmDoanhThu = new Fm_ThongKe() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmDoanhThu);
            frmDoanhThu.Show();
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Nhân Viên";
            this.pnlFromLoad.Controls.Clear();
            Fm_NhanVien frmNhanVien = new Fm_NhanVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmNhanVien);
            frmNhanVien.Show();
        }

        private void btn_HoaDon_Click_1(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Hóa Đơn";
            this.pnlFromLoad.Controls.Clear();
            Fm_HoaDon frmhoaDon = new Fm_HoaDon() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmhoaDon);
            frmhoaDon.Show();
        }

        private void btn_Voucher_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Voucher";
            this.pnlFromLoad.Controls.Clear();
            Fm_GiamGia frmGiamGia = new Fm_GiamGia() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmGiamGia);
            frmGiamGia.Show();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Khách Hàng";
            this.pnlFromLoad.Controls.Clear();
            Fm_KhachHang frmKhachHang = new Fm_KhachHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmKhachHang);
            frmKhachHang.Show();
        }
    }
}
