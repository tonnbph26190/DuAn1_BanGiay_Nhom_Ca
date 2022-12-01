namespace _3.PL.View
{
    partial class Frm_SizeGiay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SizeGiay));
            this.Drg_size = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SZ_TTCC = new System.Windows.Forms.RadioButton();
            this.SZ_TTDC = new System.Windows.Forms.RadioButton();
            this.btn_ClearSZ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_DeleteSZ = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_UpdateSZ = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_AddSZ = new System.Windows.Forms.Button();
            this.SZ_Ma = new System.Windows.Forms.TextBox();
            this.SZ_SizeGiay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Drg_size)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Drg_size
            // 
            this.Drg_size.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Drg_size.Location = new System.Drawing.Point(480, 38);
            this.Drg_size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Drg_size.Name = "Drg_size";
            this.Drg_size.RowHeadersWidth = 51;
            this.Drg_size.RowTemplate.Height = 29;
            this.Drg_size.Size = new System.Drawing.Size(366, 289);
            this.Drg_size.TabIndex = 11;
            this.Drg_size.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Drg_size_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Tomato;
            this.groupBox1.Controls.Add(this.SZ_TTCC);
            this.groupBox1.Controls.Add(this.SZ_TTDC);
            this.groupBox1.Controls.Add(this.btn_ClearSZ);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_DeleteSZ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_UpdateSZ);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_AddSZ);
            this.groupBox1.Controls.Add(this.SZ_Ma);
            this.groupBox1.Controls.Add(this.SZ_SizeGiay);
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(464, 289);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // SZ_TTCC
            // 
            this.SZ_TTCC.AutoSize = true;
            this.SZ_TTCC.Location = new System.Drawing.Point(176, 167);
            this.SZ_TTCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SZ_TTCC.Name = "SZ_TTCC";
            this.SZ_TTCC.Size = new System.Drawing.Size(69, 19);
            this.SZ_TTCC.TabIndex = 80;
            this.SZ_TTCC.TabStop = true;
            this.SZ_TTCC.Text = "Chưa có";
            this.SZ_TTCC.UseVisualStyleBackColor = true;
            // 
            // SZ_TTDC
            // 
            this.SZ_TTDC.AutoSize = true;
            this.SZ_TTDC.Location = new System.Drawing.Point(110, 167);
            this.SZ_TTDC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SZ_TTDC.Name = "SZ_TTDC";
            this.SZ_TTDC.Size = new System.Drawing.Size(55, 19);
            this.SZ_TTDC.TabIndex = 79;
            this.SZ_TTDC.TabStop = true;
            this.SZ_TTDC.Text = "Đã có";
            this.SZ_TTDC.UseVisualStyleBackColor = true;
            // 
            // btn_ClearSZ
            // 
            this.btn_ClearSZ.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_ClearSZ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ClearSZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_ClearSZ.Image")));
            this.btn_ClearSZ.Location = new System.Drawing.Point(298, 182);
            this.btn_ClearSZ.Name = "btn_ClearSZ";
            this.btn_ClearSZ.Size = new System.Drawing.Size(88, 26);
            this.btn_ClearSZ.TabIndex = 73;
            this.btn_ClearSZ.Text = "Clear";
            this.btn_ClearSZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ClearSZ.UseVisualStyleBackColor = false;
            this.btn_ClearSZ.Click += new System.EventHandler(this.btn_ClearSZ_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã :";
            // 
            // btn_DeleteSZ
            // 
            this.btn_DeleteSZ.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_DeleteSZ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_DeleteSZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_DeleteSZ.Image")));
            this.btn_DeleteSZ.Location = new System.Drawing.Point(296, 133);
            this.btn_DeleteSZ.Name = "btn_DeleteSZ";
            this.btn_DeleteSZ.Size = new System.Drawing.Size(88, 26);
            this.btn_DeleteSZ.TabIndex = 74;
            this.btn_DeleteSZ.Text = "Xóa";
            this.btn_DeleteSZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_DeleteSZ.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng Thái :";
            // 
            // btn_UpdateSZ
            // 
            this.btn_UpdateSZ.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_UpdateSZ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_UpdateSZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_UpdateSZ.Image")));
            this.btn_UpdateSZ.Location = new System.Drawing.Point(298, 81);
            this.btn_UpdateSZ.Name = "btn_UpdateSZ";
            this.btn_UpdateSZ.Size = new System.Drawing.Size(88, 26);
            this.btn_UpdateSZ.TabIndex = 75;
            this.btn_UpdateSZ.Text = "Sửa";
            this.btn_UpdateSZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_UpdateSZ.UseVisualStyleBackColor = false;
            this.btn_UpdateSZ.Click += new System.EventHandler(this.btn_UpdateSZ_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size Giày :";
            // 
            // btn_AddSZ
            // 
            this.btn_AddSZ.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_AddSZ.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_AddSZ.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddSZ.Image")));
            this.btn_AddSZ.Location = new System.Drawing.Point(298, 32);
            this.btn_AddSZ.Name = "btn_AddSZ";
            this.btn_AddSZ.Size = new System.Drawing.Size(86, 28);
            this.btn_AddSZ.TabIndex = 72;
            this.btn_AddSZ.Text = "Thêm";
            this.btn_AddSZ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddSZ.UseVisualStyleBackColor = false;
            this.btn_AddSZ.Click += new System.EventHandler(this.btn_AddSZ_Click);
            // 
            // SZ_Ma
            // 
            this.SZ_Ma.Location = new System.Drawing.Point(108, 59);
            this.SZ_Ma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SZ_Ma.Name = "SZ_Ma";
            this.SZ_Ma.Size = new System.Drawing.Size(142, 23);
            this.SZ_Ma.TabIndex = 3;
            // 
            // SZ_SizeGiay
            // 
            this.SZ_SizeGiay.Location = new System.Drawing.Point(108, 114);
            this.SZ_SizeGiay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SZ_SizeGiay.Name = "SZ_SizeGiay";
            this.SZ_SizeGiay.Size = new System.Drawing.Size(142, 23);
            this.SZ_SizeGiay.TabIndex = 4;
            // 
            // Frm_SizeGiay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 358);
            this.Controls.Add(this.Drg_size);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_SizeGiay";
            this.Text = "Frm_MauSac";
            ((System.ComponentModel.ISupportInitialize)(this.Drg_size)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Drg_size;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SZ_TTCC;
        private System.Windows.Forms.RadioButton SZ_TTDC;
        private System.Windows.Forms.Button btn_ClearSZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_DeleteSZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_UpdateSZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_AddSZ;
        private System.Windows.Forms.TextBox SZ_Ma;
        private System.Windows.Forms.TextBox SZ_SizeGiay;
    }
}