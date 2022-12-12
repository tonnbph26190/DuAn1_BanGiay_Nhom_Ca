using _2.BUS.IServices;
using _2.BUS.Services;
using _3.PL.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    public partial class Fm_HoaDon : Form
    {
        private IHoaDonService _iHoadonService;
        private IHoaDonChiTietServices _iHoadonChitietSerivce;
        Guid _idHoadon;
        public Fm_HoaDon()
        {
            _iHoadonService = new HoaDonServices();
            _iHoadonChitietSerivce = new HoaDonChiTietServices();
            InitializeComponent();
            LoadHdCho();
        }

        private void Fm_HoaDon_Load(object sender, EventArgs e)
        {

        }
        private void LoadHdCho()
        {
            int stt = 1;
            dgrid_HoaDon.ColumnCount = 5;
            dgrid_HoaDon.Columns[0].Name = "STT";
            dgrid_HoaDon.Columns[1].Name = "Id";
            dgrid_HoaDon.Columns[2].Name = "Mã hóa đơn";
            dgrid_HoaDon.Columns[3].Name = "Tên khách hàng";
            dgrid_HoaDon.Columns[4].Name = "NV bán";
            dgrid_HoaDon.Rows.Clear();

            foreach (var x in _iHoadonService.ShowHoadon().Where(c => c.TrangThai == 1))
            {
                dgrid_HoaDon.Rows.Add(stt++, x.Id, x.MaHoaDon, x.TenKH,x.NV);
            }
        }
        private void LoadGiohang(Guid id)
        {
            int stt = 1;
            dgrid_HoaDonChiTiet.ColumnCount = 6;
            dgrid_HoaDonChiTiet.Columns[0].Name = "STT";
            dgrid_HoaDonChiTiet.Columns[1].Name = "Id";
            dgrid_HoaDonChiTiet.Columns[2].Name = "Mã sản phẩm";
            dgrid_HoaDonChiTiet.Columns[3].Name = "Tên sản phẩm";
            dgrid_HoaDonChiTiet.Columns[4].Name = "Số lượng";
            dgrid_HoaDonChiTiet.Columns[5].Name = "Đơn giá";
            dgrid_HoaDonChiTiet.Rows.Clear();


            foreach (var x in _iHoadonChitietSerivce.ShowHoadonChitiet(id))
            {
                dgrid_HoaDonChiTiet.Rows.Add(stt++, x.IdChiTIetSp, x.MaSp, x.TenSp, x.SoLuong, x.DonGia);
            }

        }
        private void dgrid_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow r = dgrid_HoaDon.Rows[e.RowIndex];
                _idHoadon = Guid.Parse(r.Cells[1].Value.ToString());
                txt_MaHD.Text= r.Cells[2].Value.ToString();
                LoadGiohang(_idHoadon);
            }
        }

        private void btn_CLear_Click(object sender, EventArgs e)
        {
            LoadGiohang(Guid.Empty);
        }
    }
}
