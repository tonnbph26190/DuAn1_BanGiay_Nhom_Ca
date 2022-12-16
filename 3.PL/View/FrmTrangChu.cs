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
using _2.BUS.IServices;
using _2.BUS.Services;
using _3.PL.Properties;
using _1.DAL.Models;

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
        private INhanVienService _NvService;
        private IChucVuService _ChucVuService;
        public FrmTrangChu(string user, string  tenChucVu)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRecRgn(0, 0, Width, Height, 25, 25));
            if (user=="Admin")
            {
                btn_BanHang.Enabled = false;
                btn_DoanhThu.Enabled = false;
                btn_HoaDon.Enabled= false;
                btn_KhachHang.Enabled = false;  
                btn_HoaDon.Enabled= false;
                btn_SanPham.Enabled=false;
                btn_ViewSP.Enabled=false;   
            }
            User.Text = user;
            lbl_TenChucVu.Text = tenChucVu;
            if (tenChucVu == "Nhân Viên")
            {
                btn_NhanVien.Enabled = false;
            }
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
            Frm_ThongKeHD frm = new Frm_ThongKeHD() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frm);
            frm.Show();
            
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
            Fm_HoaDon frmDoanhThu = new Fm_HoaDon() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmDoanhThu);
            frmDoanhThu.Show();
        }

        

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Khách Hàng";
            this.pnlFromLoad.Controls.Clear();
            Fm_KhachHang frmKhachHang = new Fm_KhachHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmKhachHang);
            frmKhachHang.Show();
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Bán Hàng";
            this.pnlFromLoad.Controls.Clear();
            FrmThanhToan frmThanhToan = new FrmThanhToan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmThanhToan);
            frmThanhToan.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.OK)
            {
                this.Close();
                FrmLogin frmlg = new FrmLogin();
                frmlg.ShowDialog();
            }

            if (dg == DialogResult.No)
            {
                return;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Hide();
                Application.Exit();
            }
            return;
        }

        private void btn_ViewSP_Click(object sender, EventArgs e)
        {
            lb_TrangChu.Text = "Danh mục sản phẩm";
            this.pnlFromLoad.Controls.Clear();
            Frm_ViewSP frmViewSp = new Frm_ViewSP() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.pnlFromLoad.Controls.Add(frmViewSp);
            frmViewSp.Show();
        }
    }
}
