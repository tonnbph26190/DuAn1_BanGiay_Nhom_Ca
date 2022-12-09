using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.View;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    public partial class Fm_NhanVien : Form
    {
        private INhanVienService _NvService;
        private IChucVuService _CvService;
        private string _maClick;
        private string fileImg = "";

        public Fm_NhanVien()
        {
            InitializeComponent();
            _NvService = new NhanVienService();
            _CvService = new ChucVuService();
            LoadDGridNV(null);
            LoadLstChucVu();
           
           
            LoadLoc();
        }
        public bool check()
        {
            if (string.IsNullOrEmpty(txt_MaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                return false;
            }

            if (rbtn_Nam.Checked == false && rbtn_Nu.Checked == false)
            {
                MessageBox.Show("Giới tính phải được chọn", "Thông báo");
                return false;
            }

            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Ngày sinh phải được chọn", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_QueQuanNV.Text))
            {
                MessageBox.Show("Quê quán không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_CmNV.Text))
            {
                MessageBox.Show("CMND không được bỏ trống!", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_SdtNV.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_SdtNV.Text, @"[0-9]+") == false)
            {
                MessageBox.Show("Số điện thoại Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (txt_SdtNV.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại Bắt buộc phải chứa 10 số", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_SdtNV.Text, @"(09|03|07|08|05)+[0-9]+") == false)
            {
                MessageBox.Show("Số điện thoại này không tồn tại", "ERR");
                return false;
            }
            if (cbx_HoatDong.Checked == false && cbx_KoHoatDong.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_ChucVuNV.Text))
            {
                MessageBox.Show("Chức vụ nhân viên không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_EmailNV.Text))
            {
                MessageBox.Show("Email không được bỏ trống", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(txt_EmailNV.Text, @"(@)(.+)$") == false)
            {

                MessageBox.Show("Email không hợp lệ", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(txt_PassNV.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                return false;
            }
            
            else
            {
                return true;
            }
        }
        public void LoadLstChucVu()
        {
            cmb_ChucVuNV.Items.Clear();
            foreach (var x in _CvService.GetAll().Where(c=>c.TrangThai==1))
            {
                cmb_ChucVuNV.Items.Add(x.Ma + "-" + x.Ten);
            }
        }
       public void Change() 
        {
           LoadLstChucVu();
        }
        public void LoadLoc()
        {
            ArrayList row =new ArrayList();
            row.Add("Lọc theo tên từ A-Z");
            row.Add("Lọc theo tên từ Z-A");
            cmb_LocNV.Items.AddRange(row.ToArray());
        }

        

        private void LoadDGridNV(string input)
        {
            int stt = 1;
            Type type = typeof(NhanVien);
            int sLuong = type.GetProperties().Length;
            dgrid_NV.ColumnCount = sLuong;
            //dgrid_NV.ColumnCount=12;
            dgrid_NV.Columns[0].Name = "STT";
            dgrid_NV.Columns[1].Name = "Mã nhân viên";
            dgrid_NV.Columns[2].Name = "Tên nhân viên";
            dgrid_NV.Columns[3].Name = "Giới tính";
            dgrid_NV.Columns[4].Name = "Năm Sinh";
            dgrid_NV.Columns[5].Name = "Quê quán";
            dgrid_NV.Columns[6].Name = "Số CMND";
            dgrid_NV.Columns[7].Name = "Số điện thoại";
            dgrid_NV.Columns[8].Name = "Trạng thái";
            dgrid_NV.Columns[9].Name = "Chức vụ";
            dgrid_NV.Columns[10].Name = "Email";
            dgrid_NV.Columns[11].Name = "Password";
           
            dgrid_NV.Columns[12].Name = "Đường dẫn ảnh";

            dgrid_NV.Rows.Clear();
            foreach (var x in _NvService.GetAll(input))
            {
                // dgrid_NV.Rows.Add(stt++, x.DienThoai);
                dgrid_NV.Rows.Add(
                    stt++,
                    x.MaNhanVien,
                    x.TenNhanVien,
                    (x.GioiTinh == 0 ? "Nam" : "Nữ"), 
                    x.NamSinh, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == 0 ? "Đã nghỉ" : "Đang làm",x.ChucVu.Ma+"-"+ _CvService.GetNameByID(x.IdChucVu), x.Email, x.PassWord, x.Anh);
            }
        }

        private NhanVienView GetGui()
        {
            return new NhanVienView()
            {
                Id = Guid.Empty,
                MaNhanVien = txt_MaNV.Text,
                TenNhanVien = txt_TenNV.Text,
                GioiTinh = (rbtn_Nam.Checked ? 0 : 1),
                NamSinh = dateTimePicker1.Value,
                QueQuan = txt_QueQuanNV.Text,
                SoCmnd = txt_CmNV.Text,
                DienThoai = txt_SdtNV.Text,
                TrangThai = cbx_HoatDong.Checked ? 1 : 0,
                Email = txt_EmailNV.Text,
                PassWord = txt_PassNV.Text,
                IdChucVu = _CvService.GetById(_CvService.GetAll()[cmb_ChucVuNV.SelectedIndex].Id).Id,
               

                Anh = txt_Anh.Text,
            };
        }

        private void dgrid_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _NvService.GetAll(null).Count) return;
            _maClick = dgrid_NV.Rows[rowIndex].Cells[1].Value.ToString();
            var obj = _NvService.GetAll(null).FirstOrDefault(c => c.MaNhanVien == _maClick);
            txt_MaNV.Text = obj.MaNhanVien;
            txt_TenNV.Text = obj.TenNhanVien;
            dateTimePicker1.Value = obj.NamSinh;
            txt_QueQuanNV.Text = obj.QueQuan;
            txt_CmNV.Text = obj.SoCmnd;
            txt_SdtNV.Text = obj.DienThoai;
            txt_EmailNV.Text = obj.Email;
            txt_PassNV.Text = obj.PassWord;
            cmb_ChucVuNV.Text = obj.ChucVu.Ma + "-" + _CvService.GetNameByID(obj.IdChucVu);
           //cmb_BaoCao.Text = _CvService.GetNameByID();
            if (obj.Anh != null)
            {
                txt_Anh.Text = obj.Anh;
                Image img =Image.FromFile(obj.Anh);
                pb_AnhNV.Image = img;
                pb_AnhNV.SizeMode = PictureBoxSizeMode.StretchImage;

                // Bitmap bm = new Bitmap(txt_Anh.Text);
            }
            // pb_AnhNV.
            if (obj.GioiTinh == 0)
            {
                rbtn_Nam.Checked = true;
                return;
            }
            else
            {
                rbtn_Nu.Checked = true;

            }
            
            txt_PassNV.Text = obj.PassWord;
            if (obj.TrangThai == 1)
            {
                cbx_HoatDong.Checked = true;
            }
            else cbx_KoHoatDong.Checked = true;


        }

        private void bnt_Them_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _NvService.GetAll())
                {
                    if (x.MaNhanVien == txt_MaNV.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }

                    if (x.TenNhanVien == txt_TenNV.Text)
                    {
                        MessageBox.Show("Tên này đã tồn tại", "Thông báo");
                        return;
                    }

                    if (x.Email == txt_EmailNV.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }

                    if (x.DienThoai == txt_SdtNV.Text)
                    {
                        MessageBox.Show("Tên này đã tồn tại", "Thông báo");
                        return;
                    }

                }

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm nhân viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_NvService.Add(GetGui()));
                    LoadDGridNV(null);

                }

                if (dialogResult == DialogResult.No) return;
            }
        }

        private void bnt_Sua_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _NvService.GetAll())
                {                   

                    if (x.Email == txt_EmailNV.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }

                    if (x.DienThoai == txt_SdtNV.Text)
                    {
                        MessageBox.Show("Tên này đã tồn tại", "Thông báo");
                        return;
                    }

                }

                var temp = GetGui();
                temp.MaNhanVien = _maClick;
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa nhân viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_NvService.Update(temp));
                    LoadDGridNV(null);
                }

                if (dialogResult == DialogResult.No) return;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            var temp = GetGui();
            temp.MaNhanVien = _maClick;
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_NvService.Delete(temp));
                LoadDGridNV(null);
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_CLear_Click(object sender, EventArgs e)
        {
            txt_MaNV.Text = "";
            txt_TenNV.Text = "";
            dateTimePicker1= new DateTimePicker();
            txt_QueQuanNV.Text = "";
            txt_CmNV.Text = "";
            txt_SdtNV.Text = "";
            txt_EmailNV.Text = "";
            txt_PassNV.Text = "";
            rbtn_Nam.Checked = true;
            txt_Anh.Text = "";
            cmb_ChucVuNV.Text = "";
           
        }

        private void btn_UpAnh_Click(object sender, EventArgs e)
        {
            LoadAnh(ref fileImg);
            pb_AnhNV.Image = new Bitmap(fileImg);
        }
        public void LoadAnh(ref string imgname)
        {
            OpenFileDialog fileimgname = new OpenFileDialog();
            if (fileimgname.ShowDialog() == DialogResult.OK)
            {
                imgname = fileimgname.FileName;
                txt_Anh.Text = fileimgname.FileName;
                pb_AnhNV.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        //public bool Check()
        //{
        //    #region Phần trống

        //    if (string.IsNullOrEmpty(txt_EmailNV.Text))
        //    {
        //        MessageBox.Show("Email không được bỏ trống");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txt_MaNV.Text))
        //    {
        //        MessageBox.Show("Maxnhaan viên không được bỏ trống");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txt_TenNV.Text))
        //    {
        //        MessageBox.Show("Tên nhân viên không được bỏ trống");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txt_QueQuanNV.Text))
        //    {
        //        MessageBox.Show("Quê quán không được bỏ trống");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txt_CmNV.Text))
        //    {
        //        MessageBox.Show("Căn cước không được bỏ trống");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txt_SdtNV.Text))
        //    {
        //        MessageBox.Show("Số điện thoại không được bỏ trống");
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(txt_PassNV.Text))
        //    {
        //        MessageBox.Show("Password không được bỏ trống");
        //        return false;
        //    }
        //    #endregion

        //    #region 
        //    //Mã
        //    if (Regex.IsMatch(txt_MaNV.Text,@"[0-9]+")==false)
        //    {
        //        MessageBox.Show("Mã nahan viên bắt buộc phải chứa số", "ERR");
        //        return false;
        //    }
        //    for (int i = 0; i < _NvService.GetAll().Count; i++)
        //    {
        //        if (true)
        //        {

        //        }
        //    }
        //    #endregion
        //}

        private void rbtn_Nam_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Nam.Checked)
            {
                rbtn_Nu.Checked = false;
            }
        }

        private void rbtn_Nu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Nu.Checked)
            {
                rbtn_Nam.Checked = false;
            }
        }

       

      

        private void txt_TimKiemNV_TextChanged(object sender, EventArgs e)
        {
            LoadDGridNV(txt_TimKiemNV.Text);
        }

        private void txt_TimKiemNV_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDGridNV(txt_TimKiemNV.Text);
        }

        private void txt_TimKiemNV_MouseHover(object sender, EventArgs e)
        {
            if (txt_TimKiemNV.Text == "")
            {
                txt_TimKiemNV.Text = "Mã, email, sđt, căn cước của nhân viên";
                LoadDGridNV(null);
            }
        }

        private void txt_TimKiemNV_Leave(object sender, EventArgs e)
        {
            txt_TimKiemNV.Text = "";
        }

        private void txt_TimKiemNV_MouseDown(object sender, MouseEventArgs e)
        {
            txt_TimKiemNV.Text = "";
        }

        private void cmb_LocNV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_LocNV.Text=="Lọc theo tên từ A-Z")
            {
                LoadLoc1();
                return;
            }
             if (cmb_LocNV.Text=="Lọc theo tên từ Z-A")
            {
                LoadLoc2();
                return;
            }

        }

        private void LoadLoc1( )
        {
            int stt = 1;
            Type type = typeof(NhanVien);
            int sLuong = type.GetProperties().Length;
            dgrid_NV.ColumnCount = sLuong;
            //dgrid_NV.ColumnCount=12;
            dgrid_NV.Columns[0].Name = "STT";
            dgrid_NV.Columns[1].Name = "Mã nhân viên";
            dgrid_NV.Columns[2].Name = "Tên nhân viên";
            dgrid_NV.Columns[3].Name = "Giới tính";
            dgrid_NV.Columns[4].Name = "Năm Sinh";
            dgrid_NV.Columns[5].Name = "Quê quán";
            dgrid_NV.Columns[6].Name = "Số CMND";
            dgrid_NV.Columns[7].Name = "Số điện thoại";
            dgrid_NV.Columns[8].Name = "Trạng thái";
            dgrid_NV.Columns[9].Name = "Chức vụ";
            dgrid_NV.Columns[10].Name = "Email";
            dgrid_NV.Columns[11].Name = "Password";
            dgrid_NV.Columns[12].Name = "Báo Cáo";
            dgrid_NV.Columns[13].Name = "Đường dẫn ảnh";

            dgrid_NV.Rows.Clear();
            foreach (var x in _NvService.GetAll(null).OrderBy(c=>c.TenNhanVien))
            {
                // dgrid_NV.Rows.Add(stt++, x.DienThoai);
                dgrid_NV.Rows.Add(stt++, x.MaNhanVien, x.TenNhanVien, (x.GioiTinh == 0 ? "Nam" : "Nữ"), x.NamSinh, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == 0 ? "Đã nghỉ" : "Đang làm", x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Email, x.PassWord, x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Anh);
            }
        }

        private void LoadLoc2( )
        {
            int stt = 1;
            Type type = typeof(NhanVien);
            int sLuong = type.GetProperties().Length;
            dgrid_NV.ColumnCount = sLuong;
            //dgrid_NV.ColumnCount=12;
            dgrid_NV.Columns[0].Name = "STT";
            dgrid_NV.Columns[1].Name = "Mã nhân viên";
            dgrid_NV.Columns[2].Name = "Tên nhân viên";
            dgrid_NV.Columns[3].Name = "Giới tính";
            dgrid_NV.Columns[4].Name = "Năm Sinh";
            dgrid_NV.Columns[5].Name = "Quê quán";
            dgrid_NV.Columns[6].Name = "Số CMND";
            dgrid_NV.Columns[7].Name = "Số điện thoại";
            dgrid_NV.Columns[8].Name = "Trạng thái";
            dgrid_NV.Columns[9].Name = "Chức vụ";
            dgrid_NV.Columns[10].Name = "Email";
            dgrid_NV.Columns[11].Name = "Password";
            dgrid_NV.Columns[12].Name = "Báo Cáo";
            dgrid_NV.Columns[13].Name = "Đường dẫn ảnh";

            dgrid_NV.Rows.Clear();
            foreach (var x in _NvService.GetAll(null).OrderByDescending(c => c.TenNhanVien))
            {
                // dgrid_NV.Rows.Add(stt++, x.DienThoai);
                dgrid_NV.Rows.Add(stt++, x.MaNhanVien, x.TenNhanVien, (x.GioiTinh == 0 ? "Nam" : "Nữ"), x.NamSinh, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == 0 ? "Đã nghỉ" : "Đang làm", x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Email, x.PassWord, x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Anh);
            }
        }

        private void cmb_LocNV_Leave(object sender, EventArgs e)
        {
            cmb_LocNV.Text = "";
        }

        private void pb_AnhNV_Click(object sender, EventArgs e)
        {

        }

        private void cbx_HoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_HoatDong.Checked == true)
            {
                cbx_KoHoatDong.Checked = false;
            }
        }

        private void cbx_KoHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_KoHoatDong.Checked == true)
            {
                cbx_HoatDong.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmChucVu chucVu= new FrmChucVu(this);
            chucVu.Show();
        }
    }
}
