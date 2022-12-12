using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL
{
    public partial class Frm_Load : Form
    {

        string b;
        private string c;
        public Frm_Load(string user, string tenChucVu)
        {
            InitializeComponent();
            b = user;
            this.c = tenChucVu;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 25;

            }
            else
            {
                timer1.Stop();
                this.Hide();
                FrmTrangChu trangChu = new FrmTrangChu(b,c);
                trangChu.Show();
            }           
        }

        private void Frm_Load_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
