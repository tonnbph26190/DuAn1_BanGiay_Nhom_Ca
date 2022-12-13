namespace _3.PL
{
    partial class Fm_KhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_KhachHang));
            this.drg_khachHang = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cmb_ThanhPho = new System.Windows.Forms.ComboBox();
            this.cmb_QuoCGia = new System.Windows.Forms.ComboBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Ma = new System.Windows.Forms.TextBox();
            this.txt_diaChi = new System.Windows.Forms.TextBox();
            this.rdb_Off = new System.Windows.Forms.RadioButton();
            this.rdb_On = new System.Windows.Forms.RadioButton();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.drg_khachHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drg_khachHang
            // 
            this.drg_khachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drg_khachHang.Location = new System.Drawing.Point(615, 40);
            this.drg_khachHang.Name = "drg_khachHang";
            this.drg_khachHang.RowHeadersWidth = 51;
            this.drg_khachHang.RowTemplate.Height = 29;
            this.drg_khachHang.Size = new System.Drawing.Size(654, 572);
            this.drg_khachHang.TabIndex = 58;
            this.drg_khachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drg_khachHang_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.Cmb_ThanhPho);
            this.groupBox1.Controls.Add(this.cmb_QuoCGia);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_Ma);
            this.groupBox1.Controls.Add(this.txt_diaChi);
            this.groupBox1.Controls.Add(this.rdb_Off);
            this.groupBox1.Controls.Add(this.rdb_On);
            this.groupBox1.Controls.Add(this.btn_Delete);
            this.groupBox1.Controls.Add(this.btn_Update);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_SDT);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_Email);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_Ten);
            this.groupBox1.Location = new System.Drawing.Point(62, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 572);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "thông tin";
            // 
            // Cmb_ThanhPho
            // 
            this.Cmb_ThanhPho.FormattingEnabled = true;
            this.Cmb_ThanhPho.Location = new System.Drawing.Point(201, 360);
            this.Cmb_ThanhPho.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cmb_ThanhPho.Name = "Cmb_ThanhPho";
            this.Cmb_ThanhPho.Size = new System.Drawing.Size(209, 28);
            this.Cmb_ThanhPho.TabIndex = 83;
            // 
            // cmb_QuoCGia
            // 
            this.cmb_QuoCGia.FormattingEnabled = true;
            this.cmb_QuoCGia.Location = new System.Drawing.Point(201, 309);
            this.cmb_QuoCGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmb_QuoCGia.Name = "cmb_QuoCGia";
            this.cmb_QuoCGia.Size = new System.Drawing.Size(209, 28);
            this.cmb_QuoCGia.TabIndex = 82;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.Location = new System.Drawing.Point(73, 507);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(98, 37);
            this.btn_Add.TabIndex = 81;
            this.btn_Add.Text = "Thêm";
            this.btn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 78;
            this.label9.Text = "Mã";
            // 
            // txt_Ma
            // 
            this.txt_Ma.Location = new System.Drawing.Point(201, 60);
            this.txt_Ma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Ma.Name = "txt_Ma";
            this.txt_Ma.Size = new System.Drawing.Size(209, 27);
            this.txt_Ma.TabIndex = 79;
            // 
            // txt_diaChi
            // 
            this.txt_diaChi.Location = new System.Drawing.Point(201, 405);
            this.txt_diaChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_diaChi.Name = "txt_diaChi";
            this.txt_diaChi.Size = new System.Drawing.Size(209, 27);
            this.txt_diaChi.TabIndex = 74;
            // 
            // rdb_Off
            // 
            this.rdb_Off.AutoSize = true;
            this.rdb_Off.Location = new System.Drawing.Point(309, 264);
            this.rdb_Off.Name = "rdb_Off";
            this.rdb_Off.Size = new System.Drawing.Size(151, 24);
            this.rdb_Off.TabIndex = 73;
            this.rdb_Off.TabStop = true;
            this.rdb_Off.Text = "Không Hoạt Động";
            this.rdb_Off.UseVisualStyleBackColor = true;
            // 
            // rdb_On
            // 
            this.rdb_On.AutoSize = true;
            this.rdb_On.Location = new System.Drawing.Point(201, 264);
            this.rdb_On.Name = "rdb_On";
            this.rdb_On.Size = new System.Drawing.Size(104, 24);
            this.rdb_On.TabIndex = 72;
            this.rdb_On.TabStop = true;
            this.rdb_On.Text = "Hoạt Động";
            this.rdb_On.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.Location = new System.Drawing.Point(347, 505);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(101, 35);
            this.btn_Delete.TabIndex = 70;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Delete.UseVisualStyleBackColor = false;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.Location = new System.Drawing.Point(214, 507);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(101, 35);
            this.btn_Update.TabIndex = 71;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Điện Thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa Chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thành Phố";
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(201, 219);
            this.txt_SDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(209, 27);
            this.txt_SDT.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Quốc Gia";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(201, 169);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(209, 27);
            this.txt_Email.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Trạng Thái";
            // 
            // txt_Ten
            // 
            this.txt_Ten.Location = new System.Drawing.Point(201, 115);
            this.txt_Ten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(209, 27);
            this.txt_Ten.TabIndex = 48;
            this.txt_Ten.TextChanged += new System.EventHandler(this.txt_Ten_TextChanged);
            // 
            // Fm_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1330, 651);
            this.Controls.Add(this.drg_khachHang);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Fm_KhachHang";
            this.Text = "Fm_KhachHang";
            ((System.ComponentModel.ISupportInitialize)(this.drg_khachHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView drg_khachHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cmb_ThanhPho;
        private System.Windows.Forms.ComboBox cmb_QuoCGia;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Ma;
        private System.Windows.Forms.TextBox txt_diaChi;
        private System.Windows.Forms.RadioButton rdb_Off;
        private System.Windows.Forms.RadioButton rdb_On;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Ten;
    }
}