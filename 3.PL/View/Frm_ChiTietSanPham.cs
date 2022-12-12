using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.Properties;
using _3.PL.Utilities;
using _3.PL.View;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _3.PL
{
    public partial class Frm_ChiTietSanPham : Form
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
        public Frm_ChiTietSanPham()
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
           txt_Ma.Enabled= false;

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
                    ma = "SP" + Utilitys.GetNumber(3);
                } while (_iQLSanPhamView.GetAll().Any(c => c.Ma.Equals(ma)));
                txt_Ma.Text = ma;
            }
        }

        private void txt_Ma_TextChanged(object sender, EventArgs e)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txt_Ma.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pic_QR.Image = code.GetGraphic(4);
            OpenFileDialog op = new OpenFileDialog();
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
        }
        

        private void dgrid_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iQLSanPhamView.GetAll().Count) return;
            _idWhenclick = Guid.Parse(dgrid_sanpham.Rows[rowIndex].Cells[1].Value.ToString());
            var ctspv = _iQLSanPhamView.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);
            cmb_SanPham.SelectedIndex = _iSanPhamService.GetAll().FindIndex(c => c.Id == ctspv.IdSp);
            cmb_DongSp.SelectedIndex = _iDongSpService.GetAll().FindIndex(c => c.Id == ctspv.IdDongSP);
            Cmb_MauSac.SelectedIndex = _iMauSacService.GetAll().FindIndex(c => c.Id == ctspv.IdMauSac);
            cmb_NSX.SelectedIndex = _iNsxService.GetAll().FindIndex(c => c.Id == ctspv.IdNsx);
            cmb_ChatLieu.SelectedIndex = _IChatLieuService.GetAll().FindIndex(c => c.Id == ctspv.IdchatLieu);
            cmb_Size.SelectedIndex = _ISizeService.GetAll().FindIndex(c => c.Id == ctspv.IdSize);
            txt_SoLuong.Text = ctspv.SoLuong.ToString();
            txt_gianhap.Text = ctspv.DonGiaNhap.ToString();
            txt_giaban.Text = ctspv.DonGiaBan.ToString();
            txt_Ma.Text = ctspv.Ma;
            richtxt_mota.Text = ctspv.MoTa;
            if (ctspv.anh != null && File.Exists(ctspv.anh))
            {
                pic_SanPham.Image = Image.FromFile(ctspv.anh);
                pic_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;
                linkavatar = ctspv.anh;

            }
            else
            {

                pic_SanPham.Image = null;
            }
            if (ctspv.Mavach != null && File.Exists(ctspv.Mavach))
            {
                pic_QR.Image = Image.FromFile(ctspv.Mavach);
                pic_QR.SizeMode = PictureBoxSizeMode.StretchImage;
                linkQR = ctspv.Mavach;
            }
            else
            {

                pic_QR.Image = null;
            }
            if (ctspv.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
            }
            else
            {
                rbtn_KhongHoatDong.Checked = true;
            }
        }
        public void loadFlSp()
        {
            Fl_SanPham.Controls.Clear();

            foreach (var x in _ChiTIetSpViews)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() { Width = 80, Height = 80 };
                btn.Text = x.Ma;
                btn.Tag = x;
                btn.Image= Bitmap.FromFile(x.anh);
                btn.BackColor = Color.Red;
                btn.Click += Btn_Click; ;
                btn.ForeColor = Color.Black;
                Fl_SanPham.Controls.Add(btn);
            }

        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            _idWhenclick2 = ((sender as System.Windows.Forms.Button).Tag as ChiTIetSpView).Id;
            var ctspv = _ChiTIetSpViews.FirstOrDefault(c => c.Id == _idWhenclick2);
            cmb_SanPham.SelectedIndex = _iSanPhamService.GetAll().FindIndex(c => c.Id == ctspv.IdSp);
            cmb_DongSp.SelectedIndex = _iDongSpService.GetAll().FindIndex(c => c.Id == ctspv.IdDongSP);
            Cmb_MauSac.SelectedIndex = _iMauSacService.GetAll().FindIndex(c => c.Id == ctspv.IdMauSac);
            cmb_NSX.SelectedIndex = _iNsxService.GetAll().FindIndex(c => c.Id == ctspv.IdNsx);
            cmb_ChatLieu.SelectedIndex = _IChatLieuService.GetAll().FindIndex(c => c.Id == ctspv.IdchatLieu);
            cmb_Size.SelectedIndex = _ISizeService.GetAll().FindIndex(c => c.Id == ctspv.IdSize);
            txt_SoLuong.Text = ctspv.SoLuong.ToString();
            txt_gianhap.Text = ctspv.DonGiaNhap.ToString();
            txt_giaban.Text = ctspv.DonGiaBan.ToString();
            txt_Ma.Text = ctspv.Ma;
            richtxt_mota.Text = ctspv.MoTa;
            if (ctspv.anh != null && File.Exists(ctspv.anh))
            {
                pic_SanPham.Image = Image.FromFile(ctspv.anh);
                Image img = Image.FromFile(ctspv.anh);
                pic_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;
                linkavatar = ctspv.anh;
                pic_SanPham.Image = img;

            }
            else
            {

                pic_SanPham.Image = null;
            }
            if (ctspv.Mavach != null && File.Exists(ctspv.Mavach))
            {
                pic_QR.Image = Image.FromFile(ctspv.Mavach);
                pic_QR.SizeMode = PictureBoxSizeMode.StretchImage;
                linkQR = ctspv.Mavach;
            }
            else
            {

                pic_QR.Image = null;
            }
            if (ctspv.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
            }
            else
            {
                rbtn_KhongHoatDong.Checked = true;
            }

        }

        private void bnt_Sua_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_idWhenclick2 != Guid.Empty)
                {
                    for (int i = 0; i < _ChiTIetSpViews.Count; i++)
                    {
                        if (_ChiTIetSpViews[i].Id == _idWhenclick2)
                        {
                            _ChiTIetSpViews[i].IdSp = _iSanPhamService.GetById(_iSanPhamService.GetIdByName(cmb_SanPham.Text)).Id;
                            _ChiTIetSpViews[i].IdMauSac = _iMauSacService.GetById(_iMauSacService.GetIdFromTen(Cmb_MauSac.Text)).Id;
                            _ChiTIetSpViews[i].IdNsx = _iNsxService.GetById(_iNsxService.GetIdFromTen(cmb_NSX.Text)).Id;
                            _ChiTIetSpViews[i].IdDongSP = _iDongSpService.GetById(_iDongSpService.GetIdByName(cmb_DongSp.Text)).Id;
                            _ChiTIetSpViews[i].IdchatLieu = _IChatLieuService.GetById(_IChatLieuService.GetIdByName(cmb_ChatLieu.Text)).Id;
                            _ChiTIetSpViews[i].IdSize = _ISizeService.GetById(_ISizeService.GetIdFromTen(cmb_Size.Text)).Id;
                            _ChiTIetSpViews[i].SoLuong = Convert.ToInt32(txt_SoLuong.Text);
                            _ChiTIetSpViews[i].DonGiaNhap = Convert.ToDouble(txt_gianhap.Text);
                            _ChiTIetSpViews[i].DonGiaBan = Convert.ToDouble(txt_giaban.Text);
                            _ChiTIetSpViews[i].MoTa = richtxt_mota.Text;
                            _ChiTIetSpViews[i].TrangThai = rbtn_HoatDong.Checked ? 1 : 0;
                            _ChiTIetSpViews[i].anh = linkavatar;
                            _ChiTIetSpViews[i].Mavach = linkQR;
                            _ChiTIetSpViews[i].Ma = txt_Ma.Text;
                            MessageBox.Show("Sửa Thành Công");
                            _idWhenclick2 = Guid.Empty;
                            loadFlSp();
                        }
                    }
                }
                else
                {
                    var temp = GetDataFromGui();
                    temp.Id = _idWhenclick;
                    MessageBox.Show(_iQLSanPhamView.UPDATE(temp));
                    LoadDgridSP();
                }
            }
            clear();
            if (dialogResult == DialogResult.No) return;
        }

        private void bnt_Them_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm Sp này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string path = @"D:\Desktop\Máy tính\Ki4\PRO_DuAn1\LanCuoiThat\3.PL\Qrcode\";
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = path;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pic_QR.Image.Save(dialog.FileName);
                    pic_QR.SizeMode = PictureBoxSizeMode.StretchImage;
                    linkQR = dialog.FileName;
                    
                }
                if (_iQLSanPhamView.ADD(GetDataFromGui()))
                {
                    MessageBox.Show("Thêm thành công");
                }
                LoadDgridSP();
                clear();

            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_ThemList_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string path = @"D:\Desktop\Máy tính\Ki4\PRO_DuAn1\LanCuoiThat\3.PL\Qrcode\";
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = path;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pic_QR.Image.Save(dialog.FileName);
                    pic_QR.SizeMode = PictureBoxSizeMode.StretchImage;
                    linkQR = dialog.FileName;

                }
                _ChiTIetSpViews.Add(GetDataFromGui());

                loadFlSp();
            }
            clear();
            if (dialogResult == DialogResult.No) return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                foreach (var item in _ChiTIetSpViews)
                {

                    if ((_iQLSanPhamView.ADD(item)))
                    {
                        MessageBox.Show("Them Thanh Cong");

                    }
                    else
                    {
                        MessageBox.Show("Them that That Bai");
                        return;
                    }
                    _ChiTIetSpViews.Remove(item);
                    if (_ChiTIetSpViews.Count == 0)
                    {
                        break;
                    }

                }

                loadFlSp();
                LoadDgridSP();
            }
            clear();
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xoa sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = _ChiTIetSpViews.FirstOrDefault(c => c.Id == _idWhenclick2);
                _ChiTIetSpViews.Remove(temp);
                loadFlSp();
            }
            clear();
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            Frm_SanPham sp=new Frm_SanPham(this);
            sp.ShowDialog(this);
        }

        private void btn_ThemDSP_Click(object sender, EventArgs e)
        {
            FrmDongSp dongSp= new FrmDongSp(this);
            dongSp.ShowDialog(this);
        }

        private void btn_ThenNsx_Click(object sender, EventArgs e)
        {
            Frm_Nsx nsx= new Frm_Nsx(this);
            nsx.ShowDialog(this);
        }

        private void btn_ThemChatLieu_Click(object sender, EventArgs e)
        {
            Frm_ChatLieu chatLieu= new Frm_ChatLieu(this);
            chatLieu.ShowDialog(this);
        }

        private void btn_ThemMauSac_Click(object sender, EventArgs e)
        {
            Frm_MauSac mauSac= new Frm_MauSac(this);
            mauSac.ShowDialog(this);
        }

        private void btn_ThemSize_Click(object sender, EventArgs e)
        {
            Frm_SizeGiay sizeGiay= new Frm_SizeGiay(this);
            sizeGiay.ShowDialog(this);
        }
        public void updateData()
        {

            LoadCmb();

        }

        private void Frm_ChiTietSanPham_Load(object sender, EventArgs e)
        {

        }

        void clear()
        {
            cmb_SanPham.Text = "";
            txt_Ma.Text = "";
            cmb_DongSp.Text = "";
            cmb_NSX.Text = "";
            cmb_ChatLieu.Text = "";
            Cmb_MauSac.Text = "";
            cmb_Size.Text = "";
            txt_SoLuong.Text = "";
            txt_giaban.Text = "";
            txt_gianhap.Text = "";
            rbtn_HoatDong.Checked = true;
            richtxt_mota.Text = "";
            pic_SanPham.Image = Resources.anhsanpham_frmSanPham;
            pic_QR.Image = Resources.anhsanpham_frmSanPham;
        }
        private void btn_CLear_Click(object sender, EventArgs e)
        {
           clear();
        }
    }
}
