using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private string taiKhoan = "admin";
        private string matKhau = "admin";
        public void CheckDK()
        {
            if (txt_TaiKhoan.Text == "" && txt_MatKhau.Text == "")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được để trống","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                txt_TaiKhoan.Clear();
                txt_MatKhau.Clear();
            }
            else if(txt_TaiKhoan.Text != this.taiKhoan && txt_MatKhau.Text != this.matKhau)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công","Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                FrmTrangChu tc = new FrmTrangChu();
                tc.ShowDialog();
                this.Hide();

            }

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            CheckDK();
        }
    }
}
