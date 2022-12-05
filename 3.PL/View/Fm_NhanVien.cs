using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.View;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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
            LoadLstBaoCao();
            LoadLstNamSinh();
            LoadLoc();
            LoadThanhPho();
            cmb_ChucVuNV.Visible = false;
            LoadTrangThai();
            txt_MaNV.Enabled = false;
            cmb_NamSinhNV.Visible = false;
        }

        public void LoadThanhPho()
        {
            List<string> list = new List<string>() { "Bà Rịa", "Bạc Liêu", "Bảo Lộc", "Bắc Giang", "Bắc Kạn", "Bắc Ninh", "Bến Tere", "Biên Hòa", "Buôn Ma Thuật", "Cà Mau", "Cam Ranh", "Cao Bằng", "Cao Lãnh", "Cẩm Phả", "Cần Thơ", "Châu Đốc", "Đà Lạt", "Đà Nẵng", "Điện Biên Phủ", "Đông Hà", "Đồng Hới", "Đồng Xoài", "Hà Giang", "Hà Nội", "Hải Phòng", "Hạ Long", "Hà Tiên", "Hà Tĩnh", "Hải Dương", "Hòa Bình", "Hội An", "Huế", "Hưng Yên", "Kon Tum", "Lai Châu", "Lạng Sơn", "Lòa Cai", "Long Xuyên", "Móng Cái", "Mỹ Tho", "Nam Định", "Nha Trang", "Ninh Bình", "Phan Rang", "Phan Thiết", "Phủ Lý", "Phúc Yên", "Pleiku", "QUảng Ngãi", "Quy Nhơn", "Rạch Giá", "Sa Đéc", "Sầm Sơn", "Sóc Trăng", "Sơn La", "Sông Công", "Tam Điệp", "Tam Kỳ", "Tây An", "Tây Ninh", "Thái Nguyên", "Thái Bình", "Thanh Hóa", "Trà Vinh", "Tuy Hòa", "TP Hồ CHí Minh", "Phú Quốc" };
            foreach (var x in list)
            {
                cmb_ThanhPho.Items.Add(x);
            }
        }

        public void LoadTrangThai()
        {
            List<string> list = new List<string>() { "Đã nghỉ", "Đang làm" };
            foreach (var x in list)
            {
                cmb_TrangThai.Items.Add(x);
            }
        }
        public void LoadLstChucVu()
        {
            foreach (var x in _CvService.GetAll())
            {
                cmb_ChucVuNV.Items.Add(x.Ma + "-" + x.Ten);
            }
        }
        public void LoadLstBaoCao()
        {
            //foreach (var x in _NvService.GetAll(null))
            //{
            //    if (_CvService.GetNameByID(x.IdChucVu) == "Lao Công")
            //    {
            //        cmb_BaoCao.Items.Add(x.MaNhanVien + "-" + x.TenNhanVien);
            //    }
            //}
        }
        public void LoadLoc()
        {
            ArrayList row = new ArrayList();
            row.Add("Lọc theo tên từ A-Z");
            row.Add("Lọc theo tên từ Z-A");
            cmb_LocNV.Items.AddRange(row.ToArray());
        }

        public void LoadLstNamSinh()
        {
            List<int> lst = new List<int>();
            for (int i = 1982; i <= 2004; i++)
            {
                lst.Add(i);
            }
            foreach (var x in lst)
            {
                cmb_NamSinhNV.Items.Add(x);
            }
        }

        private void LoadDGridNV(string input)
        {
            int stt = 1;
            Type type = typeof(NhanVien);
            int sLuong = type.GetProperties().Length;
            //dgrid_NV.ColumnCount = sLuong;
            dgrid_NV.ColumnCount=13;
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
                dgrid_NV.Rows.Add(stt++, x.MaNhanVien, x.TenNhanVien, (x.GioiTinh == 0 ? "Nam" : "Nữ"), x.NamSinh, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == 0 ? "Đã nghỉ" : "Đang làm", x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Email, x.PassWord, x.Anh);
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
                NamSinh = dtp_NamSinh.Value,
                QueQuan = cmb_ThanhPho.Text,
                SoCmnd = txt_CmNV.Text,
                DienThoai = txt_SdtNV.Text,
                TrangThai = (cmb_TrangThai.Text == "Đã nghỉ" ? 0 : 1),
                Email = txt_EmailNV.Text,
                PassWord = txt_PassNV.Text,
                IdChucVu = _CvService.GetIDByMa(cmb_ChucVuNV.Text.Split("-")[0]),
                // IdBc = _CvService.GetIDByMa(cmb_ChucVuNV.Text.Split("-")[0]),
                //IdBc = Guid.Parse("2B4EE488-5584-4BA1-A291-74446E9635AE"),
                Anh = txt_Anh.Text,
            };
        }

        private void dgrid_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dtp_NamSinh.Visible = false;
            //cmb_NamSinhNV.Visible = true;
            cmb_ChucVuNV.Visible = true;
            cb_TaoMoi.Visible = false;
            cb_DaCo.Visible = false;
            int rowIndex = e.RowIndex;
            if (rowIndex == _NvService.GetAll(null).Count) return;
            _maClick = dgrid_NV.Rows[rowIndex].Cells[1].Value.ToString();
            var obj = _NvService.GetAll(null).FirstOrDefault(c => c.MaNhanVien == _maClick);
            txt_MaNV.Text = obj.MaNhanVien;
            txt_TenNV.Text = obj.TenNhanVien;
            dtp_NamSinh.Value = obj.NamSinh;
            cmb_ThanhPho.Text = obj.QueQuan;
            txt_CmNV.Text = obj.SoCmnd;
            txt_SdtNV.Text = obj.DienThoai;
            txt_EmailNV.Text = obj.Email;
            txt_PassNV.Text = obj.PassWord;
            cmb_ChucVuNV.Text = obj.ChucVu.Ma + "-" + _CvService.GetNameByID(obj.IdChucVu);
            cmb_TrangThai.Text = (obj.TrangThai == 1 ? "Đang làm" : "Đã nghỉ");
            //cmb_BaoCao.Text = _CvService.GetNameByID();
            if (obj.Anh != null)
            {
                txt_Anh.Text = obj.Anh;
                Image img = Image.FromFile(obj.Anh);
                pb_AnhNV.Image = img;
                pb_AnhNV.SizeMode = PictureBoxSizeMode.StretchImage;

                // Bitmap bm = new Bitmap(txt_Anh.Text);
            }
            else
                pb_AnhNV.Image = Image.FromFile("D:\\Desktop\\Máy tính\\Ki4\\PRO_DuAn1\\CoLen\\3.PL\\Resources\\icons8-account-96.png");
            if (obj.GioiTinh == 0)
            {
                rbtn_Nam.Checked = true;
                return;
            }
            rbtn_Nu.Checked = true;
            cmb_TrangThai.Text = (obj.TrangThai == 0 ? "Đã nghỉ" : "Đang làm");




        }

        private void bnt_Them_Click(object sender, EventArgs e)
        {
            if (Check() == false)
            {
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_NvService.Add(GetGui()));
                LoadDGridNV(null);
                cmb_ChucVuNV.Visible = false;
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void bnt_Sua_Click(object sender, EventArgs e)
        {
            if (checkTrong() == false)
            {
                return;
            }
            var temp = GetGui();
            temp.MaNhanVien = _maClick;
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_NvService.Update(temp));
                LoadDGridNV(null);
            }
            if (dialogResult == DialogResult.No) return;
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
            cmb_NamSinhNV.Text = "";
            dtp_NamSinh.Value = DateTime.Now;
            txt_CmNV.Text = "";
            txt_SdtNV.Text = "";
            txt_EmailNV.Text = "";
            txt_PassNV.Text = "";
            cmb_ThanhPho.Text = "";
            rbtn_Nam.Checked = true;
            txt_Anh.Text = "";
            cmb_ChucVuNV.Text = "";
            cmb_ChucVuNV.Visible= false;
            cb_DaCo.Visible= true;
            cb_TaoMoi.Visible= true;
            cmb_TrangThai.Text = "";
            //cmb_BaoCao.Text = "";
            pb_AnhNV.Image = Image.FromFile("D:\\Desktop\\Máy tính\\Ki4\\PRO_DuAn1\\CoLen\\3.PL\\Resources\\icons8-account-96.png");
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

        public bool checkTrong()
        {

            if (string.IsNullOrEmpty(txt_EmailNV.Text))
            {
                MessageBox.Show("Email không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_MaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_TenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống");
                return false;
            }
            //if (string.IsNullOrEmpty(cmb_NamSinhNV.Text))
            //{
            //    MessageBox.Show("Năm sinh nhân viên không được bỏ trống");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(cmb_BaoCao.Text))
            //{
            //    MessageBox.Show("Người gửi báo cáo không được bỏ trống");
            //    return false;
            //}
            if (string.IsNullOrEmpty(cmb_TrangThai.Text))
            {
                MessageBox.Show("Trạng thái nhân viên không được bỏ trống");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_ChucVuNV.Text))
            {
                MessageBox.Show("Chức vụ nhân viên không được bỏ trống");
                return false;
            }


            if (string.IsNullOrEmpty(cmb_ThanhPho.Text))
            {
                MessageBox.Show("Quê quán (Thành phố) không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_CmNV.Text))
            {
                MessageBox.Show("Căn cước không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_SdtNV.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_PassNV.Text))
            {
                MessageBox.Show("Password không được bỏ trống");
                return false;
            }

            return true;
        }
        public bool Check()
        {
            #region Phần trống

            if (string.IsNullOrEmpty(txt_EmailNV.Text))
            {
                MessageBox.Show("Email không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_MaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_TenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được bỏ trống");
                return false;
            }
            //if (string.IsNullOrEmpty(cmb_NamSinhNV.Text))
            //{
            //    MessageBox.Show("Năm sinh nhân viên không được bỏ trống");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(cmb_BaoCao.Text))
            //{
            //    MessageBox.Show("Người gửi báo cáo không được bỏ trống");
            //    return false;
            //}
            if (string.IsNullOrEmpty(cmb_TrangThai.Text))
            {
                MessageBox.Show("Trạng thái nhân viên không được bỏ trống");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_ChucVuNV.Text))
            {
                MessageBox.Show("Chức vụ nhân viên không được bỏ trống");
                return false;
            }


            if (string.IsNullOrEmpty(cmb_ThanhPho.Text))
            {
                MessageBox.Show("Quê quán (Thành phố) không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_CmNV.Text))
            {
                MessageBox.Show("Căn cước không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_SdtNV.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(txt_PassNV.Text))
            {
                MessageBox.Show("Password không được bỏ trống");
                return false;
            }
            #endregion

            #region 
            //Mã          
            //for (int i = 0; i < _NvService.GetAll(null).Count; i++)
            //{
            //    if (_NvService.GetAll(null)[i].MaNhanVien==txt_MaNV.Text)
            //    {
            //        MessageBox.Show("Mã nhân Viên Đã tồn Tại yêu cầu nhập mã nhân viên khác", "ERR");
            //        return false;
            //    }
            //}
            #endregion
            //Tên
            if (txt_TenNV.Text.Length <= 3)
            {
                MessageBox.Show("Tên nhân Viên phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_TenNV.Text, @"^[a-zA-Z]") == false)
            {

                MessageBox.Show("Tên nhân Viên không được chứa số", "ERR");
                return false;
            }

            //giới tính
            if (rbtn_Nam.Checked == false && rbtn_Nu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "ERR");
                return false;
            }
            //sđt


            //email
            if (txt_EmailNV.Text.Length <= 3)
            {
                MessageBox.Show("email bạn nhập không hợp lệ", "ERR");
                return false;
            }
            for (int i = 0; i < _NvService.GetAll(null).Count; i++)
            {
                if (_NvService.GetAll(null)[i].Email == txt_EmailNV.Text)
                {
                    MessageBox.Show("Email nhân Viên Đã tồn Tại yêu cầu nhập email nhân viên khác", "ERR");
                    return false;
                }
            }
            //pass
            if (txt_PassNV.Text.Length <= 3)
            {
                MessageBox.Show("Mật Khẩu nhân Viên phải trên 3 ký tự", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_PassNV.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("mật khẩu nhân Viên Bắt buộc phải chứa số", "ERR");
                return false;
            }


            //dien thoai
            if (txt_SdtNV.Text.Length <= 3)
            {
                MessageBox.Show(" số điện thoại không hợp lệ", "ERR");
                return false;
            }
            if (Regex.IsMatch(txt_SdtNV.Text, @"^\d+$") == false)
            {

                MessageBox.Show("số điện thoại nhân viên không được chứa chữ cái", "ERR");
                return false;
            }
            return true;
        }




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
            if (cmb_LocNV.Text == "Lọc theo tên từ A-Z")
            {
                LoadLoc1();
                return;
            }
            if (cmb_LocNV.Text == "Lọc theo tên từ Z-A")
            {
                LoadLoc2();
                return;
            }

        }

        private void LoadLoc1()
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
            foreach (var x in _NvService.GetAll(null).OrderBy(c => c.TenNhanVien))
            {
                // dgrid_NV.Rows.Add(stt++, x.DienThoai);
                dgrid_NV.Rows.Add(stt++, x.MaNhanVien, x.TenNhanVien, (x.GioiTinh == 0 ? "Nam" : "Nữ"), x.NamSinh, x.QueQuan, x.SoCmnd, x.DienThoai, x.TrangThai == 0 ? "Đã nghỉ" : "Đang làm", x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Email, x.PassWord, x.ChucVu.Ma + "-" + _CvService.GetNameByID(x.IdChucVu), x.Anh);
            }
        }

        private void LoadLoc2()
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

        private void cb_DaCo_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DaCo.Checked)
            {
                cb_TaoMoi.Checked = false;
                cb_TaoMoi.Visible = false;
                cb_DaCo.Visible = false;
                LoadLstChucVu();
                cmb_ChucVuNV.Visible = true;

            }
        }

        private void cb_TaoMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_TaoMoi.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm mới 1 chức vụ khum?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    cb_DaCo.Checked = false;
                    FrmChucVu frmCv = new FrmChucVu();
                    // frmCv.TopLevel = false;
                    frmCv.ShowDialog();
                }
                if (dialogResult == DialogResult.No) return;
            }

        }

        private void pb_AnhNV_Click(object sender, EventArgs e)
        {

        }

        private void txt_TenNV_TextChanged(object sender, EventArgs e)
        {
            txt_MaNV.Text = Utilities.Utility.ZenMaTuDong(txt_TenNV.Text);
        }
    }
}
