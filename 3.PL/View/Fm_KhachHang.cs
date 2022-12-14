using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    public partial class Fm_KhachHang : Form
    {
        private IKhachHangService _iKhachHangService;
        Guid _idWhenclick;
        int Flag = 1;
        public Fm_KhachHang()
        {
            InitializeComponent();
            _iKhachHangService = new KhachHangService();
            LoadKhachHang();
            loadCmb();
            txt_Ma.Enabled = false;
        }
        private void loadCmb()
        {

            foreach (var i in _iKhachHangService.GetAllTP())
            {
                Cmb_ThanhPho.Items.Add(i);
            }
            foreach (var i in _iKhachHangService.GetAllQG())
            {
                cmb_QuoCGia.Items.Add(i);
            }
        }
        private void LoadKhachHang()
        {
            int stt = 1;
            drg_khachHang.ColumnCount = 10;
            drg_khachHang.Columns[0].Name = "STT";
            drg_khachHang.Columns[1].Name = "Id";
            drg_khachHang.Columns[1].Visible = false; 
            drg_khachHang.Columns[2].Name = "Mã";
            drg_khachHang.Columns[3].Name = "Mã";
            drg_khachHang.Columns[4].Name = "Email";
            drg_khachHang.Columns[5].Name = "SĐT";
            drg_khachHang.Columns[6].Name = "Trạng Thái";
            drg_khachHang.Columns[7].Name = "Quôc Gia";
            drg_khachHang.Columns[8].Name = "Thành Phố";
            drg_khachHang.Columns[9].Name = "Địa Chỉ";
            drg_khachHang.Rows.Clear();

            foreach (var x in _iKhachHangService.GetAll())
            {
                drg_khachHang.Rows.Add(stt++, x.Id, x.Ma, x.Ten, x.Email, x.SoDienThoai, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động", x.QuocGia, x.ThangPho, x.DiaChi);
            }
        }
        private KhachHangView GetDataFromGui()
        {
            return new KhachHangView()
            {
                Id = Guid.Empty,
                Ma = txt_Ma.Text,
                Ten = txt_Ten.Text,
                Email = txt_Email.Text,
                SoDienThoai = txt_SDT.Text,
                TrangThai = rdb_On.Checked ? 1 : 0,
                QuocGia = cmb_QuoCGia.Text,
                ThangPho = Cmb_ThanhPho.Text,
                DiaChi = txt_diaChi.Text,
            };
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(txt_Ma.Text))
            {
                MessageBox.Show("Tên Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_Ten.Text))
            {
                MessageBox.Show("Tên Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_Email.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_Email.Text, @"(@)(.+)$") == false)
            {

                MessageBox.Show("Email không hợp lệ", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_SDT.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_SDT.Text, @"[0-9]+") == false)
            {
                MessageBox.Show("Số điện thoại Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (txt_SDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại Bắt buộc phải chứa 10 số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_SDT.Text, @"(09|03|07|08|05)+[0-9]+") == false)
            {
                MessageBox.Show("Số điện thoại này không tồn tại", "ERR");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_QuoCGia.Text))
            {
                MessageBox.Show("Quốc Gia Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(Cmb_ThanhPho.Text))
            {
                MessageBox.Show("Thành Phố Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_diaChi.Text))
            {
                MessageBox.Show("Địa Chỉ Khách Hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (rdb_On.Checked == false && rdb_Off.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _iKhachHangService.GetAll())
                {
                    if (x.Ma == txt_Ma.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Ten == txt_Ten.Text)
                    {
                        MessageBox.Show("Tên này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Email == txt_Email.Text)
                    {
                        MessageBox.Show("Email này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.SoDienThoai == txt_SDT.Text)
                    {
                        MessageBox.Show("SDT này đã tồn tại", "Thông báo");
                        return;
                    }

                }

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_iKhachHangService.Add(GetDataFromGui()));
                    LoadKhachHang();
                    Clear();
                }
                if (dialogResult == DialogResult.No) return;

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var temp = GetDataFromGui();
                    temp.Id = _idWhenclick;
                    MessageBox.Show(_iKhachHangService.Update(temp));
                    LoadKhachHang();
                    Clear();
                }
                if (dialogResult == DialogResult.No) return;

            }
        }

        private void drg_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iKhachHangService.GetAll().Count) return;
            _idWhenclick = Guid.Parse(drg_khachHang.Rows[rowIndex].Cells[1].Value.ToString());
            var obj = _iKhachHangService.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);
            txt_Ma.Text = obj.Ma;
            txt_Ten.Text = obj.Ten;
            txt_Email.Text = obj.Email;
            txt_SDT.Text = obj.SoDienThoai;
            if (obj.TrangThai == 1)
            {
                rdb_On.Checked = true;
            }
            else rdb_Off.Checked = true;
            cmb_QuoCGia.Text = obj.QuocGia;
            Cmb_ThanhPho.Text = obj.ThangPho;
            txt_diaChi.Text = obj.DiaChi;
        }
        public void Clear()
        {
            txt_Ma.Text = "";
            txt_Ten.Text = null;
            txt_Ten.Text = "";
            txt_SDT.Text= "";
            txt_Email.Text = "";
            txt_diaChi.Text = "";
            cmb_QuoCGia.Text = "";
            Cmb_ThanhPho.Text = "";
            rdb_Off.Checked = false;
            rdb_On.Checked= false;
        }
        private void txt_Ten_TextChanged(object sender, EventArgs e)
        {
            if (!(_idWhenclick == Guid.Empty))
            {
                Flag = 0;
            }
            if (Flag == 0)
            {
                var temp = _iKhachHangService.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);

                txt_Ma.Text = temp.Ma;
                Flag = 1;

            }
            else
            {
                string ma = txt_Ma.Text;
                do
                {
                    ma = "KH" + Utilitys.GetNumber(3);
                } while (_iKhachHangService.GetAll().Any(c => c.Ma.Equals(ma)));
                txt_Ma.Text = ma;
            }
        }
    }
}
