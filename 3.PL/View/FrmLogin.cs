using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2.BUS.IServices;
using _2.BUS.Services;
using _3.PL.View;

namespace _3.PL
{
    public partial class FrmLogin : Form
    {
        private INhanVienService _nhanVienService;
        public FrmLogin()
        {
            InitializeComponent();
            _nhanVienService = new NhanVienService();
        }


        public bool CheckDK()
        {
            if (string.IsNullOrEmpty(txt_TaiKhoan.Text))
            {
                MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return false;
            }
            if (string.IsNullOrEmpty(txt_MatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return false;
            }
            if (txt_TaiKhoan.Text.Length <= 3)
            {
                MessageBox.Show("email bạn nhập không hợp lệ", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_TaiKhoan.Text, @"(@)(.+)$") == false)
            {

                MessageBox.Show("Email không hợp lệ", "Thông báo");
                return false;
            }
            if (txt_MatKhau.Text.Length <= 3)
            {
                MessageBox.Show("Mật khẩu bạn nhập không hợp lệ", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_TaiKhoan.Text, @"(@)(.+)$") == false)
            {

                MessageBox.Show("Tài khoản phải nhập đúng định dang", "Thông báo");
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (CheckDK() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _nhanVienService.GetAll())
                {
                    if (x.Email == txt_TaiKhoan.Text && x.PassWord == txt_MatKhau.Text)
                    {
                        MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        FrmTrangChu tc = new FrmTrangChu(txt_TaiKhoan.Text);
                        tc.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    return;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmQuenMK q=new FrmQuenMK();
            q.ShowDialog();

        }
    }
}
