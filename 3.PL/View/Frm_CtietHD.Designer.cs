namespace _3.PL.View
{
    partial class Frm_CtietHD
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
            this.grb_loc = new System.Windows.Forms.GroupBox();
            this.dgrid_Hd = new System.Windows.Forms.DataGridView();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.grb_loc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Hd)).BeginInit();
            this.SuspendLayout();
            // 
            // grb_loc
            // 
            this.grb_loc.Controls.Add(this.dgrid_Hd);
            this.grb_loc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_loc.ForeColor = System.Drawing.Color.IndianRed;
            this.grb_loc.Location = new System.Drawing.Point(0, 0);
            this.grb_loc.Name = "grb_loc";
            this.grb_loc.Size = new System.Drawing.Size(1135, 352);
            this.grb_loc.TabIndex = 3;
            this.grb_loc.TabStop = false;
            this.grb_loc.Text = "Chi Tiết Hóa Đơn";
            // 
            // dgrid_Hd
            // 
            this.dgrid_Hd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_Hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_Hd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_Hd.Location = new System.Drawing.Point(3, 23);
            this.dgrid_Hd.Name = "dgrid_Hd";
            this.dgrid_Hd.RowHeadersWidth = 51;
            this.dgrid_Hd.RowTemplate.Height = 29;
            this.dgrid_Hd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_Hd.Size = new System.Drawing.Size(1129, 326);
            this.dgrid_Hd.TabIndex = 0;
            this.dgrid_Hd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_Hd_CellContentClick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(999, 367);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(113, 41);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // Frm_CtietHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 420);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.grb_loc);
            this.Name = "Frm_CtietHD";
            this.Text = "Frm_CtietHD";
            this.Load += new System.EventHandler(this.Frm_CtietHD_Load);
            this.grb_loc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Hd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_loc;
        private System.Windows.Forms.DataGridView dgrid_Hd;
        private System.Windows.Forms.Button btn_Exit;
    }
}