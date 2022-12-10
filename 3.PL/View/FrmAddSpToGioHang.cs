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
        bool Flag = false;

        

        public FrmAddSpToGioHang(string Ma)
        {
            InitializeComponent();
            
            _iQLSanPhamView= new ChiTIetSpServices();
            load(Ma);
            
        }
        private void load(string input)
        {
           
            if (check(input)==false)
            {
                MessageBox.Show("QR không tồn tại");
                return;
            }
            var obj= _iQLSanPhamView.GETMASP(input);
            lb_Ma.Text = obj.Ma;
            lb_TenSp.Text=_iQLSanPhamView.GETNAME(obj.Ma);
            pic_SanPham.ImageLocation = obj.Anh;
            pic_SanPham.SizeMode=PictureBoxSizeMode.StretchImage;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.Close();
                Flag = true;
            }
        }
        public string taken()
        {
            return textBox1.Text;
        }
        public bool check(string input)
        {
            if (!_iQLSanPhamView.GetAll().Any(c => c.Ma == input))
            {

                
                return false;
            }
            return true;
        }
       public bool change()
        {
            
            if (Flag==false)
            {
                return false;
            }
            return true;
        }
        private void FrmAddSpToGioHang_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change();
            this.Close();
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
