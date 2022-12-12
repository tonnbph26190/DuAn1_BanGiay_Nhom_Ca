using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
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
    public partial class Frm_SanPham : Form
    {
        private ISanPhamService _iSanPhamService;
        Guid _idWhenclick;
        Frm_ChiTietSanPham _form;
        public Frm_SanPham(Frm_ChiTietSanPham form)
        {
            _iSanPhamService = new SanPhamService();
            _form= form;
            InitializeComponent();
            LoadDgridSp(null);
        }
        private void LoadDgridSp(string input)
        {
            int stt = 1;
            dgrid_Sp.ColumnCount = 5;
            dgrid_Sp.Columns[0].Name = "STT";
            dgrid_Sp.Columns[1].Name = "Id";
            dgrid_Sp.Columns[2].Name = "Ma";
            dgrid_Sp.Columns[3].Name = "Ten";
            dgrid_Sp.Columns[4].Name = "Trang Thai";
            dgrid_Sp.Columns[1].Visible = false;
            dgrid_Sp.Rows.Clear();

            foreach (var x in _iSanPhamService.GetAll())
            {
                dgrid_Sp.Rows.Add(stt++, x.Id, x.Ma, x.Ten, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
            }
        }
        private SanPhamView GetDataFromGui()
        {
            SanPhamView Sp = new SanPhamView()
            {
                Id = Guid.Empty,
                Ma = txt_Ma.Text,
                Ten = txt_Ten.Text,
                TrangThai= rbtn_HoatDong.Checked?1:0
            };
            return Sp;
        }
        public bool check()
        {
            if (string.IsNullOrEmpty(txt_Ma.Text))
            {
                MessageBox.Show("Không được đê trống Mã", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_Ten.Text))
            {
                MessageBox.Show("Không được đê trống Sản phẩm", "Thông báo");
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
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _iSanPhamService.GetAll())
                {
                    if (x.Ma == txt_Ma.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Ten == txt_Ten.Text)
                    {
                        MessageBox.Show("sản phẩm này đã tồn tại", "Thông báo");
                        return;
                    }
                }
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm size này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_iSanPhamService.Add(GetDataFromGui()));
                    _form.updateData();
                    LoadDgridSp(null);
                }
                if (dialogResult == DialogResult.No) return;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

            if (check() == false)
            {
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm Sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var temp = GetDataFromGui();
                    temp.Id = _idWhenclick;
                    MessageBox.Show(_iSanPhamService.Update(temp));
                    _form.updateData();
                    LoadDgridSp(null);
                }
                if (dialogResult == DialogResult.No) return;

            }
        }

        private void dgrid_Sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iSanPhamService.GetAll().Count) return;
            _idWhenclick = Guid.Parse(dgrid_Sp.Rows[rowIndex].Cells[1].Value.ToString());
            var obj = _iSanPhamService.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);
            txt_Ma.Text = obj.Ma;
            txt_Ten.Text = obj.Ten;
            if (obj.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
                return;
            }

            rbtn_KhongHoatDong.Checked = true;
        }
    }
}
