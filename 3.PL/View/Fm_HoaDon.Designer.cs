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
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_HoaDonChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_HoaDon)).BeginInit();
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
            this.btn_CLear.Location = new System.Drawing.Point(27, 495);
            this.btn_CLear.Name = "btn_CLear";
            this.btn_CLear.Size = new System.Drawing.Size(88, 38);
            this.btn_CLear.TabIndex = 155;
            this.btn_CLear.Text = "Reset";
            this.btn_CLear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CLear.UseVisualStyleBackColor = false;
            this.btn_CLear.Click += new System.EventHandler(this.btn_CLear_Click);
            // 
            // Fm_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1343, 575);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgrid_HoaDonChiTiet;
        private System.Windows.Forms.DataGridView dgrid_HoaDon;
        private System.Windows.Forms.TextBox txt_MaHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CLear;
    }
}