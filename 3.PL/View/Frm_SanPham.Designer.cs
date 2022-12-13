namespace _3.PL.View
{
    partial class Frm_SanPham
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.bl = new System.Windows.Forms.Label();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ma = new System.Windows.Forms.TextBox();
            this.dgrid_Sp = new System.Windows.Forms.DataGridView();
            this.rbtn_KhongHoatDong = new System.Windows.Forms.RadioButton();
            this.rbtn_HoatDong = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Sp)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btn_Xoa);
            this.groupBox1.Controls.Add(this.btn_Sua);
            this.groupBox1.Controls.Add(this.btn_Them);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(314, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(371, 400);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Xoa.Location = new System.Drawing.Point(3, 154);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(365, 65);
            this.btn_Xoa.TabIndex = 2;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Sua.Location = new System.Drawing.Point(3, 89);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(365, 65);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Them.Location = new System.Drawing.Point(3, 24);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(365, 65);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-5, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tìm kiếm:";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(70, 361);
            this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(237, 27);
            this.txt_TimKiem.TabIndex = 3;
            // 
            // bl
            // 
            this.bl.AutoSize = true;
            this.bl.Location = new System.Drawing.Point(34, 167);
            this.bl.Name = "bl";
            this.bl.Size = new System.Drawing.Size(32, 20);
            this.bl.TabIndex = 22;
            this.bl.Text = "Tên";
            // 
            // txt_Ten
            // 
            this.txt_Ten.Location = new System.Drawing.Point(83, 156);
            this.txt_Ten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(222, 27);
            this.txt_Ten.TabIndex = 21;
            this.txt_Ten.TextChanged += new System.EventHandler(this.txt_Ten_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mã SP:";
            // 
            // txt_Ma
            // 
            this.txt_Ma.Location = new System.Drawing.Point(83, 75);
            this.txt_Ma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Ma.Name = "txt_Ma";
            this.txt_Ma.Size = new System.Drawing.Size(222, 27);
            this.txt_Ma.TabIndex = 19;
            // 
            // dgrid_Sp
            // 
            this.dgrid_Sp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_Sp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgrid_Sp.Location = new System.Drawing.Point(0, 400);
            this.dgrid_Sp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgrid_Sp.Name = "dgrid_Sp";
            this.dgrid_Sp.RowHeadersWidth = 51;
            this.dgrid_Sp.RowTemplate.Height = 25;
            this.dgrid_Sp.Size = new System.Drawing.Size(685, 200);
            this.dgrid_Sp.TabIndex = 18;
            this.dgrid_Sp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_Sp_CellClick);
            // 
            // rbtn_KhongHoatDong
            // 
            this.rbtn_KhongHoatDong.AutoSize = true;
            this.rbtn_KhongHoatDong.Location = new System.Drawing.Point(102, 279);
            this.rbtn_KhongHoatDong.Name = "rbtn_KhongHoatDong";
            this.rbtn_KhongHoatDong.Size = new System.Drawing.Size(146, 24);
            this.rbtn_KhongHoatDong.TabIndex = 26;
            this.rbtn_KhongHoatDong.TabStop = true;
            this.rbtn_KhongHoatDong.Text = "Không hoạt động";
            this.rbtn_KhongHoatDong.UseVisualStyleBackColor = true;
            // 
            // rbtn_HoatDong
            // 
            this.rbtn_HoatDong.AutoSize = true;
            this.rbtn_HoatDong.Location = new System.Drawing.Point(102, 228);
            this.rbtn_HoatDong.Name = "rbtn_HoatDong";
            this.rbtn_HoatDong.Size = new System.Drawing.Size(102, 24);
            this.rbtn_HoatDong.TabIndex = 25;
            this.rbtn_HoatDong.TabStop = true;
            this.rbtn_HoatDong.Text = "Hoạt động";
            this.rbtn_HoatDong.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Trạng Thái";
            // 
            // Frm_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 600);
            this.Controls.Add(this.rbtn_KhongHoatDong);
            this.Controls.Add(this.rbtn_HoatDong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.bl);
            this.Controls.Add(this.txt_Ten);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Ma);
            this.Controls.Add(this.dgrid_Sp);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_SanPham";
            this.Text = "Frm_SanPham";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Sp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Label bl;
        private System.Windows.Forms.TextBox txt_Ten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Ma;
        private System.Windows.Forms.DataGridView dgrid_Sp;
        private System.Windows.Forms.RadioButton rbtn_KhongHoatDong;
        private System.Windows.Forms.RadioButton rbtn_HoatDong;
        private System.Windows.Forms.Label label3;
    }
}