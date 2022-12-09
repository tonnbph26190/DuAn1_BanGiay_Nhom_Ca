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
    public partial class Fm_HoaDon : Form
    {
        public Fm_HoaDon()
        {
            InitializeComponent();
        }

        private void Fm_HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Alert n = new Frm_Alert();
            n.showAlert("Tồn",Frm_Alert.enmType.Success);
        }
    }
}
