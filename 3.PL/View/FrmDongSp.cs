
using _2.BUS.IServices;
using _2.BUS.Services;
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
    public partial class FrmDongSp : Form
    {
        private IDongSPService _dongSpService;
        private Guid _id;
        public FrmDongSp()
        {
            InitializeComponent();
            _dongSpService = new DongSPService();
            LoadData();
        }
        public void LoadData()
        {
            dgrid_DataShow.ColumnCount = 4;
            dgrid_DataShow.Columns[0].Name = "Id";
            dgrid_DataShow.Columns[0].Visible = false;
            dgrid_DataShow.Columns[1].Name = "Mã dòng sản phẩm";
            dgrid_DataShow.Columns[2].Name = "Tên dòng sản phẩm";
            dgrid_DataShow.Columns[3].Name = "Trạng Thái";
            dgrid_DataShow.Rows.Clear();
            foreach (var x in _dongSpService.GetAll())
            {
                dgrid_DataShow.Rows.Add(x.Id, x.Ma, x.Ten, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
            }
        }

        private _1.DAL.Models.DongSP GetDataFromGui()
        {
            return new _1.DAL.Models.DongSP()
            {
                Id = new Guid(),
                Ma = txt_MaDSP.Text,
                Ten = txt_TenDSP.Text,
                TrangThai = rbtn_HoatDong.Checked ? 1 : 0,
            };
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_MaDSP.Text == "")
            {
                MessageBox.Show("Mã chức vụ không được để trống!", "Thông báo", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
            }

            if (txt_TenDSP.Text == "")
            {
                MessageBox.Show("Tên chức vụ không được để trống!", "Thông báo", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
            }
            else
            {
                DialogResult dg = MessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk);
                if (dg == DialogResult.Yes)
                {
                    _dongSpService.Add(GetDataFromGui());
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

                if (dg == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_MaDSP.Text == "")
            {
                MessageBox.Show("Mã chức vụ không được để trống!", "Thông báo", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                return;
            }

            if (txt_TenDSP.Text == "")
            {
                MessageBox.Show("Tên chức vụ không được để trống!", "Thông báo", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                return;
            }
            DialogResult dg = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk);
            if (dg == DialogResult.Yes)
            {
                _dongSpService.Update(GetDataFromGui());
                MessageBox.Show("Sửa chức vụ thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }

            if (dg == DialogResult.No)
            {
                return;
            }
        }

        private void dgrid_DataShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1)
            {
                return;
            }
            _id = Guid.Parse(dgrid_DataShow.Rows[rd].Cells[0].Value.ToString());
            var chuVu = _dongSpService.GetAll().Find(c => c.Id == _id);
           
            txt_MaDSP.Text = dgrid_DataShow.Rows[rd].Cells[1].Value.ToString();
            txt_TenDSP.Text = dgrid_DataShow.Rows[rd].Cells[2].Value.ToString();
            if (chuVu.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
                return;
            }

            rbtn_KhongHoatDong.Checked = true;
        }
    }
}
