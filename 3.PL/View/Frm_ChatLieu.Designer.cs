namespace _3.PL.View
{
    partial class Frm_ChatLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ChatLieu));
            this.Drg_mausac = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MS_TTCC = new System.Windows.Forms.RadioButton();
            this.MS_TTDC = new System.Windows.Forms.RadioButton();
            this.btn_AddMS = new System.Windows.Forms.Button();
            this.btn_ClearMS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bnt_DeleteMS = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.MS_Ma = new System.Windows.Forms.TextBox();
            this.MS_Ten = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Drg_mausac)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Drg_mausac
            // 
            this.Drg_mausac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Drg_mausac.Location = new System.Drawing.Point(402, 45);
            this.Drg_mausac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Drg_mausac.Name = "Drg_mausac";
            this.Drg_mausac.RowHeadersWidth = 51;
            this.Drg_mausac.RowTemplate.Height = 29;
            this.Drg_mausac.Size = new System.Drawing.Size(457, 233);
            this.Drg_mausac.TabIndex = 11;
            this.Drg_mausac.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Drg_mausac_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Tomato;
            this.groupBox1.Controls.Add(this.MS_TTCC);
            this.groupBox1.Controls.Add(this.MS_TTDC);
            this.groupBox1.Controls.Add(this.btn_AddMS);
            this.groupBox1.Controls.Add(this.btn_ClearMS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bnt_DeleteMS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_Update);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MS_Ma);
            this.groupBox1.Controls.Add(this.MS_Ten);
            this.groupBox1.Location = new System.Drawing.Point(0, 45);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(442, 233);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // MS_TTCC
            // 
            this.MS_TTCC.AutoSize = true;
            this.MS_TTCC.Location = new System.Drawing.Point(180, 160);
            this.MS_TTCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MS_TTCC.Name = "MS_TTCC";
            this.MS_TTCC.Size = new System.Drawing.Size(69, 19);
            this.MS_TTCC.TabIndex = 78;
            this.MS_TTCC.TabStop = true;
            this.MS_TTCC.Text = "Chưa có";
            this.MS_TTCC.UseVisualStyleBackColor = true;
            // 
            // MS_TTDC
            // 
            this.MS_TTDC.AutoSize = true;
            this.MS_TTDC.Location = new System.Drawing.Point(115, 160);
            this.MS_TTDC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MS_TTDC.Name = "MS_TTDC";
            this.MS_TTDC.Size = new System.Drawing.Size(55, 19);
            this.MS_TTDC.TabIndex = 77;
            this.MS_TTDC.TabStop = true;
            this.MS_TTDC.Text = "Đã có";
            this.MS_TTDC.UseVisualStyleBackColor = true;
            // 
            // btn_AddMS
            // 
            this.btn_AddMS.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_AddMS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_AddMS.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddMS.Image")));
            this.btn_AddMS.Location = new System.Drawing.Point(286, 28);
            this.btn_AddMS.Name = "btn_AddMS";
            this.btn_AddMS.Size = new System.Drawing.Size(86, 28);
            this.btn_AddMS.TabIndex = 76;
            this.btn_AddMS.Text = "Thêm";
            this.btn_AddMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_AddMS.UseVisualStyleBackColor = false;
            this.btn_AddMS.Click += new System.EventHandler(this.btn_AddMS_Click);
            // 
            // btn_ClearMS
            // 
            this.btn_ClearMS.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_ClearMS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ClearMS.Image = ((System.Drawing.Image)(resources.GetObject("btn_ClearMS.Image")));
            this.btn_ClearMS.Location = new System.Drawing.Point(288, 188);
            this.btn_ClearMS.Name = "btn_ClearMS";
            this.btn_ClearMS.Size = new System.Drawing.Size(88, 26);
            this.btn_ClearMS.TabIndex = 73;
            this.btn_ClearMS.Text = "Clear";
            this.btn_ClearMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ClearMS.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã :";
            // 
            // bnt_DeleteMS
            // 
            this.bnt_DeleteMS.BackColor = System.Drawing.SystemColors.Highlight;
            this.bnt_DeleteMS.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bnt_DeleteMS.Image = ((System.Drawing.Image)(resources.GetObject("bnt_DeleteMS.Image")));
            this.bnt_DeleteMS.Location = new System.Drawing.Point(286, 136);
            this.bnt_DeleteMS.Name = "bnt_DeleteMS";
            this.bnt_DeleteMS.Size = new System.Drawing.Size(88, 26);
            this.bnt_DeleteMS.TabIndex = 74;
            this.bnt_DeleteMS.Text = "Xóa";
            this.bnt_DeleteMS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bnt_DeleteMS.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng Thái :";
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Update.Image = ((System.Drawing.Image)(resources.GetObject("btn_Update.Image")));
            this.btn_Update.Location = new System.Drawing.Point(288, 81);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(88, 26);
            this.btn_Update.TabIndex = 75;
            this.btn_Update.Text = "Sửa";
            this.btn_Update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên :";
            // 
            // MS_Ma
            // 
            this.MS_Ma.Location = new System.Drawing.Point(110, 58);
            this.MS_Ma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MS_Ma.Name = "MS_Ma";
            this.MS_Ma.Size = new System.Drawing.Size(144, 23);
            this.MS_Ma.TabIndex = 3;
            // 
            // MS_Ten
            // 
            this.MS_Ten.Location = new System.Drawing.Point(110, 113);
            this.MS_Ten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MS_Ten.Name = "MS_Ten";
            this.MS_Ten.Size = new System.Drawing.Size(144, 23);
            this.MS_Ten.TabIndex = 4;
            // 
            // Frm_ChatLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 279);
            this.Controls.Add(this.Drg_mausac);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_ChatLieu";
            this.Text = "Frm_ChatLieu";
            ((System.ComponentModel.ISupportInitialize)(this.Drg_mausac)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Drg_mausac;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton MS_TTCC;
        private System.Windows.Forms.RadioButton MS_TTDC;
        private System.Windows.Forms.Button btn_AddMS;
        private System.Windows.Forms.Button btn_ClearMS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnt_DeleteMS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MS_Ma;
        private System.Windows.Forms.TextBox MS_Ten;
    }
}