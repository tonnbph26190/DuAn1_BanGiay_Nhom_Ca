namespace _3.PL.View
{
    partial class Frm_ThongKeHD
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
            this.components = new System.ComponentModel.Container();
            this.grb_loc = new System.Windows.Forms.GroupBox();
            this.dgrid_Hd = new System.Windows.Forms.DataGridView();
            this.txt_dataemail = new System.Windows.Forms.TextBox();
            this.grb_ss = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgrid_t2 = new System.Windows.Forms.DataGridView();
            this.dgrid_t1 = new System.Windows.Forms.DataGridView();
            this.dtp_n2ss = new System.Windows.Forms.DateTimePicker();
            this.dtp_n1ss = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_t2 = new System.Windows.Forms.Label();
            this.lbl_t1 = new System.Windows.Forms.Label();
            this.lbl_dt2 = new System.Windows.Forms.Label();
            this.lbl_dt1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zg_ss = new ZedGraph.ZedGraphControl();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.cmb_mailBC = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_getemail = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.pb_ex = new System.Windows.Forms.PictureBox();
            this.pb_email = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_tongtien = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_counthd = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_huydon = new System.Windows.Forms.Label();
            this.dtp_loc = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_lbllockhoang = new System.Windows.Forms.Label();
            this.lab_closedetail = new System.Windows.Forms.Label();
            this.lbl_ss = new System.Windows.Forms.Label();
            this.lbl_start = new System.Windows.Forms.Label();
            this.lbl_end = new System.Windows.Forms.Label();
            this.btn_lockhoangtg = new System.Windows.Forms.Button();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.btn_reload = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_LocTT = new System.Windows.Forms.ComboBox();
            this.labl_sodonthanhcong = new System.Windows.Forms.Label();
            this.lbl_chuathanhtoan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_DangGiao = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_ss = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grb_loc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Hd)).BeginInit();
            this.grb_ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_t2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_t1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.rightpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb_loc
            // 
            this.grb_loc.Controls.Add(this.dgrid_Hd);
            this.grb_loc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grb_loc.ForeColor = System.Drawing.Color.IndianRed;
            this.grb_loc.Location = new System.Drawing.Point(0, 0);
            this.grb_loc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_loc.Name = "grb_loc";
            this.grb_loc.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_loc.Size = new System.Drawing.Size(1355, 264);
            this.grb_loc.TabIndex = 2;
            this.grb_loc.TabStop = false;
            this.grb_loc.Text = "Thống Kê Chi Tiết Kheo Khoảng Thời Gian";
            // 
            // dgrid_Hd
            // 
            this.dgrid_Hd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_Hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_Hd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_Hd.Location = new System.Drawing.Point(3, 18);
            this.dgrid_Hd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrid_Hd.Name = "dgrid_Hd";
            this.dgrid_Hd.RowHeadersWidth = 51;
            this.dgrid_Hd.RowTemplate.Height = 29;
            this.dgrid_Hd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_Hd.Size = new System.Drawing.Size(1349, 244);
            this.dgrid_Hd.TabIndex = 0;
            // 
            // txt_dataemail
            // 
            this.txt_dataemail.Location = new System.Drawing.Point(300, 26);
            this.txt_dataemail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_dataemail.Name = "txt_dataemail";
            this.txt_dataemail.Size = new System.Drawing.Size(148, 23);
            this.txt_dataemail.TabIndex = 15;
            // 
            // grb_ss
            // 
            this.grb_ss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.grb_ss.Controls.Add(this.label15);
            this.grb_ss.Controls.Add(this.label13);
            this.grb_ss.Controls.Add(this.dgrid_t2);
            this.grb_ss.Controls.Add(this.dgrid_t1);
            this.grb_ss.Controls.Add(this.dtp_n2ss);
            this.grb_ss.Controls.Add(this.dtp_n1ss);
            this.grb_ss.Controls.Add(this.label7);
            this.grb_ss.Controls.Add(this.label9);
            this.grb_ss.Controls.Add(this.tableLayoutPanel1);
            this.grb_ss.Controls.Add(this.label8);
            this.grb_ss.Controls.Add(this.zg_ss);
            this.grb_ss.ForeColor = System.Drawing.Color.Salmon;
            this.grb_ss.Location = new System.Drawing.Point(3, 424);
            this.grb_ss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_ss.Name = "grb_ss";
            this.grb_ss.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grb_ss.Size = new System.Drawing.Size(887, 324);
            this.grb_ss.TabIndex = 17;
            this.grb_ss.TabStop = false;
            this.grb_ss.Text = "Bảng So Sánh ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.PeachPuff;
            this.label15.Location = new System.Drawing.Point(798, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 27);
            this.label15.TabIndex = 50;
            this.label15.Text = "VND";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.PeachPuff;
            this.label13.Location = new System.Drawing.Point(798, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 27);
            this.label13.TabIndex = 49;
            this.label13.Text = "VND";
            // 
            // dgrid_t2
            // 
            this.dgrid_t2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_t2.Location = new System.Drawing.Point(616, 221);
            this.dgrid_t2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrid_t2.Name = "dgrid_t2";
            this.dgrid_t2.RowHeadersWidth = 51;
            this.dgrid_t2.RowTemplate.Height = 29;
            this.dgrid_t2.Size = new System.Drawing.Size(164, 82);
            this.dgrid_t2.TabIndex = 48;
            // 
            // dgrid_t1
            // 
            this.dgrid_t1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_t1.Location = new System.Drawing.Point(446, 221);
            this.dgrid_t1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgrid_t1.Name = "dgrid_t1";
            this.dgrid_t1.RowHeadersWidth = 51;
            this.dgrid_t1.RowTemplate.Height = 29;
            this.dgrid_t1.Size = new System.Drawing.Size(164, 82);
            this.dgrid_t1.TabIndex = 47;
            // 
            // dtp_n2ss
            // 
            this.dtp_n2ss.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_n2ss.Location = new System.Drawing.Point(698, 30);
            this.dtp_n2ss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_n2ss.Name = "dtp_n2ss";
            this.dtp_n2ss.Size = new System.Drawing.Size(180, 23);
            this.dtp_n2ss.TabIndex = 46;
            this.dtp_n2ss.ValueChanged += new System.EventHandler(this.dtp_n2ss_ValueChanged);
            // 
            // dtp_n1ss
            // 
            this.dtp_n1ss.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_n1ss.Location = new System.Drawing.Point(473, 30);
            this.dtp_n1ss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_n1ss.Name = "dtp_n1ss";
            this.dtp_n1ss.Size = new System.Drawing.Size(180, 23);
            this.dtp_n1ss.TabIndex = 36;
            this.dtp_n1ss.ValueChanged += new System.EventHandler(this.dtp_n1ss_ValueChanged);
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoEllipsis = true;
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.PeachPuff;
            this.label7.Location = new System.Drawing.Point(514, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 27);
            this.label7.TabIndex = 35;
            this.label7.Text = "Thời gian";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.PeachPuff;
            this.label9.Location = new System.Drawing.Point(669, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 27);
            this.label9.TabIndex = 45;
            this.label9.Text = "Doanh Thu";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.70588F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.29412F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_t2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_t1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_dt2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_dt1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(512, 106);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.67442F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.32558F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(243, 69);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // lbl_t2
            // 
            this.lbl_t2.AllowDrop = true;
            this.lbl_t2.AutoEllipsis = true;
            this.lbl_t2.AutoSize = true;
            this.lbl_t2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_t2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_t2.ForeColor = System.Drawing.Color.PeachPuff;
            this.lbl_t2.Location = new System.Drawing.Point(3, 32);
            this.lbl_t2.Name = "lbl_t2";
            this.lbl_t2.Size = new System.Drawing.Size(24, 27);
            this.lbl_t2.TabIndex = 49;
            this.lbl_t2.Text = "0";
            this.lbl_t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_t1
            // 
            this.lbl_t1.AllowDrop = true;
            this.lbl_t1.AutoEllipsis = true;
            this.lbl_t1.AutoSize = true;
            this.lbl_t1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_t1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_t1.ForeColor = System.Drawing.Color.PeachPuff;
            this.lbl_t1.Location = new System.Drawing.Point(3, 0);
            this.lbl_t1.Name = "lbl_t1";
            this.lbl_t1.Size = new System.Drawing.Size(24, 27);
            this.lbl_t1.TabIndex = 46;
            this.lbl_t1.Text = "0";
            this.lbl_t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dt2
            // 
            this.lbl_dt2.AllowDrop = true;
            this.lbl_dt2.AutoEllipsis = true;
            this.lbl_dt2.AutoSize = true;
            this.lbl_dt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_dt2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_dt2.ForeColor = System.Drawing.Color.PeachPuff;
            this.lbl_dt2.Location = new System.Drawing.Point(160, 32);
            this.lbl_dt2.Name = "lbl_dt2";
            this.lbl_dt2.Size = new System.Drawing.Size(24, 27);
            this.lbl_dt2.TabIndex = 47;
            this.lbl_dt2.Text = "0";
            this.lbl_dt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_dt1
            // 
            this.lbl_dt1.AllowDrop = true;
            this.lbl_dt1.AutoEllipsis = true;
            this.lbl_dt1.AutoSize = true;
            this.lbl_dt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_dt1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_dt1.ForeColor = System.Drawing.Color.PeachPuff;
            this.lbl_dt1.Location = new System.Drawing.Point(160, 0);
            this.lbl_dt1.Name = "lbl_dt1";
            this.lbl_dt1.Size = new System.Drawing.Size(24, 27);
            this.lbl_dt1.TabIndex = 48;
            this.lbl_dt1.Text = "0";
            this.lbl_dt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.PeachPuff;
            this.label8.Location = new System.Drawing.Point(512, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 21);
            this.label8.TabIndex = 36;
            // 
            // zg_ss
            // 
            this.zg_ss.Location = new System.Drawing.Point(18, 22);
            this.zg_ss.Margin = new System.Windows.Forms.Padding(4);
            this.zg_ss.Name = "zg_ss";
            this.zg_ss.ScrollGrace = 0D;
            this.zg_ss.ScrollMaxX = 0D;
            this.zg_ss.ScrollMaxY = 0D;
            this.zg_ss.ScrollMaxY2 = 0D;
            this.zg_ss.ScrollMinX = 0D;
            this.zg_ss.ScrollMinY = 0D;
            this.zg_ss.ScrollMinY2 = 0D;
            this.zg_ss.Size = new System.Drawing.Size(401, 282);
            this.zg_ss.TabIndex = 39;
            // 
            // rightpanel
            // 
            this.rightpanel.BackColor = System.Drawing.Color.RosyBrown;
            this.rightpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightpanel.Controls.Add(this.cmb_mailBC);
            this.rightpanel.Controls.Add(this.label2);
            this.rightpanel.Controls.Add(this.lbl_getemail);
            this.rightpanel.Controls.Add(this.btn_open);
            this.rightpanel.Controls.Add(this.pb_ex);
            this.rightpanel.Controls.Add(this.pb_email);
            this.rightpanel.Controls.Add(this.txt_dataemail);
            this.rightpanel.Location = new System.Drawing.Point(896, 427);
            this.rightpanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(564, 301);
            this.rightpanel.TabIndex = 15;
            // 
            // cmb_mailBC
            // 
            this.cmb_mailBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mailBC.FormattingEnabled = true;
            this.cmb_mailBC.Location = new System.Drawing.Point(180, 152);
            this.cmb_mailBC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_mailBC.Name = "cmb_mailBC";
            this.cmb_mailBC.Size = new System.Drawing.Size(231, 23);
            this.cmb_mailBC.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Xuất Thống Kê Ra File Excel";
            // 
            // lbl_getemail
            // 
            this.lbl_getemail.AutoSize = true;
            this.lbl_getemail.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_getemail.Location = new System.Drawing.Point(3, 26);
            this.lbl_getemail.Name = "lbl_getemail";
            this.lbl_getemail.Size = new System.Drawing.Size(158, 15);
            this.lbl_getemail.TabIndex = 17;
            this.lbl_getemail.Text = "Xuất Danh Sách Khách Hàng";
            // 
            // btn_open
            // 
            this.btn_open.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_open.FlatAppearance.BorderSize = 0;
            this.btn_open.ForeColor = System.Drawing.Color.Maroon;
            this.btn_open.Location = new System.Drawing.Point(-2, 177);
            this.btn_open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(446, 76);
            this.btn_open.TabIndex = 14;
            this.btn_open.Text = "Gửi Mail Thông Báo";
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // pb_ex
            // 
            this.pb_ex.BackColor = System.Drawing.Color.RosyBrown;
            this.pb_ex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_ex.Location = new System.Drawing.Point(180, 60);
            this.pb_ex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_ex.Name = "pb_ex";
            this.pb_ex.Size = new System.Drawing.Size(130, 64);
            this.pb_ex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_ex.TabIndex = 7;
            this.pb_ex.TabStop = false;
            this.pb_ex.Click += new System.EventHandler(this.pb_ex_Click);
            // 
            // pb_email
            // 
            this.pb_email.BackColor = System.Drawing.Color.RosyBrown;
            this.pb_email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_email.Location = new System.Drawing.Point(180, 8);
            this.pb_email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_email.Name = "pb_email";
            this.pb_email.Size = new System.Drawing.Size(130, 64);
            this.pb_email.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_email.TabIndex = 7;
            this.pb_email.TabStop = false;
            this.pb_email.Click += new System.EventHandler(this.pb_email_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(608, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tổng Doanh Thu :";
            // 
            // lbl_tongtien
            // 
            this.lbl_tongtien.AutoSize = true;
            this.lbl_tongtien.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_tongtien.Location = new System.Drawing.Point(726, 17);
            this.lbl_tongtien.Name = "lbl_tongtien";
            this.lbl_tongtien.Size = new System.Drawing.Size(13, 15);
            this.lbl_tongtien.TabIndex = 20;
            this.lbl_tongtien.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.PeachPuff;
            this.label5.Location = new System.Drawing.Point(700, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tổng Số Hóa Đơn :";
            // 
            // lbl_counthd
            // 
            this.lbl_counthd.AutoSize = true;
            this.lbl_counthd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_counthd.ForeColor = System.Drawing.Color.PeachPuff;
            this.lbl_counthd.Location = new System.Drawing.Point(860, 106);
            this.lbl_counthd.Name = "lbl_counthd";
            this.lbl_counthd.Size = new System.Drawing.Size(19, 21);
            this.lbl_counthd.TabIndex = 22;
            this.lbl_counthd.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(792, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "VND";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(874, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Tổng Số Đơn Hủy:";
            // 
            // lbl_huydon
            // 
            this.lbl_huydon.AutoSize = true;
            this.lbl_huydon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_huydon.Location = new System.Drawing.Point(1001, 17);
            this.lbl_huydon.Name = "lbl_huydon";
            this.lbl_huydon.Size = new System.Drawing.Size(13, 15);
            this.lbl_huydon.TabIndex = 25;
            this.lbl_huydon.Text = "0";
            // 
            // dtp_loc
            // 
            this.dtp_loc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_loc.Location = new System.Drawing.Point(178, 9);
            this.dtp_loc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_loc.Name = "dtp_loc";
            this.dtp_loc.Size = new System.Drawing.Size(180, 23);
            this.dtp_loc.TabIndex = 26;
            this.dtp_loc.ValueChanged += new System.EventHandler(this.dtp_loc_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Lọc Theo Mốc Thời Gian:";
            // 
            // txt_lbllockhoang
            // 
            this.txt_lbllockhoang.AutoSize = true;
            this.txt_lbllockhoang.ForeColor = System.Drawing.Color.LightCoral;
            this.txt_lbllockhoang.Location = new System.Drawing.Point(5, 47);
            this.txt_lbllockhoang.Name = "txt_lbllockhoang";
            this.txt_lbllockhoang.Size = new System.Drawing.Size(158, 15);
            this.txt_lbllockhoang.TabIndex = 27;
            this.txt_lbllockhoang.Text = "Lọc Theo Khoảng Thời Gian :";
            // 
            // lab_closedetail
            // 
            this.lab_closedetail.AutoSize = true;
            this.lab_closedetail.ForeColor = System.Drawing.Color.LightCoral;
            this.lab_closedetail.Location = new System.Drawing.Point(3, 87);
            this.lab_closedetail.Name = "lab_closedetail";
            this.lab_closedetail.Size = new System.Drawing.Size(112, 15);
            this.lab_closedetail.TabIndex = 27;
            this.lab_closedetail.Text = "Đóng Xem Chi Tiết :";
            // 
            // lbl_ss
            // 
            this.lbl_ss.AutoSize = true;
            this.lbl_ss.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_ss.Location = new System.Drawing.Point(0, 128);
            this.lbl_ss.Name = "lbl_ss";
            this.lbl_ss.Size = new System.Drawing.Size(52, 15);
            this.lbl_ss.TabIndex = 27;
            this.lbl_ss.Text = "So Sánh:";
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_start.Location = new System.Drawing.Point(383, 17);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(107, 15);
            this.lbl_start.TabIndex = 27;
            this.lbl_start.Text = "Thời Gian Bắt Đầu :";
            // 
            // lbl_end
            // 
            this.lbl_end.AutoSize = true;
            this.lbl_end.ForeColor = System.Drawing.Color.LightCoral;
            this.lbl_end.Location = new System.Drawing.Point(383, 90);
            this.lbl_end.Name = "lbl_end";
            this.lbl_end.Size = new System.Drawing.Size(112, 15);
            this.lbl_end.TabIndex = 27;
            this.lbl_end.Text = "Thời Gian Kết Thúc :";
            // 
            // btn_lockhoangtg
            // 
            this.btn_lockhoangtg.Location = new System.Drawing.Point(178, 34);
            this.btn_lockhoangtg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_lockhoangtg.Name = "btn_lockhoangtg";
            this.btn_lockhoangtg.Size = new System.Drawing.Size(179, 38);
            this.btn_lockhoangtg.TabIndex = 17;
            this.btn_lockhoangtg.Text = "Lọc Theo Khoảng Thời Gian";
            this.btn_lockhoangtg.UseVisualStyleBackColor = true;
            this.btn_lockhoangtg.Click += new System.EventHandler(this.btn_lockhoangtg_Click);
            // 
            // dtp_start
            // 
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_start.Location = new System.Drawing.Point(383, 36);
            this.dtp_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(180, 23);
            this.dtp_start.TabIndex = 28;
            this.dtp_start.ValueChanged += new System.EventHandler(this.dtp_start_ValueChanged);
            // 
            // dtp_end
            // 
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_end.Location = new System.Drawing.Point(383, 107);
            this.dtp_end.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(180, 23);
            this.dtp_end.TabIndex = 28;
            this.dtp_end.ValueChanged += new System.EventHandler(this.dtp_end_ValueChanged);
            // 
            // btn_reload
            // 
            this.btn_reload.Location = new System.Drawing.Point(179, 75);
            this.btn_reload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(178, 37);
            this.btn_reload.TabIndex = 29;
            this.btn_reload.Text = "ReLoad";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(1256, 3);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(60, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(874, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "Tổng Số Đơn Thành Công:";
            // 
            // cmb_LocTT
            // 
            this.cmb_LocTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_LocTT.FormattingEnabled = true;
            this.cmb_LocTT.Location = new System.Drawing.Point(1114, 36);
            this.cmb_LocTT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_LocTT.Name = "cmb_LocTT";
            this.cmb_LocTT.Size = new System.Drawing.Size(231, 23);
            this.cmb_LocTT.TabIndex = 16;
            this.cmb_LocTT.SelectedIndexChanged += new System.EventHandler(this.cmb_LocTT_SelectedIndexChanged);
            // 
            // labl_sodonthanhcong
            // 
            this.labl_sodonthanhcong.AutoSize = true;
            this.labl_sodonthanhcong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labl_sodonthanhcong.Location = new System.Drawing.Point(1039, 43);
            this.labl_sodonthanhcong.Name = "labl_sodonthanhcong";
            this.labl_sodonthanhcong.Size = new System.Drawing.Size(13, 15);
            this.labl_sodonthanhcong.TabIndex = 31;
            this.labl_sodonthanhcong.Text = "0";
            // 
            // lbl_chuathanhtoan
            // 
            this.lbl_chuathanhtoan.AutoSize = true;
            this.lbl_chuathanhtoan.ForeColor = System.Drawing.Color.White;
            this.lbl_chuathanhtoan.Location = new System.Drawing.Point(812, 43);
            this.lbl_chuathanhtoan.Name = "lbl_chuathanhtoan";
            this.lbl_chuathanhtoan.Size = new System.Drawing.Size(13, 15);
            this.lbl_chuathanhtoan.TabIndex = 32;
            this.lbl_chuathanhtoan.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(608, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tổng Số Đơn Chưa Thanh Toán:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(1121, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "Lọc Theo Tình Trạng:";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(1113, 97);
            this.txt_TimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(232, 23);
            this.txt_TimKiem.TabIndex = 18;
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
            this.txt_TimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_TimKiem_KeyUp);
            this.txt_TimKiem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_TimKiem_MouseDown);
            this.txt_TimKiem.MouseLeave += new System.EventHandler(this.txt_TimKiem_MouseLeave);
            this.txt_TimKiem.MouseHover += new System.EventHandler(this.txt_TimKiem_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(1121, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "Tìm kiếm:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_DangGiao);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btn_ss);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_TimKiem);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbl_chuathanhtoan);
            this.panel1.Controls.Add(this.labl_sodonthanhcong);
            this.panel1.Controls.Add(this.cmb_LocTT);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.btn_reload);
            this.panel1.Controls.Add(this.dtp_end);
            this.panel1.Controls.Add(this.dtp_start);
            this.panel1.Controls.Add(this.btn_lockhoangtg);
            this.panel1.Controls.Add(this.lbl_end);
            this.panel1.Controls.Add(this.lbl_start);
            this.panel1.Controls.Add(this.lbl_ss);
            this.panel1.Controls.Add(this.lab_closedetail);
            this.panel1.Controls.Add(this.txt_lbllockhoang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp_loc);
            this.panel1.Controls.Add(this.lbl_huydon);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbl_counthd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbl_tongtien);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.IndianRed;
            this.panel1.Location = new System.Drawing.Point(0, 264);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1355, 156);
            this.panel1.TabIndex = 16;
            // 
            // lbl_DangGiao
            // 
            this.lbl_DangGiao.AutoSize = true;
            this.lbl_DangGiao.ForeColor = System.Drawing.Color.White;
            this.lbl_DangGiao.Location = new System.Drawing.Point(783, 68);
            this.lbl_DangGiao.Name = "lbl_DangGiao";
            this.lbl_DangGiao.Size = new System.Drawing.Size(13, 15);
            this.lbl_DangGiao.TabIndex = 37;
            this.lbl_DangGiao.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(608, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 15);
            this.label16.TabIndex = 36;
            this.label16.Text = "Tổng Số Đơn Đang Giao:";
            // 
            // btn_ss
            // 
            this.btn_ss.Location = new System.Drawing.Point(179, 115);
            this.btn_ss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ss.Name = "btn_ss";
            this.btn_ss.Size = new System.Drawing.Size(178, 37);
            this.btn_ss.TabIndex = 35;
            this.btn_ss.Text = "So sánh";
            this.btn_ss.UseVisualStyleBackColor = true;
            this.btn_ss.Click += new System.EventHandler(this.btn_ss_Click);
            // 
            // Frm_ThongKeHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 730);
            this.Controls.Add(this.rightpanel);
            this.Controls.Add(this.grb_ss);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grb_loc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_ThongKeHD";
            this.Text = "Frm_ThongKeHD";
            this.grb_loc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_Hd)).EndInit();
            this.grb_ss.ResumeLayout(false);
            this.grb_ss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_t2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_t1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.rightpanel.ResumeLayout(false);
            this.rightpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb_loc;
        private System.Windows.Forms.DataGridView dgrid_Hd;
        private System.Windows.Forms.TextBox txt_dataemail;
        private System.Windows.Forms.GroupBox grb_ss;
        private System.Windows.Forms.Panel rightpanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_getemail;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.PictureBox pb_ex;
        private System.Windows.Forms.PictureBox pb_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_tongtien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_counthd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_huydon;
        private System.Windows.Forms.DateTimePicker dtp_loc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_lbllockhoang;
        private System.Windows.Forms.Label lab_closedetail;
        private System.Windows.Forms.Label lbl_ss;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.Label lbl_end;
        private System.Windows.Forms.Button btn_lockhoangtg;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_LocTT;
        private System.Windows.Forms.Label labl_sodonthanhcong;
        private System.Windows.Forms.Label lbl_chuathanhtoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zg_ss;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_dt2;
        private System.Windows.Forms.Label lbl_t1;
        private System.Windows.Forms.Button btn_ss;
        private System.Windows.Forms.DateTimePicker dtp_n2ss;
        private System.Windows.Forms.DateTimePicker dtp_n1ss;
        private System.Windows.Forms.DataGridView dgrid_t2;
        private System.Windows.Forms.DataGridView dgrid_t1;
        private System.Windows.Forms.Label lbl_t2;
        private System.Windows.Forms.Label lbl_dt1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_mailBC;
        private System.Windows.Forms.Label lbl_DangGiao;
        private System.Windows.Forms.Label label16;
    }
}