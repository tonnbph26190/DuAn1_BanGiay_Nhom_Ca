
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.Utilities;
using QRCoder;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace _3.PL.View
{
    public partial class FrmChiTietSp_demo : Form
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
        public FrmChiTietSp_demo()
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
            loadFlSp();


        }
        public void LoadCmb()
        {
            cmb_tensp.Items.Clear();
            cmb_dongsanpham.Items.Clear();
            cmb_mausac.Items.Clear();
            cmb_nhasanxuat.Items.Clear();
            cmb_Size.Items.Clear();
            cmb_ChatLieu.Items.Clear();
            foreach (var x in _iSanPhamService.GetAll())
            {

                cmb_tensp.Items.Add(x.Ten);
            }

            foreach (var x in _iDongSpService.GetAll())
            {

                cmb_dongsanpham.Items.Add(x.Ten);
            }


            foreach (var x in _iMauSacService.GetAll())
            {

                cmb_mausac.Items.Add(x.Ten);
            }


            foreach (var x in _iNsxService.GetAll())
            {

                cmb_nhasanxuat.Items.Add(x.Ten);
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
        public bool check()
        {
            if (string.IsNullOrEmpty(cmb_tensp.Text))
            {
                MessageBox.Show("Tên sản phẩm không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_Ma.Text))
            {
                MessageBox.Show("Mã không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_dongsanpham.Text))
            {
                MessageBox.Show("Dòng sản phẩm không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_nhasanxuat.Text))
            {
                MessageBox.Show("Nhà sản xuất không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_mausac.Text))
            {
                MessageBox.Show("Màu sắc không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_ChatLieu.Text))
            {
                MessageBox.Show("Chất liệu không được bỏ trống!", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(cmb_Size.Text))
            {
                MessageBox.Show("Size không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_soluong.Text))
            {
                MessageBox.Show("Số lượng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_gianhap.Text))
            {
                MessageBox.Show("Giá nhập không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_giaban.Text))
            {
                MessageBox.Show("Giá bán không được bỏ trống", "Thông báo");
                return false;
            }
            if (rbtn_HoatDong.Checked == false && rbtn_KhongHoatDong.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo");
                return false;
            }
            else
            {
                return true;
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
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.TenMauSac, x.TenNsx, x.TenDongSp, x.SoLuong, x.DonGiaNhap, x.DonGiaBan, x.MoTa,x.TenNsx,x.TenDongSp,x.TenChatLieu,x.LoaiSize,x.TenMauSac,x.TrangThai==1?"Hoạt Động":"Không hoạt động");
            }
        }
        private ChiTIetSpView GetDataFromGui()
        {

            ChiTIetSpView spv = new ChiTIetSpView()
            {
                Id = Guid.NewGuid(),
                IdSp = _iSanPhamService.GetById(_iSanPhamService.GetIdByName(cmb_tensp.Text)).Id,
                IdMauSac = _iMauSacService.GetById(_iMauSacService.GetIdFromTen(cmb_mausac.Text)).Id,
                IdNsx = _iNsxService.GetById(_iNsxService.GetIdFromTen(cmb_nhasanxuat.Text)).Id,
                IdDongSP = _iDongSpService.GetById(_iDongSpService.GetIdByName(cmb_dongsanpham.Text)).Id,
                IdchatLieu = _IChatLieuService.GetById(_IChatLieuService.GetIdByName(cmb_ChatLieu.Text)).Id,
                IdSize = _ISizeService.GetById(_ISizeService.GetIdFromTen(cmb_Size.Text)).Id,
                SoLuong = Convert.ToInt32(txt_soluong.Text),
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

        private void cmb_tensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(_idWhenclick == Guid.Empty))
            {
                Flag = 0;
            }
            if(Flag==0)
            {
                var temp = _iQLSanPhamView.GetAll().FirstOrDefault(c=>c.Id==_idWhenclick);

                txt_Ma.Text = temp.Ma;
                Flag=1;

            }
            else
            {
                string ma = txt_Ma.Text;
                do
                {
                    ma ="SP"+ Utilitys.GetNumber(3);
                } while (_iQLSanPhamView.GetAll().Any(c => c.Ma.Equals(ma)));
                txt_Ma.Text = ma;
            }
        }

        private void txt_Ma_TextChanged(object sender, EventArgs e)
        {

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txt_Ma.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pic_Qrcode.Image = code.GetGraphic(5);
            OpenFileDialog op = new OpenFileDialog();

        }

      

        private void dgrid_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iQLSanPhamView.GetAll().Count) return;
            _idWhenclick = Guid.Parse(dgrid_sanpham.Rows[rowIndex].Cells[1].Value.ToString());
            var ctspv = _iQLSanPhamView.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);
            cmb_tensp.SelectedIndex = _iSanPhamService.GetAll().FindIndex(c => c.Id == ctspv.IdSp);
            cmb_dongsanpham.SelectedIndex = _iDongSpService.GetAll().FindIndex(c => c.Id == ctspv.IdDongSP);
            cmb_mausac.SelectedIndex = _iMauSacService.GetAll().FindIndex(c => c.Id == ctspv.IdMauSac);
            cmb_nhasanxuat.SelectedIndex = _iNsxService.GetAll().FindIndex(c => c.Id == ctspv.IdNsx);
            cmb_ChatLieu.SelectedIndex = _IChatLieuService.GetAll().FindIndex(c => c.Id == ctspv.IdchatLieu);
            cmb_Size.SelectedIndex = _ISizeService.GetAll().FindIndex(c => c.Id == ctspv.IdSize);
            txt_soluong.Text = ctspv.SoLuong.ToString();
            txt_gianhap.Text = ctspv.DonGiaNhap.ToString();
            txt_giaban.Text = ctspv.DonGiaBan.ToString();
            txt_Ma.Text = ctspv.Ma;
            richtxt_mota.Text = ctspv.MoTa;
            if (ctspv.anh != null)
            {
                
                Image img = Image.FromFile(ctspv.anh);
                pic_SanPham.Image = img;
                pic_SanPham.SizeMode = PictureBoxSizeMode.StretchImage;

                // Bitmap bm = new Bitmap(txt_Anh.Text);
            }
            if (ctspv.Mavach != null && File.Exists(ctspv.Mavach))
            {
                pic_Qrcode.Image = Image.FromFile(ctspv.Mavach);
                pic_Qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
                linkQR = ctspv.Mavach;
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

        private void btn_themsp_Click(object sender, EventArgs e)
        {
            if (check()==false)
            {
                return;
            }
            else
            {
                foreach (var x in _ChiTIetSpViews)
                {
                    if (x.Ma == txt_Ma.Text)
                    {
                        MessageBox.Show("Mã đã tồn tại", "Thông báo");
                    }
                }
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string path = @"C:\Users\nguye\Source\Repos\DuAn1_BanGiay_Nhom_Ca\3.PL\Qrcode\";
                var dialog = new SaveFileDialog();
                dialog.InitialDirectory = path;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pic_Qrcode.Image.Save(dialog.FileName);
                    pic_Qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
                    linkQR = dialog.FileName;

                }
                _ChiTIetSpViews.Add(GetDataFromGui());
                
                loadFlSp();
            }
            if (dialogResult == DialogResult.No) return;
        }
        public void loadFlSp()
        {
            Fl_SanPham.Controls.Clear();

            foreach (var x in  _ChiTIetSpViews)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() { Width = 80, Height = 80 };
                btn.Text = x.Ma;
                btn.Tag = x;
                btn.BackColor = Color.Red;
                btn.Click += Btn_Click;
                btn.ForeColor = Color.Black;
                Fl_SanPham.Controls.Add(btn);
            }
            
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
           
            
            _idWhenclick2 = ((sender as System.Windows.Forms.Button).Tag as ChiTIetSpView).Id;
            var ctspv = _ChiTIetSpViews.FirstOrDefault(c => c.Id == _idWhenclick2);
            cmb_tensp.SelectedIndex = _iSanPhamService.GetAll().FindIndex(c => c.Id == ctspv.IdSp);
            cmb_dongsanpham.SelectedIndex = _iDongSpService.GetAll().FindIndex(c => c.Id == ctspv.IdDongSP);
            cmb_mausac.SelectedIndex = _iMauSacService.GetAll().FindIndex(c => c.Id == ctspv.IdMauSac);
            cmb_nhasanxuat.SelectedIndex = _iNsxService.GetAll().FindIndex(c => c.Id == ctspv.IdNsx);
            cmb_ChatLieu.SelectedIndex = _IChatLieuService.GetAll().FindIndex(c => c.Id == ctspv.IdchatLieu);
            cmb_Size.SelectedIndex = _ISizeService.GetAll().FindIndex(c => c.Id == ctspv.IdSize);
            txt_soluong.Text = ctspv.SoLuong.ToString();
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
                pic_Qrcode.Image = Image.FromFile(ctspv.Mavach);
                pic_Qrcode.SizeMode = PictureBoxSizeMode.StretchImage;
                linkQR = ctspv.Mavach;
            }
            else
            {

                pic_Qrcode.Image = null;
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

        private void btn_xoasp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xoa sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = _ChiTIetSpViews.FirstOrDefault(c => c.Id == _idWhenclick2);
                _ChiTIetSpViews.Remove(temp);

                loadFlSp();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_suasp_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa sản phẩn này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_idWhenclick2!=Guid.Empty)
                {                 
                    for (int i = 0; i < _ChiTIetSpViews.Count; i++)
                    {
                        if (_ChiTIetSpViews[i].Id == _idWhenclick2)
                        {
                            _ChiTIetSpViews[i].IdSp = _iSanPhamService.GetById(_iSanPhamService.GetIdByName(cmb_tensp.Text)).Id;
                            _ChiTIetSpViews[i].IdMauSac = _iMauSacService.GetById(_iMauSacService.GetIdFromTen(cmb_mausac.Text)).Id;
                            _ChiTIetSpViews[i].IdNsx = _iNsxService.GetById(_iNsxService.GetIdFromTen(cmb_nhasanxuat.Text)).Id;
                            _ChiTIetSpViews[i].IdDongSP = _iDongSpService.GetById(_iDongSpService.GetIdByName(cmb_dongsanpham.Text)).Id;
                            _ChiTIetSpViews[i].IdchatLieu = _IChatLieuService.GetById(_IChatLieuService.GetIdByName(cmb_ChatLieu.Text)).Id;
                            _ChiTIetSpViews[i].IdSize = _ISizeService.GetById(_ISizeService.GetIdFromTen(cmb_Size.Text)).Id;
                            _ChiTIetSpViews[i].SoLuong = Convert.ToInt32(txt_soluong.Text);
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
            if (dialogResult == DialogResult.No) return;
        }

        private void txt_Ma_Leave(object sender, EventArgs e)
        {
            
        }

        private void btn_Commit_Click(object sender, EventArgs e)
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
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            
        }
    }
}
