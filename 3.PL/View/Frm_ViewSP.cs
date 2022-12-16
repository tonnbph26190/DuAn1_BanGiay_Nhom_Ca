using _2.BUS.IServices;
using _2.BUS.Services;
using _3.PL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.View
{
    public partial class Frm_ViewSP : Form
    {
        private IChiTietSpServices _iQLSanPhamView;
        string _maClick;
        public Frm_ViewSP()
        {
            InitializeComponent();
            _iQLSanPhamView = new ChiTIetSpServices();
            LoadSP();
            pictureBox6.Image = Resources.timkiem;
            pictureBox1.Image = Resources.sx;
            pictureBox3.Image = Resources.sheet;
            pictureBox2.Image = Resources.Screenshot_20221115_071639;
            lbl_nsx.Visible= false;
            lbl_dsp.Visible = false;
            lbl_cl.Visible = false;
            lbl_ms.Visible = false;
            lbl_s.Visible = false;
            lbl_tensp.Visible = false;
            lbl_sl.Visible = false;
        }

        public void LoadSP()
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll())
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }

        #region

        //Size 35
        public void LoadSize(string mess)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            //dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.LoaiSize.Trim() == mess.Trim()))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }


        //Load Giá
        public void LoadGia(double mess1, double mess2)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            // dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.DonGiaBan >= mess1 && c.DonGiaBan <= mess2))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }

        //Load NSX
        public void LoadNSX(string mess)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            //dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.TenNsx.Trim() == mess.Trim()))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }

        public void LoadSizeGia(string mess, double mess1, double mess2)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            //dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.LoaiSize.Trim() == mess.Trim() && c.DonGiaBan >= mess1 && c.DonGiaBan <= mess2))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }

        public void LoadSizeNSX(string mess, string mess1)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            //dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.LoaiSize.Trim() == mess.Trim() && c.TenNsx.Trim() == mess1.Trim()))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }
        public void LoadGiaNSX(string mess, double mess1, double mess2)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            //dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.TenNsx.Trim() == mess.Trim() && c.DonGiaBan >= mess1 && c.DonGiaBan <= mess2))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }

        public void Load3Cai(string mess, double mess1, double mess2, string mess3)
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[8].Visible = false;
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            //dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll().Where(c => c.LoaiSize.Trim() == mess.Trim() && c.DonGiaBan >= mess1 && c.DonGiaBan <= mess2 && c.TenNsx.Trim() == mess3.Trim()))
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }


        public void checkSize(string mess)
        {
            if (chk_under500.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "NewBalance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "NewBalance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 0, 500000, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia(mess, 0, 500000);

            }
            if (chk51.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "NewBalance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "NewBalance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 500000, 1000000, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia(mess, 500000, 1000000);

            }
            if (chk_12.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "NewBalance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "NewBalance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 1000000, 2000000, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia(mess, 1000000, 2000000);

            }
            if (chk_tren2tr.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "NewBalance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "NewBalance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai(mess, 2000000, 9999999, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia(mess, 2000000, 9999999);
            }
            dgrid_sanpham.Rows.Clear();
            LoadSize(mess);
        }

        public void checkGia(double mess1, double mess2)
        {
            if (chk_35.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 35", mess1, mess2);
            }
            if (chk_36.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 36", mess1, mess2);
            }
            if (chk_37.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 37", mess1, mess2);
            }
            if (chk_38.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 38", mess1, mess2);
            }
            if (chk_39.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 39", mess1, mess2);
            }
            if (chk_40.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 40", mess1, mess2);
            }
            if (chk_41.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 41", mess1, mess2);
            }
            if (chk_42.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 42", mess1, mess2);
            }
            if (chk_43.Checked)
            {
                if (chk_Nike.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Nike");
                }
                if (chk_Adidas.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Adidas");
                }
                if (chk_Converse.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Converse");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "New Balance");
                }
                if (chk_Puma.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Puma");
                }
                if (chk_Vans.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Vans");
                }
                if (chk_NewBalance.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "New Balance");
                }
                if (chk_Fila.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Fila");
                }
                if (chk_Reebok.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", mess1, mess2, "Reebok");
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeGia("Size 43", mess1, mess2);
            }
            dgrid_sanpham.Rows.Clear();
            LoadGia(mess1,mess2);

        }

        public void checkNSX(string mess)
        {
            if (chk_35.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 35", 2000000, 9999999, mess);
                }
                LoadSizeNSX("Size 35",mess);
            }
            if (chk_36.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 36", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 36", mess);
            }
            if (chk_37.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 37", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 37", mess);
            }
            if (chk_38.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 38", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 38", mess);
            }
            if (chk_39.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 39", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 39", mess);
            }
            if (chk_40.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 40", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 40", mess);
            }
            if (chk_41.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 41", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 41", mess);
            }
            if (chk_42.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 42", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 42", mess);
            }
            if (chk_43.Checked)
            {
                if (chk_under500.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", 0, 500000, mess);
                }
                if (chk51.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", 500000, 1000000, mess);
                }
                if (chk_12.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", 1000000, 2000000, mess);
                }
                if (chk_tren2tr.Checked)
                {
                    dgrid_sanpham.Rows.Clear();
                    Load3Cai("Size 43", 2000000, 9999999, mess);
                }
                dgrid_sanpham.Rows.Clear();
                LoadSizeNSX("Size 43", mess);
            }
            dgrid_sanpham.Rows.Clear();
            LoadNSX(mess);
        }
        public void LoadChecked()
        {
            //Size
            if (chk_35.Checked)
            {
                checkSize("Size 35");
            }
            if (chk_36.Checked)
            {
                checkSize("Size 36");
            }
            if (chk_37.Checked)
            {
                checkSize("Size 37");
            }
            if (chk_38.Checked)
            {
                checkSize("Size 38");
            }
            if (chk_39.Checked)
            {
                checkSize("Size 39");
            }
            if (chk_40.Checked)
            {
                checkSize("Size 40");
            }
            if (chk_41.Checked)
            {
                checkSize("Size 41");
            }
            if (chk_42.Checked)
            {
                checkSize("Size 42");
            }
            if (chk_43.Checked)
            {
                checkSize("Size 43");
            }

            //Giá
            if (chk_under500.Checked)
            {
                checkGia(0, 500000);
            }
            if (chk51.Checked)
            {
                checkGia(500000, 1000000);
            }
            if (chk_12.Checked)
            {
                checkGia(1000000, 2000000);
            }
            if (chk_tren2tr.Checked)
            {
                checkGia(2000000, 999999999);
            }

            //NSX
            if (chk_Nike.Checked)
            {
                checkNSX("Nike");
            }
            if (chk_Adidas.Checked)
            {
                checkNSX("Adidas");
            }
            if (chk_Converse.Checked)
            {
                checkNSX("Converse");
            }
            if (chk_NewBalance.Checked)
            {
                checkNSX("New Balance");
            }
            if (chk_Puma.Checked)
            {
                checkNSX("Puma");
            }
            if (chk_Vans.Checked)
            {
                checkNSX("Vans");
            }
            if (chk_NewBalance.Checked)
            {
                checkNSX("New Balance");
            }
            if (chk_Fila.Checked)
            {
                checkNSX("Fila");
            }
            if (chk_Reebok.Checked)
            {
                checkNSX("Reebok");
            }

        }
        #endregion
        private void chk_35_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_36_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_37_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_38_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_39_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_40_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_41_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_42_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_43_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_under500_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk51_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_12_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_tren2tr_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Nike_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Adidas_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Converse_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_NewBalance_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Puma_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Vans_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Balenciaga_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Fila_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void chk_Reebok_CheckedChanged(object sender, EventArgs e)
        {
            dgrid_sanpham.Rows.Clear();
            LoadChecked();
        }

        private void dgrid_sanpham_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_nsx.Visible = true;
            lbl_dsp.Visible = true;
            lbl_cl.Visible = true;
            lbl_ms.Visible = true;
            lbl_s.Visible = true;
            lbl_tensp.Visible = true;
            lbl_sl.Visible = true;
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iQLSanPhamView.GetAll().Count) return;
            _maClick = dgrid_sanpham.Rows[rowIndex].Cells[2].Value.ToString();
            var obj = _iQLSanPhamView.GetAll().FirstOrDefault(c => c.Ma == _maClick);
            lbl_nsx.Text = obj.TenNsx;
            lbl_dsp.Text = obj.TenDongSp;
            lbl_cl.Text = obj.TenChatLieu;
            lbl_ms.Text = obj.TenMauSac;
            lbl_s.Text = obj.TenSp;
            lbl_tensp.Text = obj.TenSp;
            lbl_sl.Text = obj.SoLuong.ToString();
            if (obj.anh == "")
            {
                pictureBox2.Image = Resources.Screenshot_20221115_071639;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            if (obj.anh != "")
            {
                Image img = Image.FromFile(obj.anh);
                pictureBox2.Image = img;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Resources.Screenshot_20221115_071639;
            lbl_nsx.Visible = false;
            lbl_dsp.Visible = false;
            lbl_cl.Visible = false;
            lbl_ms.Visible = false;
            lbl_s.Visible = false;
            lbl_tensp.Visible = false;
            lbl_sl.Visible = false;
            chk_35.Checked=false;
            chk_36.Checked=false;
            chk_37.Checked=false;
            chk_38.Checked=false;
            chk_39.Checked=false;
            chk_40.Checked=false;
            chk_41.Checked=false;
            chk_42.Checked=false;
            chk_43.Checked=false;
            chk_under500.Checked=false;
            chk51.Checked = false;
            chk_12.Checked=false;
            chk_tren2tr.Checked=false;
            chk_Nike.Checked=false;
            chk_Adidas.Checked = false;
            chk_Converse.Checked=false;
            chk_NewBalance.Checked=false;
            chk_Puma.Checked=false;
            chk_Vans.Checked=false;
            chk_Balenciaga.Checked=false;
            chk_Fila.Checked=false;
            chk_Reebok.Checked=false;
            LoadSP();

        }
    }
}
