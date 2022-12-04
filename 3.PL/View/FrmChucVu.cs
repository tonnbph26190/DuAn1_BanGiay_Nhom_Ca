
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.View
{
    public partial class FrmChucVu : Form
    {
        private IChucVuService _chucVuService;
        Guid _id;  
        public FrmChucVu()
        {
            InitializeComponent();
           
            _chucVuService = new ChucVuService();
            LoadData();
            

        }
        private void LoadData()
        {
            dgrid_DataShow.ColumnCount = 4;
            dgrid_DataShow.Columns[0].Name = "Id";
            dgrid_DataShow.Columns[0].Visible = false;
            dgrid_DataShow.Columns[1].Name = "Mã chức vụ";
            dgrid_DataShow.Columns[2].Name = "Tên chức vụ";
            dgrid_DataShow.Columns[3].Name = "Trạng Thái";
            dgrid_DataShow.Rows.Clear();
            foreach (var x in _chucVuService.GetAll())
            {
                dgrid_DataShow.Rows.Add(x.Id, x.Ma, x.Ten, x.TrangThai == 1 ? "Hoạt động" : "Không hoạt động");
            }
        }
        private _1.DAL.Models.ChucVu GetDataFromGui()
        {
            return new _1.DAL.Models.ChucVu()
            {
                Id = new Guid(),
                Ma = txt_MaCV.Text,
                Ten = txt_TenCv.Text,
                TrangThai = rbtn_HoatDong.Checked ? 1 : 0,
            };
        }

        public bool check()
        {
            if (string.IsNullOrEmpty(txt_MaCV.Text))
            {
                MessageBox.Show("Không được đê trống Mã", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txt_TenCv.Text))
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
                foreach (var x in _chucVuService.GetAll())
                {
                    if (x.Ma == txt_MaCV.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Ten == txt_TenCv.Text)
                    {
                        MessageBox.Show("chất liệu này đã tồn tại", "Thông báo");
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm màu này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _chucVuService.Add(GetDataFromGui());
                        MessageBox.Show("Thêm thành công");
                        LoadData();
                    }
                    if (dialogResult == DialogResult.No) return;
                }
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
                foreach (var x in _chucVuService.GetAll())
                {
                    if (x.Ma == txt_MaCV.Text)
                    {
                        MessageBox.Show("Mã này đã tồn tại", "Thông báo");
                        return;
                    }
                    if (x.Ten == txt_TenCv.Text)
                    {
                        MessageBox.Show("chất liệu này đã tồn tại", "Thông báo");
                        return;
                    }
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm màu này?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var temp = GetDataFromGui();
                        temp.Id = _id;
                        _chucVuService.Update(temp);
                        MessageBox.Show("Sửa chức vụ thành công");
                        LoadData();
                    }
                    if (dialogResult == DialogResult.No) return;
                }
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
            var chuVu = _chucVuService.GetAll().Find(c => c.Id == _id);
            
            txt_MaCV.Text = dgrid_DataShow.Rows[rd].Cells[1].Value.ToString();
            txt_TenCv.Text = dgrid_DataShow.Rows[rd].Cells[2].Value.ToString();
            if (chuVu.TrangThai == 1)
            {
                rbtn_HoatDong.Checked = true;
                return;
            }

            rbtn_KhongHoatDong.Checked = true;
        }
    }
}
