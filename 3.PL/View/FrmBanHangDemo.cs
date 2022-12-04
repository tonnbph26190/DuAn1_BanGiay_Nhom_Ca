using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.Utilities;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using _1.DAL.Models;

namespace _3.PL.View
{
    public partial class FrmBanHangDemo : Form
    {
        private INhanVienService _iQlNhanvienService;
        private IChiTietSpServices _iQlSanphamSerivce;
        private IKhachHangService _iKhachHangService;
        private IHoaDonService _iHoadonService;
        private IHoaDonChiTietServices _iHoadonChitietSerivce;

        List<HoaDonChiTIetView> _lstChitietHD;
        Guid _idSanpham;
        Guid _idHoadon;
        KhachHangView KhachHang;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        public FrmBanHangDemo()
        {
            _iQlNhanvienService = new NhanVienService();
            _iQlSanphamSerivce = new ChiTIetSpServices();
            _iKhachHangService = new KhachHangService();
            _iHoadonService = new HoaDonServices();
            _iHoadonChitietSerivce = new HoaDonChiTietServices();
            KhachHang = new KhachHangView();
            _lstChitietHD = new List<HoaDonChiTIetView>();

            _idHoadon = Guid.Empty;
            InitializeComponent();

            LoadSanpham();
            LoadHdCho();
            LoadGiohang();
            LoadCmb();
            LoadHdChoGiao();
            dgrid_sanpham.Columns[1].Visible = false;
            dgrid_hdcho.Columns[1].Visible = false;
            dgrid_dhGiao.Columns[1].Visible = false;
            dgrid_hdchitiet.Columns[1].Visible = false;
        }

        public bool check()
        {
            if (string.IsNullOrEmpty(txt_mahd.Text))
            {
                MessageBox.Show("Mã hóa đơn không được để trống");
                return false;
            }

            if (dtp_Ship.Value > dtp_NhanHang.Value)
            {
                MessageBox.Show("Ngày ship phải trước hoặc bằng ngày nhận", "Thông báo");
                return false;
            }
            return true;
        }
        private void LoadCmb()
        {
            cmb_sdtkhachhang.Items.Clear();
            cmb_nhanvien.Items.Clear();


            foreach (var x in _iKhachHangService.GetAll())
            {
                cmb_sdtkhachhang.Items.Add(x.SoDienThoai);
            }

            foreach (var x in _iQlNhanvienService.GetAll())
            {
                cmb_nhanvien.Items.Add(x.DienThoai);
            }
        }

        private void LoadSanpham()
        {
            int stt = 1;
            dgrid_sanpham.ColumnCount = 6;
            dgrid_sanpham.Columns[0].Name = "STT";
            dgrid_sanpham.Columns[1].Name = "ID";
            dgrid_sanpham.Columns[2].Name = "Mã";
            dgrid_sanpham.Columns[3].Name = "Tên sản phẩm";
            dgrid_sanpham.Columns[4].Name = "Số lượng tồn";
            dgrid_sanpham.Columns[5].Name = "Đơn giá";
            dgrid_sanpham.Rows.Clear();

            foreach (var x in _iQlSanphamSerivce.GetAll())
            {
                dgrid_sanpham.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.SoLuong, x.DonGiaBan);
            }
        }

        private void LoadHdCho()
        {
            int stt = 1;
            dgrid_hdcho.ColumnCount = 4;
            dgrid_hdcho.Columns[0].Name = "STT";
            dgrid_hdcho.Columns[1].Name = "Id";
            dgrid_hdcho.Columns[2].Name = "Mã hóa đơn";
            dgrid_hdcho.Columns[3].Name = "Tên khách hàng";
            dgrid_hdcho.Rows.Clear();

            foreach (var x in _iHoadonService.ShowHoadon().Where(c => c.TrangThai == 0))
            {
                dgrid_hdcho.Rows.Add(stt++, x.Id, x.MaHoaDon, x.TenKH);
            }
        }
        private void LoadHdChoGiao()
        {
            int stt = 1;
            dgrid_dhGiao.ColumnCount = 4;
            dgrid_dhGiao.Columns[0].Name = "STT";
            dgrid_dhGiao.Columns[1].Name = "Id";
            dgrid_dhGiao.Columns[2].Name = "Mã hóa đơn";
            dgrid_dhGiao.Columns[3].Name = "Tên khách hàng";
            dgrid_dhGiao.Rows.Clear();

            foreach (var x in _iHoadonService.ShowHoadon().Where(c => c.TrangThai == 3))
            {
                dgrid_dhGiao.Rows.Add(stt++, x.Id, x.MaHoaDon, x.TenKH);
            }
        }

        private void LoadGiohang()
        {
            int stt = 1;
            dgrid_hdchitiet.ColumnCount = 6;
            dgrid_hdchitiet.Columns[0].Name = "STT";
            dgrid_hdchitiet.Columns[1].Name = "Id";
            dgrid_hdchitiet.Columns[2].Name = "Mã sản phẩm";
            dgrid_hdchitiet.Columns[3].Name = "Tên sản phẩm";
            dgrid_hdchitiet.Columns[4].Name = "Số lượng";
            dgrid_hdchitiet.Columns[5].Name = "Đơn giá";
            dgrid_hdchitiet.Rows.Clear();

            if (_lstChitietHD == null)
            {
                return;
            }
            else
            {
                foreach (var x in _lstChitietHD)
                {
                    dgrid_hdchitiet.Rows.Add(stt++, x.IdChiTIetSp, x.MaSp, x.TenSp, x.SoLuong, x.DonGia);
                }
            }
        }
        private void ThemSpVaoGiohang(Guid idSanpham)
        {
            var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == idSanpham);
            var data = _lstChitietHD.FirstOrDefault(c => c.IdChiTIetSp == sp.Id);
            if (sp.SoLuong == 0)
            {
                MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép", "Cảnh báo");
                return;
            }
            if (data == null)
            {
                HoaDonChiTIetView hoaDonctView = new HoaDonChiTIetView()
                {
                    IdChiTIetSp = sp.Id,
                    MaSp = sp.Ma,
                    TenSp = sp.TenSp,
                    SoLuong = 1,
                    DonGia = sp.DonGiaBan,
                };
                _lstChitietHD.Add(hoaDonctView);
                totalCart();

            }
            else
            {
                if (data.SoLuong == sp.SoLuong)
                {
                    MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép", "Cảnh báo");
                    return;
                }

                else
                {
                    data.SoLuong++;

                }
            }
            LoadGiohang();
        }
        private void totalCart()
        {
            if (_lstChitietHD != null)
            {
                int total = 0;
                foreach (var x in _lstChitietHD)
                {
                    total += Convert.ToInt32(x.DonGia) * x.SoLuong;
                }
                lbl_totalcart.Text = total.ToString();
                //lbl_tongtien.Text = total.ToString();
            }
            else
            {
                lbl_totalcart.Text = "";
                //lbl_tongtien.Text = "";
            }
        }

        private void dgrid_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgrid_sanpham.Rows[e.RowIndex];
                _idSanpham = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == Guid.Parse(r.Cells[1].Value.ToString())).Id;
                ThemSpVaoGiohang(_idSanpham);
                totalCart();
            }
        }

        private void dgrid_hdchitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgrid_sanpham.Rows[e.RowIndex];
                _idSanpham = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == Guid.Parse(r.Cells[1].Value.ToString())).Id;
                ThemSpVaoGiohang(_idSanpham);
                totalCart();
            }
        }

        private void dgrid_hdchitiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgrid_hdchitiet.Rows[e.RowIndex];
                if (int.TryParse(dgrid_hdchitiet.Rows[r.Index].Cells[4].Value.ToString(), out int x))
                {
                    if (dgrid_hdchitiet.Rows[r.Index].Cells[3].Value != _lstChitietHD[r.Index].SoLuong.ToString())
                    {
                        if (Convert.ToInt32(dgrid_hdchitiet.Rows[r.Index].Cells[4].Value) <= 0)
                        {
                            MessageBox.Show("Nhập sai số lượng");
                            dgrid_hdchitiet.Rows[r.Index].Cells[3].Value = _lstChitietHD[r.Index].SoLuong;
                        }
                        else
                        {
                            var p = _iQlSanphamSerivce.GetAll().FirstOrDefault(x => x.Id == _lstChitietHD[r.Index].IdChiTIetSp);
                            if (p.SoLuong < Convert.ToInt32(dgrid_hdchitiet.Rows[r.Index].Cells[4].Value))
                            {
                                MessageBox.Show("Sản phẩm trong giỏ hàng đã vượt quá số lượng cho phép");
                                dgrid_hdchitiet.Rows[r.Index].Cells[3].Value = _lstChitietHD[r.Index].SoLuong;
                            }
                            else
                            {
                                _lstChitietHD[r.Index].SoLuong = Convert.ToInt32(dgrid_hdchitiet.Rows[r.Index].Cells[4].Value);
                                totalCart();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai số lượng");
                    dgrid_hdchitiet.Rows[r.Index].Cells[4].Value = _lstChitietHD[r.Index].SoLuong;
                }
            }
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            if (txt_mahd.Text != "")
            {
                HoaDonView hoadon = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon.Equals(txt_mahd.Text) && c.TrangThai == 0);
                if (hoadon == null)
                {
                    MessageBox.Show("Đơn hàng không tồn tại hoặc đã thanh toán");
                    lbl_tongtien.Text = "0";
                }
                else
                {
                    var khachhang = _iKhachHangService.GetAll().FirstOrDefault(c => c.Id == hoadon.IdKhachHang);
                    int x;

                    if (Convert.ToDecimal(lbl_tienthua.Text) < 0 || txt_tienkhachdua.Text == "" || !int.TryParse(txt_tienkhachdua.Text, out int y) || y < 0)
                    {
                        MessageBox.Show("Vui lòng nhập đúng số tiền");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thanh toán không?", "Thanh toán", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            hoadon.TrangThai = 1;
                            _iHoadonService.Update(hoadon);
                            MessageBox.Show("Thanh toán thành công");
                            txt_giamgia.Text = "";
                            txt_tienkhachdua.Text = "";
                            lbl_tongtien.Text = "0";
                            lbl_tienthua.Text = "0";
                            rtxt_ghichu.Text = "";
                            LoadHdCho();
                            _lstChitietHD = new List<HoaDonChiTIetView>();
                            LoadGiohang();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn");
            }
        }

        private void txt_tienkhachdua_TextChanged(object sender, EventArgs e)
        {
            if (!(txt_tienkhachdua.Text == "" && txt_giamgia.Text == ""))
            {
                if (txt_giamgia.Text == "")
                {
                    if (decimal.TryParse(txt_tienkhachdua.Text, out decimal x))
                    {
                        lbl_tienthua.Text = (Convert.ToDecimal(txt_tienkhachdua.Text) - Convert.ToDecimal(lbl_tongtien.Text)).ToString();
                    }
                }
                else
                {
                    if (decimal.TryParse(txt_tienkhachdua.Text, out decimal x) && decimal.TryParse(txt_giamgia.Text, out decimal y))
                    {
                        lbl_tienthua.Text = (Convert.ToDecimal(txt_tienkhachdua.Text) - Convert.ToDecimal(lbl_tongtien.Text) + Convert.ToDecimal(txt_giamgia.Text)).ToString();
                    }
                }
            }
        }

        private void btn_xoasp_Click(object sender, EventArgs e)
        {
            if (_lstChitietHD.Any())
            {
                var item = _lstChitietHD.FirstOrDefault(x => x.IdChiTIetSp == _idSanpham);
                _lstChitietHD.Remove(item);
                LoadGiohang();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }

        private void btn_xoagiohang_Click(object sender, EventArgs e)
        {
            if (_lstChitietHD.Any())
            {
                _lstChitietHD = new List<HoaDonChiTIetView>();
                LoadGiohang();
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
            }
        }

        private void btn_taohoadon_Click(object sender, EventArgs e)
        {
            if (cmb_sdtkhachhang.SelectedIndex == -1)
            {
                MessageBox.Show("bạn chưa chọn khách hàng");
            }
            else if (cmb_nhanvien.SelectedIndex == -1)
            {
                MessageBox.Show("bạn chưa chọn nhân vien");
            }
            else
            {
                if (_lstChitietHD.Any())
                {
                    Guid IdNhanvien = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.DienThoai == cmb_nhanvien.Text).Id;
                    KhachHang = _iKhachHangService.GetAll().FirstOrDefault(c => c.SoDienThoai == cmb_sdtkhachhang.Text);
                    if (KhachHang != null)
                    {
                        HoaDonView hoadon = new HoaDonView()
                        {
                            MaHoaDon = "HD" + Utility.GetNumber(8),
                            NgayLap = DateTime.Now,
                            IdNhanVien = IdNhanvien,
                            IdKhachHang = KhachHang.Id,
                            TrangThai = 0,
                            TenKH = KhachHang.Ten,
                            Sdt = KhachHang.SoDienThoai,

                        };
                        _iHoadonService.Add(hoadon);
                        var IdHd = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon == hoadon.MaHoaDon).Id;
                        foreach (var item in _lstChitietHD)
                        {
                            item.IdhoaDon = IdHd;
                            _iHoadonChitietSerivce.Add(item);
                            var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == item.IdChiTIetSp);
                            sp.SoLuong -= item.SoLuong;
                            _iQlSanphamSerivce.UPDATE(sp);
                        }

                        cmb_sdtkhachhang.Text = "";
                        lbl_totalcart.Text = "";
                        MessageBox.Show($"Tạo hóa đơn thành công. ID: {hoadon.MaHoaDon}");
                        LoadSanpham();
                        LoadHdCho();
                        _lstChitietHD = new List<HoaDonChiTIetView>();
                        dgrid_hdchitiet.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
                }
            }
        }

        private void dgrid_hdcho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgrid_hdcho.Rows[e.RowIndex];
                _idHoadon = Guid.Parse(r.Cells[1].Value.ToString());
                var hoadonview = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.Id == _idHoadon);
                var hoadonchitiet = _iHoadonChitietSerivce.ShowHoadonChitiet(hoadonview.Id);
                txt_mahd.Text = hoadonview.MaHoaDon;
                cmb_sdtkhachhang.Text = _iKhachHangService.GetAll().FirstOrDefault(c => c.Id == hoadonview.IdKhachHang).SoDienThoai;
                cmb_nhanvien.Text = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.Id == hoadonview.IdNhanVien).DienThoai;


                _lstChitietHD = new List<HoaDonChiTIetView>();
                foreach (var item in hoadonchitiet)
                {
                    var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == item.IdChiTIetSp);

                    HoaDonChiTIetView hdct = new HoaDonChiTIetView()
                    {
                        IdChiTIetSp= item.IdChiTIetSp,
                        MaSp = sp.Ma,
                        TenSp = sp.TenSp,
                        DonGia = sp.DonGiaBan,
                        SoLuong = hoadonchitiet.FirstOrDefault(c => c.IdChiTIetSp == sp.Id).SoLuong,
                    };
                    _lstChitietHD.Add(hdct);
                    LoadGiohang();
                }
                totalCart();
                lbl_tongtien.Text = lbl_totalcart.Text;
            }
        }

        private void cmb_sdtkhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_tenkh.Text = _iKhachHangService.GetAll().Where(c => c.SoDienThoai == cmb_sdtkhachhang.Text).Select(c => c.Ten).FirstOrDefault();
        }

        private void btn_capnhathd_Click(object sender, EventArgs e)
        {
            if (_idHoadon != Guid.Empty)
            {
                if (_lstChitietHD.Any())
                {
                    int total = 0;
                    KhachHang = _iKhachHangService.GetAll().FirstOrDefault(c => c.SoDienThoai == cmb_sdtkhachhang.Text);
                    if (KhachHang != null)
                    {
                        var hoadon = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.Id == _idHoadon);
                        var hdct = _iHoadonChitietSerivce.ShowHoadonChitiet(hoadon.Id);
                        foreach (var item in hdct)
                        {
                            item.IdhoaDon = hoadon.Id;
                            _iHoadonChitietSerivce.Delete(item);
                        }
                        foreach (var item in _lstChitietHD)
                        {
                            item.IdhoaDon = hoadon.Id;
                            _iHoadonChitietSerivce.Add(item);
                            var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == item.IdChiTIetSp);
                            sp.SoLuong -= item.SoLuong;
                            _iQlSanphamSerivce.UPDATE(sp);
                        }
                        Guid IdNhanvien = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.DienThoai == cmb_nhanvien.Text).Id;
                        hoadon.NgayLap = DateTime.Now;

                        hoadon.IdNhanVien = IdNhanvien;
                        hoadon.IdKhachHang = KhachHang.Id;
                        _iHoadonService.Update(hoadon);

                        //txt_mahd.Text = hoadon.MaHd;
                        lbl_tongtien.Text = total.ToString();
                        cmb_sdtkhachhang.Text = "";
                        lbl_totalcart.Text = "";
                        MessageBox.Show($"Cập nhật hóa đơn thành công. ID: {hoadon.MaHoaDon}");
                        _idHoadon = Guid.Empty;
                        LoadSanpham();
                        LoadHdCho();
                        dgrid_hdchitiet.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn chưa thanh toán");
            }
        }

            private void pictureBox1_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn mở CAM không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += CaptureDevice_NewFrame; ;
                    captureDevice.Start();
                    timer1.Start();
                }
                if (dialogResult == DialogResult.No) return;

            }

            private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }

            private void FrmBanHangDemo_Load(object sender, EventArgs e)
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


                    FrmAddSpToGioHang frm = new FrmAddSpToGioHang(result.ToString().Trim());
                    if (!frm.check(result.ToString().Trim()))
                    {

                        return;
                    } 
                    frm.ShowDialog();
                    var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Ma == result.ToString().Trim());
                   if (frm.change()==false) { return; }
                    HoaDonChiTIetView hoaDonctView = new HoaDonChiTIetView()
                    {
                        IdChiTIetSp = sp.Id,
                        MaSp = sp.Ma,
                        TenSp = sp.TenSp,
                        SoLuong = Convert.ToInt32(frm.taken()),
                        
                        DonGia = sp.DonGiaBan,
                    };
                    
                    _lstChitietHD.Add(hoaDonctView);
                    LoadGiohang();
                    totalCart();

                    timer1.Stop();




                    if (captureDevice.IsRunning)
                        {
                            captureDevice.SignalToStop();
                        }
                    }
                }
            }
            


            private void FrmBanHangDemo_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (captureDevice == null)
                {
                    return;
                }      
                    if (captureDevice.IsRunning)
                    {
                        captureDevice.SignalToStop();
                    }
            }

        private void dgrid_hdchitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_GiaoHang_Click(object sender, EventArgs e)
        {
            if (cmb_sdtkhachhang.SelectedIndex == -1)
            {
                MessageBox.Show("bạn chưa chọn khách hàng");
            }
            else if (cmb_nhanvien.SelectedIndex == -1)
            {
                MessageBox.Show("bạn chưa chọn nhân vien");
            }
            else
            {
                if (_lstChitietHD.Any())
                {
                    Guid IdNhanvien = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.DienThoai == cmb_nhanvien.Text).Id;
                    KhachHang = _iKhachHangService.GetAll().FirstOrDefault(c => c.SoDienThoai == cmb_sdtkhachhang.Text);
                    if (KhachHang != null)
                    {
                        HoaDonView hoadon = new HoaDonView()
                        {
                            MaHoaDon = "HD" + Utility.GetNumber(8),
                            NgayLap = DateTime.Now,
                            IdNhanVien = IdNhanvien,
                            IdKhachHang = KhachHang.Id,
                            TrangThai = 3,
                            TenKH = KhachHang.Ten,
                            Sdt = KhachHang.SoDienThoai,

                        };
                        _iHoadonService.Add(hoadon);
                        var IdHd = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon == hoadon.MaHoaDon).Id;
                        foreach (var item in _lstChitietHD)
                        {
                            item.IdhoaDon = IdHd;
                            _iHoadonChitietSerivce.Add(item);
                            var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == item.IdChiTIetSp);
                            sp.SoLuong -= item.SoLuong;
                            _iQlSanphamSerivce.UPDATE(sp);
                        }

                        cmb_sdtkhachhang.Text = "";
                        lbl_totalcart.Text = "";
                        MessageBox.Show($"Tạo hóa đơn thành công. ID: {hoadon.MaHoaDon}");
                        LoadSanpham();
                       LoadHdChoGiao();
                        _lstChitietHD = new List<HoaDonChiTIetView>();
                        dgrid_hdchitiet.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng");
                }
            }
        }

        private void dgrid_dhGiao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgrid_hdcho.Rows[e.RowIndex];
                _idHoadon = Guid.Parse(r.Cells[1].Value.ToString());
                var hoadonview = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.Id == _idHoadon);
                var hoadonchitiet = _iHoadonChitietSerivce.ShowHoadonChitiet(hoadonview.Id);
                txt_mahd.Text = hoadonview.MaHoaDon;
                cmb_sdtkhachhang.Text = _iKhachHangService.GetAll().FirstOrDefault(c => c.Id == hoadonview.IdKhachHang).SoDienThoai;
                cmb_nhanvien.Text = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.Id == hoadonview.IdNhanVien).DienThoai;


                _lstChitietHD = new List<HoaDonChiTIetView>();
                foreach (var item in hoadonchitiet)
                {
                    var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == item.IdChiTIetSp);

                    HoaDonChiTIetView hdct = new HoaDonChiTIetView()
                    {
                        IdChiTIetSp = item.IdChiTIetSp,
                        MaSp = sp.Ma,
                        TenSp = sp.TenSp,
                        DonGia = sp.DonGiaBan,
                        SoLuong = hoadonchitiet.FirstOrDefault(c => c.IdChiTIetSp == sp.Id).SoLuong,
                    };
                    _lstChitietHD.Add(hdct);
                    LoadGiohang();
                }
                totalCart();
                lbl_tongtien.Text = lbl_totalcart.Text;
            }
        }

    }  
    }



