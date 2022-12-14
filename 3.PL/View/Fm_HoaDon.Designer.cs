namespace _3.PL
{
    partial class Fm_HoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_HoaDon));
            this.dgrid_HoaDonChiTiet = new System.Windows.Forms.DataGridView();
            this.dgrid_HoaDon = new System.Windows.Forms.DataGridView();
            this.txt_MaHD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CLear = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Fl_SanPhams = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_HoaDonChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_HoaDon)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrid_HoaDonChiTiet
            // 
            this.dgrid_HoaDonChiTiet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrid_HoaDonChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_HoaDonChiTiet.Location = new System.Drawing.Point(684, 64);
            this.dgrid_HoaDonChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrid_HoaDonChiTiet.Name = "dgrid_HoaDonChiTiet";
            this.dgrid_HoaDonChiTiet.RowHeadersWidth = 51;
            this.dgrid_HoaDonChiTiet.RowTemplate.Height = 29;
            this.dgrid_HoaDonChiTiet.Size = new System.Drawing.Size(619, 425);
            this.dgrid_HoaDonChiTiet.TabIndex = 30;
            this.dgrid_HoaDonChiTiet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_HoaDonChiTiet_CellContentClick);
            this.dgrid_HoaDonChiTiet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_HoaDonChiTiet_CellValueChanged);
            // 
            // dgrid_HoaDon
            // 
            this.dgrid_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_HoaDon.Location = new System.Drawing.Point(27, 64);
            this.dgrid_HoaDon.Name = "dgrid_HoaDon";
            this.dgrid_HoaDon.RowTemplate.Height = 25;
            this.dgrid_HoaDon.Size = new System.Drawing.Size(589, 425);
            this.dgrid_HoaDon.TabIndex = 31;
            this.dgrid_HoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_HoaDon_CellClick);
            // 
            // txt_MaHD
            // 
            this.txt_MaHD.Enabled = false;
            this.txt_MaHD.Location = new System.Drawing.Point(131, 35);
            this.txt_MaHD.Name = "txt_MaHD";
            this.txt_MaHD.Size = new System.Drawing.Size(129, 23);
            this.txt_MaHD.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 33;
            this.label1.Text = "Mã Hóa Đơn:";
            // 
            // btn_CLear
            // 
            this.btn_CLear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_CLear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_CLear.Image = ((System.Drawing.Image)(resources.GetObject("btn_CLear.Image")));
            this.btn_CLear.Location = new System.Drawing.Point(528, 26);
            this.btn_CLear.Name = "btn_CLear";
            this.btn_CLear.Size = new System.Drawing.Size(88, 38);
            this.btn_CLear.TabIndex = 155;
            this.btn_CLear.Text = "Reset";
            this.btn_CLear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CLear.UseVisualStyleBackColor = false;
            this.btn_CLear.Click += new System.EventHandler(this.btn_CLear_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Location = new System.Drawing.Point(27, 507);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(864, 186);
            this.panel4.TabIndex = 156;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Fl_SanPhams);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(861, 186);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách sản phẩm";
            // 
            // Fl_SanPhams
            // 
            this.Fl_SanPhams.AutoScroll = true;
            this.Fl_SanPhams.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Fl_SanPhams.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Fl_SanPhams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fl_SanPhams.Location = new System.Drawing.Point(3, 18);
            this.Fl_SanPhams.Name = "Fl_SanPhams";
            this.Fl_SanPhams.Size = new System.Drawing.Size(855, 166);
            this.Fl_SanPhams.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(684, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 157;
            this.label2.Text = "Sản phẩm đã mua";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1213, 494);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 158;
            this.button1.Text = "Confirm";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Fm_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1343, 704);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_CLear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_MaHD);
            this.Controls.Add(this.dgrid_HoaDon);
            this.Controls.Add(this.dgrid_HoaDonChiTiet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fm_HoaDon";
            this.Text = "Fm_HoaDon";
            this.Load += new System.EventHandler(this.Fm_HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_HoaDonChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_HoaDon)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgrid_HoaDonChiTiet;
        private System.Windows.Forms.DataGridView dgrid_HoaDon;
        private System.Windows.Forms.TextBox txt_MaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CLear;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel Fl_SanPhams;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}