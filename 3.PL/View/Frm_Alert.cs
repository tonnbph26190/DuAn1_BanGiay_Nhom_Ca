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
    public partial class Frm_Alert : Form
    {
        public Frm_Alert()
        {
          //  showAlert("Kuaka");
            InitializeComponent();
        }
         

        private int x, y;
        public enum emAction
        {
            wait,
            start,
            close
        }

        private Frm_Alert.emAction action;


        private void button1_Click(object sender, EventArgs e)
        {
            var t = new System.Timers.Timer();
            t.Interval = 1;
            action = emAction.close;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var t = new System.Timers.Timer();
            switch (this.action)
            {

                case emAction.wait:
                    t.Interval = 5000;
                    action = emAction.close;
                    break;
                case emAction.start:
                    t.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = emAction.wait;
                        }
                    }
                    break;
                case emAction.close:
                    t.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void showAlert(string mess)
        {
            var t = new System.Timers.Timer();
            //this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            //this.button1.Image = global::_3.PL.Properties.Resources.x_mark_24;
            //button1.Image=Image.FromFile("D:\\Downloads\\DuAn1_BanGiay_Nhom_Ca1\\3.PL\\Resources\\close.png");
            //pictureBox1.Image = Image.FromFile("D:\\Downloads\\DuAn1_BanGiay_Nhom_Ca1\\3.PL\\Resources\\close.png");
            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Frm_Alert frm = (Frm_Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            this.lbl_mess.Text = mess;
            this.Show();
            this.action = emAction.start;
            t.Interval = 1;
            t.Start();
        }

        private void Frm_Alert_Load(object sender, EventArgs e)
        {
             Postion();
            //showAlert();
           

        }

        public void Postion()
        {
            int xPos = 0;
            int yPos = 0;
            //xPos = Screen.GetWorkingArea(this).Width;
            //yPos = Screen.GetWorkingArea(this).Height;
            //this.Location = new Point(xPos - this.Width, yPos - this.Height);
            //var t = new System.Timers.Timer();
            ////this.Opacity = 0.0;
            ////this.StartPosition = FormStartPosition.Manual;
            //// string fname;
            ////this.lbl_mess.Text = mess;
            ////this.ShowDialog();
            //this.action = emAction.start;
            //t.Interval = 1;
            //t.Start();

            xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
            yPos = Screen.PrimaryScreen.WorkingArea.Height - this.Height * 1;
            this.Location = new Point(xPos, yPos);
            this.action = emAction.start;
            //t.Interval = 1;
            //t.Start();
        }

    }
}
