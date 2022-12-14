
using _2.BUS.IServices;
using _2.BUS.Services;
using _3.PL.Utilities;
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
        int Flag = 1;
        Frm_ChiTietSanPham _form;
        public FrmDongSp(Frm_ChiTietSanPham form)
        {
            InitializeComponent();
            _dongSpService = new DongSPService();
            LoadData();
            _form = form;
            txt_MaDSP.Enabled = false;
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

        public bool check()
        {
            if (string.IsNullOrEmpty(txt_MaDSP.Text))
            {
                MessageBox.Show("Không được đê trống Mã", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenDSP.Text))
            {
                MessageBox.Show("Không được đê trống Dòng sản phẩm", "Thông báo");
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
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (check() == false)
            {
                return;
            }
            else
            {
                foreach (var x in _dongSpService.GetAll())
                {
                    if (x.Ma == txt_MaDSP.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Ten == txt_TenDSP.Text)
                    {
                        MessageBox.Show("Dòng sản phẩm này đã tồn tại", "Thông báo");
                        return;
                    }
                }
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm Dòng sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _dongSpService.Add(GetDataFromGui());
                    MessageBox.Show("Thêm thành công");
                    _form.updateData();
                    LoadData();
                    Clear();
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
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm Dòng sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var temp = GetDataFromGui();
                    temp.Id = _id;
                    MessageBox.Show(_dongSpService.Update(temp));
                    _form.updateData();
                    LoadData();
                    Clear();
                }
                if (dialogResult == DialogResult.No) return;
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
        public void Clear()
        {
            txt_MaDSP.Text = "";
            txt_TenDSP.Text = null;
            rbtn_HoatDong.Checked = false;
            rbtn_KhongHoatDong.Checked = false;
        }
        private void txt_TenDSP_TextChanged(object sender, EventArgs e)
        {
            if (!(_id == Guid.Empty))
            {
                Flag = 0;
            }
            if (Flag == 0)
            {
                var temp = _dongSpService.GetAll().FirstOrDefault(c => c.Id == _id);

                txt_MaDSP.Text = temp.Ma;
                Flag = 1;

            }
            else
            {
                string ma = txt_MaDSP.Text;
                do
                {
                    ma = "DSP" + Utilitys.GetNumber(3);
                } while (_dongSpService.GetAll().Any(c => c.Ma.Equals(ma)));
                txt_MaDSP.Text = ma;
            }
        }
    }
}
