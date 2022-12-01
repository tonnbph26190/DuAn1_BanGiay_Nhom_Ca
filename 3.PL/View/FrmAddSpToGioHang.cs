using _2.BUS.IServices;
using _2.BUS.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class FrmAddSpToGioHang : Form
    {
        
        private IChiTietSpServices _iQLSanPhamView;
        public FrmAddSpToGioHang(string Ma)
        {
            InitializeComponent();
            
            _iQLSanPhamView= new ChiTIetSpServices();
            load(Ma);
            
        }
        private void load(string input)
        {
            var obj= _iQLSanPhamView.GETMASP(input);
            lb_Ma.Text = obj.Ma;
            lb_TenSp.Text=_iQLSanPhamView.GETNAME(obj.Ma);
            pic_SanPham.ImageLocation = obj.Anh;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.Close();
            }
        }
        public string taken()
        {
            return textBox1.Text;
        }
        private void FrmAddSpToGioHang_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
