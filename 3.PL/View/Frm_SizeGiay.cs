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
    public partial class Frm_SizeGiay : Form
    {
        private ISizeService _iSizeService;
        Guid _idWhenclick;
        public Frm_SizeGiay()
        {
            InitializeComponent();
           _iSizeService= new SizeService();
            LoadSize();
            Drg_size.Columns[1].Visible = false;
        }
        private void LoadSize()
        {
            int stt = 1;
            Drg_size.ColumnCount = 5;
            Drg_size.Columns[0].Name = "STT";
            Drg_size.Columns[1].Name = "Id";
            Drg_size.Columns[2].Name = "Mã";
            Drg_size.Columns[3].Name = "Size Giày";
            Drg_size.Columns[4].Name = "Trạng Thái";
            Drg_size.Rows.Clear();

            foreach (var x in _iSizeService.GetAll())
            {
                Drg_size.Rows.Add(stt++, x.Id, x.Ma, x.SizeGiay, x.TrangThai == 1 ? "Đã có" : "Chưa có");
            }
        }
        private SizeView GetDataFromGui()
        {
            return new SizeView()
            {
                Id = Guid.Empty,
                Ma = SZ_Ma.Text,
                SizeGiay = SZ_SizeGiay.Text,
                TrangThai = SZ_TTDC.Checked ? 1 : 0
            };
        }

        private void btn_AddSZ_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm size này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iSizeService.Add(GetDataFromGui()));
                LoadSize();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_UpdateSZ_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa màu này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = GetDataFromGui();
                temp.Id = _idWhenclick;
                MessageBox.Show(_iSizeService.Update(temp));
                LoadSize();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_ClearSZ_Click(object sender, EventArgs e)
        {
            SZ_Ma.Text = "";
            SZ_SizeGiay.Text = "";
            SZ_TTDC.Checked = true;
        }

        private void Drg_size_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex = e.RowIndex;
            if (rowIndex == _iSizeService.GetAll().Count) return;
            _idWhenclick = Guid.Parse(Drg_size.Rows[rowIndex].Cells[1].Value.ToString());
            var obj = _iSizeService.GetAll().FirstOrDefault(c => c.Id == _idWhenclick);
            SZ_Ma.Text = obj.Ma;
            SZ_SizeGiay.Text = obj.SizeGiay;
            if (obj.TrangThai == 1)
            {
                SZ_TTDC.Checked = true;
            }
            else SZ_TTCC.Checked = true;
        }
    }
}
