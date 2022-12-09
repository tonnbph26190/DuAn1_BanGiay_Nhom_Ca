using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
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

namespace _3.PL.View
{
    public partial class FrmBanHang : Form
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
        public FrmBanHang()
        {
            _iQlNhanvienService = new NhanVienService();
            _iQlSanphamSerivce = new ChiTIetSpServices();
            _iKhachHangService = new KhachHangService();
            _iHoadonService = new HoaDonServices();
            _iHoadonChitietSerivce = new HoaDonChiTietServices();
            KhachHang = new KhachHangView();
            _lstChitietHD = new List<HoaDonChiTIetView>();
            loadSp();
            _idHoadon = Guid.Empty;
            InitializeComponent();
        }
       private void loadSp()
        {
            Fl_SanPham.Controls.Clear();
            foreach (var x in _iQlSanphamSerivce.GetAll())
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() { Width = 80, Height = 80 };              
                btn.Tag = x;
                btn.Image = Bitmap.FromFile(x.anh);
                btn.BackColor = Color.Red;             
                btn.ForeColor = Color.Black;
                btn.Click += Btn_Click;
                Fl_SanPham.Controls.Add(btn);
                
            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            _idSanpham = ((sender as System.Windows.Forms.Button).Tag as ChiTIetSpView).Id;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
