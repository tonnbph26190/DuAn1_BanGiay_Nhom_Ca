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
using System.Net;
using System.Net.Mail;
using _3.PL.Utilities;

namespace _3.PL.View
{
    public partial class FrmQuenMK : Form
    {
        private INhanVienService _NhanVienService;
        public FrmQuenMK()
        {
            InitializeComponent();
            _NhanVienService= new NhanVienService();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_NhanVienService.GetAll().Any(c => c.Email == textBox1.Text.Trim()))
            {
                MessageBox.Show("Tk không tồn tại");
                return;
            }
            else
            {
                string from, to, pass, content;
                from = "ckuotga1997@gmail.com";
                pass = "rblzrnngambpsdoe";
                content = Utility.GetNumber(6);
                to =textBox1.Text.Trim();
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from);
                mail.Subject = "Mật khẩu mới của bạn";
                mail.Body = content;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                var obj=   _NhanVienService.GetAll().FirstOrDefault(c=>c.Email== textBox1.Text.Trim());
                obj.PassWord=content.Trim();
                _NhanVienService.Update(obj);
                try
                {
                    smtp.Send(mail);
                    MessageBox.Show("Succes");
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Fail");
                    
                }
            }
        }
    }
}
