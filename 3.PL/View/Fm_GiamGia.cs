using _3.PL.View;
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
    public partial class Fm_GiamGia : Form
    {
        public Fm_GiamGia()
        {
            InitializeComponent();
        }

        public void Alert(string mess) 
        {
            Frm_Alert frm = new Frm_Alert();
            frm.showAlert(mess);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Alert("t là test nè");
        }
    }
}
