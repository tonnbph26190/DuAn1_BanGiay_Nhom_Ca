using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
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
        private IChiTietSpServices _iQlSanphamSerivce;
        private IHoaDonService _iHoadonService;
        private IHoaDonChiTietServices _iHoadonChitietSerivce;
        Guid _idHoadon;
        Guid _idSanpham;
        List<HoaDonChiTIetView> _lstChitietHD;
        List<HoaDonView> _lstHoaDon;
        public Fm_HoaDon()
        {
            _iHoadonService = new HoaDonServices();
            _iHoadonChitietSerivce = new HoaDonChiTietServices();
            _iQlSanphamSerivce = new ChiTIetSpServices();
            _lstChitietHD = new List<HoaDonChiTIetView>();
            InitializeComponent();
            LoadHdCho("");
            loadSp();
        }

        private void Fm_HoaDon_Load(object sender, EventArgs e)
        {

        }
        private void LoadHdCho(string input)
        {
            int stt = 1;
            dgrid_HoaDon.ColumnCount = 5;
            dgrid_HoaDon.Columns[0].Name = "STT";
            dgrid_HoaDon.Columns[1].Name = "Id";
            dgrid_HoaDon.Columns[1].Visible= false;
            dgrid_HoaDon.Columns[2].Name = "Mã hóa đơn";
            dgrid_HoaDon.Columns[3].Name = "Tên khách hàng";
            dgrid_HoaDon.Columns[4].Name = "NV bán";
            dgrid_HoaDon.Rows.Clear();
            _lstHoaDon = _iHoadonService.ShowHoadon(input).Where(c => c.TrangThai == 1).ToList();
          

            foreach (var x in _lstHoaDon)
            {
                dgrid_HoaDon.Rows.Add(stt++, x.Id, x.MaHoaDon, x.TenKH,x.NV);
            }
        }
        private void LoadGiohang(Guid id)
        {
            int stt = 1;
            dgrid_HoaDonChiTiet.ColumnCount = 8;
            dgrid_HoaDonChiTiet.Columns[0].Name = "STT";
            dgrid_HoaDonChiTiet.Columns[1].Name = "Id";
            dgrid_HoaDonChiTiet.Columns[1].Visible=true;
            dgrid_HoaDonChiTiet.Columns[2].Name = "Mã sản phẩm";
            dgrid_HoaDonChiTiet.Columns[3].Name = "Tên sản phẩm";
            dgrid_HoaDonChiTiet.Columns[4].Name = "Số lượng";
            dgrid_HoaDonChiTiet.Columns[5].Name = "Đơn giá";
            dgrid_HoaDonChiTiet.Columns[6].Name = "Idsp";
            dgrid_HoaDonChiTiet.Columns[7].Name = "Ghi Chú";
            dgrid_HoaDonChiTiet.Columns[6].Visible= true;
            dgrid_HoaDonChiTiet.Rows.Clear();

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            
            buttonColumn.Text = "Trả hàng";
            buttonColumn.Name = "TraHang";
            buttonColumn.UseColumnTextForButtonValue = true;
            dgrid_HoaDonChiTiet.Columns.Add(buttonColumn);          
                _lstChitietHD = _iHoadonChitietSerivce.ShowHoadonChitiet(id);   
            foreach (var x in _lstChitietHD )
            {
                dgrid_HoaDonChiTiet.Rows.Add(stt++, x.Id, x.MaSp, x.TenSp, x.SoLuong, x.DonGia,x.IdChiTIetSp,x.GhiChu);
            }

        }
        private void dgrid_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if (e.RowIndex==_iHoadonService.ShowHoadon().Where(c=>c.TrangThai==1).ToList().Count)
                {
                    return;
                }             
                DataGridViewRow r = dgrid_HoaDon.Rows[e.RowIndex];
                _idHoadon = Guid.Parse(r.Cells[1].Value.ToString());
                txt_MaHD.Text= r.Cells[2].Value.ToString();
                LoadGiohang(_idHoadon);
            }
        }

        private void btn_CLear_Click(object sender, EventArgs e)
        {          
            LoadGiohang(Guid.Empty);
            txt_MaHD.Text = "";
        }
       

        private void dgrid_HoaDonChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                

            }
        }
        private void loadSp()
        {
            Fl_SanPhams.Controls.Clear();
            foreach (var x in _iQlSanphamSerivce.GetAll().Where(c => c.SoLuong > 0 && c.TrangThai == 1))
            {
                Panel products = new Panel()
                {
                    Size = new System.Drawing.Size(160, 160),
                    BackColor = Color.White
                };

                System.Windows.Forms.Button btn = new System.Windows.Forms.Button() { Width = 110, Height = 110 };
                Label lb = new Label() { ForeColor = Color.Black, Location = new System.Drawing.Point(20, 120) };
                btn.Tag = x;
                btn.Image = Bitmap.FromFile(x.anh);
                btn.Click += Btn_Click; ;
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.Black;
                lb.Text = x.TenSp + " " + x.LoaiSize;
                products.Controls.Add(lb);
                products.Controls.Add(btn);
                Fl_SanPhams.Controls.Add(products);


            }

        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            _idSanpham = ((sender as System.Windows.Forms.Button).Tag as ChiTIetSpView).Id;          
           
           

        }

        private void dgrid_HoaDonChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgrid_HoaDonChiTiet.Rows[e.RowIndex];
                if (dgrid_HoaDonChiTiet.Columns[e.ColumnIndex].Name== "TraHang")
                {
                    if (int.TryParse(dgrid_HoaDonChiTiet.Rows[r.Index].Cells[4].Value.ToString(), out int x))
                    {                       
                        var idHdct = Guid.Parse(dgrid_HoaDonChiTiet.Rows[e.RowIndex].Cells[1].Value.ToString());    
                        var idSp = Guid.Parse(dgrid_HoaDonChiTiet.Rows[e.RowIndex].Cells[6].Value.ToString());
                        var Hdct = _iHoadonChitietSerivce.ShowHoadonChitiet(_idHoadon).FirstOrDefault(c => c.Id == idHdct);
                        var Sp = _iQlSanphamSerivce.GetAll().FirstOrDefault(c => c.Id == idSp);
                        Hdct.SoLuong--;
                        Hdct.GhiChu = "Khách trả hàng";
                        Sp.SoLuong++;
                        if (Hdct.SoLuong==0)
                        {
                            Hdct.GhiChu = "Khách toàn bộ hàng trả hàng";
                        }
                        if (Hdct.SoLuong<0)
                        {
                            return;
                        }
                        _iHoadonChitietSerivce.Update(Hdct);
                        _iQlSanphamSerivce.UPDATE(Sp);
                        LoadGiohang(_idHoadon);

                    }
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_lstChitietHD.Count==0)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadHdCho(textBox1.Text);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text= "Tìm Kiếm.....";
        }
    }
}
