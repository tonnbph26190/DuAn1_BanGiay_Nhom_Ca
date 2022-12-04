namespace _3.PL.View
{
    partial class FrmQuenMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Ma = new System.Windows.Forms.TextBox();
            this.lb_Ma = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.lb_NewPass = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(141, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản(Email):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(270, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Gửi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Ma
            // 
            this.txt_Ma.Enabled = false;
            this.txt_Ma.Location = new System.Drawing.Point(270, 107);
            this.txt_Ma.Name = "txt_Ma";
            this.txt_Ma.Size = new System.Drawing.Size(189, 23);
            this.txt_Ma.TabIndex = 4;
            // 
            // lb_Ma
            // 
            this.lb_Ma.AutoSize = true;
            this.lb_Ma.Enabled = false;
            this.lb_Ma.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_Ma.Location = new System.Drawing.Point(231, 107);
            this.lb_Ma.Name = "lb_Ma";
            this.lb_Ma.Size = new System.Drawing.Size(33, 20);
            this.lb_Ma.TabIndex = 3;
            this.lb_Ma.Text = "Mã:";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Enabled = false;
            this.txt_Pass.Location = new System.Drawing.Point(270, 148);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(189, 23);
            this.txt_Pass.TabIndex = 6;
            // 
            // lb_NewPass
            // 
            this.lb_NewPass.AutoSize = true;
            this.lb_NewPass.Enabled = false;
            this.lb_NewPass.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_NewPass.Location = new System.Drawing.Point(159, 151);
            this.lb_NewPass.Name = "lb_NewPass";
            this.lb_NewPass.Size = new System.Drawing.Size(105, 20);
            this.lb_NewPass.TabIndex = 5;
            this.lb_NewPass.Text = "Mật Khẩu mới:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(357, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "Xác Nhận";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmQuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 269);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.lb_NewPass);
            this.Controls.Add(this.txt_Ma);
            this.Controls.Add(this.lb_Ma);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmQuenMK";
            this.Text = "FrmQuenMK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Ma;
        private System.Windows.Forms.Label lb_Ma;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.Label lb_NewPass;
        private System.Windows.Forms.Button button2;
    }
}