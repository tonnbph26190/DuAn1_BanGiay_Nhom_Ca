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
using System.Text.RegularExpressions;
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
            _iSizeService = new SizeService();
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
        public bool check()
        {
            if (string.IsNullOrEmpty(SZ_Ma.Text))
            {
                MessageBox.Show("Không được đê trống Mã", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(SZ_SizeGiay.Text))
            {
                MessageBox.Show("Không được đê trống Size", "Thông báo");
                return false;
            }
            if (Regex.IsMatch(SZ_SizeGiay.Text, @"[0-9]+") == false)
            {

                MessageBox.Show("Size Bắt buộc phải chứa số", "ERR");
                return false;
            }
            if (SZ_TTDC.Checked == false && SZ_TTCC.Checked == false)
            {
                MessageBox.Show("Bạn phải chọn trạng thái", "Thông báo");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_AddSZ_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _iSizeService.GetAll())
                {
                    if (x.Ma == SZ_Ma.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.SizeGiay == SZ_SizeGiay.Text)
                    {
                        MessageBox.Show("Size này đã tồn tại", "Thông báo");
                        return;
                    }
                }
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm size này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(_iSizeService.Add(GetDataFromGui()));
                    LoadSize();
                }
                if (dialogResult == DialogResult.No) return;
            }
        }

        private void btn_UpdateSZ_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _iSizeService.GetAll())
                {
                    if (x.Ma == SZ_Ma.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.SizeGiay == SZ_SizeGiay.Text)
                    {
                        MessageBox.Show("Size này đã tồn tại", "Thông báo");
                        return;
                    }
                }
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa size này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var temp = GetDataFromGui();
                    temp.Id = _idWhenclick;
                    MessageBox.Show(_iSizeService.Update(temp));
                    LoadSize();
                }
                if (dialogResult == DialogResult.No) return;
            }
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
