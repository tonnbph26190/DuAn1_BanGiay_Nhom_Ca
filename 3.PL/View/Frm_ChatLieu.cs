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
    public partial class Frm_ChatLieu : Form
    {
        private IChatLieuService _iMauService;
        Guid _idWhenclick;
        public Frm_ChatLieu()
        {
            _iMauService= new ChatLieuService();
            InitializeComponent();
            LoadMau();
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
        private ChatLieuView GetDataFromGui()
        {
            return new ChatLieuView()
            {
                Id = Guid.Empty,
                Ma = MS_Ma.Text,
                Ten = MS_Ten.Text,
                TrangThai = MS_TTDC.Checked ? 1 : 0
            };
        }

        private void btn_AddMS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm Chat lieu này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_iMauService.Add(GetDataFromGui()));
                LoadMau();
            }
            if (dialogResult == DialogResult.No) return;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa màu này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = GetDataFromGui();
                temp.Id = _idWhenclick;
                MessageBox.Show(_iMauService.Update(temp));
                LoadMau();
            }
            if (dialogResult == DialogResult.No) return;
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
