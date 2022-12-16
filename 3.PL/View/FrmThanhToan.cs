using _1.DAL.Models;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using _3.PL.Utilities;
using AForge.Video.DirectShow;
using iTextSharp.text.pdf.codec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3.PL.View
{
    public partial class FrmThanhToan : Form
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
        string MaNVLG;
        bool Flag = true;
        public FrmThanhToan()
        {
            InitializeComponent();
            _iQlNhanvienService = new NhanVienService();
            _iQlSanphamSerivce = new ChiTIetSpServices();
            _iKhachHangService = new KhachHangService();
            _iHoadonService = new HoaDonServices();
            _iHoadonChitietSerivce = new HoaDonChiTietServices();
            KhachHang = new KhachHangView();
            _lstChitietHD = new List<HoaDonChiTIetView>();
            loadSp();
            _idHoadon = Guid.Empty;
            LoadGiohang();
            loadHDCho();
            MaNVLG = txt_MaNv.Text = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.Email == Properties.Settings.Default.TKdaLogin).MaNhanVien;
            txt_TenKh.Enabled= false;
            txt_ThanhTien.Enabled= false;
            txt_ThanhTien.Visible= false;
            label8.Visible= false;
            label11.Visible= false;
            txt_GiamGia.Visible= false;
            rbtn_ChuaThanhToan.Checked = true;
            txt_luu.Visible= false;
            txt_DiaChi.Visible= false;
        }
        private void loadSp()
        {
            Fl_SanPhams.Controls.Clear();
            foreach (var  x in _iQlSanphamSerivce.GetAll().Where(c=>c.SoLuong>0&&c.TrangThai==1))
            {
                Panel products = new Panel()
                {
                    Size = new System.Drawing.Size(160, 160),
                    BackColor = Color.White
                };

                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() { Width = 110, Height = 110 };   
                Label lb= new Label() {ForeColor=Color.Black,Location= new System.Drawing.Point(20, 120) };
                btn.Tag = x;
                btn.Image = Bitmap.FromFile(x.anh);
                btn.Click += Btn_Click;             
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.Black;
                lb.Text = x.TenSp+" "+x.LoaiSize;                   
                products.Controls.Add(lb);
                products.Controls.Add(btn);
                Fl_SanPhams.Controls.Add(products);
                
                
            }
            
        }

        

        private void Btn_Click(object? sender, EventArgs e)
        {
            
            _idSanpham = ((sender as System.Windows.Forms.Button).Tag as ChiTIetSpView).Id;
            if (Flag)
            {
                ThemSpVaoGiohang(_idSanpham);
            }
            else
            {
                Frm_Alert fm = new Frm_Alert();
                fm.showAlert("Đơn hàng đang được giao đi", Frm_Alert.enmType.Warning);
            }
            totalCart();
        }

        private void LoadGiohang()
        {
            int stt = 1;
            dgrid_hdchitiet.ColumnCount = 6;
            dgrid_hdchitiet.Columns[0].Name = "STT";
            dgrid_hdchitiet.Columns[1].Name = "Id";
            dgrid_hdchitiet.Columns[1].Visible= false;
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
            totalCart();
        }
        private void ThemSpVaoGiohang(Guid idSanpham)
        {
            var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == idSanpham);
            var data = _lstChitietHD.FirstOrDefault(c => c.IdChiTIetSp == sp.Id);
            if (sp.SoLuong == 0)
            {
                MessageBox.Show("Sản phẩm trong giỏ hàng đã hết", "Cảnh báo");
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
                    if (frm.change() == false) { return; }
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


        private void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in filterInfoCollection)
            {
                comboBox1.Items.Add(filter.Name);
                comboBox1.SelectedIndex = 0;
            }
        }
        void loadHDCho()
        {
            FL_HoaDon.Controls.Clear();
            foreach (var x in _iHoadonService.ShowHoadon().Where(c => c.TrangThai != 1))
            {
                Panel products = new Panel()
                {
                    Size = new System.Drawing.Size(82,82),
                    BackColor = Color.White
                };
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() { Width = 80, Height = 80 };
                btn.Tag = x;
                btn.BackColor = x.TrangThai==0?Color.Blue:Color.Red;
                btn.ForeColor = Color.Black;
                btn.Text=x.MaHoaDon.ToString();
                btn.Click += Btn_Click1;
                products.Controls.Add(btn);
                FL_HoaDon.Controls.Add(products);
            }

        }

        private void Btn_Click1(object? sender, EventArgs e)
        {
            _idHoadon = ((sender as System.Windows.Forms.Button).Tag as HoaDonView).Id;
            var hoadonview = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.Id == _idHoadon);
            var hoadonchitiet = _iHoadonChitietSerivce.ShowHoadonChitiet(hoadonview.Id);
            txt_MaHD.Text = hoadonview.MaHoaDon;
            txt_Sdt.Text = _iKhachHangService.GetAll().FirstOrDefault(c => c.Id == hoadonview.IdKhachHang).SoDienThoai;
            txt_MaNv.Text = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.Id == hoadonview.IdNhanVien).MaNhanVien;
            txt_DiaChi.Text = hoadonview.NguoiBan;
            txt_ThanhTien.Text=lbl_totalcart.Text;
            if (hoadonview.TrangThai==2)
            {
                Flag = false;
                ck_in.Enabled= false;
            }
            else
            {
                ck_in.Enabled = true;
            }
            if (hoadonview.TrangThai==1)
            {
                rbtn_DaTT.Checked = true;
            }
            else if (hoadonview.TrangThai == 0)
            {
                rbtn_ChuaThanhToan.Checked = true;
            }
          

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
            
        }

        private void Fl_SanPhams_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn mở CAM không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame; ; ;
                captureDevice.Start();
                timer1.Start();
            }
            if (dialogResult == DialogResult.No) return;
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
                
            }
            else
            {
                lbl_totalcart.Text = "";
                
            }
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            
            if (_lstChitietHD.Any())
            {
                Frm_Alert frm_Alert = new Frm_Alert();
                if (_iHoadonService.ShowHoadon().Any(c=>c.MaHoaDon==txt_MaHD.Text)&&rbtn_ChuaThanhToan.Checked)
                {
                    frm_Alert.showAlert("Mã hóa đơn đã tồn tại ko thể tạo",Frm_Alert.enmType.Warning);
                    return;
                }
                Guid IdNhanvien = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.MaNhanVien == MaNVLG).Id;
                KhachHang = _iKhachHangService.GetAll().FirstOrDefault(c => c.SoDienThoai == txt_Sdt.Text.Trim());
                if (KhachHang != null)
                {
                    if (_iHoadonService.ShowHoadon().Any(c=>c.MaHoaDon==txt_MaHD.Text))
                    {
                        var obj = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon == txt_MaHD.Text);
                        obj.TrangThai = rbtn_ChuaThanhToan.Checked ? 0 : 1;
                        obj.NgayThanhToan=DateTime.Now;
                        _iHoadonService.Update(obj);
                    }
                    HoaDonView hoadon = new HoaDonView()
                    {
                        MaHoaDon ="HD" + Utilitys.GetNumber(3),
                        NgayLap = DateTime.Today,
                        NgayNhanHang=DateTime.Today,
                        NgayShipHang=DateTime.Today,
                        NgayThanhToan= DateTime.Today,
                        IdNhanVien = IdNhanvien,
                        IdKhachHang = KhachHang.Id,
                        TrangThai = rbtn_ChuaThanhToan.Checked?0:1,
                        TenKH = KhachHang.Ten,
                        Sdt = KhachHang.SoDienThoai,
                        NguoiBan=KhachHang.DiaChi,
                    };
                     txt_luu.Text=hoadon.MaHoaDon;
                    _iHoadonService.Add(hoadon);
                    var IdHd = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon == hoadon.MaHoaDon).Id;
                    foreach (var item in _lstChitietHD)
                    {
                        item.IdhoaDon = IdHd;
                        _iHoadonChitietSerivce.Add(item);
                        var sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == item.IdChiTIetSp);
                        sp.SoLuong -= item.SoLuong;
                        
                        if (ck_diem.Checked)
                        {
                            KhachHang.diemTieuDung = KhachHang.diemTieuDung - Convert.ToDouble(txt_GiamGia.Text);
                            item.SoLuong= item.SoLuong;
                            item.GiamGia =Convert.ToDouble(txt_GiamGia.Text);
                            item.DonGia = sp.DonGiaBan;
                            break;
                                                    
                        }
                        _iQlSanphamSerivce.UPDATE(sp);
                        _iHoadonChitietSerivce.Update(item);
                        _iKhachHangService.Update(KhachHang);
                    }
                    loadHDCho();
                    loadSp();
                   
                   
                    if (rbtn_DaTT.Checked)
                    {
                        if (ck_in.Checked=true)
                        {
                            inHoaDon();
                        }
                        
                        frm_Alert.showAlert($"Thanh toán hóa đơn thành công. ID: {hoadon.MaHoaDon}", Frm_Alert.enmType.Info);
                        
                        KhachHang.diemTieuDung += Convert.ToDouble(lbl_totalcart.Text) / 100;
                        _iKhachHangService.Update(KhachHang);
                        clean();
                    }
                    else
                    {
                        clean();
                       
                        frm_Alert.showAlert($"Tạo hóa đơn thành công. ID: {hoadon.MaHoaDon}", Frm_Alert.enmType.Success);
                    }
                    _lstChitietHD = new List<HoaDonChiTIetView>();
                    dgrid_hdchitiet.Rows.Clear();
                }
                else
                {
                    Frm_Alert frm_Alert2 = new Frm_Alert();
                    if (_iHoadonService.ShowHoadon().Any(c => c.MaHoaDon == txt_MaHD.Text) && rbtn_ChuaThanhToan.Checked)
                    {
                        frm_Alert2.showAlert("Mã hóa đơn đã tồn tại ko thể tạo", Frm_Alert.enmType.Warning);
                        return;
                    }
                    KhachHangView kh = new KhachHangView()
                    {
                        Id = Guid.NewGuid(),
                        Ten = txt_TenKh.Text==""?"khach vang lai":txt_TenKh.Text,
                        diemTieuDung = 0,
                        TrangThai = 1,
                        SoDienThoai = txt_Sdt.Text,
                        DiaChi=txt_DiaChi2.Text,
                    };
                    _iKhachHangService.Add(kh);

                    HoaDonView hoadon = new HoaDonView()
                    {
                        MaHoaDon = "HD" + Utilitys.GetNumber(3),
                        NgayLap = DateTime.Today,
                        NgayNhanHang = DateTime.Today,
                        NgayShipHang = DateTime.Today,
                        NgayThanhToan = DateTime.Today,
                        IdNhanVien = IdNhanvien,
                        IdKhachHang = kh.Id,
                        TrangThai = rbtn_ChuaThanhToan.Checked ? 0 : 1,
                        TenKH = kh.Ten,
                        Sdt = kh.SoDienThoai,
                        NguoiBan=kh.DiaChi
                    };
                    txt_luu.Text = hoadon.MaHoaDon;
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
                    loadHDCho();
                    loadSp();

                    
                    if (rbtn_DaTT.Checked)
                    {
                        if (ck_in.Checked = true)
                        {
                            inHoaDon();
                        }
                        frm_Alert2.showAlert($"Thanh toán hóa đơn thành công. ID: {hoadon.MaHoaDon}", Frm_Alert.enmType.Info);
                        clean();
                    }
                    else if(rbtn_ChuaThanhToan.Checked)
                    {
                        
                        frm_Alert2.showAlert($"Tạo hóa đơn thành công. ID: {hoadon.MaHoaDon}", Frm_Alert.enmType.Success);
                        clean();
                    }
                    else
                    {
                        frm_Alert2.showAlert($"Bạn chưa chọn trạng thái", Frm_Alert.enmType.Warning);
                    }
                    _lstChitietHD = new List<HoaDonChiTIetView>();
                    dgrid_hdchitiet.Rows.Clear();
                }
            }
            else
            {
                Frm_Alert a=new Frm_Alert();
                a.showAlert("Mời bạn chọn sp",Frm_Alert.enmType.Error);
            }
        }

        private void btn_CLear_Click(object sender, EventArgs e)
        {
            _lstChitietHD.Clear();
            LoadGiohang();
           
            totalCart();
            Flag=true;
            clean();
        }
        void clean()
        {
            
            txt_Sdt.Text = "";
            txt_DiaChi.Text = "";
            txt_TenKh.Text = "";
            txt_ThanhTien.Text = "";
            dateTimePicker1 = new DateTimePicker();
            rbtn_ChuaThanhToan.Checked= true;         
            lbl_totalcart.Text = "";
            txt_GiamGia.Text ="";
            txt_MaHD.Text = "";
            txt_Diem.Text = "";
            txt_DiaChi2.Text="";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Fl_SanPhams_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {      
         
            if (_idHoadon != null)
            {
                if (_lstChitietHD.Any())
                {
                    var item = _lstChitietHD.FirstOrDefault(x => x.IdChiTIetSp == _idSanpham);
                    _lstChitietHD.Remove(item);
                    _idSanpham = Guid.Empty;
                    LoadGiohang();
                   
                    totalCart();
                    if (!_lstChitietHD.Any())
                    {
                        clean();
                    }
                }
            }
        }

        private void btn_TruSp_Click(object sender, EventArgs e)
        {
            if (_idHoadon!=Guid.Empty)
            {
                var item = _lstChitietHD.FirstOrDefault(x => x.IdChiTIetSp == _idSanpham);
                item.SoLuong--;
                if (item.SoLuong<=0)
                {
                    return;
                }
                LoadGiohang();
                totalCart();
            }
            
        }

        private void dgrid_hdchitiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowIndex = e.RowIndex;
            if (e.RowIndex == -1) return;
            if (rowIndex == _lstChitietHD.Count) return;
            _idSanpham = Guid.Parse(dgrid_hdchitiet.Rows[rowIndex].Cells[1].Value.ToString());
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

        private void txt_Sdt_TextChanged(object sender, EventArgs e)
        {
            if (txt_Sdt.Text.Trim() == ""||Utilitys.checkSDT(txt_Sdt.Text)==false)
            {
                
                return;
               
            }
            var obj = _iKhachHangService.GetAll().FirstOrDefault(c => c.SoDienThoai == txt_Sdt.Text);
            if (obj!=null)
            {
                txt_TenKh.Text = obj == null ? "" : obj.Ten;
                txt_Diem.Text = obj == null ? "": obj.diemTieuDung.ToString();
                txt_DiaChi2.Text = obj == null ? "" : obj.DiaChi;
                txt_TenKh.Enabled = false;

            }
            else
            {
                txt_TenKh.Enabled = true;
                
            }
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void rbtn_ChuaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_ChuaThanhToan.Checked)
            {
                txt_ThanhTien.Enabled = false;
                txt_ThanhTien.Visible = true;
                label8.Visible= true;
                txt_ThanhTien.Text = lbl_totalcart.Text;
            }
            else
            {
                txt_ThanhTien.Enabled = false;
                txt_ThanhTien.Visible = false;
                label8.Visible = false;
                rbtn_DaTT.Checked = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ck_diem_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_diem.Checked)
            {
                txt_GiamGia.Visible= true;
                label11.Visible= true;

            }
            else
            {
                txt_GiamGia.Visible = false;
                label11.Visible =false;
            }
        }

        private void txt_GiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_GiamGia_TextChanged(object sender, EventArgs e)
        {
            if (txt_GiamGia.Text=="")
            {
                return;
            }
            if(txt_Diem.Text!=""&&Convert.ToDouble(txt_Diem.Text) <Convert.ToDouble(txt_GiamGia.Text))
            {
                MessageBox.Show("Điểm ko đủ nhập lại");
                txt_GiamGia.Text = "";
                return;
            }
            else
            {
                txt_ThanhTien.Text=Convert.ToString(Convert.ToDouble(lbl_totalcart.Text) - Convert.ToDouble(txt_GiamGia.Text));
            }         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_DiaChi.Text.Trim() ==""||txt_Sdt.Text.Trim()==""||txt_TenKh.Text.Trim()==""|| Utilitys.checkSDT(txt_Sdt.Text)==false)
            {
                Frm_Alert fm = new Frm_Alert();
                fm.showAlert("Mời bạn nhập đầy đủ thông tin để sử dụng tính năng giao hàng ", Frm_Alert.enmType.Warning);
                return;
            }
            if (_idHoadon==Guid.Empty)
            {
                return;
            }
            var obj=_iHoadonService.ShowHoadon().FirstOrDefault(c=>c.Id==_idHoadon);
            obj.TrangThai = 2;
            obj.NgayShipHang=DateTime.Now;
            _iHoadonService.Update(obj);
            inHoaDon();
            loadHDCho();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (_idHoadon != Guid.Empty)
            {                 
                    KhachHang = _iKhachHangService.GetAll().FirstOrDefault(c => c.SoDienThoai == txt_Sdt.Text);
                    if (KhachHang != null)
                    {
                        var hoadon = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.Id == _idHoadon);
                        var hdct = _iHoadonChitietSerivce.ShowHoadonChitiet(hoadon.Id);
                    if (hoadon.TrangThai==2)
                    {
                        Frm_Alert fm = new Frm_Alert();
                        fm.showAlert("Hoa don dang duoc giao khong the sua", Frm_Alert.enmType.Warning);
                        return;
                    }
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
                        Guid IdNhanvien = _iQlNhanvienService.GetAll().FirstOrDefault(c => c.MaNhanVien==txt_MaNv.Text).Id;
                        hoadon.NgayLap = DateTime.Now;

                        hoadon.IdNhanVien = IdNhanvien;
                        hoadon.IdKhachHang = KhachHang.Id;
                        _iHoadonService.Update(hoadon);

                        //txt_mahd.Text = hoadon.MaHd;
                        clean();
                        MessageBox.Show($"Cập nhật hóa đơn thành công. ID: {hoadon.MaHoaDon}");
                        _idHoadon = Guid.Empty;
                        loadSp();
                        loadHDCho();
                        dgrid_hdchitiet.Rows.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập khách hàng");
                    }            
               
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn chưa thanh toán");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_idHoadon!=Guid.Empty)
            {
                var obj = _iHoadonService.ShowHoadon().FirstOrDefault(c => c.Id == _idHoadon);
                if (obj.TrangThai==0)
                {
                    inHoaDon();
                }
                obj.NgayNhanHang=DateTime.Now;
                obj.TrangThai = 1;
                Frm_Alert fm = new Frm_Alert();
                fm.showAlert($"Thanh toán hóa đơn {obj.MaHoaDon} thành công", Frm_Alert.enmType.Success);
                _iHoadonService.Update(obj); clean();
                
                _lstChitietHD = new List<HoaDonChiTIetView>();
                loadHDCho();
            }
        }
        void inHoaDon()
        {
           printPreviewDialog1.Document =printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (txt_MaHD.Text == "")
            {
                var w = printDocument1.DefaultPageSettings.PaperSize.Width;
                //Lấy tên cửa hàng
                var T = _iHoadonChitietSerivce.ShowHoadonChitiet().Where(c => c.IdhoaDon == _iHoadonService.GetID(txt_luu.Text));
                e.Graphics.DrawString(
                    "Cá Shoes".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                    new PointF(100, 20));
                //Mã hóa đơn
                
                e.Graphics.DrawString(
                    String.Format("{0}", txt_luu.Text+" "+_iQlNhanvienService.GetAll().FirstOrDefault(c=>c.Id== _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon == txt_luu.Text).IdNhanVien).TenNhanVien),
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new PointF(w / 2 + 200, 20));



                e.Graphics.DrawString(
                    String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:MM")),
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new PointF(w / 2 + 200, 45));

                Pen blackPEn = new Pen(Color.Black, 1);
                var y = 70;

                Point p1 = new Point(10, y);
                Point p2 = new Point(w - 10, y);
                e.Graphics.DrawLine(blackPEn, p1, p2);

                y += 30;
                e.Graphics.DrawString(
                    "Phiếu Thanh Toán".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black,
                    new PointF(190, y));


                y += 80;
                e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(50, y));
                e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w / 2, y));
                e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w / 2 + 100, y));              
                e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w - 200, y)); 
               

                //var id = _lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault();
                var list = _iHoadonService.ShowHoadon().Where(c => c.Id == _iHoadonService.GetID(txt_luu.Text));
                e.Graphics.DrawString("Giảm:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                   new Point(w - 200, y + 80));
                e.Graphics.DrawString(string.Format("{0:N0}", txt_GiamGia.Text), new Font("Varial", 8, FontStyle.Bold),
                       Brushes.Black, new Point(w - 155, y + 82));
                e.Graphics.DrawString("Tổng đơn:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                   new Point(w - 200, y + 100));
                e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToDouble(lbl_totalcart.Text) - Convert.ToDouble(txt_GiamGia.Text)), new Font("Varial", 8, FontStyle.Bold),
                       Brushes.Black, new Point(w - 120, y + 105));
                int i = 1;

                y += 20;
               

                foreach (var x in _iHoadonChitietSerivce.ShowHoadonChitiet().Where(c => c.IdhoaDon == _iHoadonService.GetID(txt_luu.Text)))
                {
                    e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                        new Point(10, y));
                    e.Graphics.DrawString("" + _iQlSanphamSerivce.GetAll()
                                              .Where(c => c.Id == x.IdChiTIetSp)
                                              .Select(c => c.TenNsx + " " + c.TenSp).FirstOrDefault() + " " +
                                          _iQlSanphamSerivce.GetAll().Where(c =>
                                                  c.Id == x.IdChiTIetSp)
                                              .Select(c => c.MoTa).FirstOrDefault(),
                        new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                    e.Graphics.DrawString(string.Format("{0:N0}", x.SoLuong), new Font("Varial", 8, FontStyle.Bold),
                        Brushes.Black, new Point(w / 2, y));
                    e.Graphics.DrawString(string.Format("{0:N0}", x.DonGia), new Font("Varial", 8, FontStyle.Bold),
                        Brushes.Black, new Point(w / 2 + 100, y));                  
                    e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToInt32(Convert.ToInt32(x.SoLuong) * Convert.ToInt32(x.DonGia))), new Font("Varial", 8, FontStyle.Bold),
                        Brushes.Black, new Point(w - 200, y));
                    y += 20;
                }
            }
            else
            {
               
                var ton2 = _iHoadonService.ShowHoadon().Where(c => c.MaHoaDon.Trim().Equals(txt_MaHD.Text.Trim()));
                //var test= _iHoadonService.ShowHoadon().Select(c=>c.MaHoaDon).ToList();
                //var txt = txt_MaHD.Text;
                var w = printDocument1.DefaultPageSettings.PaperSize.Width;
                //Lấy tên cửa hàng
                var T = _iHoadonChitietSerivce.ShowHoadonChitiet().Where(c => c.IdhoaDon == _iHoadonService.GetID(txt_MaHD.Text));
                e.Graphics.DrawString(
                    "Cá Shoes".ToUpper(), new Font("Courier New", 12, FontStyle.Bold), Brushes.Black,
                    new PointF(100, 20));
                //Mã hóa đơn

                e.Graphics.DrawString(
                   String.Format("{0}", txt_MaHD.Text + " " + _iQlNhanvienService.GetAll().FirstOrDefault(c => c.Id == _iHoadonService.ShowHoadon().FirstOrDefault(c => c.MaHoaDon == txt_MaHD.Text).IdNhanVien).TenNhanVien),
                   new Font("Courier New", 12, FontStyle.Bold),
                   Brushes.Black, new PointF(w / 2 + 200, 20));



                e.Graphics.DrawString(
                    String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:MM")),
                    new Font("Courier New", 12, FontStyle.Bold),
                    Brushes.Black, new PointF(w / 2 + 200, 45));

                Pen blackPEn = new Pen(Color.Black, 1);
                var y = 70;

                Point p1 = new Point(10, y);
                Point p2 = new Point(w - 10, y);
                e.Graphics.DrawLine(blackPEn, p1, p2);

                y += 30;
                e.Graphics.DrawString(
                    "Phiếu Giao Hàng".ToUpper(), new Font("Courier New", 30, FontStyle.Bold), Brushes.Black,
                    new PointF(190, y));


                y += 80;
                e.Graphics.DrawString("STT", new Font("Varial", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString("Tên hàng hóa", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(50, y));
                e.Graphics.DrawString("Số lượng", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w / 2, y));
                e.Graphics.DrawString("Đơn giá", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w / 2 + 100, y));               
                e.Graphics.DrawString("Thành tiền", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w - 200, y)); 
                e.Graphics.DrawString("Địa chỉ:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                    new Point(w-820, y+80));
                e.Graphics.DrawString("SĐT:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                   new Point(w - 820, y + 110));
                e.Graphics.DrawString("Tên khách hàng:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                   new Point(w - 820, y + 140));
                
                var tung = w - 820;
                var hoanh = y + 80;
                //var id = _lstHoaDonBans.Select(x => x.IdhoaDon).FirstOrDefault();
                var list = _iHoadonService.ShowHoadon().Where(c => c.MaHoaDon.Trim().Equals(txt_MaHD.Text.Trim()));
                e.Graphics.DrawString("Giảm:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                   new Point(w -200, y+80));
                e.Graphics.DrawString(string.Format("{0:N0}", txt_GiamGia.Text), new Font("Varial", 8, FontStyle.Bold),
                       Brushes.Black, new Point(w - 155, y +82));
                e.Graphics.DrawString("Tổng đơn:", new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                   new Point(w - 200, y +100));
                e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToDouble(lbl_totalcart.Text) - Convert.ToDouble(txt_GiamGia.Text)), new Font("Varial", 8, FontStyle.Bold),
                       Brushes.Black, new Point(w - 120, y + 105));
                int i = 1;

                y += 30;
                
                foreach (var x in _iHoadonChitietSerivce.ShowHoadonChitiet().Where(c => c.IdhoaDon == _iHoadonService.GetID(txt_MaHD.Text)))
                {
                    double sum = x.SoLuong*x.DonGia;
                    sum += x.ThanhTien;
                    e.Graphics.DrawString(string.Format("{0}", i++), new Font("Varial", 8, FontStyle.Bold), Brushes.Black,
                        new Point(10, y));
                    e.Graphics.DrawString("" + _iQlSanphamSerivce.GetAll()
                                              .Where(c => c.Id == x.IdChiTIetSp)
                                              .Select(c => c.TenNsx + " " + c.TenSp).FirstOrDefault() + " " +
                                          _iQlSanphamSerivce.GetAll().Where(c =>
                                                  c.Id == x.IdChiTIetSp)
                                              .Select(c => c.MoTa).FirstOrDefault(),
                        new Font("Varial", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                    e.Graphics.DrawString(string.Format("{0:N0}", x.SoLuong), new Font("Varial", 8, FontStyle.Bold),
                        Brushes.Black, new Point(w / 2, y));
                    e.Graphics.DrawString(string.Format("{0:N0}", x.DonGia), new Font("Varial", 8, FontStyle.Bold),
                        Brushes.Black, new Point(w / 2 + 100, y));
                   
                    e.Graphics.DrawString(string.Format("{0:N0}", Convert.ToInt32(Convert.ToInt32(x.SoLuong) * Convert.ToInt32(x.DonGia))), new Font("Varial", 8, FontStyle.Bold),
                        Brushes.Black, new Point(w - 200, y));                  
                    y += 20;
                    e.Graphics.DrawString(x.sdt, new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(tung + 40, hoanh+29));
                    e.Graphics.DrawString(_iHoadonService.ShowHoadon().FirstOrDefault(c=>c.Sdt==x.sdt).NguoiBan, new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(tung + 60, hoanh));                   
                    e.Graphics.DrawString(_iHoadonService.ShowHoadon().FirstOrDefault(c => c.Sdt == x.sdt).TenKH, new Font("Varial", 10, FontStyle.Bold), Brushes.Black,
                        new Point(tung + 115, hoanh+61));
                }
                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_DaTT_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtn_DaTT.Checked)
            {
                rbtn_ChuaThanhToan.Checked = true;
            }
        }

        private void txt_Sdt_TextAlignChanged(object sender, EventArgs e)
        {

        }
    }
}
