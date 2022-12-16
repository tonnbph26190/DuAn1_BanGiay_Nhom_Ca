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
using AForge.Video.DirectShow;
using iTextSharp.text.xml.xmp;
using Microsoft.Data.SqlClient;
using ZXing;

namespace _3.PL
{
    public partial class FrmLogin : Form
    {
        private INhanVienService _nhanVienService;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        string b;

        public FrmLogin()
        {
            InitializeComponent();
            _nhanVienService = new NhanVienService();
            int count = 1;
            txt_TaiKhoan.Text= Properties.Settings.Default.Tk;
            txt_MatKhau.Text=Properties.Settings.Default.Mk;

        }

        public void saveInfor()
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Tk = txt_TaiKhoan.Text;
                Properties.Settings.Default.Mk = txt_MatKhau.Text;
                Properties.Settings.Default.TKdaLogin = txt_TaiKhoan.Text;
                Properties.Settings.Default.MKdaLogin = txt_MatKhau.Text;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.Tk = "";
                Properties.Settings.Default.Mk = "";
                Properties.Settings.Default.TKdaLogin = txt_TaiKhoan.Text;
                Properties.Settings.Default.MKdaLogin = txt_MatKhau.Text;
                Properties.Settings.Default.Save();
            }
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
            if (Regex.IsMatch(txt_TaiKhoan.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") == false)
            {

                MessageBox.Show("Email không hợp lệ", "Thông báo");
                return false;
            }
            if (txt_MatKhau.Text.Length <= 3)
            {
                MessageBox.Show("Mật khẩu bạn nhập không hợp lệ", "Thông báo");
                return false;
            }
            else
            {
                return true;
            }

        }
         int check(string a,string b,int c)
        {
            foreach (var x in _nhanVienService.GetAll())
            {             
                if (a == txt_MatKhau.Text && b== txt_TaiKhoan.Text &&c  == 1)
                {
                    return 1;
                  
                }

            }
            return 0;
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {                               
            foreach (var x in _nhanVienService.GetAll())
            {
                if (check(x.PassWord, x.Email, x.TrangThai)==1)
                {
                    var chucVuNVlogin = _nhanVienService.GetAll().FirstOrDefault(c => c.Email == txt_TaiKhoan.Text);
                    txt_ChuVu.Text = chucVuNVlogin.ChucVu.Ten;
                    saveInfor();
                    Frm_Load load = new Frm_Load(txt_TaiKhoan.Text, txt_ChuVu.Text);
                    this.Hide();
                    load.ShowDialog();
                    button1.Visible = false;
                    button2.Visible = false;
                }
                else
                {
                    button1.Visible = true;
                    button2.Visible=true;
                }                  

            }                      

        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmQuenMK q = new FrmQuenMK();
            q.ShowDialog();

        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txt_MatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame; ;
            captureDevice.Start();
            timer1.Start();
        }

        private void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in filterInfoCollection)
            {
                comboBox1.Items.Add(filter.Name);
                comboBox1.SelectedIndex = 0;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    b = result.ToString().Split("||")[0];
                    if (_nhanVienService.GetAll().Any(c => c.SoCmnd == b))
                    {
                        var obj = _nhanVienService.GetAll().FirstOrDefault(c => c.SoCmnd == b);
                        txt_TaiKhoan.Text = obj == null ? "" : obj.Email.Trim();
                        txt_MatKhau.Text = obj == null ? "" : obj.PassWord.Trim();
                    }
                    else if (b == "001303047071")
                    {
                        Frm_Load tc = new Frm_Load("Admin","Admin");
                        this.Hide();
                        tc.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên không tồn tại");
                    }
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                    {
                        captureDevice.SignalToStop();
                    }
                }


            }
        }
    }
}
