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
    public partial class Frm_Nsx : Form
    {
        private INsxService _iMauService;
        Guid _idWhenclick;
        Frm_ChiTietSanPham _form;
        public Frm_Nsx(Frm_ChiTietSanPham form)
        {
            InitializeComponent();


            _iMauService = new NsxService();
            LoadMau();
            Drg_mausac.Columns[1].Visible = false;
            _form = form;
        }
        private void LoadMau()
        {
            int stt = 1;
            Drg_mausac.ColumnCount = 5;
            Drg_mausac.Columns[0].Name = "STT";
            Drg_mausac.Columns[1].Name = "Id";
            Drg_mausac.Columns[2].Name = "Mã";
            Drg_mausac.Columns[3].Name = "Tên";
            Drg_mausac.Columns[4].Name = "Trạng Thái";
            Drg_mausac.Rows.Clear();

            foreach (var x in _iMauService.GetAll())
            {
                Drg_mausac.Rows.Add(stt++, x.Id, x.Ma, x.Ten, x.TrangThai == 1 ? "Đã có" : "Chưa có");
            }
        }
        private NsxView GetDataFromGui()
        {
            return new NsxView()
            {
                Id = Guid.Empty,
                Ma = MS_Ma.Text,
                Ten = MS_Ten.Text,
                TrangThai = MS_TTDC.Checked ? 1 : 0
            };
        }
        public bool check()
        {
            if (string.IsNullOrEmpty(MS_Ma.Text))
            {
                MessageBox.Show("Không được đê trống Mã", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(MS_Ten.Text))
            {
                MessageBox.Show("Không được đê trống NSX", "Thông báo");
                return false;
            }
            if (MS_TTDC.Checked == false && MS_TTCC.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_AddMS_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _iMauService.GetAll())
                {
                    if (x.Ma == MS_Ma.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Ten == MS_Ten.Text)
                    {
                        MessageBox.Show("NSX này đã tồn tại", "Thông báo");
                        return;
                    }
                }
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm màu này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_iMauService.Add(GetDataFromGui()));
                    LoadMau();
                    _form.updateData();
                }
                if (dialogResult == DialogResult.No) return;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa màu này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var temp = GetDataFromGui();
                    temp.Id = _idWhenclick;
                    MessageBox.Show(_iMauService.Update(temp));
                    LoadMau();
                    _form.updateData();
                }
                if (dialogResult == DialogResult.No) return;
            }

        }

        private void Drg_mausac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iMauService.GetAll().Count) return;
            _idWhenclick = Guid.Parse(Drg_mausac.Rows[rowIndex].Cells[1].Value.ToString());
            var obj = _iMauService.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);
            MS_Ma.Text = obj.Ma;
            MS_Ten.Text = obj.Ten;
            if (obj.TrangThai == 1)
            {
                MS_TTDC.Checked = true;
            }
            else MS_TTCC.Checked = true;
        }
    }
}
