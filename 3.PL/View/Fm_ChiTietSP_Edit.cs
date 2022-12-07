using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.Utilities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.View
{
    public partial class Fm_ChiTietSP_Edit : Form
    {
        string linkavatar = "";
        string linkQR = "";
        private IChiTietSpServices _iQLSanPhamView;
        private IDongSPService _iDongSpService;
        private IMauSacService _iMauSacService;
        private INsxService _iNsxService;
        private ISanPhamService _iSanPhamService;
        private ISizeService _ISizeService;
        private IChatLieuService _IChatLieuService;
        Guid _idWhenclick;
        Guid _idWhenclick2;
        int Flag = 1;
        List<ChiTIetSpView> _ChiTIetSpViews;
        public Fm_ChiTietSP_Edit()
        {
            InitializeComponent();
            _iQLSanPhamView = new ChiTIetSpServices();
            LoadDgridSP();
            _iDongSpService = new DongSPService();
            _iMauSacService = new MauSacService();
            _iNsxService = new NsxService();
            _iSanPhamService = new SanPhamService();
            _ISizeService = new SizeService();
            _IChatLieuService = new ChatLieuService();
            _ChiTIetSpViews = new List<ChiTIetSpView>();
            LoadCmb();
            
            InitializeComponent();
        }
        public void LoadCmb()
        {
            cmb_SanPham.Items.Clear();
            cmb_DongSp.Items.Clear();
            Cmb_MauSac.Items.Clear();
            cmb_NSX.Items.Clear();
            cmb_Size.Items.Clear();
            cmb_ChatLieu.Items.Clear();
            foreach (var x in _iSanPhamService.GetAll())
            {

                cmb_SanPham.Items.Add(x.Ten);
            }

            foreach (var x in _iDongSpService.GetAll())
            {

                cmb_DongSp.Items.Add(x.Ten);
            }


            foreach (var x in _iMauSacService.GetAll())
            {

                Cmb_MauSac.Items.Add(x.Ten);
            }


            foreach (var x in _iNsxService.GetAll())
            {

                cmb_NSX.Items.Add(x.Ten);
            }
            foreach (var x in _IChatLieuService.GetAll())
            {

                cmb_ChatLieu.Items.Add(x.Ten);
            }
            foreach (var x in _ISizeService.GetAll())
            {

                cmb_Size.Items.Add(x.SizeGiay);
            }



        }
        private void LoadDgridSP()
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 17;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Name = "Id";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên Sản Phẩm";
            dgrid_sanpham.Columns[4].Name = "Màu";
            dgrid_sanpham.Columns[5].Name = "Tên NSX";
            dgrid_sanpham.Columns[6].Name = "Tên Dòng SP";
            dgrid_sanpham.Columns[7].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[8].Name = "Giá nhập";
            dgrid_sanpham.Columns[9].Name = "Giá bán";
            dgrid_sanpham.Columns[10].Name = "Mô tả";
            dgrid_sanpham.Columns[11].Name = "Nsx";
            dgrid_sanpham.Columns[12].Name = "Dòng Sp";
            dgrid_sanpham.Columns[13].Name = "Chất Liệu";
            dgrid_sanpham.Columns[14].Name = "Size";
            dgrid_sanpham.Columns[15].Name = "Màu Sắc";
            dgrid_sanpham.Columns[16].Name = "Trang Thái";

            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQLSanPhamView.GetAll())
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa, x.TenNsx, x.TenDongSp, x.TenChatLieu, x.LoaiSize, x.TenMauSac, x.TrangThai == 1 ? "Hoạt Động" : "Không hoạt động");
            }
        }
        private ChiTIetSpView GetDataFromGui()
        {
            ChiTIetSpView spv = new ChiTIetSpView()
            {
                Id = Guid.NewGuid(),
                IdSp = _iSanPhamService.GetById(_iSanPhamService.GetIdByName(cmb_SanPham.Text)).Id,
                IdMauSac = _iMauSacService.GetById(_iMauSacService.GetIdFromTen(Cmb_MauSac.Text)).Id,
                IdNsx = _iNsxService.GetById(_iNsxService.GetIdFromTen(cmb_NSX.Text)).Id,
                IdDongSP = _iDongSpService.GetById(_iDongSpService.GetIdByName(cmb_DongSp.Text)).Id,
                IdchatLieu = _IChatLieuService.GetById(_IChatLieuService.GetIdByName(cmb_ChatLieu.Text)).Id,
                IdSize = _ISizeService.GetById(_ISizeService.GetIdFromTen(cmb_Size.Text)).Id,
                SoLuong = Convert.ToInt32(txt_SoLuong.Text),
                DonGiaNhap = Convert.ToDouble(txt_gianhap.Text),
                DonGiaBan = Convert.ToDouble(txt_giaban.Text),
                MoTa = richtxt_mota.Text,
                TrangThai = rbtn_HoatDong.Checked ? 1 : 0,
                anh = linkavatar,
                Mavach = linkQR,
                Ma = txt_Ma.Text
            };
            return spv;
        }

        private void dgrid_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pic_SanPham_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (pic_SanPham != null)
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn thêm ảnh không", "Some tite", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        pic_SanPham.Image = Image.FromFile(op.FileName);
                        pic_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;
                        linkavatar = op.FileName;
                    }

                }
            }
            else
            {
                if (op.ShowDialog() == DialogResult.OK)
                {
                    pic_SanPham.Image = Image.FromFile(op.FileName);
                    pic_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;
                    linkavatar = op.FileName;
                }
            }
        }

        private void cmb_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(_idWhenclick == Guid.Empty))
            {
                Flag = 0;
            }
            if (Flag == 0)
            {
                var temp = _iQLSanPhamView.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);

                txt_Ma.Text = temp.Ma;
                Flag = 1;

            }
            else
            {
                string ma = txt_Ma.Text;
                do
                {
                    ma = "SP" + Utility.GetNumber(3);
                } while (_iQLSanPhamView.GetAll().Any(c => c.Ma.Equals(ma)));
                txt_Ma.Text = ma;
            }
        }
    }

}
